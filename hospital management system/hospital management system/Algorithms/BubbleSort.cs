using hospital_management_system.Models;

namespace hospital_management_system.Algorithms
{
    internal class BubbleSort
    {
        public static void SortByName(PatientList patientList)
        {
            if (patientList.Head == null) return;

            bool swapped;
            do
            {
                swapped = false;
                Node current = patientList.Head;
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
                            patientList.Head = temp;
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
    }
}