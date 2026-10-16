public class LinkedList {

    class Node
    {
        private int _value;
        private Node _next;
        private Node _prev;

        public Node(int val)
        {
            _value = val;
        }

        public Node GetNext()
        {
            return _next;
        }

        public Node GetPrev()
        {
            return _prev;
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetNext(Node next)
        {
            _next = next;
        }

        public void SetPrev(Node prev)
        {
            _prev = prev;
        }
    }

    int _count;
    Node _head;
    Node _tail;

    public LinkedList()
    {
    }

    public int Get(int index) {

        if(index < 0 || index >= _count)
            return -1;

        return GetNode(index).GetValue();
    }

    public void InsertHead(int val) {
        var node = new Node(val);

        if(_count == 0)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.SetNext(_head);
            _head.SetPrev(node);
            _head = node;
        }

        _count++;
    }

    public void InsertTail(int val) {
        var node = new Node(val);

        if(_count == 0)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.SetPrev(_tail);
            _tail.SetNext(node);
            _tail = node;
        }

        _count++;
    }

    public bool Remove(int index) {

        if(index < 0 || index >= _count)
            return false;

        var node = GetNode(index);
        var prev = node.GetPrev();
        var next = node.GetNext();

        if(prev != null)
            prev.SetNext(next);
        else
            _head = next;

        if(next != null)
            next.SetPrev(prev);
        else
            _tail = prev;

        _count--;

        return true;
    }

    public List<int> GetValues() {
        var result = new List<int>(_count);
        var current = _head;

        for(int i = 0; i < _count; i++)
        {
            result.Add(current.GetValue());
            current = current.GetNext();
        }

        return result;
    }

    // index має бути в межах [0, _count)
    Node GetNode(int index)
    {
        Node current;

        if(index < _count / 2)
        {
            current = _head;
            for(int i = 0; i < index; i++)
                current = current.GetNext();
        }
        else
        {
            current = _tail;
            for(int i = _count - 1; i > index; i--)
                current = current.GetPrev();
        }

        return current;
    }
}