using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Capture
{
    public partial class frmCapture : Form
    {
        private List<colorControls> colorControlsList;
        public frmCapture()
        {
            InitializeComponent();
            colorControlsList = new List<colorControls>();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            MouseHook.Start();
            MouseHook.MouseAction += MouseHook_MouseAction;
        }

        private void MouseHook_MouseAction(object sender, MouseHook.RawMouseEventArgs e)
        {
            Console.WriteLine("mouse act" + e.Message);
            Color clcolor = GetColorAt(e.Point.x, e.Point.y);
            picSelColor.BackColor = clcolor;
            string htmlcol = ColorTranslator.ToHtml(Color.FromArgb(clcolor.ToArgb()));
            txtHtmlColor.Text = htmlcol;
            if (e.Message == MouseHook.MouseMessages.WM_LBUTTONDOWN)
            {
                Console.WriteLine("mouse click "+e.Point.x+":"+e.Point.y);
                MouseHook.Stop();
                MouseHook.MouseAction -= MouseHook_MouseAction;
                cloneAndAdd(clcolor);
            }
        }
        private void cloneAndAdd(Color selcol)
        {
            int row = tblColors.RowCount;
            SuspendLayout();
            PictureBox p = (PictureBox)CloneObject(picSelColor);
            p.BackColor = selcol;
            p.Name = "picSelColor" + row.ToString();
            PictureBox c = (PictureBox)CloneObject(picBtnCopy);
            c.Image = Properties.Resources.copy1_32;
            PictureBox d = (PictureBox)CloneObject(picBtnDelete);
            TextBox h = (TextBox)CloneObject(txtHtmlColor);
            colorControls cc = new colorControls() { picColor=p, picCopy=c,picDelete=d, htmlColor=h };
            colorControlsList.Add(cc);
            
            tblColors.RowCount = row + 1;
            tblColors.Controls.Add(cc.picColor,0, row); 
            tblColors.Controls.Add(cc.htmlColor,1,row);
            tblColors.Controls.Add(cc.picCopy,2,row);
            tblColors.Controls.Add(cc.picDelete,3,row);
            
            tblColors.Refresh();
            
            ResumeLayout();
            cc.Refresh();
            Refresh();
        }
        private object CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();

            Object p = t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);

            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(o, null), null);
                }
            }

            return p;
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

        private void ntfColorCapture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void ntfColorCapture_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void frmCapture_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ntfColorCapture.Visible = true;
                //ntfColorCapture.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
                //this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                ntfColorCapture.Visible = false;
                this.ShowInTaskbar = true;
              //  this.Show();
            }
        }
        internal class colorControls
        {
            public PictureBox picColor { get; set; }
            public TextBox htmlColor { get; set; }
            public PictureBox picCopy { get; set; }
            public PictureBox picDelete { get; set; }
            public void Refresh()
            {
                picColor.Refresh();
                picCopy.Refresh();
                picDelete.Refresh();
            }
        }
    }
}
