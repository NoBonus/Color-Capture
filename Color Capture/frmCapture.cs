using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Capture
{
    public partial class frmCapture : Form
    {
        public frmCapture()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            MouseHook.Start();
            MouseHook.MouseAction += MouseHook_MouseAction;
        }

        private void MouseHook_MouseAction(object sender, MouseHook.RawMouseEventArgs e)
        {
            Console.WriteLine("mouse act" + e.Message);
            if (e.Message == MouseHook.MouseMessages.WM_LBUTTONDOWN)
            {
                Console.WriteLine("mouse click "+e.Point.x+":"+e.Point.y);
                MouseHook.Stop();
                MouseHook.MouseAction -= MouseHook_MouseAction;
                Color clcolor = GetColorAt(e.Point.x, e.Point.y);
                pnlSelColor.BackColor = clcolor;
                string htmlcol = ColorTranslator.ToHtml(Color.FromArgb(clcolor.ToArgb()));
                txtHtmlColor.Text = htmlcol;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);

        public static Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
    }
}
