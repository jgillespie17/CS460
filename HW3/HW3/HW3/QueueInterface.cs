using System;

namespace HW3
{


    public interface QueueInterface<T>
    {
        T push(T element);

        T pop();

        T peek();

        bool isEmpty();
    }
}