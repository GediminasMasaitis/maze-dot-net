using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze.WinFormsGDI.Controls
{
    public partial class PolygonShape : UserControl
    {
        public Point[] Polygon { get; set; }
        private Point[] SizedPolygon { get; set; }
        private Brush PolygonBrush { get; set; }
        private Color _polygonColor;
        public Color PolygonColor
        {
            get => _polygonColor;
            set
            {
                _polygonColor = value;
                PolygonBrush = new SolidBrush(value);
            }
        }
        public int PolygonSize { get; set; }

        public PolygonShape()
        {
            InitializeComponent();
            PolygonColor = Color.Black;
            Polygon = new Point[0];
            PolygonSize = 10;
            SyncSizedPolygon();
        }

        protected override void OnResize(EventArgs e)
        {
            SyncSizedPolygon();
            base.OnResize(e);
        }

        protected void SyncSizedPolygon()
        {
            SizedPolygon = Polygon.Select(x => new Point(x.X*Size.Width/PolygonSize, x.Y*Size.Height/PolygonSize)).ToArray();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillPolygon(PolygonBrush, SizedPolygon);
        }
    }
}
