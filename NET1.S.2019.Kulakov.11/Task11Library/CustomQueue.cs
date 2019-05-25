namespace Task11Library
{
    using System;
    using System.Collections;

    public class CustomQueue<T> : IEnumerable
    {
        private int start = 0;
        private int end = 0;
        private int count = 0;
        private int capacity = 10;
        private T[] items;

        public CustomQueue()
        {
            items = new T[Capacity];
        }

        public CustomQueue(int capacity)
        {
            this.capacity = capacity;
        }

        /// <summary>
        /// Количество элементов в очереди
        /// </summary>
        public int Count { get => this.count; }

        /// <summary>
        /// true если очередь пуста, иначе false.
        /// </summary>
        public bool IsEmpty { get => Count == 0 ? true : false; }

        public int Capacity { get => capacity; }

        public void UpSize()
        {
            T[] tmp = new T[items.Length * 2];
            int curr = start;
            for (int i = 0; i < count; i++)
            {
                tmp[i] = items[curr];
                curr = NextItem(curr);
            }

            start = 0;
            end = count;
            items = tmp;
            capacity = items.Length;
        }

        /// <summary>
        /// Проверяет находится ли элемент в очереди
        /// </summary>
        /// <param name="item">Искомый элемент</param>
        /// <returns>true - если элемент есть в очереди, false - если элемента нет в очереди</returns>
        public bool Contains(T item)
        {
            for (int i = start; i <= end; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// добавляет элемент в конец очереди
        /// </summary>
        public void Enqueue(T item) // добавить в конец
        {
            if (count == Capacity)
            {
                UpSize();
                items[end] = item;
                end = NextItem(end);
            }
            else
            {
                items[end] = item;
                end = NextItem(end);
            }

            count++;
        }

        /// <summary>
        /// Очищает очередь
        /// </summary>
        public void Clear()
        {
            start = 0;
            end = 0;
            count = 0;
            capacity = 10;
            items = new T[10];
        }

        /// <summary>
        /// Извлекает и возвращает первый элемент очереди
        /// </summary>
        public T Dequeue() // извлекает из начала
        {
            if (count > 0)
            {
                T result = items[start];
                start = NextItem(start);
                count--;

                return result;
            }

            throw new InvalidOperationException("Очередь пуста!");
        }

        /// <summary>
        /// возвращает первый элемент из начала очереди без его удаления
        /// </summary>
        public T Peek()
        {
            return items[start];
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }

        private int NextItem(int current)
        {
            if (current == Capacity - 1)
            {
                return 0;
            }

            return current + 1;
        }
    }
}
