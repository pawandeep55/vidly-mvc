using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VidlyMvc.Models
{
    [Bind(Exclude="Id")]
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetters { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? Dob { get; set; }
    }
}