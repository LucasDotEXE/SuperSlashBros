using System;

namespace SuperSLashWPF
{
    class Stats
    {
        private double speed;
        private double fat;
        private double jumpForce;

        public Stats(int speed, int fat, int jumpForce)
        {
            this.speed = speed;
            this.fat = fat;
            this.jumpForce = jumpForce;
        }

        public Stats(bool random, int max)
        {
            if (random)
            {
                Random rnd = new Random();
                this.speed = rnd.Next(1, max);
                this.fat = rnd.Next(1, max);
                this.jumpForce = rnd.Next(15, max);
            }
            else
            {
                this.speed = 10;
                this.fat = 50;
                this.jumpForce = 20;
            }
        }

        public int getFat()
        {
            return (int)this.fat;
        }
        public int getSpeed()
        {
            return (int)this.speed;
        }
        public int getJumpForce()
        {
            return (int)this.jumpForce;
        }

        public void leverlUp() {
            this.speed+=0.05;
            this.fat -= 0.05;
            this.jumpForce += 0.01;
        }
    }
}
