using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace GaussianAlhorithm_New
{
    public class Program
    {
        //public static List<double[][]> Matrixes;
        //public static List<double[]> FreeMemberses;


        public static void Main()
        {
            //var (matrix, freeMembers) = Data.GetMatrixRandom(8);
            //var time = SolveUseTask(matrix, freeMembers);
            //Console.WriteLine(time);

            //CreateData();
            //Matrixes = 


            //var parallels = Solves(SolveUseParallel);
            //Console.WriteLine(String.Join(" ", parallels));
            //Console.WriteLine();

            //var threads = Solves(SolveUseThreads);
            //Console.WriteLine(String.Join(" ", threads));
            //Console.WriteLine();

            var tasks = Solves(SolveUseTask);
            Console.WriteLine(String.Join(" ", tasks));
            Console.WriteLine();

            //var times = Solves(SolveUseNoThread);
            //Console.WriteLine(String.Join(" ", times));
            //Console.WriteLine();

            //Console.WriteLine(String.Join(" ", parallels));
            //Console.WriteLine();

            //Console.WriteLine(String.Join(" ", threads));
            //Console.WriteLine();

            //Console.WriteLine(String.Join(" ", tasks));
            //Console.WriteLine();

            //Console.WriteLine(String.Join(" ", times));
            //Console.WriteLine();


            using (StreamWriter writer = new StreamWriter("Data", false))
            {
                for (int i = 0; i < 48; i++)
                {
                    writer.WriteLine($"{tasks[i]}");
                }
            }
            
        }

        public static void CreateData()
        {
            //var rnd = new Random();
            //var (matrix, freeMembers) = Data.GetMatrixRandom();

            using (StreamWriter writer = new StreamWriter("Data.txt", false))
            {
                for (int i = 2; i < 50; i++)
                {
                    var (matrix, freeMembers) = Data.GetMatrixRandom(i);

                    for (int j = 0; j < matrix.Length; j++)
                    {
                        writer.WriteLine(String.Join(' ', matrix[j]));
                    }
                    writer.WriteLine();
                }
            }


            //for (int i = 2; i < 50; i++)
            //{
            //    var (matrix, freeMembers) = Data.GetMatrixRandom(i);
            //    Matrixes.Add(matrix);
            //    FreeMemberses.Add(freeMembers);
            //}
        }

        //public static void ReadData()
        //{
        //    Matrixes = new List<double[][]>();
        //    FreeMemberses = new List<double[]>();

        //    using (var reader = new StreamReader("Data.txt"))
        //    {
        //        for (int i = 0; i < reader.)
        //    }

        //}

        public static List<long> Solves(Func<double[][], double[], long> solve)
        {
            var lstTimes = new List<long>();

            for (int i = 2; i < 50; i++)
            {
                var (matrix, freeMembers) = Data.GetMatrixRandom(i);
                //long time = solve(matrix, freeMembers);
                long time = solve(matrix, freeMembers);
                lstTimes.Add(time);
            }

            return lstTimes;
        }

        public static long SolveUseThreads(double[][] matrix, double[] freeMembers)
        {
            var a = new LearningUseThread.GaussianAlgorithmThreads
                (matrix, freeMembers);

            Stopwatch st = new Stopwatch();

            st.Start();
            a.Solve();
            st.Stop();

            return st.ElapsedTicks;
        }

        public static long SolveUseTask(double[][] matrix, double[] freeMembers)
        {
            var a = new LearningUseTask.GaussianAlgorithmTasks(matrix, freeMembers);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            a.Solve();
            sw.Stop();

            return sw.ElapsedTicks;
        }

        public static long SolveUseParallel(double[][] matrix, double[] freeMembers)
        {
            var a = new LearningUseParallel.GaussianAlgorithmParallels(matrix, freeMembers);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            a.Solve();
            sw.Stop();

            return sw.ElapsedTicks;
        }

        public static long SolveUseNoThread(double[][] matrix, double[] freeMembers)
        {
            var a = new NoThread.GaussianAlgorithmNoThreads(matrix, freeMembers);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            a.Solve();
            sw.Stop();

            //Print(matrix, freeMembers);

            return sw.ElapsedTicks;
        }

        public static void Print(double[][] matrix, double[] freeMembers)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(String.Join("\t", matrix[i]) + $"\t\t{freeMembers[i]}");
            }
            Console.WriteLine();
        }

    }
}



