using System;

namespace ConsoleApplication1
{
    class Program
    {
        public static int x = 0;
        public static int y = 0;
        public static int[,] matris = new int[5, 5];
        public static int[,] matris_engel = new int[5, 5];

        static void Main(string[] args)
        {
            // X
            setTargetPoint(4, 0);

            // Reset Matris
            refleshMatris();
            //Walls
            addRock(1, 1);
            addRock(4, 1);
            addRock(2,3);
            addRock(3, 3);


            lookAll(x, y); 


            int[,] matris_control = new int[5, 5]; 
            int y1 = 0, y2=0, x1 = 0,x2 = 0;

            //int count = 0;
            for (int k = 1; k <= 6; k++)
             {
                y1 = y - k;
                y2 = y + k;
                if (y - k < 0) { y1 = 0; }
                if (y + k > 4) { y2 = 4; }

                x1 = x - k;
                x2 = x + k;
                if (x - k < 0) { x1 = 0; }
                if (x + k > 4) { x2 = 4; }
                
                for (int i = y1; i <= y2; i++)
                 {
                     for (int j = x1; j <= x2; j++)
                     {
                        //count++;
                        //if (matris_control[i, j] == 1) continue;
                        if (i == y && j == x) continue;
                        //matris_control[i, j] = 1;
                        lookAll( i, j );
                     }
                 }
             }
            //Console.WriteLine(count);
            //Matrix path validation.
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == y && j == x) continue;
                    if (findPath(j, i) == 1)
                    {
                        setPath(j, i);
                    }else if(findPath(j,i) == 0)
                    {
                        matris[i,j] = 0;
                    }
                }
               
            }
           
            write();

            Console.ReadLine();
        }
        public static void write()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == y && j == x)
                        Console.Write("X" + " ");

                    else if (matris_engel[i, j] == 1)
                        Console.Write("■" + " ");

                    else
                        Console.Write(matris[i, j].ToString() + " ");

                }
                Console.WriteLine();
            }
        }
        // Path Count
        private static int path = 0;
        
        private static int findPath(int k_x, int k_y)
        {
            path = 0;
            if (matris_engel[k_y, k_x] == 0)
            {
                //sola
                if (k_x - 1 >= 0 && matris_engel[k_y, k_x - 1] == 0)
                {
                    path++;
                }//saga
                if (k_x + 1 <= 4 && matris_engel[k_y, k_x + 1] == 0)
                {
                    path++;
                }//yukarı
                if (k_y - 1 >= 0 && matris_engel[k_y - 1, k_x] == 0)
                {
                    path++;
                }//asagı
                if (k_y + 1 <= 4 && matris_engel[k_y + 1, k_x] == 0)
                {
                    path++;
                }

            }
            return path;
        }
        private static void setPath(int k_x, int k_y)
        {
            //sola
            if (k_x - 1 >= 0 && matris_engel[k_y, k_x - 1] == 0)
            {
                matris[k_y, k_x] = matris[k_y, k_x - 1] + 1;
            }//saga
            if (k_x + 1 <= 4 && matris_engel[k_y, k_x + 1] == 0)
            {
                matris[k_y, k_x] = matris[k_y, k_x + 1] + 1;
            }//yukarı
            if (k_y - 1 >= 0 && matris_engel[k_y - 1, k_x] == 0)
            {
                matris[k_y, k_x] = matris[k_y - 1, k_x] + 1;
            }//asagı
            if (k_y + 1 <= 4 && matris_engel[k_y + 1, k_x] == 0)
            {
                matris[k_y, k_x] = matris[k_y + 1, k_x] + 1;
            }

        }

        private static void setTargetPoint(int t_x, int t_y)
        {
            x = t_x;
            y = t_y;
        }
        
        private static int value;

        private static void lookAll(int x_c, int y_c)
        {
           if (x_c < 0 || x_c > 4 || y_c < 0 || y_c > 4)
                return;

            if (matris_engel[y_c, x_c] == 1)
                return;

            lookLeft(x_c, y_c);
            lookRight(x_c, y_c);
            lookUp(x_c, y_c);
            lookDown(x_c, y_c);
            
            lookLeftUp(x_c, y_c);
            lookLeftDown(x_c, y_c);
            lookRightDown(x_c, y_c);
            lookRightUp(x_c, y_c);
        }
      
        public static void lookLeft(int x_c, int y_c )
        {
            value = matris[y_c, x_c];
            for (int i = 1; i < 4; i++)
            {
                if ( x_c  - i >= 0 && x_c - i <= 4 )
                    if ( matris_engel[y_c, x_c - i] != 1 )
                    {
                        if ( value + i < matris[y_c, x_c - i]  )
                                matris[y_c, x_c - i] = value + i;
                     } else
                        break;
            }
        }
        public static void lookRight(int x_c, int y_c)
        {
            value = matris[y_c, x_c];
            for (int i = 1; i < 4; i++)
            {
                if (x_c + i >= 0 && x_c + i <= 4)
                    if (matris_engel[y_c, x_c + i] != 1)
                    { 
                        if (value + i < matris[y_c, x_c + i])
                            matris[y_c, x_c + i] = value + i;
                    }
                    else
                        break;
            }
        }
        public static void lookUp(int x_c, int y_c)
        {
            value = matris[y_c, x_c];
            for (int i = 1; i < 4; i++)
            {
                if (y_c - i >= 0 && y_c - i <= 4)
                    if (matris_engel[y_c - i, x_c] != 1)
                    { 
                        if (value + i < matris[y_c - i, x_c])
                            matris[ y_c - i, x_c] = value + i;
                    }
                    else
                        break;
            }
        }

        public static void lookDown(int x_c, int y_c)
        {
            value = matris[y_c, x_c];
            for (int i = 1; i < 4; i++)
            {
                if (y_c + i >= 0 && y_c + i <= 4)
                    if (matris_engel[y_c + i, x_c] != 1)
                    { 
                        if (value + i < matris[y_c + i, x_c])
                            matris[y_c + i, x_c] = value + i;
                    }
                    else
                        break;
            }
        }
        private static int two = 2;
        public static void lookLeftUp(int x_c, int y_c)
        {
            two = 0;
            value = matris[y_c, x_c];
            for (int i = 1; i < 5; i++)
            {
                two += 2;
                if (x_c - i >= 0 && x_c - i <= 4 && y_c - i >= 0 && y_c - i <= 4) //x-i, y-i icin kontrol.
                    if (matris_engel[y_c - i, x_c - i] != 1)
                    {
                        if (value + i < matris[y_c - i, x_c - i])
                            matris[y_c - i, x_c - i] = value + two;
                    } else
                        break;

            }
        }
        public static void lookLeftDown(int x_c, int y_c)
        {
            two = 0;
            value = matris[y_c, x_c];
            for (int i = 1; i < 5; i++)
            {
                two += 2;
                if (x_c - i >= 0 && x_c - i <= 4 && y_c + i >= 0 && y_c + i <= 4) //x-i, y-i icin kontrol.
                    if (matris_engel[y_c + i, x_c - i] != 1)
                    { 
                        if (value + i < matris[y_c + i, x_c - i])
                            matris[y_c + i, x_c - i] = value + two;
                    }
                    else
                        break;
            }
        }
        public static void lookRightDown(int x_c, int y_c)
        {
            two = 0;
            value = matris[y_c, x_c];
            for (int i = 1; i < 5; i++)
            {
                two += 2;
                if (x_c + i >= 0 && x_c + i <= 4 && y_c + i >= 0 && y_c + i <= 4) //x-i, y-i icin kontrol.
                    if (matris_engel[y_c + i, x_c + i] != 1) { 
                        if (value + i < matris[y_c + i, x_c + i])
                            matris[y_c + i, x_c + i] = value + two;
                    }
                    else
                        break;
            }
        }
        public static void lookRightUp(int x_c, int y_c)
        {
            two = 0;
            value = matris[y_c, x_c];
            for (int i = 1; i < 5; i++)
            {
                two += 2;
                if (x_c + i >= 0 && x_c + i <= 4 && y_c - i >= 0 && y_c - i <= 4) //x-i, y-i icin kontrol.
                    if (matris_engel[y_c - i, x_c + i] != 1) { 
                        if (value + i < matris[y_c - i, x_c + i])
                            matris[y_c - i, x_c + i] = value + two;
                    }
                    else
                        break;
            }
        }
       public static void addRock(int x_e, int y_e)
       {
            matris_engel[y_e, x_e] = 1;
       }

       public static void refleshMatris()
       {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matris[i, j] = 20; //max value
                    matris_engel[i, j] = 0;
                }
               
            }
            matris[y, x] = 0;
        }
    }
}
