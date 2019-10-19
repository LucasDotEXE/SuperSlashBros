using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SuperSLashWPF
{
    class Body
    {
        private Ellipse belly;
        private Point position;

        public Body(Point position) {
            this.position = position;
            constructBelly();
        }

        public void constructBelly() {
            this.belly = new Ellipse();
            this.belly.Stroke = System.Windows.Media.Brushes.Black;
            this.belly.Fill = System.Windows.Media.Brushes.Red;
            this.belly.Width = 50;
            this.belly.Height = 50;
            Canvas.SetTop(this.belly, position.Y - 25);
            Canvas.SetLeft(this.belly, position.X - 25);
        }

        public void update(Point position, int fat) {
            this.position = position;

            Application.Current.Dispatcher.Invoke(new Action(() => {
                this.belly = new Ellipse();
                this.belly.Stroke = System.Windows.Media.Brushes.Black;
                this.belly.Fill = System.Windows.Media.Brushes.Red;
                this.belly.Width = fat;
                this.belly.Height = fat;
                Canvas.SetTop(this.belly, position.Y - fat/2);
                Canvas.SetLeft(this.belly, position.X - fat/2);
            }));

        }

        public Ellipse getBelly() {
            return this.belly;
        }
    }
}
