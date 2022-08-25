using AppStore.Business.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string TaxNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Number { get; set; }
        
        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

    }
}
