using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POEOne.Models
{
   
    
        public enum ApprovalSet
        {
            // a list of fixed values
            // repressent staus of a claim 
            Pending,
            Approved,
            Disapproved,
        }
        // class
        public class ClaimApproval
        {
            [Key] //pk

            [Display(Name = "Claim Approval ID")] // tells MVC how to display in the UI
            public int ClaimApprovalId { get; set; }


            [Display(Name = "Approval Officer ")]
            public string? Approver { get; set; }


            [Display(Name = "Approval Date")]
            public DateTime ApprovalDate { get; set; }

            [Display(Name = "Status")]
            public ApprovalSet Approve { get; set; }

            [Display(Name = "Lecturer ID")]
            public int LecturerID { get; set; } //fk 
            [ForeignKey("LecturerID")]
            public Lecturer? Lecturers { get; set; }
        }
    }


