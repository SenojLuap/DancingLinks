using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DLX;

namespace DancingLinksLibTest {
    public class Program {
        public static void Main(string[] args) {

	    DLXSolver solver = new DLXSolver();
	    
	    int[,] matrix = new int[,]
		{ {0, 0, 1, 0, 1, 1, 0},
		  {1, 0, 0, 1, 0, 0, 1},
		  {0, 1, 1, 0, 0, 1, 0},
		  {1, 0, 0, 1, 0, 0, 0},
		  {0, 1, 0, 0, 0, 0, 1},
		  {0, 0, 0, 1, 1, 0, 1} };
		
	    Node header = solver.GetMatrix(matrix);
	    Node current = header;
	    /*
	    do {
		current.Dump();
		current = current.right;
	    } while (current != header);
	    */
	    current = current.right;
	    do {
		System.Console.WriteLine("Column: " + ((Header)current).column);
		System.Console.WriteLine("--Count: " + ((Header)current).count);
		for (Node row = current.down; row != current; row = row.down) {
		    row.DumpRow();
		}
		current = current.right;
	    } while (current != header);

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
