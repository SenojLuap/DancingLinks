using System;
using System.Collections.Generic;

namespace DLX {

    public class DLXSolver {

	/// <summary>
	///   The header for the matrix being solved.
	/// </summary>
	public Header header;


	/// <summary>
	///   The solution currently being explored.
	/// </summary>
	public Stack<int[]> partialSolution;


	/// <summary>
	///   The set of all accepted solutions.
	/// </summary>
	public List<IList<int[]>> solutions;


	public DLXSolver() { }


	#region Solve The Matrix

	/// <summary>
	///   Solve the matrix.
	/// </summary>
	public bool Solve(bool[,] matrix) {
	    BuildMatrix(matrix);
	    partialSolution = new Stack<int[]>();
	    solutions = new List<IList<int[]>>();
	    Solve();
	    return solutions.Count > 0;
	}


	/// <summary>
	///   Solve the matrix.
	/// </summary>
	public bool Solve(int[,] matrix) {
	    bool[,] converted = ConvertIntMatrix(matrix);
	    return Solve(converted);
	}

	
	/// <summary>
	///   Solve the matrix; main loop.
	/// </summary>
	public void Solve() {
	    if (header.right == header) {
		PushSolution();
		return;
	    }
	    Header column = ChooseColumn();
	    if (column == null) return;
	    column.Cover();
	    for (Node row = column.down; row != column; row = row.down) {
		partialSolution.Push(row.Row());

		for (Node rowColumn = row.right;
		     rowColumn != row;
		     rowColumn = rowColumn.right) {
		    rowColumn.columnHeader.Cover();
		}
		Solve();
		for (Node rowColumn = row.left;
		     rowColumn != row;
		     rowColumn = rowColumn.left) {
		    rowColumn.columnHeader.Uncover();
		}

		partialSolution.Pop();
	    }
	    column.Uncover();
	}


	/// <summary>
	///   Choose a column.
	/// </summary>
	public Header ChooseColumn() {
	    int bestCount = int.MaxValue;
	    Header candidate = null;
	    for (Header current = (Header)header.right;
		 current != header;
		 current = (Header)current.right) {
		if (current.count < bestCount) {
		    bestCount = current.count;
		    candidate = current;
		}
	    }
	    if (bestCount == 0) return null;
	    return candidate;
	}


	#endregion

	#region Build The Internal Matrix
      
	/// <summary>
	///   Create a node matrix from a boolean matrix.
	/// </summary>
	public void BuildMatrix(bool[,] matrix) {
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
	}


	/// <summary>
	///   Create a node matrix from an int matrix.
	/// </summary>
	public void BuildMatrix(int[,] matrix) {
	    BuildMatrix(ConvertIntMatrix(matrix));
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

	#endregion


	#region Utility Methods

	/// <summary>
	///   Convert an int matrix to a bool matrix.
	/// </summary>
	public bool[,] ConvertIntMatrix(int[,] matrix) {
	    bool[,] converted = new bool[matrix.GetLength(0), matrix.GetLength(1)];
	    for( int x = 0; x < matrix.GetLength(0); x++)
		for ( int y = 0; y < matrix.GetLength(1); y++)
		    converted[x, y] = (matrix[x, y] != 0);
	    return converted;
	}


	/// <summary>
	///   Push the current partial solution to the set of accepted solutions.
	/// </summary>
	public void PushSolution() {
	    List<int[]> solution = new List<int[]>(partialSolution.ToArray());
	    solutions.Add(solution);
	}

	#endregion
    }
}
