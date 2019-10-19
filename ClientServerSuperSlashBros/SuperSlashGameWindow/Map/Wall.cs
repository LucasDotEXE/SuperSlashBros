using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SuperSLashWPF.Map
{
    class Wall
    {
        private Line line;

        public Wall(int x1, int x2, int y1, int y2) {
            constructWall(x1,x2,y1,y2);
        }

        private void constructWall(int x1, int x2, int y1, int y2) {
            line = new Line();
            this.line.X1 = x1;
            this.line.X2 = x2;
            this.line.Y1 = y1;
            this.line.Y2 = y2;
            this.line.StrokeThickness = 2;
            this.line.Stroke = System.Windows.Media.Brushes.Green;
        }

        public Line drawLine() {
            return this.line;
        }
    }
}
