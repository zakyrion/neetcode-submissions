public class DynamicArray
{
    private readonly int _initialCapacity;
    private int[][] _arrays;

    private int _capacity;
    private int _count;
    private int _lastChunkIndex;

    public DynamicArray(int capacity)
    {
        _arrays = new int[1][];
        _initialCapacity = capacity;

        _arrays[0] = new int[_initialCapacity];

        _capacity = capacity;
        _count = 0;
    }

    public int Get(int i)
    {
        if (i >= _count)
            throw new IndexOutOfRangeException();

        var arrayIndex = i / _initialCapacity;
        var indexInside = i % _initialCapacity;
        return _arrays[arrayIndex][indexInside];
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public int GetSize()
    {
        return _count;
    }

    public int PopBack()
    {
        if (--_count < 0)
            throw new IndexOutOfRangeException();

        var i = _count;
        var arrayIndex = i / _initialCapacity;
        var indexInside = i % _initialCapacity;

        return _arrays[arrayIndex][indexInside];
    }

    public void PushBack(int n)
    {
        if (++_count > _capacity)
        {
            Resize();
        }

        var i = _count-1;
        var arrayIndex = i / _initialCapacity;
        var indexInside = i % _initialCapacity;

        if(_lastChunkIndex <= arrayIndex)
        {
            for (var j = 1; j <= arrayIndex - _lastChunkIndex; j++)
            {
                _arrays[_lastChunkIndex + j] = new int[_initialCapacity];
            }
            _lastChunkIndex = arrayIndex;
        }

        _arrays[arrayIndex][indexInside] = n;
    }

    public void Set(int i, int n)
    {
        if (i >= _count)
            throw new IndexOutOfRangeException();

        var arrayIndex = i / _initialCapacity;
        var indexInside = i % _initialCapacity;

        if(_lastChunkIndex < arrayIndex)
        {
            for(int j = 0; j < arrayIndex - _lastChunkIndex; j++)
            {
                _arrays[j] = new int[_initialCapacity];
            }
            _lastChunkIndex = arrayIndex;
        }

        _arrays[arrayIndex][indexInside] = n;
    }

    private void Resize()
    {
        var oldCapacity = _capacity;
        _capacity *= 2;

        Array.Resize(ref _arrays, _capacity / _initialCapacity);
        _lastChunkIndex++;
        _arrays[_lastChunkIndex] = new int[_initialCapacity];  
    }

    private int SizeOf(int deep = 0)
    {
        return _initialCapacity * (int)Math.Pow(2, deep);
    }
}