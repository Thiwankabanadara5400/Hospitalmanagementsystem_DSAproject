using hospital_management_system.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        PatientList patientList = new PatientList();
        PatientList leavedPatientList = new PatientList();

        while (true)
        {
            Console.WriteLine("What do you want?");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Leave Patient");
            Console.WriteLine("3. Sort Patient");
            Console.WriteLine("4. Exit");

            // Read and validate the choice
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.Trim(); // Trim any extra spaces
                bool isValidChoice = int.TryParse(input, out choice);

                if (isValidChoice && choice >= 1 && choice <= 4) // Validate range
                {
                    break; // Valid input, exit the loop
                }
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Patient Name: ");
                    string name = Console.ReadLine()?.Trim();

                    Console.Write("Enter Admission Date (yyyy-mm-dd): ");
                    DateTime admissionDate;
                    while (!DateTime.TryParse(Console.ReadLine()?.Trim(), out admissionDate))
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-mm-dd): ");
                    }

                    Console.Write("Enter Age: ");
                    int age;
                    while (!int.TryParse(Console.ReadLine()?.Trim(), out age))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid age: ");
                    }

                    Console.Write("Enter Admission Number: ");
                    int admissionNumber;
                    while (!int.TryParse(Console.ReadLine()?.Trim(), out admissionNumber))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid admission number: ");
                    }

                    patientList.AddPatient(new Patient(name, age, admissionDate, admissionNumber));
                    break;

                case 2:
                    Console.Write("Enter Admission Number: ");
                    int leaveAdmissionNumber;
                    while (!int.TryParse(Console.ReadLine()?.Trim(), out leaveAdmissionNumber))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid admission number: ");
                    }

                    Node current = patientList.Head;
                    while (current != null)
                    {
                        if (current.Patient.AdmissionNumber == leaveAdmissionNumber)
                        {
                            Console.Write("Enter Leave Date (yyyy-mm-dd): ");
                            DateTime leaveDate;
                            while (!DateTime.TryParse(Console.ReadLine()?.Trim(), out leaveDate))
                            {
                                Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-mm-dd): ");
                            }
                            current.Patient.LeaveDate = leaveDate;
                            leavedPatientList.AddPatient(current.Patient);
                            patientList.DeletePatient(leaveAdmissionNumber);
                            break;
                        }
                        current = current.Next;
                    }
                    break;
                case 3:
                    Console.WriteLine("1. Sort current patient by name");
                    Console.WriteLine("2. Sort current patient by admission date");
                    Console.WriteLine("3. Sort current patient by age");
                    Console.WriteLine("4. Sort leaved patient by name");
                    Console.WriteLine("5. Sort leaved patient by admission date");
                    Console.WriteLine("6. Sort leaved patient by age");
                    Console.WriteLine("7. Sort all registered patient by name");
                    Console.WriteLine("8. Sort all registered patient by admission date");
                    Console.WriteLine("9. Sort all registered patient by age");

                    int sortChoice;
                    while (true)
                    {
                        Console.Write("Enter your choice: ");
                        string sortInput = Console.ReadLine()?.Trim();
                        bool isValidSortChoice = int.TryParse(sortInput, out sortChoice);

                        if (isValidSortChoice && sortChoice >= 1 && sortChoice <= 9) // Validate range
                        {
                            break; // Valid input, exit the loop
                        }
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                    }

                    switch (sortChoice)
                    {
                        case 1:
                            patientList.QuickSortByName((p1, p2) => string.Compare(p1.Name, p2.Name));
                            patientList.PrintPatients();
                            break;
                        case 2:
                            patientList.MergeSortByAdmissionDate((p1, p2) => DateTime.Compare(p1.AdmissionDate, p2.AdmissionDate));
                            patientList.PrintPatients();
                            break;
                        case 3:
                            patientList.BubbleSortByAge();
                            patientList.PrintPatients();
                            break;
                        case 4:
                            leavedPatientList.QuickSortByName((p1, p2) => string.Compare(p1.Name, p2.Name));
                            leavedPatientList.PrintPatients();
                            break;
                        case 5:
                            leavedPatientList.MergeSortByAdmissionDate((p1, p2) => DateTime.Compare(p1.AdmissionDate, p2.AdmissionDate));
                            leavedPatientList.PrintPatients();
                            break;
                        case 6:
                            leavedPatientList.BubbleSortByAge();
                            leavedPatientList.PrintPatients();
                            break;
                        case 7:
                            PatientList allPatients = new PatientList();
                            Node currentPatient = patientList.Head;
                            while (currentPatient != null)
                            {
                                allPatients.AddPatient(currentPatient.Patient);
                                currentPatient = currentPatient.Next;
                            }
                            Node currentLeavedPatient = leavedPatientList.Head;
                            while (currentLeavedPatient != null)
                            {
                                allPatients.AddPatient(currentLeavedPatient.Patient);
                                currentLeavedPatient = currentLeavedPatient.Next;
                            }
                            allPatients.QuickSortByName((p1, p2) => string.Compare(p1.Name, p2.Name));
                            allPatients.PrintPatients();
                            break;
                        case 8:
                            PatientList allPatients2 = new PatientList();
                            Node currentPatient2 = patientList.Head;
                            while (currentPatient2 != null)
                            {
                                allPatients2.AddPatient(currentPatient2.Patient);
                                currentPatient2 = currentPatient2.Next;
                            }
                            Node currentLeavedPatient2 = leavedPatientList.Head;
                            while (currentLeavedPatient2 != null)
                            {
                                allPatients2.AddPatient(currentLeavedPatient2.Patient);
                                currentLeavedPatient2 = currentLeavedPatient2.Next;
                            }
                            allPatients2.MergeSortByAdmissionDate((p1, p2) => DateTime.Compare(p1.AdmissionDate, p2.AdmissionDate));
                            allPatients2.PrintPatients();
                            break;
                        case 9:
                            PatientList allPatients3 = new PatientList();
                            Node currentPatient3 = patientList.Head;
                            while (currentPatient3 != null)
                            {
                                allPatients3.AddPatient(currentPatient3.Patient);
                                currentPatient3 = currentPatient3.Next;
                            }
                            Node currentLeavedPatient3 = leavedPatientList.Head;
                            while (currentLeavedPatient3 != null)
                            {
                                allPatients3.AddPatient(currentLeavedPatient3.Patient);
                                currentLeavedPatient3 = currentLeavedPatient3.Next;
                            }
                            allPatients3.BubbleSortByAge();
                            allPatients3.PrintPatients();
                            break;
                    }
                    break;



                case 4:
                    return;
            }
        }
    }
}