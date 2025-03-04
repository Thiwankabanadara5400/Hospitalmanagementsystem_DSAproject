using hospital_management_system.Models;

namespace hospital_management_system.Algorithms
{
    internal class QuickSort
    {
        public static Node Sort(Node start, Func<Patient, Patient, int> compare)
        {
            if (start == null || start.Next == null) return start;

            Node pivot = start;
            Node smaller = null;
            Node greater = null;
            Node current = start.Next;

            while (current != null)
            {
                if (compare(current.Patient, pivot.Patient) <= 0)
                {
                    Node temp = current.Next;
                    current.Next = smaller;
                    smaller = current;
                    current = temp;
                }
                else
                {
                    Node temp = current.Next;
                    current.Next = greater;
                    greater = current;
                    current = temp;
                }
            }

            pivot.Next = null;

            smaller = Sort(smaller, compare);
            greater = Sort(greater, compare);

            if (smaller == null)
            {
                pivot.Next = greater;
                return pivot;
            }

            Node tempSmaller = smaller;
            while (tempSmaller.Next != null)
            {
                tempSmaller = tempSmaller.Next;
            }

            tempSmaller.Next = pivot;
            pivot.Next = greater;

            return smaller;
        }
    }
}