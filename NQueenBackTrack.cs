﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractise
{
    public class NQueenBackTrack
    {
        public void NQueenProb()
        {
            int N = 4;
            int count = 0;
            int[,] board = new int[N, N];

            //Initialize the board array to 0
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = 0;
                }
            }

            //Initialize the pointer array
            int[] pointer = new int[N];
            for (int i = 0; i < N; i++)
            {
                pointer[i] = -1;
            }

            //Implementation of Back Tracking Algorithm
            for (int j = 0; ;)
            {
                pointer[j]++;
                //Reset and move one column back
                if (pointer[j] == N)
                {
                    board[pointer[j] - 1, j] = 0;
                    pointer[j] = -1;
                    j--;

                    if (j == -1)
                    {
                        Console.WriteLine("all possible solutions to N–Queens problem are done");
                        break;
                    }
                }
                else
                {
                    board[pointer[j], j] = 1;
                    if (pointer[j] != 0)
                    {
                        board[pointer[j] - 1, j] = 0;
                    }

                    if (SolutionCheck(board))
                    {
                        j++;//move to next column
                        if (j == N)
                        {
                            j--;
                            count++;
                            Console.WriteLine("Solution" + count.ToString() + ":");
                            for (int p = 0; p < N; p++)
                            {
                                for (int q = 0; q < N; q++)
                                {
                                    Console.Write(board[p, q] + " ");
                                }

                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

            Console.ReadLine();
        }

        public static bool SolutionCheck(int[,] board)
        {
            int N = 4;
            //Row check

            for (int i = 0; i < N; i++)
            {

                int sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum = sum + board[i, j];
                }

                if (sum > 1)
                {
                    return false;
                }
            }

            //Main diagonal check
            for (int i = 0, j = N - 2; j >= 0; j--)
            {
                int sum = 0;
                for (int p = i, q = j; q < N; p++, q++)
                {
                    sum = sum + board[p, q];
                }

                if (sum > 1)
                {
                    return false;
                }
            }

            //below

            for (int i = 1, j = 0; i < N - 1; i++)
            {
                int sum = 0;
                for (int p = i, q = j; p < N; p++, q++)
                {
                    sum = sum + board[p, q];
                }

                if (sum > 1)
                {
                    return false;
                }
            }

            //Minor diagonal check

            //above

            for (int i = 0, j = 1; j < N; j++)
            {
                int sum = 0;
                for (int p = i, q = j; q >= 0; p++, q--)
                {
                    sum = sum + board[p, q];
                }

                if (sum > 1)
                {
                    return false;
                }
            }

            //below

            for (int i = 1, j = N - 1; i < N - 1; i++)
            {
                int sum = 0;
                for (int p = i, q = j; p < N; p++, q--)
                {
                    sum = sum + board[p, q];
                }

                if (sum > 1)
                {
                    return false;
                }
            }

            return true;

        }    
    }
}
