public class DynamicArray {
    
    private int[] arr;
    private int length;
    private int capacity;

    // Constructor to initialize the dynamic array
    public DynamicArray(int capacity) {
        this.capacity = capacity;
        this.length = 0;
        this.arr = new int[this.capacity];
    }

    // Get value at the i-th index
    public int Get(int i) {
        return arr[i];
    }

    // Insert value n at the i-th index
    public void Set(int i, int n) {
        arr[i] = n;
    }

    // Insert n in the last position of the array
    public void PushBack(int n) {
        if (length == capacity)
        {
            Resize();
        }
        arr[length] = n;
        length++;
    }

    // Remove the last element in the array
    public int PopBack() {
        if (length > 0)
        {
            // soft delete the last element
            length--;
        }
        return arr[length];
    }

    // Resize the array
    private void Resize() {
        capacity *= 2;
        int[] newArr = new int[capacity];
        for (int i = 0; i < length; i++)
        {
            newArr[i] = arr[i];
        }
        arr = newArr;
    }

    // Get the size of the array
    public int GetSize() {
        return length;
    }

    // Get the capacity of the array
    public int GetCapacity() {
        return capacity;
    }
}
