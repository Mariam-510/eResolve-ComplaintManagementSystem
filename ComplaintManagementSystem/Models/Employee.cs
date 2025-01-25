using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
        
        [Required]
        [MinLength(11)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        #region Navigation Prop
        public City City { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>(); 
        #endregion

    }
}
