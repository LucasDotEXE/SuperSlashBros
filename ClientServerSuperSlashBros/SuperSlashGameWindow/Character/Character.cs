using System.Drawing;
using System.Windows;

namespace SuperSLashWPF
{
    class Character
    {
        private Point position;
        private CharacterObjects characterObjects;
        private Stats stats;

        public Character()
        {
            this.stats = new Stats(false, 30);
            position.X = 100;
            position.Y = 50;
            characterObjects = new CharacterObjects(this.position, this);
        }

        public CharacterObjects GetCharacterObjects()
        {
            return this.characterObjects;
        }

        public void move(Point move)
        {
            this.position.X += move.X;
            this.position.Y += move.Y;
            this.characterObjects.changePosition(this.position);
        }

        public void up()
        {
            move(new Point(0, -this.stats.getSpeed()));
        }

        public void levelUp() {
            this.stats.leverlUp();
        }

        public void right()
        {
            move(new Point(this.stats.getSpeed(), 0));
            this.characterObjects.setDirection(true);
        }

        public void left()
        {
            move(new Point(-this.stats.getSpeed(), 0));
            this.characterObjects.setDirection(false);
        }

        public void down()
        {
            move(new Point(0, this.stats.getSpeed()));
        }

        public void jump(int mod)
        {
            move(new Point(0, -mod));
        }

        public void up(int mod)
        {
            move(new Point(0, mod));
        }

        public void jump() {
        
        }

        public int getJumpForce() {
            return this.stats.getJumpForce();
        }

        public void right(int mod)
        {
            move(new Point(mod, 0));
            this.characterObjects.setDirection(true);
        }

        public void left(int mod)
        {
            move(new Point(-mod, 0));
            this.characterObjects.setDirection(false);
        }

        public void down(int mod)
        {
            move(new Point(0, mod));
        }

        public Point getPosition() {
            return this.position;
        }

        public int getSpeed() {
            return this.stats.getSpeed();
        }

        public int getFat() {
            return this.stats.getFat();
        }
    }
}
