using System;
using System.Collections.Generic;

namespace Sudoku
{
    class Program
    {
        static Grid test1 = new Grid(new List<string>() 
                { 
                    " 5 3 0 0 7 0 0 0 0 ",
                    " 6 0 0 1 9 5 0 0 0 ",
                    " 0 9 8 0 0 0 0 6 0 ",
                    " 8 0 0 0 6 0 0 0 3 ",
                    " 4 0 0 8 0 3 0 0 1 ",
                    " 7 0 0 0 2 0 0 0 6 ",
                    " 0 6 0 0 0 0 2 8 0 ",
                    " 0 0 0 4 1 9 0 0 5 ",
                    " 0 0 0 0 8 0 0 7 9 ",
                });

        static Grid test2 = new Grid(new List<string>()
                {
            " 0 0 0 7 0 0 0 0 0 ",
            " 1 0 0 0 0 0 0 0 0 ",
            " 0 0 0 4 3 0 2 0 0 ",
            " 0 0 0 0 0 0 0 0 6 ",
            " 0 0 0 5 0 9 0 0 0 ",
            " 0 0 0 0 0 0 4 1 8 ",
            " 0 0 0 0 8 1 0 0 0 ",
            " 0 0 2 0 0 0 0 5 0 ",
            " 0 4 0 0 0 0 3 0 0 ",
                });

        static Grid test3 = new Grid(new List<string>()
                {
            " 8 0 0 0 0 0 0 0 0 ",
            " 0 0 3 6 0 0 0 0 0 ",
            " 0 7 0 0 9 0 2 0 0 ",
            " 0 5 0 0 0 7 0 0 0 ",
            " 0 0 0 0 4 5 7 0 0 ",
            " 0 0 0 1 0 0 0 3 0 ",
            " 0 0 1 0 0 0 0 6 8 ",
            " 0 0 8 5 0 0 0 1 0 ",
            " 0 9 0 0 0 0 4 0 0 ",
                });

        static Grid test4NotUnique = new Grid(new List<string>()
                {
            " 8 0 0 0 0 0 0 0 0 ",
            " 0 0 3 6 0 0 0 0 0 ",
            " 0 7 0 0 9 0 2 0 0 ",
            " 0 5 0 0 0 7 0 0 0 ",
            " 0 0 0 0 4 5 7 0 0 ",
            " 0 0 0 1 0 0 0 3 0 ",
            " 0 0 1 0 0 0 0 6 8 ",
            " 0 0 8 5 0 0 0 1 0 ",
            " 0 9 0 0 0 0 0 0 0 ",
                });
        static void Main(string[] args)
        {
            try
            {
                var grid = test3;
                grid.Solve();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
