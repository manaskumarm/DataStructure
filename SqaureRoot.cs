using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractise
{
    internal class SqaureRoot
    {
        public static double square_root(double myNumber)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double precision = 0.00001;
            double low = 0;
            double high = myNumber;
            double mid = 0;
            int counter = 0;

            while ((high - low) > precision)
            {
                counter++;
                mid = (double)((low + high) / 2);
                if ((mid - precision) >= mid * mid && mid * mid <= (precision + mid))
                {
                    break;
                }
                else if (mid * mid < myNumber)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            sw.Stop();

            // Write result.
            Console.WriteLine("Counter: {0}", counter);
            Console.WriteLine("Time elapsed(1): {0}", sw.Elapsed);
            return mid;
        }

        public static float squareRoot(int number, int precision)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int start = 0, end = number;
            int mid;
            int counter2 = 0;
            // variable to store the answer
            double ans = 0.0;

            // for computing integral part
            // of square root of number
            while (start <= end)
            {
                counter2++;
                mid = (start + end) / 2;

                if (mid * mid == number)
                {
                    ans = mid;
                    break;
                }

                // incrementing start if integral
                // part lies on right side of the mid
                if (mid * mid < number)
                {
                    start = mid + 1;
                    ans = mid;
                }

                // decrementing end if integral part
                // lies on the left side of the mid
                else
                {
                    end = mid - 1;
                }
            }

            // For computing the fractional part
            // of square root upto given precision
            double increment = 0.1;
            int counter = 0;
            for (int i = 0; i < precision; i++)
            {
                while (ans * ans <= number)
                {
                    counter++;
                    ans += increment;
                }

                // loop terminates when ans * ans > number
                ans = ans - increment;
                increment = increment / 10;
            }
            sw.Stop();

            // Write result.
            Console.WriteLine("Counter2: {0}", counter + counter2);
            Console.WriteLine("Time elapsed(2): {0}", sw.Elapsed);
            return (float)ans;
        }
    }
}
