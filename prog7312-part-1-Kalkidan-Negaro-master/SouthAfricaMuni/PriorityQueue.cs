using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<(T item, int priority)> elements = new List<(T, int)>();

    public bool IsEmpty => elements.Count == 0;

    public void Enqueue(T item, int priority)
    {
        elements.Add((item, priority));
        int ci = elements.Count - 1; // child index
        while (ci > 0)
        {
            int pi = (ci - 1) / 2; // parent index
            if (elements[ci].priority >= elements[pi].priority) break; // parent is smaller or equal
            (elements[pi], elements[ci]) = (elements[ci], elements[pi]); // swap
            ci = pi;
        }
    }

    public T Dequeue()
    {
        int li = elements.Count - 1; // last index
        (elements[0], elements[li]) = (elements[li], elements[0]); // swap
        var result = elements[li].item;
        elements.RemoveAt(li);

        // Reorder the heap
        int pi = 0; // parent index
        while (true)
        {
            int ci = pi * 2 + 1; // left child index
            if (ci >= elements.Count) break; // if there is no child
            int ri = ci + 1; // right child index
            if (ri < elements.Count && elements[ri].priority < elements[ci].priority) ci = ri; // get the smaller child
            if (elements[pi].priority <= elements[ci].priority) break; // parent is smaller or equal
            (elements[pi], elements[ci]) = (elements[ci], elements[pi]); // swap
            pi = ci; // move down
        }

        return result;
    }
}
