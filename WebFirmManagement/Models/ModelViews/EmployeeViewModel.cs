using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebFirmManagment.Models.Entities;

namespace WebFirmManagment.Models.ViewModels
{
    public class EmployeeEntryModel
    {
        [Required(ErrorMessage = "Employee's first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Employee's last name is required")]
        public string LastName { get; set; }
    }

    public class EmployeeManagementPanelModel
    {
        public Employee SelectedUser { get; set; }
        public List<Employee> FirmEmployees { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime WorkPermitDate { get; set; }

        public bool Gender { get; set; }

        public bool isOperator { get; set; }

        public FirmDepartment Workplace { get; set; }
    }

    public class EmployeeSearch
    {
        public EmployeeSearch()
        {
            this.SearchedEmployees = new List<Employee>();
        }
        public string GenderString { get; set; }
        public string NameString { get; set; }
        public string WorkplaceString { get; set; }
        public string HobbyString { get; set; }
        public List<Employee> SearchedEmployees { get; set; }
    }
    
}