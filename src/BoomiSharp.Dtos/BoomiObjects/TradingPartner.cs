using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class TradingPartner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TradingPartnerCategory[] Category { get; set; }
    }
}
