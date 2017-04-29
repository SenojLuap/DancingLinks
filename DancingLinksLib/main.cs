using System;
using System.Collections.Generic;

namespace DLX {

    public class DLXSolver {

	/// <summary>
	///   The header for the matrix being solved.
	/// </summary>
	public Header header;


	public DLXSolver() {
	    
	}


	/// <summary>
	///   Create a node matrix from a boolean matrix.
	/// </summary>
	public Node GetMatrix(bool[,] matrix) {
	    int rows = matrix.GetLength(0);
	    int columns = matrix.GetLength(1);

	    if (columns <= 0 || rows <= 0)
		throw new ArgumentException("Matrix must be at least 1x1", "matrix");

	    header = BuildControlRow(columns);

	    List<Node> toRemove = new List<Node>();

	    for (Header column = (Header)header.right;
		 column != header;
		 column = (Header)column.right) {
		for (int row = 0; row < rows; row++) {
		    Node next = column.AppendDown();
		    if (!matrix[row, column.column])
			toRemove.Add(next);
		}
	    }

	    for (Header column = (Header)header.right;
		 column != header;
		 column = (Header)column.right) {
		Node left = column.left;
		if (left == header)
		    left = left.left;
		Node right = column.right;
		if (right == header)
		    right = right.right;
		Node node = column.down;
		Node leftSibling = left.down;
		Node rightSibling = right.down;
		do {
		    node.left = leftSibling;
		    node.right = rightSibling;
		    node = node.down;
		    leftSibling = leftSibling.down;
		    rightSibling = rightSibling.down;
		} while (node != column);
	    }

	    foreach (Node victim in toRemove)
		victim.Remove();

	    return header;
	}


	/// <summary>
	///   Create a node matrix from an int matrix.
	/// </summary>
	public Node GetMatrix(int[,] matrix) {
	    bool[,] converted = new bool[matrix.GetLength(0), matrix.GetLength(1)];
	    for( int x = 0; x < matrix.GetLength(0); x++)
		for ( int y = 0; y < matrix.GetLength(1); y++)
		    converted[x, y] = (matrix[x, y] != 0);
	    return GetMatrix(converted);
	}


	/// <summary>
	///   Build the control row.
	/// </summary>
	public Header BuildControlRow(int columns) {
	    Header res = new Header(-1);
	    Header last = res;
	    for (int column = 0; column < columns; column++) {
		Header next = new Header(column);
		last.right = next;
		next.left = last;
		last = next;
	    }
	    last.right = res;
	    res.left = last;
	    return res;
	}
    }
}
