namespace hospital_management_system.Models
{
    public class Node
    {
        public Patient Patient { get; set; }
        public Node Next { get; set; }

        public Node(Patient patient)
        {
            Patient = patient;
            Next = null;
        }
    }
}