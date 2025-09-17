using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POEOne.Models
{
    public class Status
    {
        [Key]

        [Display(Name = "Claim ID")]
        public int ClaimId { get; set; }

        [Display(Name = "Lecturer ID")]
        public int LecturerID { get; set; }
        [ForeignKey("LecturerID")]
        public Lecturer? Lecturers { get; set; }

        [Display(Name = "Claim Approval ID")]
        public int? ClaimApprovalId { get; set; }
        [ForeignKey("ClaimApprovalId")]
        public ClaimApproval? ClaimApproval { get; set; }

        public ApprovalSet Approve { get; set; }
    }
}


    