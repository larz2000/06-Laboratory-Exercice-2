using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeNamespace
{
    internal class Employee
    {
        private string Employee_ID;
        private string First_Name;
        private string Last_Name;
        private string position;

        public Employee() 
        {
            this.EmployeeID = "INVALID";
            this.FirstName = "INVALID";
            this.LastName = "INVALID";
            this.position = "INVALID";
        }
        public Employee(string employee_id, string first_name, string last_name, string _position) 
        { 
            EmployeeID=employee_id;
            FirstName=first_name;
            LastName=last_name;
            position=_position;
        }

        public string EmployeeID 
        {
            get { return this.Employee_ID; }
            set { this.Employee_ID = value; }
        }
        public string FirstName 
        { 
            get { return this.First_Name; } 
            set { this.First_Name = value; } 
        }
        public string LastName 
        {
            get { return this.Last_Name; }
            set { this.Last_Name = value;}
        }
        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
    }
}
