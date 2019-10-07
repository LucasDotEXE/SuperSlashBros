using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperSLashWPF
{
    public class Drawer
    {
        private Canvas canvas;
        public Drawer(Canvas canvas) {
            this.canvas = canvas;
        }

        public void drawObject(List<Line> lines) {
            foreach(Line line in lines) {
                this.canvas.Children.Add(line);
            }
        }

    }
}
