using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [Required]
        [MinLength(11)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        
        [MaxLength(100)]
        public string Address {  get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        
        public DateTime? ResolutionDate { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        
        [ForeignKey("Citizen")]
        public int CitizenId { get; set; }
        
        [ForeignKey("AssignedEmployee")]
        public int? AssignedEmployeeId { get; set; }

        #region Navigation Prop
        public City City { get; set; }
        public virtual Department Department { get; set; }
        public virtual Citizen Citizen { get; set; }
        public virtual Employee? AssignedEmployee { get; set; } 
        #endregion


    }
}
