using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SuperSLashWPF.Map;

namespace SuperSLashWPF
{
    class CharacterHandler
    {
        private Character P1;
        private HashSet<Key> keys;
        private Point AppliedForce = new Point(0, 0);
        private enum direction { up, down, right, left };

        private int jumpIteration = 0;
        public CharacterHandler(HashSet<Key> keys)
        {
            P1 = new Character();
            this.keys = keys;
        }

        public Character getP1()
        {
            return P1;
        }

        public void setKeys(HashSet<Key> keys)
        {
            this.keys = keys;
        }

        public async void Handle(MapHandler mapHandler)
        {
            HashSet<Key> tempKeys = new HashSet<Key>();
            tempKeys = this.keys;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                foreach (Key key in tempKeys)
                {
                    switch (key)
                    {
                        case Key.A:
                            this.P1.left(checkCollision(direction.left, mapHandler, this.P1.getSpeed()));
                            break;
                        case Key.D:
                            this.P1.right(checkCollision(direction.right, mapHandler, this.P1.getSpeed()));
                            break;
                        case Key.W:
                            if (this.jumpIteration == -1 && checkOnFloor(mapHandler))
                            {
                                this.P1.jump(calculateJumpModeration());
                            }
                            break;
                        case Key.S:
                            this.P1.down(checkCollision(direction.down, mapHandler, this.P1.getSpeed()));
                            break;

                    }
                }
            }));

            this.P1.down(checkCollision(direction.down, mapHandler, mapHandler.GetMap().getGravitation()));
            if (this.jumpIteration < this.P1.getJumpForce() && this.jumpIteration > -1)
            {
                this.P1.jump(calculateJumpModeration());
                if (this.jumpIteration == this.P1.getJumpForce())
                {
                    this.jumpIteration = -1;
                }
            }

            applyForce(mapHandler);

            this.P1.GetCharacterObjects().updateWeapon();
            this.P1.GetCharacterObjects().updateBelly();
        }

        public void applyForce(MapHandler mapHandler)
        {
            if (this.AppliedForce.X > 0)
            {
                this.P1.right(checkCollision(direction.right, mapHandler, (int) this.AppliedForce.X));
                this.AppliedForce.X -= 2;
            }
            else if (this.AppliedForce.X < 0)
            {
                this.P1.left(-checkCollision(direction.left, mapHandler,(int) this.AppliedForce.X));
                this.AppliedForce.X += 2;
            }
            if (this.AppliedForce.Y > 0)
            {
                this.P1.down(checkCollision(direction.up, mapHandler, (int)this.AppliedForce.Y));
                this.AppliedForce.Y -= 2;
            }
            else if (this.AppliedForce.Y < 0)
            {
                this.P1.up(checkCollision(direction.down, mapHandler,(int) this.AppliedForce.Y));
                this.AppliedForce.Y += 2;
            }
        }

        public void addForce(Point force)
        {
            this.AppliedForce.X += force.X;
            this.AppliedForce.Y += force.Y;
        }

        public int calculateJumpModeration()
        {
            this.jumpIteration++;

            return this.P1.getJumpForce() - this.jumpIteration;
        }

        private int checkCollision(direction direction, MapHandler mapHandler, int speed)
        {
            if (speed == 0)
            {
                return speed;
            }
            switch (direction)
            {
                case direction.left:
                    foreach (Wall wall in mapHandler.GetMap().GetWalls())
                    {
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                if (wall.drawLine().X1 == wall.drawLine().X2 && (wall.drawLine().Y1 - (this.P1.getFat() / 2)) < this.P1.getPosition().Y && this.P1.getPosition().Y < (wall.drawLine().Y2 + (this.P1.getFat() / 2)))
                                {
                                    if (wall.drawLine().X1 < this.P1.getPosition().X && wall.drawLine().X1 > (this.P1.getPosition().X - (this.P1.getFat() / 2) - speed))
                                    {
                                        speed--;
                                        speed = checkCollision(direction, mapHandler, speed);
                                    }
                                }
                            }));
                            if (speed == 0)
                            {
                                return speed;
                            }
                        }
                    }
                    break;
                case direction.right:
                    foreach (Wall wall in mapHandler.GetMap().GetWalls())
                    {
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                if (wall.drawLine().X1 == wall.drawLine().X2 && (wall.drawLine().Y1 - (this.P1.getFat() / 2)) < this.P1.getPosition().Y && this.P1.getPosition().Y < (wall.drawLine().Y2 + (this.P1.getFat() / 2)))
                                {
                                    if (wall.drawLine().X1 > this.P1.getPosition().X && wall.drawLine().X1 < (this.P1.getPosition().X + (this.P1.getFat() / 2) + speed))
                                    {
                                        speed--;
                                        speed = checkCollision(direction, mapHandler, speed);
                                    }
                                }
                            }));
                            if (speed == 0)
                            {
                                return speed;
                            }
                        }
                    }
                    break;
                case direction.up:
                    break;
                case direction.down:
                    foreach (Wall wall in mapHandler.GetMap().GetWalls())
                    {
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                if (this.P1.getPosition().X > (wall.drawLine().X1 - (this.P1.getFat() / 2)) && this.P1.getPosition().X < (wall.drawLine().X2 + (this.P1.getFat() / 2)))
                                {
                                    if (this.P1.getPosition().Y + (this.P1.getFat() / 2) + speed > wall.drawLine().Y1 && this.P1.getPosition().Y - (wall.drawLine().Y1 - (this.P1.getFat() / 2)) < this.P1.getFat())
                                    {
                                        speed--;
                                        speed = checkCollision(direction, mapHandler, speed);
                                    }
                                }
                            }));
                            if (speed == 0)
                            {
                                return speed;
                            }
                        }
                    }
                    break;
            }
            return speed;
        }

        private bool checkOnFloor(MapHandler mapHandler)
        {
            bool onFloor = false;

            foreach (Wall wall in mapHandler.GetMap().GetWalls())
            {
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        if (this.P1.getPosition().X >= wall.drawLine().X1 && this.P1.getPosition().X <= wall.drawLine().X2)
                        {
                            if (wall.drawLine().Y1 == wall.drawLine().Y2)
                            {
                                if (wall.drawLine().Y1 - this.P1.getPosition().Y <= this.P1.getFat() / 2 && wall.drawLine().Y1 - this.P1.getPosition().Y >= -this.P1.getFat() / 2)
                                {
                                    onFloor = true;
                                }
                            }
                        }
                    }));
                    if (onFloor)
                    {
                        return onFloor;
                    }
                }
            }

            return onFloor;
        }

        public void Attack(CharacterHandler CharacterHandler)
        {
            int range = this.P1.GetCharacterObjects().getWeapon().getRange();
            bool direction = this.P1.GetCharacterObjects().getDirection();
            if (direction)
            {
                if (CharacterHandler.getP1().getPosition().X >= this.P1.getPosition().X)
                {
                    if (CalculateDistance(CharacterHandler.getP1()) < range)
                    {
                        CharacterHandler.addForce(new Point(10, -5));
                    }
                }
            }
            else if (!direction)
            {
                if (CharacterHandler.getP1().getPosition().X <= this.P1.getPosition().X)
                {
                    if (CalculateDistance(CharacterHandler.getP1()) < range)
                    {
                        CharacterHandler.addForce(new Point(-10, -5));
                    }
                }
            }
        }

        private double CalculateDistance(Character character)
        {
            int distX = (int)(this.P1.getPosition().X - character.getPosition().X);
            int distY = (int)(this.P1.getPosition().Y - character.getPosition().Y);

            return Math.Sqrt(distX * distX + distY * distY);
        }
    }




}
