using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperSLashWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character character;
        private Canvas canvas;
        private Drawer drawer;
        public MainWindow()
        {
            InitializeComponent();
            this.canvas = MainCanvas;

            this.drawer = new Drawer(canvas);

            this.character = new Character();

            this.character.move(new System.Drawing.Point(1, 1));
            this.canvas.Children.Clear();
            this.drawer.drawObject(character.GetCharacterObjects().drawWeapon());
        }

        private void TESTMOUSENTER(object sender, MouseButtonEventArgs e) {
            Console.WriteLine("HHHHHHHHHIIIIIIIIIII");
            this.character.move(new System.Drawing.Point(1,1));
            this.canvas.Children.Clear();
            this.drawer.drawObject(character.GetCharacterObjects().drawWeapon());
        }

        public void keydown(object sender, KeyEventArgs e) {
            /*switch (e.Key) {
                case Key.D:
                    this.character.right();
                case Key.A:
                    this.character.left();
                    break;
                case Key.S:
                    this.character.down();
                    break;
                case Key.W:
                    this.character.up();
                    break;
                default:
                    break;
            }*/

            if (e.Key == Key.D) {
                this.character.right();
            }
            if (e.Key == Key.A)
            {
                this.character.left();
            }
            if (e.Key == Key.S)
            {
                this.character.down();
            }
            if (e.Key == Key.W)
            {
                this.character.up();
            }

            this.canvas.Children.Clear();
            this.drawer.drawObject(character.GetCharacterObjects().drawWeapon());
        }
    }
}
