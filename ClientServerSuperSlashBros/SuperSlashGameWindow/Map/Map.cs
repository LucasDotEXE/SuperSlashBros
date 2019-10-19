using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSLashWPF.Map
{
    class Map
    {
        private HashSet<Wall> walls;
        private int gravitation;

        public Map() {
            constructWalls();
            this.gravitation = 6;
        }

        private void constructWalls() {
            this.walls = new HashSet<Wall>();
            //Zei muren
            this.walls.Add(new Wall(5, 5, 0, 1000));
            this.walls.Add(new Wall(700, 700, 0, 1000));

            //Onderste vloer
            this.walls.Add(new Wall(55, 650, 500, 500));
            this.walls.Add(new Wall(55, 650, 510, 510));
            this.walls.Add(new Wall(55, 55, 500, 510));
            this.walls.Add(new Wall(650, 650, 500, 510));

            //Bovenste vloer
            this.walls.Add(new Wall(145, 560, 400, 400));
            this.walls.Add(new Wall(145, 560, 410, 410));
            this.walls.Add(new Wall(145, 145, 400, 410));
            this.walls.Add(new Wall(560, 560, 400, 410));

        }

        public HashSet<Wall> GetWalls() {
            return this.walls;
        }

        public int getGravitation() {
            return this.gravitation;
        }
    }
}
