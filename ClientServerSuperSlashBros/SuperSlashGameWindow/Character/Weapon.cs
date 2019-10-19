using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace SuperSLashWPF
{
    class Weapon
    {
        private List<Line> lines = new List<Line>();
        private Point position;
        private int range;
        public void updateSword(Point position, bool direction)
        {

            Application.Current.Dispatcher.Invoke(new Action(() => {
            this.position = position;
            lines.Clear();
            this.position = position;
            lines.Clear();
            Line sword = new Line();
            sword.X1 = position.X;
            sword.Y1 = position.Y;
            if (direction == true)
            {
                sword.X2 = position.X + 30;
                sword.Y2 = position.Y - 30;
            }
            else if (direction == false)
            {
                sword.X2 = position.X - 30;
                sword.Y2 = position.Y - 30;
            }
            sword.Stroke = System.Windows.Media.Brushes.Red;
            sword.StrokeThickness = 5;
            this.lines.Add(sword);
            this.range = 50;
            }));

            

        }

        public void updateAxe(Point position, bool direction)
        {
            this.position = position;
            lines.Clear();
            Line sword = new Line();
            sword.X1 = position.X;
            sword.Y1 = position.Y;
            if (direction == true)
            {
                sword.X2 = position.X + 30;
                sword.Y2 = position.Y - 30;
            }
            else if (direction == false)
            {
                sword.X2 = position.X - 30;
                sword.Y2 = position.Y - 30;
            }
            sword.Stroke = System.Windows.Media.Brushes.Red;
            sword.StrokeThickness = 5;
            this.lines.Add(sword);
        }

        public List<Line> getWeapons()
        {
            return this.lines;
        }

        public int getRange() {
            return this.range;
        }

    }
}
