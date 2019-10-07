using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Shapes;

namespace SuperSLashWPF
{
    class Weapon
    {
        private List<Line> lines = new List<Line>();
        private Point position;
        public List<Line> getSword(Point position, bool direction){
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
            else if (direction == false) {
                sword.X2 = position.X - 30;
                sword.Y2 = position.Y - 30;
            }
            sword.Stroke = System.Windows.Media.Brushes.Red;
            sword.StrokeThickness = 5;
            this.lines.Add(sword);
            return this.lines;
        }

        public List<Line> getAxe()
        {
            return this.lines;
        }
    }
}
