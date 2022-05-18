// See https://aka.ms/new-console-template for more information
LinkedList<int> IntToLinkedList(int n, bool reversed = false) {
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
