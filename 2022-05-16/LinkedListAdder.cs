/* NOTE: since the problem only utilizes singly-linked lists, we will restrict
 * LinkedList usage to only "First" and "Next" methods/properties
 */
public static class LinkedListAdder {
    public static LinkedList<int> Add(LinkedList<int> x, LinkedList<int> y) {
        LinkedList<int> sum = new LinkedList<int>();
        LinkedListNode<int>? xCurr = x?.First;
        LinkedListNode<int>? yCurr = y?.First;
        int carry = 0;

        while (xCurr != null || yCurr != null) {
            int digitSum = (xCurr == null ? 0 : xCurr.Value) +
                           (yCurr == null ? 0 : yCurr.Value) +
                           carry;
            sum.AddFirst(digitSum % 10);
            carry = digitSum / 10;
            xCurr = xCurr?.Next;
            yCurr = yCurr?.Next;
        }
        if (carry > 0 || sum.Count == 0) sum.AddFirst(carry);

        return sum;
    }

    public static LinkedList<int> AddReversed(LinkedList<int> x, LinkedList<int> y) {
        LinkedList<int> revX = new LinkedList<int>();
        LinkedListNode<int>? currX = x?.First;
        while (currX != null) {
            revX.AddFirst(currX.Value);
            currX = currX?.Next;
        }
        LinkedList<int> revY = new LinkedList<int>();
        LinkedListNode<int>? currY = y?.First;
        while (currY != null) {
            revY.AddFirst(currY.Value);
            currY = currY?.Next;
        }
        return Add(revX, revY);
    }
}