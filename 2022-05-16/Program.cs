// See https://aka.ms/new-console-template for more information
LinkedList<int> IntToLinkedList(int n, bool reversed = false)
{
    LinkedList<int> ll = new LinkedList<int>();
    if (n <= 0) {
        ll.AddFirst(0);
    }
    while (n > 0) {
        int digit = n % 10;
        if (reversed) {
            ll.AddFirst(digit);
        } else {
            ll.AddLast(digit);
        }
        n /= 10;
    }
    return ll;
}

string LinkedListToString(LinkedList<int> ll)
{
    string str = "";
    LinkedListNode<int>? curr = ll?.First;
    while (curr != null) {
        str += curr.Value;
        curr = curr.Next;
        if (curr != null) str += "->";
    }
    return str;
}

Console.WriteLine("LinkedListAdder tests:");
Console.WriteLine("--Forward--");

LinkedList<int> i0 = IntToLinkedList(5234);
LinkedList<int> i1 = IntToLinkedList(9068);
LinkedList<int> i2 = IntToLinkedList(45);
LinkedList<int> i3 = IntToLinkedList(2058);

// 5234 + 9068 = 14302
Console.WriteLine(LinkedListToString(i0) + " + " +
                  LinkedListToString(i1) + " = " +
                  LinkedListToString(LinkedListAdder.Add(i0, i1)));
// 45 + 2058 = 2103
Console.WriteLine(LinkedListToString(i2) + " + " +
                  LinkedListToString(i3) + " = " +
                  LinkedListToString(LinkedListAdder.Add(i2, i3)));

LinkedList<int> r0 = IntToLinkedList(1234, true);
LinkedList<int> r1 = IntToLinkedList(9876, true);
LinkedList<int> r2 = IntToLinkedList(358, true);
LinkedList<int> r3 = IntToLinkedList(72, true);

Console.WriteLine("--Reversed--");

// 1234 + 9876 = 11110
Console.WriteLine(LinkedListToString(r0) + " + " +
                  LinkedListToString(r1) + " = " +
                  LinkedListToString(LinkedListAdder.AddReversed(r0, r1)));
// 358 + 72 = 430
Console.WriteLine(LinkedListToString(r2) + " + " +
                  LinkedListToString(r3) + " = " +
                  LinkedListToString(LinkedListAdder.AddReversed(r2, r3)));


Console.WriteLine("\nCoolStack tests:");

