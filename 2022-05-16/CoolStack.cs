// Algorithm based off https://www.geeksforgeeks.org/design-a-stack-that-supports-getmin-in-o1-time-and-o1-extra-space/amp/
public class CoolStack
{
    private Stack<int> _stack;
    private int _min;

    public CoolStack()
    {
        _stack = new Stack<int>();
    }

    public void Push(int n)
    {
        if (_stack.Count() <= 0) {
            _min = n;
            _stack.Push(n);
        } else {
            if (n < _min) {
                _stack.Push(2*n - _min);
                _min = n;
            } else {
                _stack.Push(n);
            }
        }
    }

    public int? Pop()
    {
        if (_stack.Count <= 0) {
            return null;
        }
        int top = _stack.Pop();
        if (top < _min) {
            int temp = _min;
            _min = 2*_min - top;
            top = temp;
        }
        return top;
    }

    public int? Min()
    {
        if (_stack.Count <= 0) {
            return null;
        }
        return _min;
    }
}
