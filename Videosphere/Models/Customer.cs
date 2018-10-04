using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //zeby uzywac [Required]
using System.Linq;
using System.Web;

namespace Videosphere.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] //required - nie moze byc nullable. string jest reference type wiec entity-framework ogarnia jako nvarchar (max) nullable.
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } //navigation property bcs it allows us to navigate from one type to another.

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //entity-framework rozpozna konwencje i potraktuje to jako foreign key.

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
    }
}