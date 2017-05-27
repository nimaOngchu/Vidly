using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubcribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Types")]
        public byte MembershipTypeID { set; get; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<DateTime> BirthDate { get; set; }


    }
}