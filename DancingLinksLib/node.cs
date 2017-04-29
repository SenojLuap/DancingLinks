using System.Collections.Generic;

namespace DLX {
    public class Node {


	/// <summary>
	///   Left sibling.
	/// </summary>
	public Node left;

	
	/// <summary>
	///   Right sibling.
	/// </summary>
	public Node right;

	
	/// <summary>
	///   Upper sibling.
	/// </summary>
	public Node up;

	
	/// <summary>
	///   Lower sibling.
	/// </summary>
	public Node down;


	/// <summary>
	///   The header for the column the node resides in.
	/// </summary>
	public Header columnHeader;

	
	public Node() { }


	/// <summary>
	///   Remove this node from the row.
	/// </summary>
	public void RemoveFromRow() {
	    left.right = right;
	    right.left = left;
	}


	/// <summary>
	///   Return this node to the row it was removed from.
	/// </summary>
	public void ReturnToRow() {
	    left.right = this;
	    right.left = this;
	}


	/// <summary>
	///   Remove this node from the column.
	/// </summary>
	public void RemoveFromColumn() {
	    up.down = down;
	    down.up = up;
	    columnHeader.count--;
	}


	/// <summary>
	///   Return this node to the column it was removed from.
	/// </summary>
	public void ReturnToColumn() {
	    columnHeader.count++;
	    up.down = this;
	    down.up = this;
	}


	/// <summary>
	///   Remove this node from all siblings.
	/// </summary>
	public void Remove() {
	    RemoveFromRow();
	    RemoveFromColumn();
	}


	/// <summary>
	///   Return this node to the column and row it was removed from.
	/// </summary>
	public void Return() {
	    ReturnToColumn();
	    ReturnToRow();
	}


	/// <summary>
	///   Remove this row from the matrix.
	/// </summary>
	public void RemoveRow() {
	    for (Node current = right; current != this; current = current.right)
		current.RemoveFromColumn();
	}


	/// <summary>
	///   Return this row to the matrix.
	/// </summary>
	public void RestoreRow() {
	    for (Node current = left; current != this; current = current.left)
		current.ReturnToColumn();
	}


	/// <summary>
	///   Get the entire row, as a solution subset.
	/// </summary>
	public int[] Row() {
	    List<int> res = new List<int>();
	    Node current = this;
	    do {
		res.Add(current.columnHeader.column);
		current = current.right;
	    } while (current != this);
	    return res.ToArray();
	}


	/// <summary>
	///   Dump the contents of this row.
	/// </summary>
	public void DumpRow() {
	    Node current = this;
	    System.Console.Write("{ ");
	    do {
		if (columnHeader == null)
		    System.Console.Write("? ");
		else
		    System.Console.Write("" + current.columnHeader.column + " ");
		current = current.right;
	    } while (current != this);
	    System.Console.WriteLine("}");
	}


	public void Dump() {
	    
	    System.Console.WriteLine(ToString());
	    System.Console.Write("Up: ");
	    if (up != null) System.Console.WriteLine(up.ToString());
	    else System.Console.WriteLine("?");

	    System.Console.Write("Down: ");
	    if (down != null) System.Console.WriteLine(down.ToString());
	    else System.Console.WriteLine("?");

	    System.Console.Write("Left: ");
	    if (left != null) System.Console.WriteLine(left.ToString());
	    else System.Console.WriteLine("?");

	    System.Console.Write("Right: ");
	    if (right != null) System.Console.WriteLine(right.ToString());
	    else System.Console.WriteLine("?");
	}


	override public string ToString() {
	    return "X";
	}
    }
}
