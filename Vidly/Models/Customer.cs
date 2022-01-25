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
        
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSuscribedToNewsLetter { get; set; }

        public bool IsDelinquent { get; set; }

        [Display(Name="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Required]
        [Display(Name = "Limit Of Movies Rented")]
        [Range(1, 20)]
        public int LimitOfMoviesRented { get; set; }

        [Required]
        [Display(Name = "Movies Rented")]
        public int MoviesRented { get; set; }
    }
}