using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMvc.Models;

namespace VidlyMvc.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetters { get; set; }

       // public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

       // [Min18YearsIfAMember]
        public DateTime? Dob { get; set; }
    }
}