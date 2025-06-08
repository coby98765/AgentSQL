using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agent.Models;


namespace Agent.Models
    {
        public class Employee
            {
            private int _employeeNumber;
            private string _lastName;
            private string _firstName;
            private string _jobTitle;

            public Employee(int empNum, string FN, string LN, string JT)
                {
                this._firstName = FN;
                this._lastName = LN;
                this._jobTitle = JT;
                this._employeeNumber = empNum;
                }

            public void printDetails()
                {
                Console.WriteLine($"first name: {_firstName} last name: {_lastName}, job title: {_jobTitle}");
                }
            }
        }