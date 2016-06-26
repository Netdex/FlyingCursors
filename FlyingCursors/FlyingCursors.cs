using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingCursors
{
    public partial class FlyingCursors : Form
    {
        public FlyingCursors()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private List<Cursor> _types;
        private List<CursorSprite> _sprites;
        private Random _random;

        private void FlyingCursors_Load(object sender, EventArgs e)
        {
            _types = new List<Cursor>();
            foreach (var pi in typeof(Cursors).GetProperties())
            {
                _types.Add(pi.GetValue(this, null) as Cursor);
            }
            _sprites = new List<CursorSprite>();
            _random = new Random();
            WindowState = FormWindowState.Maximized;
        }


        private void FlyingCursors_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            foreach (var sp in _sprites)
            {
                sp.Type.Draw(g, new Rectangle((int)sp.LocationX, (int)sp.LocationY, 10, 10));
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            foreach (CursorSprite sp in _sprites)
            {
                // Calculate new positioning
                sp.LocationX += sp.VelocityX;
                sp.LocationY += sp.VelocityY;

                // Do wall bounces
                if (sp.LocationX < 0)
                {
                    sp.LocationX = 0;
                    sp.VelocityX *= -1;
                }
                else if (sp.LocationX > Width)
                {
                    sp.LocationX = Width;
                    sp.VelocityX *= -1;
                }
                if (sp.LocationY < 0)
                {
                    sp.LocationY = 0;
                    sp.VelocityY *= -1;
                }
                else if (sp.LocationY > Height)
                {
                    sp.LocationY = Height;
                    sp.VelocityY *= -1;
                }
                // Cap maximum velocity
                sp.VelocityX = Math.Min(20, sp.VelocityX);
                sp.VelocityY = Math.Min(20, sp.VelocityY);
            }
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            foreach (CursorSprite sp in _sprites)
            {
                Invalidate(new Rectangle((int)sp.LocationX - 20, (int)sp.LocationY - 20, 80, 80));
            }
        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            CursorSprite sp = new CursorSprite(
                _random.Next(Width),
                _random.Next(Height),
                _random.Next(20) - 10,
                _random.Next(20) - 10,
                _types[_random.Next(_types.Count)]);
            _sprites.Add(sp);
            if (_sprites.Count > 1500)
                timerSpawn.Stop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

    class CursorSprite
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public Cursor Type { get; set; }
        public CursorSprite(double locx, double locy, double velx, double vely, Cursor type)
        {
            LocationX = locx;
            LocationY = locy;
            VelocityX = velx;
            VelocityY = vely;
            Type = type;
        }
    }
}
