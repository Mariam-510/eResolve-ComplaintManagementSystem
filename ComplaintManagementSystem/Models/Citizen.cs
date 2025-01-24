using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Models
{
    public class Citizen
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(11)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        #region Navigation Prop
        public virtual Account Account { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>(); 
        #endregion

    }
}
