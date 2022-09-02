namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private int count;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            count = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = $"{count++}";
            button1.Location = new Point(random.Next(0, this.Width - button1.Width), random.Next(0, this.Height - button1.Height));
        }

        Button b;
        bool release = false;
        int X = 0;
        int Y = 0;
        int secX = 0;
        int secY = 0;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            X = 0;
            Y = 0;
            secX = e.X;
            secY = e.Y;
            release = false;
            b = new Button
            {
                Location = new Point(secX, secY),
                Size = new Size(X, Y)
            };
            this.Controls.Add(b);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!release)
            {
                if(b != null)
                {
                    var newLocationX = 0;
                    var newLocationY = 0;

                    if (e.X - secX > 0)
                    {
                        X = e.X - secX;
                        newLocationX = secX;
                    }
                    else
                    {
                        newLocationX = e.X;
                        X = Math.Abs(secX - e.X);
                    }
                    if (e.Y - secY > 0)
                    {
                        Y = e.Y - secY;
                        newLocationY = secY;
                    }
                    else
                    {
                        newLocationY = e.Y;
                        Y = Math.Abs(secY - e.Y);
                    }

                    b.Size = new Size(X, Y);
                    b.Location = new Point(newLocationX, newLocationY);
                }
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            release = true;
        }
    }
}