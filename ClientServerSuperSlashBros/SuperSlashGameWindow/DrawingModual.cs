using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using SuperSLashWPF.Map;

namespace SuperSLashWPF
{
    class DrawingModual
    {
        private Canvas canvas;
        public DrawingModual(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public bool drawWeapon(List<Line> lines)
        {
            try
            {
                foreach (Line line in lines)
                {

                    this.canvas.Children.Add(line);

                }
                return true;
            }
            catch {
                return false;
            }
        }

        public bool drawBelly(Ellipse belly) {
            try
            {
                this.canvas.Children.Add(belly);
                return true;
            }
            catch {
                return false;
            }
        }

        public bool clear()
        {
            try
            {
                this.canvas.Children.Clear();
                return true;
            }
            catch {
                return false;
            }
        }

        public void DrawCharacter(Character character)
        {
            
            drawBelly(character.GetCharacterObjects().drawBody().getBelly());
            drawWeapon(character.GetCharacterObjects().drawWeapon());
        }

        public void drawMap(Map.Map map) {
            foreach (Wall wall in map.GetWalls()) {
                this.canvas.Children.Add(wall.drawLine());
            }
        }

    }
}
