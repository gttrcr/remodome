namespace RemoDome
{
    public partial class CrossRoadForm : Form
    {
        public CrossRoadForm()
        {
            InitializeComponent();

            trackBarOpacity.Minimum = 0;
            trackBarOpacity.Maximum = 100;
            trackBarRadius.Minimum = 0;
            trackBarRadius.Maximum = this.panelCrossRoad.Size.Height;
        }

        private void TrackBarRadius_Scroll(object sender, EventArgs e)
        {
            int val = trackBarRadius.Value;
            Graphics graphics = this.panelCrossRoad.CreateGraphics();
            graphics.Clear(panelCrossRoad.BackColor);
            int p1X = val / 2;
            int p1Y = val / 2;
            int p2X = panelCrossRoad.Width - val;
            int p2Y = panelCrossRoad.Height - val;

            Rectangle rectangle = new Rectangle(p1X, p1Y, p2X, p2Y);
            graphics.DrawEllipse(Pens.Black, rectangle);
            graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(panelCrossRoad.Size));
            graphics.DrawLine(Pens.Black, new Point(0, panelCrossRoad.Size.Width), new Point(panelCrossRoad.Size.Height, 0));
        }

        private void TrackBarOpacity_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (double)(trackBarOpacity.Maximum - trackBarOpacity.Value) / 100;
        }
    }
}