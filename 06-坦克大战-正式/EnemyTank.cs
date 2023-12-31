using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_坦克大战_正式
{
    class EnemyTank:Movething
    {
        private Random random = new Random();

        public EnemyTank(int x, int y, int speed, Bitmap bitmapUp, Bitmap bitmapDown, Bitmap bitmapLeft, Bitmap bitmapRight)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.BitmapUp = bitmapUp;
            this.BitmapDown = bitmapDown;
            this.BitmapLeft = bitmapLeft;
            this.BitmapRight = bitmapRight;
            this.Dir = Direction.Down;
        }

        public override void Update()
        {
            MoveCheck(); // 移动检查
            Move();
            base.Update();
        }

        private void MoveCheck()
        {
            // 检查坦克是否碰撞边界
            if ((Dir == Direction.Up && Y - Speed <= 0) || (Dir == Direction.Down && Y + Speed + Height >= 450))
            {
                ChangeDirection();
                return;
            }
            if ((Dir == Direction.Left && X - Speed <= 0) || (Dir == Direction.Right && X + Speed + Width >= 450))
            {
                ChangeDirection();
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
                ChangeDirection();
                return;
            }
        }

        private void ChangeDirection()
        {
            while(true)
            {
                Direction dir = (Direction)random.Next(0, 4);
                if (dir != Dir)
                {
                    Dir = dir;
                    break;
                }
            }
            MoveCheck();
        }

        private void Move()
        {
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
    }
}
