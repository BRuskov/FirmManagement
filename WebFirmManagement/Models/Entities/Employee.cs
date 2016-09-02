using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebFirmManagment.Models.Entities
{
    public class Employee
    {
        public Employee() { }

        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime WorkPermitDate { get; set; }

        public bool Gender { get; set; } // 0 - man, 1 - woman 

        public bool isOperator { get; set; }

        public FirmDepartment Workplace { get; set; }

        public string Hobbies { get; set; }

        public double Salary { get; set; }
    }

    public enum FirmDepartment
    {
        Production,
        Research,
        Marketing,
        Purchasing,
        Accounting
    }
}