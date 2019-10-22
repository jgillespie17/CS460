namespace HW3
{
    public interface IQueueInterface<T>
    {
        T Push(T element);

        T Pop();

        T Peek();

        bool IsEmpty();
    }
}