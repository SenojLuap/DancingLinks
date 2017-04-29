
namespace DancingLinks {
    public class Node {


	/// <summary>
	///   The node is included.
	/// </summary>
	public bool value;

	
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

	
	public Node(bool value) {
	    this.value = value;
	}


	public Node(int value) {
	    this.value = (value != 0);
	}


	/// <summary>
	///   Remove this node from the row.
	/// </summary>
	public void removeFromRow() {
	    left.right = right;
	    right.left = left;
	}


	/// <summary>
	///   Return this node to the row it was removed from.
	/// </summary>
	public void returnToRow() {
	    left.right = this;
	    right.left = this;
	}


	/// <summary>
	///   Remove this node from the column.
	/// </summary>
	public void removeFromColumn() {
	    up.down = down;
	    down.up = up;
	}


	/// <summary>
	///   Return this node to the column it was removed from.
	/// </summary>
	public void returnToColumn() {
	    up.down = this;
	    down.up = this;
	}


	/// <summary>
	///   The length of the node list horizonally.
	/// </summary>
	public int CountRight() {
	    if (right != null) return right.CountRight() + 1;
	    return 1;
	}


	/// <summary>
	///   The length of the node vertically.
	/// </summary>
	public int CountDown() {
	    if (down != null) return down.CountDown() + 1;
	    return 1;
	}


	/// <summary>
	///   Get the node 'index' positions to the right.
	/// </summary>
	public Node Right(int index) {
	    if (index == 0 ||
		right == null)
		return this;
	    return right.Right(index-1);
	}


	/// <summary>
	///   Get the node 'index' positions to the left.
	/// </summary>
	public Node Left(int index) {
	    if (index == 0 ||
		left == null)
		return this;
	    return left.Left(index-1);
	}


	/// <summary>
	///   Get the node 'index' positions below.
	/// </summary>
	public Node Down(int index) {
	    if (index == 0 ||
		down == null)
		return this;
	    return down.Down(index-1);
	}


	/// <summary>
	///   Get the node 'index' positions above.
	/// </summary>
	public Node Up(int index) {
	    if (index == 0 ||
		up == null)
		return this;
	    return up.Up(index-1);
	}
	

	/// <summary>
	///   Treat the node as a row, and dump it's contents.
	/// </summary>
	public void DumpRow() {
	    System.Console.Write("" + (value ? 1 : 0) + " ");
	    if (right != null) right.DumpRow();
	    else System.Console.WriteLine();
	}

	/// <summary>
	///   Treat the node as the top-left of matrix. Dump this matrix.
	/// </summary>
	public void Dump() {
	    DumpRow();
	    if (down != null) down.Dump();
	}

    }
}
