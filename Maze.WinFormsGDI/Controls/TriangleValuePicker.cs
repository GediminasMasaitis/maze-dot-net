using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Point = System.Drawing.Point;


namespace Maze.WinFormsGDI.Controls
{
    public sealed partial class TriangleValuePicker : UserControl
    {
        public TriangleValuePicker()
        {
            MaxValue = 1000;
            CircleRadius = 5;
            UseInnerCircle = true;
            InnerCircleRadius = 3;
            InnerMargin = 5;
            ForeBrush = new SolidBrush(ForeColor);

            InitializeComponent();
        }

        public int InnerMargin { get; set; }
        public int MaxValue { get; set; }
        public Point Value { get; private set; }
        public int CircleRadius { get; set; }
        public bool UseInnerCircle { get; set; }
        public int InnerCircleRadius { get; set; }

        public int ValueA { get; private set; }
        public int ValueB { get; private set; }
        public int ValueC { get; private set; }

        private int RawValueA { get; set; }
        private int RawValueB { get; set; }
        private int RawValueC { get; set; }

        const double Sqrt3 = 1.7320508075688772935274463415059;
        // Corners
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }

        private Point AVec { get; set; }
        private Point BVec { get; set; }
        private Point CVec { get; set; }

        private Point ABMidVec { get; set; }
        private Point BCMidVec { get; set; }
        private Point ACMidVec { get; set; }

        private int RawValueSum { get; set; }
        private double Dist { get; set; }
        private Rectangle InnerRect { get; set; }
        private SolidBrush ForeBrush { get; set; }

        private int GetRawValueX(Point corner, Point midLine)
        {
            var pt = GetClosetPoint(corner, midLine, Value);
            var val = MaxValue - 10 - (int)Math.Round((Math.Pow(corner.X - pt.X, 2) + Math.Pow(corner.Y - pt.Y, 2)) * MaxValue / Dist);
            return val > 0 ? val + 10 : 0;
        }

        private void RecalcParams()
        {
            InnerRect = new Rectangle(ClientRectangle.X + InnerMargin, ClientRectangle.Y + InnerMargin,
            ClientRectangle.Width - InnerMargin * 2, ClientRectangle.Height - InnerMargin * 2);
            var oldRect = InnerRect;
            oldRect.Height = (int)(Sqrt3 / 2 * InnerRect.Width);
            InnerRect = oldRect;
            Height = InnerRect.Height + InnerMargin * 2;

            A = new Point(InnerRect.Left + InnerRect.Width / 2, InnerRect.Top);
            B = new Point(InnerRect.Left, InnerRect.Bottom);
            C = new Point(InnerRect.Right, InnerRect.Bottom);

            AVec = new Point(InnerRect.Left + InnerRect.Width / 2, InnerRect.Top);
            BVec = new Point(InnerRect.Left, InnerRect.Bottom);
            CVec = new Point(InnerRect.Right, InnerRect.Bottom);

            ABMidVec = new Point(AVec.X / 2 + BVec.X / 2, AVec.Y / 2 + BVec.Y / 2);
            BCMidVec = new Point(BVec.X / 2 + CVec.X / 2, BVec.Y / 2 + CVec.Y / 2);
            ACMidVec = new Point(AVec.X / 2 + CVec.X / 2, AVec.Y / 2 + CVec.Y / 2);

            Dist = GetDistance(AVec, BCMidVec);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            ForeBrush = new SolidBrush(ForeColor);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            RecalcParams();
            Invalidate();
            Value = B;
        }

        private double GetDistance(Point a, Point b)
        {
            return Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2);
        }

        private int DeterminePlane(Point p)
        {
            var planeAB = ((A.X - p.X) * (B.Y - p.Y) - (B.X - p.X) * (A.Y - p.Y)) > 0;
            var planeBC = ((B.X - p.X) * (C.Y - p.Y) - (C.X - p.X) * (B.Y - p.Y)) > 0;
            var planeCA = ((C.X - p.X) * (A.Y - p.Y) - (A.X - p.X) * (C.Y - p.Y)) > 0;

            if (!planeAB && !planeBC && !planeCA)
            {
                return 0;
            }
            if (planeAB && planeBC && !planeCA)
            {
                return 1;
            }
            if (planeAB && !planeBC && !planeCA)
            {
                return 2;
            }
            if (planeAB && !planeBC && planeCA)
            {
                return 3;
            }
            if (!planeAB && !planeBC && planeCA)
            {
                return 4;
            }
            if (!planeAB && planeBC && planeCA)
            {
                return 5;
            }
            if (!planeAB && planeBC && !planeCA)
            {
                return 6;
            }
            return -1;
        }

        private void UpdateValueFromCoords(Point p)
        {
            Invalidate(new Rectangle(Value.X - CircleRadius - 1, Value.Y - CircleRadius - 1, CircleRadius * 2 + 2, CircleRadius * 2 + 2));
            switch (DeterminePlane(p))
            {
                case 0:
                    Value = p;
                    break;
                case 1:
                    Value = B;
                    break;
                case 2:
                    Value = GetClosetPoint(AVec, BVec, p);
                    break;
                case 3:
                    Value = A;
                    break;
                case 4:
                    Value = GetClosetPoint(AVec, CVec, p);
                    break;
                case 5:
                    Value = C;
                    break;
                case 6:
                    Value = GetClosetPoint(BVec, CVec, p);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(p), p, null);
            }

            RawValueA = GetRawValueX(AVec, BCMidVec);
            RawValueB = GetRawValueX(BVec, ACMidVec);
            RawValueC = GetRawValueX(CVec, ABMidVec);

            RawValueSum = RawValueA + RawValueB + RawValueC;

            ValueA = GetValueX(RawValueA);
            ValueB = GetValueX(RawValueB);
            ValueC = GetValueX(RawValueC);
            Invalidate(new Rectangle(Value.X - CircleRadius - 1, Value.Y - CircleRadius - 1, CircleRadius * 2 + 2, CircleRadius * 2 + 2));
        }

        private int GetValueX(int rawValue)
        {
            return (rawValue * MaxValue) / RawValueSum;
        }

        private Point GetClosetPoint(Point a, Point b, Point pt, bool segmentClamp = true)
        {
            var p = new Point(pt.X, pt.Y);
            var ap = p - (Size)a;
            var ab = b - (Size)a;
            var ab2 = ab.X * ab.X + ab.Y * ab.Y;
            var apAb = ap.X * ab.X + ap.Y * ab.Y;
            var t = apAb / (float)ab2;
            if (segmentClamp)
            {
                if (t < 0.0f)
                {
                    t = 0.0f;
                }
                else if (t > 1.0f)
                {
                    t = 1.0f;
                }
            }
            var closest = new Point((int)(ab.X * t), (int)(ab.Y * t)) + (Size)a;
            return new Point((int)closest.X, (int)closest.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateValueFromCoords(e.Location);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateValueFromCoords(e.Location);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            var arr = new[] { A, B, C };
            e.Graphics.FillPolygon(ForeBrush, arr);
            var defaultSmoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPolygon(Pens.Black, arr);
            e.Graphics.DrawEllipse(Pens.Black, Value.X - CircleRadius, Value.Y - CircleRadius, CircleRadius * 2, CircleRadius * 2);
            if (UseInnerCircle)
            {
                e.Graphics.DrawEllipse(Pens.Black, Value.X - InnerCircleRadius, Value.Y - InnerCircleRadius, InnerCircleRadius*2, InnerCircleRadius*2);
            }
            e.Graphics.SmoothingMode = defaultSmoothingMode;
        }
    }
}
