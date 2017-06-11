using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubcribedToNewsletter { get; set; }
       
        public byte MembershipTypeID { set; get; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Min18YearsIfAMember]
        public Nullable<DateTime> BirthDate { get; set; }
    }
}