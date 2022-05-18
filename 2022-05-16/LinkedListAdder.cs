/* NOTE: since the problem only utilizes singly-linked lists, we will restrict
 * LinkedList usage to only "First" and "Next" methods/properties
 */
public static class LinkedListAdder
{
    public static LinkedList<int> Add(LinkedList<int> x, LinkedList<int> y)
    {
        LinkedList<int> sum = new LinkedList<int>();
        LinkedListNode<int>? xCurr = x?.First;
        LinkedListNode<int>? yCurr = y?.First;
        LinkedListNode<int>? sumCurr = null;
        int carry = 0;

        while (xCurr != null || yCurr != null) {
            int digitSum = (xCurr == null ? 0 : xCurr.Value) +
                           (yCurr == null ? 0 : yCurr.Value) +
                           carry;
            if (sumCurr == null) {
                sum.AddFirst(digitSum % 10);
                sumCurr = sum.First;
            } else {
                sum.AddAfter(sumCurr, digitSum % 10);
                sumCurr = sumCurr.Next;
            }
            carry = digitSum / 10;
            xCurr = xCurr?.Next;
            yCurr = yCurr?.Next;
        }
        if (carry > 0) {
            if (sumCurr == null) {
                sum.AddFirst(carry);
            } else {
                sum.AddAfter(sumCurr, carry);
            }
        }
        if (sum.Count == 0) {
            sum.AddFirst(0);
        }
        return sum;
    }

    public static LinkedList<int> AddReversed(LinkedList<int> x, LinkedList<int> y)
    {
        LinkedList<int> revX = ReverseLinkedList(x);
        LinkedList<int> revY = ReverseLinkedList(y);
        return ReverseLinkedList(Add(revX, revY));
    }

    private static LinkedList<int> ReverseLinkedList(LinkedList<int> ll)
    {
        LinkedList<int> rev = new LinkedList<int>();
        LinkedListNode<int>? curr = ll?.First;
        while (curr != null) {
            rev.AddFirst(curr.Value);
            curr = curr.Next;
        }
        return rev;
    }
}
