using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMvc.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }//byte coz 4 tyoes of membership
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFee { get; set; } //upto $300
        public byte DurationInMonths { get; set; } //byte coz ony 12 possible values
        public byte DiscountRate { get; set; } //byte  coz upto 100 max discount
    }
}