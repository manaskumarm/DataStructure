using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractise
{
    internal class Permutation
    {
        public static void Execute()
        {
            string str = "ABCD";
            int n = str.Length;
            permute(str, 0, n - 1);
        }
        private static void permute(string str, int left, int right)
        {
            if (left == right)
                Console.WriteLine(str);
            else
            {
                for (int index = left; index <= right; index++)
                {
                    str = swap(str, left, index);
                    Console.WriteLine("index: {0}, left: {1}, right: {3}, permute call left: {2}", index, left, left+1, right);
                    permute(str, left + 1, right);
                }
            }
        }

        /* Swap Characters at position 
      @param a string value @param 
      i position 1 @param j position 2 
      @return swapped string */
        private static string swap(string a,
                                int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }


    }
}
