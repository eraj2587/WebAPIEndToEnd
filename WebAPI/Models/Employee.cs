using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee { Id=1, Address="Pune", Name="Raj"},
                new Employee { Id=2, Address="Satara", Name="Ram"},
                new Employee { Id=3, Address="Mumbai", Name="Santosh"},
                new Employee { Id=4, Address="Sydney", Name="Ganesh"},
                new Employee { Id=5, Address="Perth", Name="Parag"},
            };
        }
    }
}