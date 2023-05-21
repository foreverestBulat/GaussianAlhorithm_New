using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianAlhorithm_New
{
    public class LearningUseTask
    {
        public static readonly int MaxThread = 4; // 1 2 4 6
        public static int Step = 0;

        public static double[] FreeMembers4x = new double[] { 1, -4, -4, -6 };

        public class GaussianAlgorithmTasks
        {
            public double[][] Matrix { get; private set; }
            public double[] FreeMembers { get; private set; }

            public GaussianAlgorithmTasks(double[][] matrix, double[] freeMembers)
            {
                Matrix = matrix;
                FreeMembers = freeMembers;
            }

            public void Solve()
            {
                for (int i = 0; i < Matrix.Length; i++)
                {
                    GetStepMatrix(i);
                }

                for (int i = Matrix.Length - 1; i >= 0; i--)
                {
                    GetUnitMatrixNew(i);
                }

                //for (int i = 0; i < Matrix.Length; i++)
                //{
                //    Console.WriteLine(String.Join("\t", Matrix[i]));
                //}
            }


            private void GetStepMatrix(int lineAndColumnNumber)
            {
                List<int>[] linesInTask = GetLinesInTaskForGetStepMatrix(lineAndColumnNumber);

                var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

                //var count = Matrix.Length - 1 < MaxThread ? Matrix.Length - 1: MaxThread;

                Task[] tasks = new Task[MaxThread];

                //Step = lineAndColumnNumber + 1;
                Step = 0;

                for (int i = 0; i < MaxThread; i++)
                {
                    tasks[i] = new Task(() => UseAnyMethodCount(m, num, lineAndColumnNumber, linesInTask[Step++]));
                    tasks[i].Start();
                }

                Task.WaitAll(tasks);
            }

            private List<int>[] GetLinesInTaskForGetStepMatrix(int lineAndColumnNumber)
            {
                List<int>[] linesInTask = new List<int>[MaxThread];

                int countLine = Matrix.Length - lineAndColumnNumber - 1;
                int k = 1;

                while (countLine > MaxThread * k)
                    k++;

                int j = lineAndColumnNumber + 1;
                for (int i = 0; i < MaxThread; i++)
                {
                    if (countLine > k)
                    {
                        linesInTask[i] = new List<int>();
                        for (int p = j; p < j + k; p++)
                        {
                            linesInTask[i].Add(p);
                        }
                        j += k;
                        countLine -= k;
                    }
                    else
                    {
                        linesInTask[i] = new List<int>();
                        for (int p = j; p < j + countLine; p++)
                        {
                            linesInTask[i].Add(p);
                        }
                        break;
                    }
                }

                return linesInTask;
            }

            private void UseAnyMethodCount(double[] m, double num, int lineAndColumnNumber, List<int> lines)
            {
                if (lines == null) return;

                for (int i = 0; i < lines.Count; i++)
                {
                    var t = Matrix[lines[i]][lineAndColumnNumber];
                    var x = num * t * (-1);
                    var n = m.Select(p => p * x);
                    Matrix[lines[i]] = Matrix[lines[i]].Zip(n, (a, b) => a + b).ToArray();
                    FreeMembers[lines[i]] += FreeMembers[lineAndColumnNumber] * x;
                }
            }

            private void GetUnitMatrixNew(int lineAndColumnNumber)
            {
                if (lineAndColumnNumber == 0) return;

                var linesInThread = GetLinesInTaskForGetUnitMatrix(lineAndColumnNumber - 1);
                
                var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

                //var count = lineAndColumnNumber < MaxThread ? lineAndColumnNumber : MaxThread;

                var tasks = new Task[MaxThread];

                Step = 0;

                //int l = Matrix.Length >= MaxThread ? lineAndColumnNumber : MaxThread;

                for (int i = 0; i < MaxThread; i++) // i < l && i < Matrix.Length && linesInThread[i] != null
                {
                    tasks[i] = new Task(() => UseAnyMethodCount(m, num, lineAndColumnNumber, linesInThread[Step++]));
                    tasks[i].Start();
                }

                Task.WaitAll(tasks);
            }


            private List<int>[] GetLinesInTaskForGetUnitMatrix(int lineAndColumnNumber)
            {
                var MaxThread = 6;
                var linesInThread = new List<int>[MaxThread];
                double n = lineAndColumnNumber;
                var pos = 0;

                for (int i = 0; i < MaxThread; i++)
                {
                    int k = (int)Math.Ceiling((n + 1) / (MaxThread - i));
                    linesInThread[i] = new List<int>();
                    for (int j = 0; j < k; j++)
                        linesInThread[i].Add(pos++);

                    n -= k;
                }

                return linesInThread;
            }

            private (double[], double) RememberLineForSubtraction(int lineAndColumnNumber)
            {
                var num = Matrix[lineAndColumnNumber][lineAndColumnNumber];
                var m = Matrix[lineAndColumnNumber].Select(x => x / num).ToArray();
                Matrix[lineAndColumnNumber] = (double[])m.Clone();
                FreeMembers[lineAndColumnNumber] = FreeMembers[lineAndColumnNumber] / num;
                num = Matrix[lineAndColumnNumber][lineAndColumnNumber];
                return (m, num);
            }
        }
    }
}





//private void GetUnitMatrix(int lineAndColumnNumber)
//{
//    var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

//    Task[] tasks = new Task[MaxThread];

//    Step = lineAndColumnNumber - 1;

//    for (int i = Step; i >= 0; i--)
//    {
//        tasks[i] = new Task(() => InGetStepMatrix
//            (m, num, Step--, lineAndColumnNumber));
//        tasks[i].Start();
//    }

//    for (int i = Step; i >= 0; i--)
//    {
//        tasks[i].Wait();
//    }
//    //Thread[] threads = new Thread[MaxThread];

//    //Step = lineAndColumnNumber - 1;
//    //for (int i = Step; i >= 0; i--)
//    //{
//    //    threads[i] = new Thread(() => InGetStepMatrix(m, num, Step--, lineAndColumnNumber));
//    //    threads[i].Start();
//    //}

//    //for (int i = Step; i >= 0; i--)
//    //{
//    //    threads[i].Join();
//    //}
//}





//tasks[i] = Task.Factory.StartNew(() =>
//    UseAnyMethodCount
//        (m, num, lineAndColumnNumber, linesInThread[Step++]));

//tasks[i] = new Task(() =>
//    UseAnyMethodCount
//        (m, num, lineAndColumnNumber, linesInThread[Step++]));

//tasks[i].Start();




//for (int i = 0; i < MaxThread && i < Matrix.Length - 1 - lineAndColumnNumber; i++)
//{
//    tasks[i].Wait();
//}

//for (int i = 0; i < Matrix.Length; i++)
//{
//    Console.WriteLine(String.Join("\t", Matrix[i]));
//}
//Console.WriteLine();

//for (int i = 0; i < MaxThread)



//private void InGetStepMatrix(double[] m, double num, int stepi, int lineAndColumnNumber)
//{
//    var t = Matrix[stepi][lineAndColumnNumber];
//    var x = num * t * (-1);
//    var n = m.Select(p => p * x);
//    Matrix[stepi] = Matrix[stepi].Zip(n, (a, b) => a + b).ToArray();
//    FreeMembers[stepi] += FreeMembers[lineAndColumnNumber] * x;
//}