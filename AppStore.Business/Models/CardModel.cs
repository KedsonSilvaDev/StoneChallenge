using AppStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Models
{
    public class CardModel
    {
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
        public string SecurityCode { get; set; }
        public string TaxNumber { get; set; }
    }
}
