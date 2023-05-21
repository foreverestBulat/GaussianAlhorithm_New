using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianAlhorithm_New
{
    public static class Data
    {
        public static (double[][], double[]) GetMatrixRandom(int size)
        {
            double[][] matrix = new double[size][];
            var rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                matrix[i] = new double[size];
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = rnd.Next(-100, 100);
                }
            }

            return (matrix, new double[size]);
        }





        public static double[][] Matrix2x2 = new double[][]
        {
            new double[] { 1, -1 },
            new double[] { 2, 1 },
        };
        public static double[] FreeMembers2x = new double[] { -5, -7 };


        public static double[][] Matrix3x3 = new double[][]
        {
            new double[] {3, 2, -5 },
            new double[] { 2, -1, 3 },
            new double[] { 1, 2, -1 }
        };
        public static double[] FreeMembers3x = new double[] { -1, 13, 9 };


        public static double[][] Matrix4x4 = new double[][]
        {
            new double[] { 1, 1, 2, 3 },
            new double[] { 1, 2, 3, -1 },
            new double[] { 3, -1, -1, -2 },
            new double[] { 2, 3, -1, -1 },
        };
        public static double[] FreeMembers4x = new double[] { 1, -4, -4, -6 };

        //x + 2y + z - w + t = 8
        //2x + y - z + 3w + 2t = -2
        //3x + 2y + 2z + 5w - t = 10
        //4x + y + z - 2w + 3t = -5
        //x - y - z + w + 4t = 6

        public static double[][] Matrix5x5 = new double[][]
        {
            new double[] { 1, 2, 1, -1, 1 },
            new double[] { 2, 1, -1, 3, 2 },
            new double[] { 3, 2, 2, 5, -1 },
            new double[] { 4, 1, 1, -2, 3 },
            new double[] { 1, -1, -1, 1, 4 }
        };
        public static double[] FreeMembers5x = new double[] { 8, -2, 10, -5, 6 };

        //1. 2x1 + 3x2 - x3 + 4x4 + 5x5 - 6x6 = 12
        //2. 3x1 - 2x2 + 5x3 - 6x4 + 2x5 - 7x6 = -8
        //3. 4x1 + 5x2 - 3x3 + 2x4 - x5 + 8x6 = 17
        //4. x1 + 2x2 + 4x3 - 5x4 + 6x5 - 3x6 = 5
        //5. -2x1 + x2 - 3x3 + 5x4 + 4x5 - 2x6 = 10
        //6. 6x1 - 4x2 + 2x3 + x4 - 3x5 + 5x6 = 24

        public static double[][] Matrix6x6 = new double[][]
        {
            new double[] { 2, 3, -1, 4, 5, -6 },
            new double[] {3, -2, 5, -6, 2, -7 },
            new double[] {4, 5, -3, 2, -1, 8 },
            new double[] { 1, 2, 4, -5, 6, -3 },
            new double[] { -2, 1, -3, 5, 4, -2 },
            new double[] { 6, -4, 2, 1, -3, 5 },
        };
        public static double[] FreeMembers6x = new double[] { 12, -8, 17, 5, 10, 24 };

        //[ 1  2 -3  4  5 -6  7 -8 | 10 ]
        //[ 2 -4  6 -8 10 -12 14 -16 | 20 ]
        //[ 3  6 -9 12 -15 18 -21 24 | 30 ]
        //[ 4 -8 12 -16 20 -24 28 -32 | 40 ]
        //[ 5 10 -15 20 -25 30 -35 40 | 50 ]
        //[ 6 -12 18 -24 30 -36 42 -48 | 60 ]
        //[ 7 14 -21 28 -35 42 -49 56 | 70 ]
        //[ 8 -16 24 -32 40 -48 56 -64 | 80 ]

        //public static double[][] Matrix8x8 = new double[][]
        //{
        //    new double[] { 1, 2, -3, 4, 5, -6, 7, -8 },
        //    new double[] { 2, -4,  6, -8, 10, -12, 14, -16},
        //    new double[] { 3,  6, -9, 12, -15, 18, - 21, 24 },
        //    new double[] { 4, -8, 12, -16, 20, -24, 28, -32 },
        //    new double[] { 5, 10, -15, 20, -25, 30, -35, 40 },
        //    new double[] { 6, -12, 18, -24, 30, -36, 42, -48 },
        //    new double[] { 7, 14, -21, 28, -35, 42, -49, 56 },
        //    new double[] { 8, -16, 24, -32, 40, -48, 56, -64 }
        //};
        //public static double[] FreeMembers8x = new double[] { 10, 20, 30, 40, 50, 60, 70, 80 };

        public static double[][] Matrix8x8 = new double[][]
        {
            new double[] { 1, 2, 3 ,4 ,5 ,6 ,7 ,8 },
            new double[] { 2 ,3 ,4 ,5 ,6 ,7 ,8 ,1 },
            new double[] { 3, 4, 5, 6, 7, 8, 1, 2 },
            new double[] { 4, 5, 6, 7, 8, 1, 2, 3 },
            new double[] { 5, 6, 7, 8, 1, 2, 3, 4 },
            new double[] { 6 ,7 ,8 ,1, 2, 3, 4, 5 },
            new double[] { 7 ,8 ,1, 2, 3 ,4 ,5 ,6 },
            new double[] { 8, 1, 2, 3, 4, 5, 6, 7 },
        };
        public static double[] FreeMembers8x = new double[] { 10, 12, 14, 16, 18, 20, 22, 24 };


        //x1 + 2x2 + 3x3 + 4x4 + 5x5 + 6x6 + 7x7 + 8x8 = 10
        //2x1 + 3x2 + 4x3 + 5x4 + 6x5 + 7x6 + 8x7 + x8 = 12
        //3x1 + 4x2 + 5x3 + 6x4 + 7x5 + 8x6 + x7 + 2x8 = 14
        //4x1 + 5x2 + 6x3 + 7x4 + 8x5 + x6 + 2x7 + 3x8 = 16
        //5x1 + 6x2 + 7x3 + 8x4 + x5 + 2x6 + 3x7 + 4x8 = 18
        //6x1 + 7x2 + 8x3 + x4 + 2x5 + 3x6 + 4x7 + 5x8 = 20
        //7x1 + 8x2 + x3 + 2x4 + 3x5 + 4x6 + 5x7 + 6x8 = 22
        //8x1 + x2 + 2x3 + 3x4 + 4x5 + 5x6 + 6x7 + 7x8 = 24



        //[ 1   2   3   4   5   6   7   8   9   10  11  12 | 10 ]
        //[ 2   3   4   5   6   7   8   9   10  11  12  1  | 11 ]
        //[ 3   4   5   6   7   8   9   10  11  12  1   2  | 12 ]
        //[ 4   5   6   7   8   9   10  11  12  1   2   3  | 13 ]
        //[ 5   6   7   8   9   10  11  12  1   2   3   4  | 14 ]
        //[ 6   7   8   9   10  11  12  1   2   3   4   5  | 15 ]
        //[ 7   8   9   10  11  12  1   2   3   4   5   6  | 16 ]
        //[ 8   9   10  11  12  1   2   3   4   5   6   7  | 17 ]
        //[ 9   10  11  12  1   2   3   4   5   6   7   8  | 18 ]
        //[ 10  11  12  1   2   3   4   5   6   7   8   9  | 19 ]
        //[ 11  12  1   2   3   4   5   6   7   8   9   10 | 20 ]
        //[ 12  1   2   3   4   5   6   7   8   9   10  11 | 21 ]

        public static double[][] Matrix12x12 = new double[][]
        {
            new double[] { 1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12 },
            new double[] { 2,   3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  1 },
            new double[] { 3,   4,   5,   6,   7,   8,   9,   10,  11,  12,  1,   2, },
            new double[] { 4,   5,   6,   7,   8,   9,   10,  11,  12,  1,   2,   3, },
            new double[] { 5,   6,   7,   8,   9,   10,  11,  12,  1,   2,   3,   4, },
            new double[] { 6,   7,   8,   9,   10,  11,  12,  1,   2,   3,   4,   5, },
            new double[] { 7,   8,   9,   10,  11,  12,  1,   2,   3,   4,   5,   6, },
            new double[] { 8,   9,   10,  11,  12,  1,   2,   3,   4,   5,   6,   7, },
            new double[] { 9,   10,  11,  12,  1,   2,   3,   4,   5,   6,   7,   8, },
            new double[] { 10,  11,  12,  1,   2,   3,   4,   5,   6,   7,   8,   9, },
            new double[] { 11,  12,  1,   2,   3,   4,   5,   6,   7,   8,   9,   10, },
            new double[] { 12,  1,   2,   3,   4,   5,   6,   7,   8,   9,   10,  11, },
        };
        public static double[] FreeMembers12x = new double[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 }; 



    }
}
