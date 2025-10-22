using System;
using System.Collections.Generic;

namespace SouthAfricaMuni
{
    public class MaxHeap
    {
        private List<IssueReport> heap;

        public MaxHeap()
        {
            heap = new List<IssueReport>();
        }

        // Swap two elements in the heap
        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Get the parent index of a given index
        private int Parent(int index) => (index - 1) / 2;

        // Get the left child index of a given index
        private int LeftChild(int index) => 2 * index + 1;

        // Get the right child index of a given index
        private int RightChild(int index) => 2 * index + 2;

        // Extract the numeric part of the IssueId
        private int ExtractNumericId(string issueId)
        {
            if (int.TryParse(issueId.Substring(5), out int numericId))
            {
                return numericId;
            }
            throw new FormatException($"Invalid IssueId format: {issueId}");
        }

        // Insert a new element into the heap
        public void Insert(IssueReport issue)
        {
            heap.Add(issue);
            HeapifyUp(heap.Count - 1);
        }

        // Maintain the heap property while moving the element up the heap
        private void HeapifyUp(int index)
        {
            while (index > 0 && heap[Parent(index)].ReportedDate < heap[index].ReportedDate)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        // Remove and return the root element (max element)
        public IssueReport RemoveMax()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

            var root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return root;
        }

        // Maintain the heap property while moving the element down the heap
        private void HeapifyDown(int index)
        {
            int left = LeftChild(index);
            int right = RightChild(index);
            int largest = index;

            if (left < heap.Count && heap[left].ReportedDate > heap[largest].ReportedDate)
                largest = left;

            if (right < heap.Count && heap[right].ReportedDate > heap[largest].ReportedDate)
                largest = right;

            if (largest != index)
            {
                Swap(index, largest);
                HeapifyDown(largest);
            }
        }

        // Return the current size of the heap
        public int Size()
        {
            return heap.Count;
        }

        // Check if the heap is empty
        public bool IsEmpty()
        {
            return heap.Count == 0;
        }
    }
}
