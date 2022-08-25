using AppStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Models
{
    public class PurchaseModel
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public CardType CardType { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        [Required]
        public string TaxNumber { get; set; }

        [Required]
        public string CodeApp { get; set; }
    }
}
