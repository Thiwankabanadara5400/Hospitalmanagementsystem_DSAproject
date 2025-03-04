using System;

namespace hospital_management_system.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public int AdmissionNumber { get; set; }

        public Patient(string name, int age, DateTime admissionDate, int admissionNumber)
        {
            Name = name;
            Age = age;
            AdmissionDate = admissionDate;
            AdmissionNumber = admissionNumber;
        }

        public override string ToString()
        {
            return $"Admission Number: {AdmissionNumber}, Name: {Name}, Age: {Age}, Admission Date: {AdmissionDate.ToShortDateString()}, Leave Date: {LeaveDate.ToShortDateString()}";
        }
    }
}