using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace ScreenFlowTest
{
    public partial class mainForm : Form
    {
        Timer tmr;

        int counter = 0;
        int maxcounter = 10;

        public mainForm()
        {
            InitializeComponent();
            init();
        }


        void init()
        {
            if (settings.current.Width > 0) this.Width = settings.current.Width;
            if (settings.current.Height > 0) this.Height = settings.current.Height;
            if (settings.current.Left > 0) { this.Left = settings.current.Left; StartPosition = FormStartPosition.Manual; }
            if (settings.current.Top > 0) { this.Top = settings.current.Top; StartPosition = FormStartPosition.Manual; }

            initMenu();            

            pic.BackColor = Color.Black;
            pic.MouseDoubleClick += Pic_MouseDoubleClick;
            //pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);


            tmr = new Timer();
            tmr.Interval = settings.current.Interval;
            tmr.Tick += Tmr_Tick;

            settings.current.IntervalChanged += Current_IntervalChanged;
            settings.current.SettingsChanged += Current_SettingsChanged;

            setText();
            setFormMode();

            if (settings.current.AutoShow)
            {
                MouseHook.Start();
            }

            
            MouseHook.MouseAction += MouseHook_MouseAction;
        }
        bool bML_Down = false;
        bool bMR_Down = false;
        private void MouseHook_MouseAction(object sender, MouseHook.MouseEventArg e)
        {
            switch (e.Kind)
            {
                case MouseHook.MouseMessages.WM_LBUTTONDOWN:
                    bML_Down = true;
                    break;
                case MouseHook.MouseMessages.WM_LBUTTONUP:
                    bML_Down = false;
                    break;
                case MouseHook.MouseMessages.WM_RBUTTONDOWN:
                    bMR_Down = true;
                    break;
                case MouseHook.MouseMessages.WM_RBUTTONUP:
                    bMR_Down = false;
                    break;
                case MouseHook.MouseMessages.WM_MOUSEMOVE:
                case MouseHook.MouseMessages.WM_MOUSEWHEEL:
                default:
                    break;
            }
        }

        private void Pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Size checkSize = pnl.Size;
            if (checkSize.Height == 0 || checkSize.Width == 0) return;


            var sr = getScreenBounds();


            decimal k1 = (decimal)checkSize.Width / sr.Width;
            decimal k2 = (decimal)checkSize.Height / sr.Height;

            decimal k = sr.Height * k1 > checkSize.Height ? k2 : k1;
            Size newSize1 = new Size((int)(sr.Width * k), (int)(sr.Height * k));

            var p = new Point((int)(e.X / k)+ sr.X, (int)(e.Y / k) + sr.Y);
            var p_Old = Cursor.Position;
            //System.Threading.Thread.Sleep(100);
            Cursor.Position = p;
            
        }

        bool isResize = false;
        protected override void OnResizeBegin(EventArgs e)
        {
            isResize = true;
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            isResize = false;
        }

        bool currentModeAlwaysTop = false;
        Point oldPos;
        Size oldSize;
        void setFormMode()
        {
            bool onForm = this.Bounds.Contains(Cursor.Position);
            if (settings.current.AlwaysTop && !onForm && ! isResize)
            {
                if (!currentModeAlwaysTop)
                {
                    this.SuspendLayout();
                    var pos = pnl.PointToScreen(new Point(0, 0));
                    oldPos = this.Location;
                    oldSize = this.Size;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.TopMost = true;
                    //this.menuStrip1.Parent = null;
                    this.Location = pos;
                    this.Size = pnl.Size;
                    this.menuStrip1.Visible = false;
                    currentModeAlwaysTop = true;
                    pnl.Location = new Point(0, 0);
                    pnl.Size = this.Size;
                    this.PerformLayout();
                    this.ResumeLayout();
                    //pnl.SendToBack();
                    //pnl.PerformLayout();
                }
            }
            else 
            {
                if (currentModeAlwaysTop)
                {
                    this.SuspendLayout();
                    this.menuStrip1.Visible = true;
                    //this.menuStrip1.Parent = this;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.TopMost = false;
                    currentModeAlwaysTop = false;
                    if (!oldPos.IsEmpty)
                    {
                        this.Location = oldPos;
                        this.Size = oldSize;
                    }
                    //menuStrip1.BringToFront();
                    //this.PerformLayout();
                    //pnl.Dock = DockStyle.Fill;
                    //pnl.PerformLayout();
                    this.ResumeLayout();
                }
            }
        }

        void setText()
        {
            this.Text = settings.current.ToString();
        }
        private void Current_SettingsChanged(object sender, EventArgs e)
        {
            setText();

        }

        protected override void OnClosed(EventArgs e)
        {
            settings.current.IntervalChanged -= Current_IntervalChanged;
            settings.current.SettingsChanged -= Current_SettingsChanged;
            base.OnClosed(e);

        }

        private void Current_IntervalChanged(object sender, EventArgs e)
        {
            tmr.Stop();
            try
            {
                tmr.Interval = settings.current.Interval;
            }
            finally
            {
                tmr.Start();
            }
            setCheckMenuItemRefresh();
        }

        void setCheckMenuItemRefresh()
        {
            resetMenuItemRefreshState();

            foreach (ToolStripItem tsi in refreshToolStripMenuItem.DropDownItems)
            {
                if (tsi.Tag.ToString() == settings.current.Interval.ToString())
                {
                    (tsi as ToolStripMenuItem).Checked = true;
                }
            }
        }

        void initMenu()
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                screenToolStripMenuItem.DropDownItems.Add(getItem(i));
            }

            setCheckMenuItemRefresh();
            showMouseToolStripMenuItem.Checked = settings.current.ShowMouse;
            autoShowToolStripMenuItem.Checked = settings.current.AutoShow;
            resizeToolStripMenuItem.Checked = settings.current.ResizeImage;
            alwaysTopToolStripMenuItem.Checked = settings.current.AlwaysTop;
            showFormIconToolStripMenuItem.Checked = settings.current.IconForm;
        }

        ToolStripItem getItem(int iscr)
        {
            Screen scr = Screen.AllScreens[iscr];

            ToolStripMenuItem res = new ToolStripMenuItem(string.Format("{0}. {1}", iscr+1, scr.DeviceName));
            res.Tag = iscr;
            res.Click += menuItem_Click;

            return res;
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            settings.current.Screen = (int)mi.Tag;
        }
        // флаг, что окно само вылезло
        bool _autoShowed = false;

        long tick_last = 0;
        long tick_curr = 0;
        Bitmap bmpCurr;
        private void Tmr_Tick(object sender, EventArgs e)
        {
            tick_curr = DateTime.Now.Ticks;
            if (settings.current.IconForm) setFormIcon();
            else if (this.Icon != Resources.res.appIcon) this.Icon = Resources.res.appIcon;

            if (this.WindowState == FormWindowState.Minimized )
            {
                if(settings.current.AutoShow)
                {
                    if (getScreenBounds().Contains(Cursor.Position) && !bML_Down && !bMR_Down)
                    {
                        this.WindowState = FormWindowState.Normal;
                        _autoShowed = true;
                    }
                }
                return;
            }
            else if(_autoShowed && !bML_Down && !bMR_Down && !getScreenBounds().Contains(Cursor.Position))
            {
                this.WindowState = FormWindowState.Minimized;
                _autoShowed = false;
                return;
            }
            try
            {
                unsafe
                {
                    Image old = pic.Image;
                    pic.Image = getImage();// resizeBitmap(ImageFromScreen(), pic.Size);
                    old?.Dispose();
                    locationAndResizePic();
                }

                if (counter < maxcounter) counter++;
                else
                {
                    counter = 0;
                    GC.Collect();
                }
                setFormMode();
            }
            catch (Exception ex) { }
        }

        Size iconSize = new Size(32, 32);
        private void setFormIcon()
        {
            var bmp = ImageFromScreen();
            this.Icon = Icon.FromHandle(resizeBitmap(bmp, iconSize).GetHicon());
        }

        void locationAndResizePic()
        {
            if (pic.Image != null)
            {
                pic.Height = pic.Image.Height;
                pic.Width = pic.Image.Width;
            }
            pic.Top = (pnl.Height - pic.Height) / 2;
            pic.Left = (pnl.Width - pic.Width) / 2;
        }

        Bitmap getImage()
        {
            Size checkSize = pnl.Size;
            if (checkSize.Height == 0 || checkSize.Width == 0) return null;


            Bitmap scr = ImageFromScreen();

            if (!settings.current.ResizeImage) return scr;

            decimal k1 = (decimal)checkSize.Width / scr.Width;
            decimal k2 = (decimal)checkSize.Height / scr.Height;

            decimal k = k1;
            if (scr.Height * k1 > checkSize.Height) k = k2;
            Size newSize1 = new Size((int)(scr.Width * k), (int)(scr.Height * k));

            Bitmap res = resizeBitmap(scr, newSize1) ;
            scr.Dispose();
            return res;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tmr.Start();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            tmr.Stop();
            if (MouseHook.Started) MouseHook.stop();

            settings.current.Width = this.Width;
            settings.current.Height = this.Height;
            settings.current.Left = this.Left;
            settings.current.Top = this.Top;

            base.OnClosing(e);
        }

        static int radiusMouseCircle = 10;
        static Color colorMouse = Color.FromArgb(70, Color.Yellow);
        static Pen penMouseCircle = new Pen(colorMouse, radiusMouseCircle * 2);
        /// <summary>
        /// Сделать снимок основного экрана
        /// </summary>
        /// <returns>Возвращает снимок с основного экрана размером с текущее разрешение экрана</returns>
        public Bitmap ImageFromScreen()
        {
            if (tick_curr == tick_last) return bmpCurr ?? new Bitmap(1, 1);
            var sr = getScreenBounds();   
            Bitmap bmp = new Bitmap(sr.Width, sr.Height,
                PixelFormat.Format24bppRgb);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.CopyFromScreen(sr.X, sr.Y,
                    0, 0, sr.Size, CopyPixelOperation.SourceCopy);
                if (settings.current.ShowMouse)
                {
                    var pm = new Point(Cursor.Position.X - sr.Left, Cursor.Position.Y - sr.Top);
                    Cursor.Current.Draw(gr, new Rectangle(pm, Cursor.Size));
                    var d = radiusMouseCircle * 2;
                    gr.DrawEllipse(penMouseCircle,
                        pm.X - (radiusMouseCircle/2),
                        pm.Y,
                        d,
                        d
                        );
                }
            }
            
                
            bmpCurr = bmp;
            tick_last = tick_curr;
            return bmpCurr;
        }

        Rectangle getScreenBounds()
        {
            Screen scr = Screen.AllScreens[settings.current.Screen];
            return scr.Bounds;
        }

        Bitmap resizeBitmap(Bitmap bmp, Size newSize)
        {
            Bitmap res = new Bitmap(bmp, newSize);

            return res;
        }
        #region установка интервала через меню

        void resetMenuItemRefreshState()
        {
            bool b = false;
            разВСекундуToolStripMenuItem.Checked = b;
            разВСекундуToolStripMenuItem1.Checked = b;
            разВСекундуToolStripMenuItem2.Checked = b;
            разВСекундуToolStripMenuItem3.Checked = b;
            разВСекундуToolStripMenuItem4.Checked = b;
        }

        private void разВСекундуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                settings.current.Interval = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
                (sender as ToolStripMenuItem).Checked = true;
            }
            finally
            {
            }
        }
        #endregion установка интервала через меню

        private void pic_Click(object sender, EventArgs e)
        {
            //var picSz = pic.Size;
            //var picPos = pic.PointToClient(Cursor.Position);
            //var sr = getScreenBounds();
            //var posOnScreen = new Point(
            //    x: picPos.X * sr.Width / picSz.Width,
            //    y: picPos.Y * sr.Height / picSz.Height
            //    );

            //mouseImitation.clickLeft(posOnScreen);
        }

        private void showMouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMouseToolStripMenuItem.Checked = (settings.current.ShowMouse = !settings.current.ShowMouse);

        }

        private void alwaysTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alwaysTopToolStripMenuItem.Checked = (settings.current.AlwaysTop = !settings.current.AlwaysTop);
            setFormMode();
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                var picSz = pic.Size;
                var picPos = e.Location;// pic.PointToClient(Cursor.Position);
                var sr = getScreenBounds();
                var posOnScreen = new Point(
                    x: picPos.X * sr.Width / picSz.Width,
                    y: picPos.Y * sr.Height / picSz.Height
                    );

                mouseImitation.clickLeft(posOnScreen);

            }
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resizeToolStripMenuItem.Checked = (settings.current.ResizeImage = !settings.current.ResizeImage);
        }

        private void autoShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoShowToolStripMenuItem.Checked = (settings.current.AutoShow = !settings.current.AutoShow);

            if (settings.current.AutoShow) MouseHook.Start();
            else MouseHook.stop();
        }

        private void deleteSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete user settings?", "Delete settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)!= DialogResult.Yes) return;

            if (!File.Exists(Program.pathSettings))
            {
                MessageBox.Show($"File {Program.pathSettings} not exist!", "Delete settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            File.Delete(Program.pathSettings);
        }

        private void showFormIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.current.IconForm = !settings.current.IconForm;
            showFormIconToolStripMenuItem.Checked = settings.current.IconForm;
        }

        private void moveToNextDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Count() == 1) return;
            var scr = Screen.FromControl(this);
            int iscr = -1;
            for(int i = 0; i< Screen.AllScreens.Count(); i++)
                if(Screen.AllScreens[i].DeviceName==scr.DeviceName)
                {
                    iscr = i;
                    break;
                }
            iscr++;
            if (iscr >= Screen.AllScreens.Count()) iscr = 0;
            var newScr = Screen.AllScreens[iscr];

            Point newLocation = new Point(
                newScr.Bounds.X,// + Math.Max(0, this.Location.X - scr.Bounds.X),
                newScr.Bounds.Y// + Math.Max(0, this.Location.Y - scr.Bounds.Y)
                );


            this.Location = newLocation;

        }

        private void setMainDisplayNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
