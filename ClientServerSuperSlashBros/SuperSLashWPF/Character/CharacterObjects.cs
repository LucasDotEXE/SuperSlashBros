using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Shapes;

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
        public CharacterObjects(Point position)
        {
            this.position = position;
            this.body = new Body();
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

        public List<Line> drawWeapon()
        {

            switch (this.currenWeapon)
            {
                case eweapon.sword:
                    Console.WriteLine("sword");
                    return weapon.getSword(position, direction);
                    break;
                case eweapon.axe:
                    Console.WriteLine("axe");
                    break;
            }

            return null; ;
        }

        public Body getBody()
        {
            return this.body;
        }

        public Weapon getWeapon()
        {
            return this.weapon;
        }

        public void setDirection(bool direction) {
            this.direction = direction;
        }

    }
}
