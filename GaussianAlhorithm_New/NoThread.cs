using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianAlhorithm_New
{
    public class NoThread
    {
        public static readonly int MaxThread = 6;
        public static int Step = 0;

        public class GaussianAlgorithmNoThreads
        {
            public double[][] Matrix { get; private set; }
            public double[] FreeMembers { get; private set; }

            public GaussianAlgorithmNoThreads(double[][] matrix, double[] freeMembers)
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


                for (int i = 0; i < end && Step < end; i++)
                {
                    InGetStepMatrix(m, num, Step++, lineAndColumnNumber);
                }
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

                for (int i = -1; i < end; i++)
                {
                    InGetStepMatrix(m, num, Step--, lineAndColumnNumber);
                }
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
