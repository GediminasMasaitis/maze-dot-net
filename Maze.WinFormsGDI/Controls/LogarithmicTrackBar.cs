using System;
using System.Windows.Forms;

namespace Maze.WinFormsGDI.Controls
{
    class LogarithmicTrackBar : TrackBar
    {

        public LogarithmicTrackBar()
        {
            Minimum = 0;
            Maximum = 1000;
            LogMinimum = 0;
            LogMiddle = 10;
            LogMaximum = 100;
            LogValue = ValToLogVal(Value);
        }

        public double LogMinimum { get; set; }
        public double LogMiddle { get; set; }
        public double LogMaximum { get; set; }
        public double LogValue { get; private set; }

        protected override void OnValueChanged(EventArgs e)
        {
            var val = Value/(double)Maximum - Minimum;
            LogValue = ValToLogVal(val);
            base.OnValueChanged(e);
        }

        private double ValToLogVal(double val)
        {
            if (Math.Abs(LogMinimum - 2 * LogMiddle + LogMaximum) < 0.001)
            {
                return val;
            }
            var logVal = A + B * Math.Exp(C * val);
            return logVal;
        }

        private double LogValToVal(double logVal)
        {
            if (Math.Abs(LogMinimum - 2 * LogMiddle + LogMaximum) < 0.001)
            {
                return logVal;
            }
            var val = Math.Log((logVal - A) / B) / C;
            return val;
        }

        private double A => (LogMinimum*LogMaximum - LogMiddle*LogMiddle)/(LogMinimum - 2*LogMiddle + LogMaximum);
        private double B => (LogMiddle - LogMinimum)*(LogMiddle - LogMinimum)/(LogMinimum - 2*LogMiddle + LogMaximum);
        private double C => 2*Math.Log((LogMaximum - LogMiddle)/(LogMiddle - LogMinimum));
    }
}
