using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sudoku
{
    public class Grid
    {
        private byte[,] datas_;
        private long counter_;
        private long solutions_;

        // csv separated 0 to 9, 0 = empty
        public Grid(List<string> valuesArray = null)
        {
            datas_ = new byte[9, 9];
            if (valuesArray!=null)
            {
                var values=string.Concat(valuesArray);
                var tokens = values.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 81)
                    throw new ArgumentException($"Invalid values, size={tokens.Length}");
                int k = 0;
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        var b = byte.Parse(tokens[k++]);
                        if (b>=0 && b<=9)
                        datas_[i, j] = b;
                        else
                            throw new ArgumentException($"Invalid value, b={b}");
                    }
            }
        }

        public Tuple<int, int> NextAvailableSlot()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (datas_[i, j] == 0)
                        return new Tuple<int, int>(i, j);
                }
            return null;
        }

        // Check if putting value v at position (i,j) is ok
        public bool IsOk(int i, int j, byte v)
        {
            Debug.Assert(datas_[i, j] == 0, $"Internal error: position ({i},{j}) not empty!");
            Debug.Assert(1 <= v && v <= 9, $"Internal error: v not correct: {v}");

            for (int k = 0; k < 9; k++)
                if (datas_[k, j] == v || datas_[i, k] == v)
                    return false;

            // Test square
            int i0 = 3 * (i / 3);
            int j0 = 3 * (j / 3);
            for (int n = i0; n < i0 + 3; n++)
                for (int m = j0; m < j0 + 3; m++)
                    if (datas_[n, m] == v)
                        return false;

            return true;
        }

        public void Solve()
        {
            counter_ = 0;
            solutions_ = 0;
            SolveInternal();
            Console.WriteLine($"counter={counter_} solutions={solutions_}");
        }

        private void SolveInternal()
        {
            counter_++;
           // Console.WriteLine(this);
           // Console.WriteLine("===============");
            var freePosition = NextAvailableSlot();
            if (freePosition != null)
            {
                for (byte v = 1; v <= 9; v++)
                {
                    if (IsOk(freePosition.Item1, freePosition.Item2, v))
                    {
                      //  Console.WriteLine($"Change {freePosition} => {v}");
                        datas_[freePosition.Item1, freePosition.Item2] = v;
                        SolveInternal();
                        datas_[freePosition.Item1, freePosition.Item2] = 0;
                    }
                    else
                    {
                     //   Console.WriteLine($"Not ok {freePosition} => {v}");
                    }
                }
                
                return;
            }
            Console.WriteLine("Solution");
            Console.WriteLine(this);
            var isValid = IsValid();
            Console.WriteLine($"Isvalid={isValid}");
            if (!isValid)
                throw new Exception("Invalid solution???");
            solutions_++;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sb.Append(datas_[i, j] == 0 ? "." : datas_[i, j].ToString()).Append(" ");
                }
                if (i<8)
                 sb.AppendLine();
            }
            return sb.ToString();
        }

        private bool IsValidCount(int[] counts)
        {
            if (counts[0] != 0)
                return false;
            for (int k = 1; k <= 9; k++)
                if (counts[k] != 1)
                    return false;
            return true;
        }

        private bool IsValid(int i, int j, int di, int dj)
        {
            int[] counts = new int[10];
            for (int k = 0; k < 9; k++)
            {
                counts[datas_[i + k * di, j + k * dj]]++;
            }
            return IsValidCount(counts);
        }

        private bool IsValidSquare(int i, int j)
        {
            int[] counts = new int[10];
            for (int n = 3*i; n < 3*i + 3; n++)
                for (int m = 3*j; m < 3*j + 3; m++)
                    counts[datas_[n,m]]++;
            return IsValidCount(counts);
        }

        public bool IsValid()
        {
            for (int k = 0; k < 9; k++)
            {
                if (!IsValid(k, 0, 0, +1))
                    return false;
                if (!IsValid(0, k, +1, 0))
                    return false;
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (!IsValidSquare(i, j))
                        return false;
            return true;
        }
    }
}
