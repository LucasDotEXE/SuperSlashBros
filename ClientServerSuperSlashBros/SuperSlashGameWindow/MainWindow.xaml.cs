using SuperSLashWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Canvas canvas;
        private HashSet<Key> keys = new HashSet<Key>();
        private Handler handler;
        private DrawingModual drawer;
        public MainWindow()
        {
            InitializeComponent();
            this.canvas = MainCanvas;

            this.drawer = new DrawingModual(this.canvas);

            this.handler = new Handler(this.keys, this);
        }

        public void mouseclicked(object sender, MouseEventArgs e)
        {
            this.handler.GetCharacterHandler(1).Attack(this.handler.GetCharacterHandler(2));
        }

        public void keydown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D:
                    keys.Add(Key.D);
                    break;
                case Key.A:
                    keys.Add(Key.A);
                    break;
                case Key.S:
                    keys.Add(Key.S);
                    break;
                case Key.W:
                    keys.Add(Key.W);
                    break;
                default:
                    break;
            }
            this.handler.setKeys(this.keys);
        }

        public void keyup(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D:
                    keys.Remove(Key.D);
                    break;
                case Key.A:
                    keys.Remove(Key.A);
                    break;
                case Key.S:
                    keys.Remove(Key.S);
                    break;
                case Key.W:
                    keys.Remove(Key.W);
                    break;
                default:
                    break;
            }
            this.handler.setKeys(this.keys);
        }

        public void handle(object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                this.drawer.clear();
                this.drawer.DrawCharacter(this.handler.GetCharacterHandler(1).getP1());
                this.drawer.DrawCharacter(this.handler.GetCharacterHandler(2).getP1());
                this.drawer.drawMap(this.handler.GetMapHandler().GetMap());
            }));
        }
    }
}

    
