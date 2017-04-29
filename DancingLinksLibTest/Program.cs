using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using DLX;

namespace DancingLinksLibTest {
    public class Program {
        public static void Main(string[] args) {

	    DLXSolver solver = new DLXSolver();
	    
	    /*
	    int[,] matrix = new int[,]
		{ {0, 0, 1, 0, 1, 1, 0},
		  {1, 0, 0, 1, 0, 0, 1},
		  {0, 1, 1, 0, 0, 1, 0},
		  {1, 0, 0, 1, 0, 0, 0},
		  {0, 1, 0, 0, 0, 0, 1},
		  {0, 0, 0, 1, 1, 0, 1} };
	    */
	    int[,] matrix = new int[,]
		{ {1, 0, 0, 1, 0, 0, 1},
		  {1, 0, 0, 1, 0, 0, 0},
		  {0, 0, 0, 1, 1, 0, 1},
		  {0, 0, 1, 0, 1, 1, 0},
		  {0, 1, 1, 0, 0, 1, 1},
		  {0, 1, 0, 0, 0, 0, 1} };
		
	    if (solver.Solve(matrix)) {
		foreach (var solution in solver.solutions) {
		    System.Console.WriteLine("{ ");
		    foreach (int[] row in solution) {
			System.Console.Write("  [");
			foreach (int column in row) {
			    System.Console.Write("" + column + " ");
			}
			System.Console.WriteLine("]");
		    }
		    System.Console.WriteLine("}");
		}
	    } else {
		System.Console.WriteLine("No Solutions!");
	    }

	    /*
	    int rows = 10000;
	    int columns = 100;
	    Random rand = new Random();
	    bool[,] bigMatrix = new bool[rows, columns];
	    for (int row = 0; row < rows; row++)
		for (int column = 0; column < columns; column++)
		    bigMatrix[row, column] = (rand.NextDouble() > .5);

	    Stopwatch timer = new Stopwatch();
	    timer.Start();
	    bool res = solver.Solve(bigMatrix);
	    timer.Stop();

	    TimeSpan ts = timer.Elapsed;
	    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					       ts.Hours, ts.Minutes, ts.Seconds,
					       ts.Milliseconds / 10);
	    System.Console.WriteLine("Time Taken: " + elapsedTime);

	    if (res) {
		foreach (var solution in solver.solutions) {
		    System.Console.WriteLine("{ ");
		    foreach (int[] row in solution) {
			System.Console.Write("  [");
			foreach (int column in row) {
			    System.Console.Write("" + column + " ");
			}
			System.Console.WriteLine("]");
		    }
		    System.Console.WriteLine("}");
		}
	    } else {
		System.Console.WriteLine("No Solutions!");
	    }
	    */

	    /*
	    System.Console.WriteLine();

	    bool[,] boolMatrix = new bool[,]
		{ { true, false, false},
		  { false, true, true},
		  { true, false, true},
		  { false, false, false} };
	    res = solver.GetMatrix(boolMatrix);
	    res = res.right;

	    for (Node row = res.down; row != res; row = row.down)
		row.DumpRow();
	    */
        }
    }
}
