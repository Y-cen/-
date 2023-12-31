using _06_坦克大战_正式.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_坦克大战_正式
{
    enum Direction
    {
        Up, Down, Left, Right
    }
    class Movething:GameObject
    {
        public Bitmap BitmapUp { get; set; }
        public Bitmap BitmapDown { get; set; }
        public Bitmap BitmapLeft { get; set; }
        public Bitmap BitmapRight { get; set; }

        public int Speed { get; set; }

        public Direction Dir { get; set; }

        protected override Image GetImage()
        {
            Bitmap bitmap = null;
            switch (Dir)
            {
                case Direction.Up:
                    bitmap = BitmapUp;
                    break;
                case Direction.Down:
                    bitmap = BitmapDown;
                    break;
                case Direction.Left:
                    bitmap = BitmapLeft;
                    break;
                case Direction.Right:
                    bitmap = BitmapRight;
                    break;
            }
            bitmap.MakeTransparent(Color.Black);
            Width = bitmap.Width;
            Height = bitmap.Height;
            return bitmap;
        }
    }
}
