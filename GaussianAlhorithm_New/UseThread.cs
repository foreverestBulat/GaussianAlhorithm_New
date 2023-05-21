using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianAlhorithm_New
{
    public static class LearningUseThread
    {
        public static readonly int MaxThread = 6; // 1 2 4 6 12
        public static int Step = 0;
        
        

        public class GaussianAlgorithmThreads
        {
            int x;
            public double[][] Matrix { get; private set; }
            public double[] FreeMembers { get; private set; }

            public List<int>[] LinesInThread;

            object locker = new();
            public GaussianAlgorithmThreads(double[][] matrix, double[] freeMembers)
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
                LinesInThread = GetLinesInThreadForGetStepMatrix(lineAndColumnNumber);

                var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

                var threads = new Thread[MaxThread];

                Step = 0;

                for (int i = 0; i < MaxThread; i++) //i < Matrix.Length - lineAndColumnNumber - 1 && i < MaxThread
                {
                    if (LinesInThread[Step] == null) break;
                    threads[i] = new Thread(() => 
                        UseAnyMethodCount
                            (m, num, lineAndColumnNumber, Step++));
                    threads[i].Start();
                }

                for (int i = 0; i < MaxThread; i++)
                {
                    if (threads[i] == null) continue;
                    threads[i].Join();
                }
            }

            private List<int>[] GetLinesInThreadForGetStepMatrix(int lineAndColumnNumber)
            {
                List<int>[] linesInThread = new List<int>[MaxThread];

                int countLine = Matrix.Length - lineAndColumnNumber - 1;
                int k = 1;

                while (countLine > MaxThread * k)
                    k++;

                int j = lineAndColumnNumber + 1;
                for (int i = 0; i < MaxThread; i++)
                {
                    if (countLine > k)
                    {
                        linesInThread[i] = new List<int>();
                        for (int p = j; p < j + k; p++)
                        {
                            linesInThread[i].Add(p);
                        }
                        j += k;
                        countLine -= k;
                    }
                    else
                    {
                        linesInThread[i] = new List<int>();
                        for (int p = j; p < j + countLine; p++)
                        {
                            linesInThread[i].Add(p);
                        }
                        break;
                    }
                }

                return linesInThread;
            }

            private void UseAnyMethodCount(double[] m, double num, int lineAndColumnNumber, int idLines) //List<int> lines
            {
                var lines = LinesInThread[idLines];

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

                LinesInThread = GetLinesInThreadForGetUnitMatrix(lineAndColumnNumber - 1);

                var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

                var threads = new Thread[MaxThread];

                Step = 0;

                int l = Matrix.Length >= MaxThread ? lineAndColumnNumber : MaxThread;

                for (int i = 0; i < MaxThread; i++) //i < 6 && i < l && i < Matrix.Length && LinesInThread[i] != null
                {
                    threads[i] = new Thread(() =>
                        UseAnyMethodCount
                            (m, num, lineAndColumnNumber, Step++));

                    threads[i].Start();
                }

                for (int i = 0; i < MaxThread; i++)
                {
                    if (threads[i] == null) break;
                    threads[i].Join();
                }
            }


            private List<int>[] GetLinesInThreadForGetUnitMatrix(int lineAndColumnNumber)
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


//private void InGetStepMatrix(double[] m, double num, int stepi, int lineAndColumnNumber)
//{
//    var t = Matrix[stepi][lineAndColumnNumber];
//    var x = num * t * (-1);
//    var n = m.Select(p => p * x);
//    Matrix[stepi] = Matrix[stepi].Zip(n, (a, b) => a + b).ToArray();
//    FreeMembers[stepi] += FreeMembers[lineAndColumnNumber] * x;
//}



//private void GetUnitMatrix(int lineAndColumnNumber)
//{
//    var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

//    Thread[] threads = new Thread[MaxThread];

//    Step = lineAndColumnNumber - 1;
//    for (int i = Step; i >= 0; i--)
//    {
//        threads[i] = new Thread(() => InGetStepMatrix(m, num, Step--, lineAndColumnNumber));
//        threads[i].Start();
//    }

//    for (int i = Step; i >= 0; i--)
//    {
//        threads[i].Join();
//    }
//}



//Thread[] threads = new Thread[MaxThread];

//Step = lineAndColumnNumber + 1;
//for (int i = Step; i < MaxThread && i < Matrix.Length; i++)
//{
//    threads[i] = new Thread(() => InGetStepMatrix(m, num, Step++, lineAndColumnNumber));
//    threads[i].Start();
//}

//for (int i = Step; i < MaxThread && i < Matrix.Length; i++)
//{
//    threads[i].Join();
//}


//private List<int>[] GetLinesInThreadForGetUnitMatrix(int lineAndColumnNumber)
//{
//    List<int>[] linesInThread = new List<int>[MaxThread];

//    int countLine = lineAndColumnNumber;
//    int k = 1;

//    while (countLine > MaxThread * k)
//        k++;

//    int j = 0;
//    for (int i = 0; i < MaxThread; i++)
//    {
//        if (countLine > k)
//        {
//            for (int p = j; p < k; p++)
//            {

//            }
//        }
//    }

//    //for (int i = 0; i < MaxThread; i++)
//    //{
//    //    if (countLine > k)
//    //    {
//    //        linesInThread[i] = new List<int>();
//    //        for (int p = j; p >= countLine - k; p--)
//    //        {
//    //            linesInThread[i].Add(p);
//    //        }
//    //        countLine -= k;
//    //        j -= (countLine - k);
//    //    }
//    //    else
//    //    {
//    //        linesInThread[i] = new List<int>();
//    //        for (int p = j; p >= 0; p--)
//    //        {

//    //        }

//    //    }
//    //}
//    //int j = lineAndColumnNumber - 1;
//    //for (int i = 0; i < MaxThread; i++)
//    //{
//    //    if (countLine >= k)
//    //    {
//    //        linesInThread[i] = new List<int>();
//    //        for (int p = j; p >= countLine - k; p--)
//    //        {
//    //            linesInThread[i].Add(p);
//    //        }
//    //        j -= k;
//    //        countLine -= k;
//    //    }
//    //    else
//    //    {
//    //        linesInThread[i] = new List<int>();
//    //        for (int p = j; p < j + countLine; p++)
//    //        {
//    //            linesInThread[i].Add(p);
//    //        }
//    //        break;
//    //    }
//    //}

//    return linesInThread;
//}
