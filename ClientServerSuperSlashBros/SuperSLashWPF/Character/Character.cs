using System.Drawing;

namespace SuperSLashWPF
{
    class Character
    {
        private Point position;
        private Stats stats;
        private CharacterObjects characterObjects;
        private int speed;

        public Character()
        {
            this.speed = 3;
            position.X = 50;
            position.Y = 50;
            characterObjects = new CharacterObjects(this.position);
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
            move(new Point(0, -speed));
        }

        public void right()
        {
            move(new Point(speed, 0));
            this.characterObjects.setDirection(true);
        }

        public void left()
        {
            move(new Point(-speed, 0));
            this.characterObjects.setDirection(false);
        }

        public void down()
        {
            move(new Point(0, speed));
        }
    }
}
