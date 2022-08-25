using AppStore.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Entities
{
    public class Purchase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
        public string SecurityCode { get; set; }
        public string TaxNumber { get; set; }
        public string CodeApp { get; set; }
        public PurchaseStatus Status { get; set; }
    }
}
