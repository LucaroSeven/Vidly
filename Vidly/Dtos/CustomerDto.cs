using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSuscribedToNewsLetter { get; set; }

        /*[Min18YearsIfAMember]*/
        public DateTime? Birthday { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto membershipType { get; set; }

        [Range(1, 20)]
        public int LimitOfMoviesRented { get; set; }

        public int MoviesRented { get; set; }
    }
}