//var time01 = SolveUseThreads(Data.Matrix2x2, Data.FreeMembers2x);
////Console.WriteLine("Time: " + time0);


//Console.WriteLine("--------------");
//var time1 = SolveUseThreads(Data.Matrix2x2, Data.FreeMembers2x);
//Console.WriteLine("Time: " + time1);
////Print(Data.Matrix2x2, Data.FreeMembers2x);
//Console.WriteLine("--------------");

//Console.WriteLine("--------------");
//var time2 = SolveUseThreads(Data.Matrix3x3, Data.FreeMembers3x);
//Console.WriteLine("Time: " + time2);
////Print(Data.Matrix3x3, Data.FreeMembers3x);
//Console.WriteLine("--------------");

//Console.WriteLine("--------------");
//var time3 = SolveUseThreads(Data.Matrix4x4, Data.FreeMembers4x);
//Console.WriteLine("Time: " + time3);
////Print(Data.Matrix4x4, Data.FreeMembers4x);
//Console.WriteLine("--------------");

//Console.WriteLine("--------------");
//var time4 = SolveUseThreads(Data.Matrix5x5, Data.FreeMembers5x);
//Console.WriteLine("Time: " + time4);
////Print(Data.Matrix5x5, Data.FreeMembers5x);
//Console.WriteLine("--------------");

//Console.WriteLine("--------------");
//var time5 = SolveUseThreads(Data.Matrix6x6, Data.FreeMembers6x);
//Console.WriteLine("Time: " + time5);
////Print(Data.Matrix6x6, Data.FreeMembers6x);
//Console.WriteLine("--------------");

//Console.WriteLine("--------------");
//var time6 = SolveUseThreads(Data.Matrix8x8, Data.FreeMembers8x);
//Console.WriteLine("Time: " + time6);
////Print(Data.Matrix8x8, Data.FreeMembers8x);
//Console.WriteLine("--------------");

//Console.WriteLine("--------------");
//var time7 = SolveUseThreads(Data.Matrix12x12, Data.FreeMembers12x);
//Console.WriteLine("Time: " + time7);
////Print(Data.Matrix12x12, Data.FreeMembers12x);
//Console.WriteLine("--------------");

/////////////////////////////////////////Console.WriteLine();

//var time110 = SolveUseTask(Data.Matrix2x2, Data.FreeMembers2x);
////Console.WriteLine("Time: " + time01);

//var time10 = SolveUseTask(Data.Matrix2x2, Data.FreeMembers2x);
//Console.WriteLine("Time: " + time10);

//var time11 = SolveUseTask(Data.Matrix3x3, Data.FreeMembers3x);
//Console.WriteLine("Time: " + time11);

//var time12 = SolveUseTask(Data.Matrix4x4, Data.FreeMembers4x);
//Console.WriteLine("Time: " + time12);
//Print(Data.Matrix4x4, Data.FreeMembers4x);
//Console.WriteLine("--------------");

//var time13 = SolveUseTask(Data.Matrix5x5, Data.FreeMembers5x);
//Console.WriteLine("Time: " + time13);

//var time14 = SolveUseTask(Data.Matrix6x6, Data.FreeMembers6x);
//Console.WriteLine("Time: " + time14);

//var time15 = SolveUseTask(Data.Matrix8x8, Data.FreeMembers8x);
//Console.WriteLine("Time: " + time15);

//var time16 = SolveUseTask(Data.Matrix12x12, Data.FreeMembers12x);
//Console.WriteLine("Time: " + time16);
//Console.WriteLine();

