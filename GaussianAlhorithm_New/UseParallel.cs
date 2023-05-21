using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianAlhorithm_New
{
    public class LearningUseParallel
    {
        public static readonly int MaxThread = 6; // 1 2 4 6
        public static int Step = 0;

        public class GaussianAlgorithmParallels
        {
            public double[][] Matrix { get; private set; }
            public double[] FreeMembers { get; private set; }

            public GaussianAlgorithmParallels(double[][] matrix, double[] freeMembers)
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
                var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

                var end = Matrix.Length;//MaxThread < Matrix.Length ? MaxThread : Matrix.Length;

                Step = lineAndColumnNumber + 1;

                Parallel.For(Step, end, (i) =>
                {
                    InGetStepMatrix(m, num, Step++, lineAndColumnNumber);
                });
            }

            private void InGetStepMatrix(double[] m, double num, int stepi, int lineAndColumnNumber)
            {
                var t = Matrix[stepi][lineAndColumnNumber];
                var x = num * t * (-1);
                var n = m.Select(p => p * x);
                Matrix[stepi] = Matrix[stepi].Zip(n, (a, b) => a + b).ToArray();
                FreeMembers[stepi] += FreeMembers[lineAndColumnNumber] * x;
            }

            private void GetUnitMatrixNew(int lineAndColumnNumber)
            {
                var (m, num) = RememberLineForSubtraction(lineAndColumnNumber);

                Step = lineAndColumnNumber - 1;

                var end = Step;

                Parallel.For(-1, end, (i) =>
                {
                    InGetStepMatrix(m, num, Step--, lineAndColumnNumber);
                });
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



//private void UseAnyMethodCount(double[] m, double num, int lineAndColumnNumber, List<int> lines)
//{
//    if (lines == null) return;

//    for (int i = 0; i < lines.Count; i++)
//    {
//        var t = Matrix[lines[i]][lineAndColumnNumber];
//        var x = num * t * (-1);
//        var n = m.Select(p => p * x);
//        Matrix[lines[i]] = Matrix[lines[i]].Zip(n, (a, b) => a + b).ToArray();
//        FreeMembers[lines[i]] += FreeMembers[lineAndColumnNumber] * x;
//    }
//}


//private List<int>[] GetLinesInThreadForGetUnitMatrix(int lineAndColumnNumber)
//{
//    var MaxThread = 6;
//    var linesInThread = new List<int>[MaxThread];
//    double n = lineAndColumnNumber;
//    var pos = 0;

//    for (int i = 0; i < MaxThread; i++)
//    {
//        int k = (int)Math.Ceiling((n + 1) / (MaxThread - i));
//        linesInThread[i] = new List<int>();
//        for (int j = 0; j < k; j++)
//            linesInThread[i].Add(pos++);

//        n -= k;
//    }

//    return linesInThread;
//}



//private List<int>[] GetLinesInThreadForGetStepMatrix(int lineAndColumnNumber)
//{
//    List<int>[] linesInThread = new List<int>[MaxThread];

//    int countLine = Matrix.Length - lineAndColumnNumber - 1;
//    int k = 1;

//    while (countLine > MaxThread * k)
//        k++;

//    int j = lineAndColumnNumber + 1;
//    for (int i = 0; i < MaxThread; i++)
//    {
//        if (countLine > k)
//        {
//            linesInThread[i] = new List<int>();
//            for (int p = j; p < j + k; p++)
//            {
//                linesInThread[i].Add(p);
//            }
//            j += k;
//            countLine -= k;
//        }
//        else
//        {
//            linesInThread[i] = new List<int>();
//            for (int p = j; p < j + countLine; p++)
//            {
//                linesInThread[i].Add(p);
//            }
//            break;
//        }
//    }

//    return linesInThread;
//}
