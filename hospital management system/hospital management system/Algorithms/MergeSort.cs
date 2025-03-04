using hospital_management_system.Models;

namespace hospital_management_system.Algorithms
{
    internal class MergeSort
    {
        public static Node Sort(Node start, Func<Patient, Patient, int> compare)
        {
            if (start == null || start.Next == null) return start;

            Node middle = GetMiddle(start);
            Node nextOfMiddle = middle.Next;
            middle.Next = null;

            Node left = Sort(start, compare);
            Node right = Sort(nextOfMiddle, compare);

            return Merge(left, right, compare);
        }

        private static Node Merge(Node left, Node right, Func<Patient, Patient, int> compare)
        {
            Node result = null;

            if (left == null) return right;
            if (right == null) return left;

            if (compare(left.Patient, right.Patient) <= 0)
            {
                result = left;
                result.Next = Merge(left.Next, right, compare);
            }
            else
            {
                result = right;
                result.Next = Merge(left, right.Next, compare);
            }

            return result;
        }

        private static Node GetMiddle(Node head)
        {
            if (head == null) return head;

            Node slow = head;
            Node fast = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }
    }
}
