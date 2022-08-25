using AppStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Models
{
    public class ShopModel
    {
        public string Name { get; set; }
        public AppType Type { get; set; }
        public string CodeApp { get; set; }
        public decimal Value { get; set; }
    }
}