//var time210 = SolveUseParallel(Data.Matrix2x2, Data.FreeMembers2x);
////Console.WriteLine("Time: " + time210);

//var time21 = SolveUseParallel(Data.Matrix2x2, Data.FreeMembers2x);
//Console.WriteLine("Time: " + time21);

//var time22 = SolveUseParallel(Data.Matrix3x3, Data.FreeMembers3x);
//Console.WriteLine("Time: " + time22);

//var time23 = SolveUseParallel(Data.Matrix4x4, Data.FreeMembers4x);
//Console.WriteLine("Time: " + time23);

//var time24 = SolveUseParallel(Data.Matrix5x5, Data.FreeMembers5x);
//Console.WriteLine("Time: " + time24);

//var time25 = SolveUseParallel(Data.Matrix6x6, Data.FreeMembers6x);
//Console.WriteLine("Time: " + time25);

//var time26 = SolveUseParallel(Data.Matrix8x8, Data.FreeMembers8x);
//Console.WriteLine("Time: " + time26);

//var time27 = SolveUseParallel(Data.Matrix12x12, Data.FreeMembers12x);
//Console.WriteLine("Time: " + time27);
//Print(Data.Matrix12x12, Data.FreeMembers12x);


//var time300 = SolveUseNoThread(Data.Matrix2x2, Data.FreeMembers2x);
////Console.WriteLine("Time: " + time30);

//var time30 = SolveUseNoThread(Data.Matrix2x2, Data.FreeMembers2x);
//Console.WriteLine("Time: " + time30);

//var time31 = SolveUseNoThread(Data.Matrix3x3, Data.FreeMembers3x);
//Console.WriteLine("Time: " + time31);

//var time32 = SolveUseNoThread(Data.Matrix4x4, Data.FreeMembers4x);
//Console.WriteLine("Time: " + time32);

//var time33 = SolveUseNoThread(Data.Matrix5x5, Data.FreeMembers5x);
//Console.WriteLine("Time: " + time33);

//var time34 = SolveUseNoThread(Data.Matrix6x6, Data.FreeMembers6x);
//Console.WriteLine("Time: " + time34);

//var time35 = SolveUseNoThread(Data.Matrix8x8, Data.FreeMembers8x);
//Console.WriteLine("Time: " + time35);

//var time36 = SolveUseNoThread(Data.Matrix12x12, Data.FreeMembers12x);
//Console.WriteLine("Time: " + time36);



//Print(Data.Matrix6x6, Data.FreeMembers6x);
//var time21 = SolveUseParallel(Data.Matrix6x6, Data.FreeMembers6x);
//Console.WriteLine("Time: " + time21);
//Print(Data.Matrix6x6, Data.FreeMembers6x);


//var (matrix, freeMembers) = Data.GetMatrixRandom(2);
//var time = SolveUseParallel(matrix, freeMembers);
//Console.WriteLine(timeTest);

//var (matrix, freeMembers) = Data.GetMatrixRandom(2);
//var time = SolveUseNoThread(matrix, freeMembers);
//Console.WriteLine(time);

//(matrix, freeMembers) = Data.GetMatrixRandom(3);
//time = SolveUseParallel(matrix, freeMembers);
//Console.WriteLine(time);

//(matrix, freeMembers) = Data.GetMatrixRandom(4);
//time = SolveUseParallel(matrix, freeMembers);
//Console.WriteLine(time);

//(matrix, freeMembers) = Data.GetMatrixRandom(5);
//time = SolveUseParallel(matrix, freeMembers);
//Console.WriteLine(time);



//var parallels = Solves(SolveUseParallel);

//var threads = Solves(SolveUseThreads);

//var tasks = Solves(SolveUseTask);

//var times = Solves(SolveUseNoThread);


//Console.WriteLine(String.Join(" ", parallels));
//Console.WriteLine();
//Console.WriteLine(String.Join(" ", threads));

//Console.WriteLine(String.Join(" ", tasks));

//Console.WriteLine(String.Join(" ", times));