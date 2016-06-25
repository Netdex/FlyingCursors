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
        }

        private Cursor _cursor;
        private List<CursorSprite> _sprites;
        private Random _random;

        private void FlyingCursors_Load(object sender, EventArgs e)
        {
            _cursor = Cursors.Default;
            _sprites = new List<CursorSprite>();
            _random = new Random();
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
        }

        
        private void FlyingCursors_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            foreach (var sp in _sprites)
            {
                _cursor.Draw(g, new Rectangle(sp.LocationX, sp.LocationY, 10, 10));
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            foreach (CursorSprite sp in _sprites)
            {
                sp.LocationX += sp.VelocityX;
                sp.LocationY += sp.VelocityY;
                if (sp.LocationX < 0 || sp.LocationX > Width)
                    sp.VelocityX *= -1;
                if (sp.LocationY < 0 || sp.LocationY > Height)
                    sp.VelocityY *= -1;
            }
            Refresh();
        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            CursorSprite sp = new CursorSprite(_random.Next(Width), _random.Next(Height), _random.Next(20) - 10, _random.Next(20) - 10);
            _sprites.Add(sp);
        }
    }

    class CursorSprite
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public CursorSprite(int locx, int locy, int velx, int vely)
        {
            LocationX = locx;
            LocationY = locy;
            VelocityX = velx;
            VelocityY = vely;
        }
    }
}
