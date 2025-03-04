using System;

namespace hospital_management_system.Models
{
    public class PatientList
    {
        private Node head;

        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        public void AddPatient(Patient patient)
        {
            Node newNode = new Node(patient);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void DeletePatient(int admissionNumber)
        {
            if (head == null) return;

            if (head.Patient.AdmissionNumber == admissionNumber)
            {
                head = head.Next;
                return;
            }

            Node current = head;
            while (current.Next != null && current.Next.Patient.AdmissionNumber != admissionNumber)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public void PrintPatients()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Patient);
                current = current.Next;
            }
        }

        public void BubbleSortByName()
        {
            if (head == null) return;

            bool swapped;
            do
            {
                swapped = false;
                Node current = head;
                Node previous = null;

                while (current.Next != null)
                {
                    if (string.Compare(current.Patient.Name, current.Next.Patient.Name) > 0)
                    {
                        Node temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;

                        if (previous == null)
                        {
                            head = temp;
                        }
                        else
                        {
                            previous.Next = temp;
                        }

                        previous = temp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
            } while (swapped);
        }

        public void BubbleSortByAge()
        {
            if (head == null) return;

            bool swapped;
            do
            {
                swapped = false;
                Node current = head;
                Node previous = null;

                while (current.Next != null)
                {
                    if (current.Patient.Age > current.Next.Patient.Age)
                    {
                        Node temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;

                        if (previous == null)
                        {
                            head = temp;
                        }
                        else
                        {
                            previous.Next = temp;
                        }

                        previous = temp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
            } while (swapped);
        }

        public void MergeSortByName(Func<Patient, Patient, int> compare)
        {
            head = MergeSort(head, compare);
        }

        public void MergeSortByAdmissionDate(Func<Patient, Patient, int> compare)
        {
            head = MergeSort(head, compare);
        }

        private Node MergeSort(Node start, Func<Patient, Patient, int> compare)
        {
            if (start == null || start.Next == null) return start;

            Node middle = GetMiddle(start);
            Node nextOfMiddle = middle.Next;
            middle.Next = null;

            Node left = MergeSort(start, compare);
            Node right = MergeSort(nextOfMiddle, compare);

            return Merge(left, right, compare);
        }

        private Node Merge(Node left, Node right, Func<Patient, Patient, int> compare)
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

        private Node GetMiddle(Node head)
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

        public void QuickSortByName(Func<Patient, Patient, int> compare)
        {
            head = QuickSort(head, compare);
        }

        private Node QuickSort(Node start, Func<Patient, Patient, int> compare)
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

            smaller = QuickSort(smaller, compare);
            greater = QuickSort(greater, compare);

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