public class DynamicArray
{
    private readonly int _first;
    private readonly int[][] _blocks = new int[32][];
    private int _blockCount;
    private int _capacity;
    private int _length;

    public DynamicArray(int capacity)
    {
        _first = capacity;
        _capacity = capacity;
        _blocks[0] = new int[capacity];
        _blockCount = 1;
    }

    public int Get(int i)
    {
        if ((uint)i >= (uint)_length)
            throw new IndexOutOfRangeException();

        Locate(i, out var block, out var offset);
        return _blocks[block][offset];
    }

    public void Set(int i, int n)
    {
        if ((uint)i >= (uint)_length)
            throw new IndexOutOfRangeException();

        Locate(i, out var block, out var offset);
        _blocks[block][offset] = n;
    }

    public void PushBack(int n)
    {
        if (_length == _capacity)
            Grow();

        Locate(_length, out var block, out var offset);
        _blocks[block][offset] = n;
        _length++;
    }

    public int PopBack()
    {
        if (_length == 0)
            throw new InvalidOperationException();

        _length--;
        Locate(_length, out var block, out var offset);
        return _blocks[block][offset];
    }

    public int GetSize() => _length;

    public int GetCapacity() => _capacity;

    private void Grow()
    {
        _blocks[_blockCount++] = new int[_capacity];
        _capacity *= 2;
    }

    private void Locate(int i, out int block, out int offset)
    {
        var q = i / _first;

        if (q == 0)
        {
            block = 0;
            offset = i;
            return;
        }

        var log = (int)((BitConverter.DoubleToInt64Bits(q) >> 52) - 1023);
        block = log + 1;
        offset = i - (_first << log);
    }
}