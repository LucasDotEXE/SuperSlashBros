using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;

namespace SuperSLashWPF
{
    class CharacterObjects
    {
        private Body body;
        private Point position;
        public enum eweapon { sword, axe };
        private eweapon currenWeapon = eweapon.sword;
        private Weapon weapon;
        private bool direction = true;
        private Character character;
        public CharacterObjects(Point position, Character character)
        {
            this.position = position;
            this.character = character;
            this.body = new Body(this.position);
            this.weapon = new Weapon();
        }

        public void changePosition(Point position)
        {
            this.position = position;
        }

        public void SetWeapon(eweapon weapon)
        {
            this.currenWeapon = weapon;
        }

        public void updateBelly() {
            body.update(position, this.character.getFat());
        }

        public void updateWeapon()
        {

            switch (this.currenWeapon)
            {
                case eweapon.sword:
                    //Console.WriteLine("sword");
                    weapon.updateSword(position, direction);
                    break;
                case eweapon.axe:
                    //Console.WriteLine("axe");
                    break;
            }
        }

        public List<Line> drawWeapon() {
            return weapon.getWeapons();
        }

        public Body getBody()
        {
            return this.body;
        }

        public Weapon getWeapon()
        {
            return this.weapon;
        }

        public Body drawBody() {
            return this.body;
        }

        public void setDirection(bool direction) {
            this.direction = direction;
        }

        public bool getDirection() {
            return this.direction;
        }

    }
}
