using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DancingLinks;

namespace DancingLinksLibTest {
    public class Program {
        public static void Main(string[] args) {

	    DancingLinksSolver solver = new DancingLinksSolver();

	    int[,] matrix = new int[,]
		{ {0, 0, 0},
		  {1, 1, 0},
		  {0, 1, 0},
		  {1, 0, 1} };
	    Node res = solver.GetMatrix(matrix);
	    res.Dump();
	    System.Console.WriteLine();


	    bool[,] boolMatrix = new bool[,]
		{ { true, false, false},
		  { false, true, true},
		  { true, false, true},
		  { false, false, false} };
	    res = solver.GetMatrix(boolMatrix);
	    res.Dump();
        }
    }
}
