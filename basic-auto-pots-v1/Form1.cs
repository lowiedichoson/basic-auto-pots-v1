using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace basic_auto_pots_v1
{
    public partial class main_form : Form
    {
        // Low-level mouse hook
        private const int WH_MOUSE_LL = 14;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int HOTKEY_ID = 1;
        private const int INPUT_KEYBOARD = 1;
        private const uint KEYEVENTF_SCANCODE = 0x0008;
        private const uint MOD_NONE = 0x0000;
        private const uint VK_F8 = 0x77;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const uint VK_LCONTROL = 0xA2; // Virtual key code for Left CTRL
        private const ushort SCANCODE_LCONTROL = 0x1D; // Scan code for Left CTRL
        private const int MIN_DELAY = 2;   // ms
        private const int MAX_DELAY = 1000; // ms

        private bool isActivated = false;
        private bool isRunning = false;

        private CancellationTokenSource cts;
        private IntPtr _hookID = IntPtr.Zero;
        private LowLevelMouseProc _proc;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }


        public main_form()
        {
            InitializeComponent();
            _proc = HookCallback;
            txt_box_delay.KeyPress += txt_box_delay_KeyPress;

            this.Opacity = 0.95;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _hookID = SetHook(_proc);

            cb_auto_qwer.Checked = true;

            if (!RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, VK_F8))
            {
                MessageBox.Show("Failed to register f8 hotkey.");
            }

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            UnregisterHotKey(this.Handle, HOTKEY_ID);

            StopAllActions();

            base.OnFormClosed(e);
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using Process curProcess = Process.GetCurrentProcess();
            using ProcessModule curModule = curProcess.MainModule;
            return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && isActivated)
            {
                if (wParam == (IntPtr)WM_RBUTTONDOWN)
                {
                    StartKeyLoop();
                }
                else if (wParam == (IntPtr)WM_RBUTTONUP)
                {
                    StopKeyLoop();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private void StartKeyLoop()
        {
            if (!isRunning)
            {
                isRunning = true;
                label_rmb_status.Text = "Held";
                label_rmb_status.ForeColor = System.Drawing.Color.Green;

                if (cb_auto_ctrl.Checked)
                {
                    SimulateScancodeDown(SCANCODE_LCONTROL);
                }

                if (cb_auto_qwer.Checked)
                {
                    cts = new CancellationTokenSource();
                    Task.Run(() => LoopKeys(cts.Token));
                }
            }
        }

        private void StopKeyLoop()
        {
            if (isRunning)
            {
                isRunning = false;
                label_rmb_status.Text = "Released";
                label_rmb_status.ForeColor = System.Drawing.Color.Red;

                if (cb_auto_ctrl.Checked)
                {
                    SimulateScancodeUp(SCANCODE_LCONTROL);
                }
                
                if (cb_auto_qwer.Checked)
                {
                    cts?.Cancel();
                }

            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                //ToggleKeyLoop();
                ToggleActivation();
            }
            base.WndProc(ref m);
        }

        private void ToggleActivation()
        {
            isActivated = !isActivated;

            if (isActivated)
            {
                label_status.Invoke((MethodInvoker)delegate
                {
                    label_status.Text = "Activated";
                    label_status.ForeColor = System.Drawing.Color.Green;
                    btn_start.Text = "Stop (F8)";
                    btn_start.BackColor = System.Drawing.Color.Red;
                });
            }
            else
            {
                StopAllActions();

                label_status.Invoke((MethodInvoker)delegate
                {
                    label_status.Text = "Deactivated";
                    label_status.ForeColor = System.Drawing.Color.Red;
                    btn_start.Text = "Start (F8)";
                    btn_start.BackColor = System.Drawing.Color.Green;
                });
            }

        }

        private void StopAllActions()
        {
            // Force stop the running loop
            cts?.Cancel();
            isRunning = false;

            // Force release CTRL if it was held down
            SimulateScancodeUp(SCANCODE_LCONTROL);

            // Force release QWER keys if they were mid-loop (this is usually handled by the loop itself, but good for cleanup)
            ushort[] scancodes = { 0x10, 0x11, 0x12, 0x13 }; // qwer
            foreach (var scancode in scancodes)
            {
                SimulateScancodeUp(scancode);
            }
        }

        private async Task LoopKeys(CancellationToken token)
        {
            ushort[] scancodes = { 0x10, 0x11, 0x12, 0x13 }; // qwer
            //ushort[] scancodes = { 0x10 }; // q only
            //ushort[] scancodes = { 0x02, 0x03, 0x04, 0x05 }; // 1234 
            //ushort[] scancodes = { 0x04, 0x02  }; // 13

            while (!token.IsCancellationRequested)
            {
                int delay = GetUserDelay();

                foreach (var scancode in scancodes)
                {
                    SimulateScancodeDown(scancode);
                    await Task.Delay(delay, token); // custom delay
                    SimulateScancodeUp(scancode);
                }
            }

            // Ensure keys are released if the loop is cancelled
            foreach (var scancode in scancodes)
            {
                SimulateScancodeUp(scancode);
            }
        }

        private void SimulateScancodeDown(ushort scancode)
        {
            var down = new INPUT
            {
                type = INPUT_KEYBOARD,
                U = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = 0,
                        wScan = scancode,
                        dwFlags = KEYEVENTF_SCANCODE,
                        time = 0,
                        dwExtraInfo = IntPtr.Zero
                    }
                }
            };
            SendInput(1, new[] { down }, Marshal.SizeOf(typeof(INPUT)));
        }

        private void SimulateScancodeUp(ushort scancode)
        {
            var up = new INPUT
            {
                type = INPUT_KEYBOARD,
                U = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = 0,
                        wScan = scancode,
                        dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP,
                        time = 0,
                        dwExtraInfo = IntPtr.Zero
                    }
                }
            };
            SendInput(1, new[] { up }, Marshal.SizeOf(typeof(INPUT)));
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            ToggleActivation();
        }

        private int GetUserDelay()
        {
            if (int.TryParse(txt_box_delay.Text, out int val))
            {
                if (val < MIN_DELAY) return MIN_DELAY;
                if (val > MAX_DELAY) return MAX_DELAY;
                return val;
            }

            return MIN_DELAY;
        }

        private void txt_box_delay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
