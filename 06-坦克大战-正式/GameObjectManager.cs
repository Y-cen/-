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
    class GameObjectManager
    {
        private static List<NotMovething> wallList = new List<NotMovething>();
        private static List<NotMovething> steelList = new List<NotMovething>();
        private static NotMovething boss;
        private static MyTank myTank;
        private static List<EnemyTank> enemyTankList = new List<EnemyTank>();

        private static int enemyBornSpeed = 60;
        private static int enemyBornCount = 60;

        private static Point[] points = new Point[3];

        public static void Start()
        {
            points[0].X = 0; points[0].Y = 0;
            points[1].X = 7 * 30; points[1].Y = 0;
            points[2].X = 14 * 30; points[2].Y = 0;
        }

        public static void Update()
        {
            foreach (NotMovething wall in wallList)
            {
                wall.Update();
            }
            foreach (NotMovething steel in steelList)
            {
                steel.Update();
            }
            foreach (EnemyTank enemyTank in enemyTankList)
            {
                enemyTank.Update();
            }

            boss.Update();

            myTank.Update();

            EnemyBorn();
        }

        private static void EnemyBorn()
        {
            ++enemyBornCount;
            if (enemyBornCount < enemyBornSpeed) return;

            // 随机坦克位置 [0, 3)
            Random random = new Random();
            int index = random.Next(0, 3);
            Point position = points[index];
            // 随机坦克类型 [1, 5)
            int enemyTankType = random.Next(1, 5);
            switch (enemyTankType)
            {
                case 1: CreateEnemyTank1(position.X, position.Y); break;
                case 2: CreateEnemyTank2(position.X, position.Y); break;
                case 3: CreateEnemyTank3(position.X, position.Y); break;
                case 4: CreateEnemyTank4(position.X, position.Y); break;
            }
            enemyBornCount = 0;            
        }

        public static NotMovething IsCollidedWithWall(Rectangle rectangle)
        {
            foreach (NotMovething wall in wallList)
            {
                if (rectangle.IntersectsWith(wall.GetRectangle()))
                {
                    return wall;
                }
            }
            return null;
        }

        public static NotMovething IsCollidedWithSteel(Rectangle rectangle)
        {
            foreach (NotMovething steel in steelList)
            {
                if (rectangle.IntersectsWith(steel.GetRectangle()))
                {
                    return steel;
                }
            }
            return null;
        }

        public static bool IsCollidedWithBoss(Rectangle rectangle)
        {
            return rectangle.IntersectsWith(boss.GetRectangle());
        }

        //public static void DrawMap()
        //{
        //    foreach (NotMovething nm in wallList)
        //    {
        //        nm.DrawSelf();
        //    }

        //    foreach (NotMovething nm in steelList)
        //    {
        //        nm.DrawSelf();
        //    }

        //    boss.DrawSelf();
        //}
        //
        //public static void DrawMyTank()
        //{
        //    myTank.DrawSelf();
        //}

        public static void CreateMyTank()
        {
            int xPosition = 5 * 30;
            int yPosition = 14 * 30;

            myTank = new MyTank(xPosition, yPosition, 2);
        }
        public static void CreateEnemyTank1(int x, int y)
        {
            EnemyTank enemyTank = new EnemyTank(x, y, 2, Resources.GrayUp, Resources.GrayDown, Resources.GrayLeft, Resources.GrayRight);
            enemyTankList.Add(enemyTank);
        }
        public static void CreateEnemyTank2(int x, int y)
        {
            EnemyTank enemyTank = new EnemyTank(x, y, 2, Resources.GreenUp, Resources.GreenDown, Resources.GreenLeft, Resources.GreenRight);
            enemyTankList.Add(enemyTank);
        }
        public static void CreateEnemyTank3(int x, int y)
        {
            EnemyTank enemyTank = new EnemyTank(x, y, 4, Resources.QuickUp, Resources.QuickDown, Resources.QuickLeft, Resources.QuickRight);
            enemyTankList.Add(enemyTank);
        }
        public static void CreateEnemyTank4(int x, int y)
        {
            EnemyTank enemyTank = new EnemyTank(x, y, 1, Resources.SlowUp, Resources.SlowDown, Resources.SlowLeft, Resources.SlowRight);
            enemyTankList.Add(enemyTank);
        }
        public static void CreateMap()
        {
            Image wall = Resources.wall;
            Image steel = Resources.steel;
            Image boss = Resources.Boss;

            // Wall
            CreateNotMovething(1, 1, 5, wall, wallList);
            CreateNotMovething(3, 1, 5, wall, wallList);
            CreateNotMovething(5, 1, 4, wall, wallList);
            CreateNotMovething(7, 1, 3, wall, wallList);
            CreateNotMovething(9, 1, 4, wall, wallList);
            CreateNotMovething(11, 1, 5, wall, wallList);
            CreateNotMovething(13, 1, 5, wall, wallList);

            CreateNotMovething(1, 9, 5, wall, wallList);
            CreateNotMovething(3, 9, 5, wall, wallList);
            CreateNotMovething(5, 8, 4, wall, wallList);
            CreateNotMovething(6, 9, 1, wall, wallList);
            CreateNotMovething(7, 8, 4, wall, wallList);
            CreateNotMovething(8, 9, 1, wall, wallList);
            CreateNotMovething(9, 8, 4, wall, wallList);
            CreateNotMovething(11, 9, 5, wall, wallList);
            CreateNotMovething(13, 9, 5, wall, wallList);

            CreateNotMovething(5, 6, 1, wall, wallList);
            CreateNotMovething(9, 6, 1, wall, wallList);
                                            
            CreateNotMovething(2, 7, 1, wall, wallList);
            CreateNotMovething(3, 7, 1, wall, wallList);

            CreateNotMovething(11, 7, 1, wall, wallList);
            CreateNotMovething(12, 7, 1, wall, wallList);
                                             
            CreateNotMovething(6, 13, 2, wall, wallList);
            CreateNotMovething(7, 13, 1, wall, wallList);
            CreateNotMovething(8, 13, 2, wall, wallList);

            // Steel
            CreateNotMovething(7, 4, 1, steel, steelList);
            CreateNotMovething(0, 7, 1, steel, steelList);
            CreateNotMovething(14, 7, 1, steel, steelList);

            // Boss
            CreateBoss(7, 14, 1, boss);
        }

        

        private static void CreateNotMovething(int x, int y, int count, Image itemImg, List<NotMovething> notMovethingList)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;

            for (int i=0; i<count; ++i)
            {
                NotMovething item1 = new NotMovething(xPosition, yPosition, itemImg);
                NotMovething item2 = new NotMovething(xPosition+15, yPosition, itemImg);
                NotMovething item3 = new NotMovething(xPosition, yPosition+15, itemImg);
                NotMovething item4 = new NotMovething(xPosition+15, yPosition+15, itemImg);

                notMovethingList.Add(item1);
                notMovethingList.Add(item2);
                notMovethingList.Add(item3);
                notMovethingList.Add(item4);

                yPosition += 30;
            }
        }

        private static void CreateBoss(int x, int y, int count, Image itemImg)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;

            boss = new NotMovething(xPosition, yPosition, itemImg);
        }

        public static void KeyDown(KeyEventArgs args)
        {
            myTank.KeyDown(args);
        }

        public static void KeyUp(KeyEventArgs args)
        {
            myTank.KeyUp(args);
        }
    }
}
