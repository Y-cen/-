using _06_坦克大战_正式.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_坦克大战_正式
{
    class MyTank:Movething
    {
        public bool IsMoving { get; set; }
        public MyTank(int x, int y, int speed)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.IsMoving = false;
            this.BitmapUp = Resources.MyTankUp;
            this.BitmapDown = Resources.MyTankDown;
            this.BitmapLeft = Resources.MyTankLeft;
            this.BitmapRight = Resources.MyTankRight;
            this.Dir = Direction.Up;
        }

        public override void Update()
        {
            MoveCheck(); // 移动检查
            Move();
            base.Update();
        }

        private void MoveCheck()
        {
            if (IsMoving == false) return;
            // 检查坦克是否碰撞边界
            if ((Dir == Direction.Up && Y - Speed <= 0) || (Dir == Direction.Down && Y + Speed + Height >= 450))
            {
                IsMoving = false;
                return;
            }
            if ((Dir == Direction.Left && X - Speed <= 0) || (Dir == Direction.Right && X + Speed + Width >= 450))
            {
                IsMoving = false;
                return;
            }
            // 检查坦克是否碰撞其他元素
            Rectangle rectangle = GetRectangle();
            switch (Dir)
            {
                case Direction.Up: rectangle.Y -= Speed; break;
                case Direction.Down: rectangle.Y += Speed; break;
                case Direction.Left: rectangle.X -= Speed; break;
                case Direction.Right: rectangle.X += Speed; break;
            }
            NotMovething wall = GameObjectManager.IsCollidedWithWall(rectangle);
            NotMovething steel = GameObjectManager.IsCollidedWithSteel(rectangle);
            bool isCollidedWithBoss = GameObjectManager.IsCollidedWithBoss(rectangle);
            if (wall != null || steel != null || isCollidedWithBoss)
            {
                IsMoving = false;
                return;
            }
        }

        private void Move()
        {
            if (IsMoving == false) return;

            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }

        public void KeyDown(KeyEventArgs args)
        {
            this.IsMoving = true;
            switch (args.KeyCode)
            {
                case Keys.Up:
                    this.Dir = Direction.Up;
                    break;
                case Keys.Down:
                    this.Dir = Direction.Down;
                    break;
                case Keys.Left:
                    this.Dir = Direction.Left;
                    break;
                case Keys.Right:
                    this.Dir = Direction.Right;
                    break;
            }
        }

        public void KeyUp(KeyEventArgs args)
        {
            this.IsMoving = false;
        }
    }
}
