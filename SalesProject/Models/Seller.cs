using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} required.")]
        [StringLength(60, MinimumLength =3, ErrorMessage ="{0} size should be at least {2} characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Enter a valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} required.")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "{0} required.")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        
        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales (SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales (DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
