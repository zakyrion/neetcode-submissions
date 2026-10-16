public class LinkedList {

    class Node
    {
        private int _value;
        private Node _next;

        public Node()
        {

        }

        public Node(int val)
        {
            _value = val;
        }

        public Node(int val, Node next)
        {
            _value = val;
            _next = next;
        }

        public bool TryMoveNext(out Node next)
        {
            next = _next;

            return _next != null;
        }

        public Node GetNext()
        {
            return _next;
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetNext(Node next)
        {
            _next = next;
        }
    }

    int _count;
    Node _head;

    public LinkedList() {
        _head = new Node();
    }

    public int Get(int index) {

        if(_count == 0 || index >= _count)
            return -1;

        var current = _head;
        while(index > 0)
        {
            current = current.GetNext();
            index--;
        }

        return current.GetValue();
    }

    public void InsertHead(int val) {
        if(_count == 0)
            _head = new Node(val);
        else
            _head = new Node(val, _head);

        _count++;
    }

    public void InsertTail(int val) {

        if(_count == 0)
            _head = new Node(val);
        else
        {
            var last = _head;
            for(int i = 0; i < _count - 1; i++)
            {
                last = last.GetNext();
            }

            last.SetNext(new Node(val));
        }

        _count++;
    }

    public bool Remove(int index) {

        if(index < 0 || index >= _count)
            return false;

        if(index == 0)
        {
            _head = _head.GetNext();
            _count--;
            return true;
        }

        var current = _head;
        Node prev = null;

        for(int i = 0; i < index; i++)
        {
            prev = current;
            current = current.GetNext();
        }
        
        if(prev != null)
            prev.SetNext(current.GetNext());

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
}