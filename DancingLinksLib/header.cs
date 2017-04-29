
namespace DLX {
    public class Header : Node {
	
	/// <summary>
	///   The column this header represents.
	/// </summary>
	public int column;


	/// <summary>
	///   The number of nodes in the column.
	/// </summary>
	public int count;


	public Header(int column) {
	    this.column = column;
	    count = 0;
	    up = this;
	    down = this;
	}


	/// <summary>
	///   Append a node to the bottom of the column.
	/// </summary>
	public Node AppendDown() {
	    Node child = new Node();
	    up.down = child;
	    child.down = this;
	    child.up = up;
	    up = child;
	    count++;
	    child.columnHeader = this;
	    return child;
	}

	
	/// <summary>
	///   Remove the column from the matrix.
	/// </summary>
	public void Cover() {
	    RemoveFromRow();
	    for (Node row = down; row != this; row = row.down)
		row.RemoveRow();
	}


	/// <summary>
	///   Return the column to the matrix.
	/// </summary>
	public void Uncover() {
	    for (Node row = up; row != this; row = row.up)
		row.RestoreRow();
	    ReturnToRow();
	}


	override public string ToString() {
	    if (column == -1) return "H";
	    return ("" + column);
	}
    }
}
