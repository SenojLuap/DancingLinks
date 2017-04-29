using System;
using System.Collections.Generic;

namespace DancingLinks {

    public class DancingLinksSolver {

	/// <summary>
	///   The matrix being solved.
	/// </summary>
	public Node matrix;


	public DancingLinksSolver() {
	    
	}


	/// <summary>
	///   Create a node matrix from a boolean matrix.
	/// </summary>
	public Node GetMatrix(bool[,] matrix) {
	    int rows = matrix.GetLength(0);
	    int columns = matrix.GetLength(1);

	    Node controlRow = new Node(true);
	    Node current = controlRow;
	    for (int i = 1; i < columns; i++) {
		Node next = new Node(true);
		current.right = next;
		next.left = current;
		current = next;
	    }
	    Node lastRow = controlRow;

	    for (int row = 0; row < rows; row++) {
		Node newRow = new Node(matrix[row, 0]);
		lastRow.down = newRow;
		newRow.up = lastRow;

		current = newRow;
		for (int column = 1; column < columns; column++) {
		    Node next = new Node(matrix[row, column]);
		    current.right = next;
		    next.left = current;
		    current = next;

		    Node above = lastRow.Right(column);
		    above.down = next;
		    next.up = above;
		}
		lastRow = newRow;
	    }

	    return controlRow;
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
    }
}
