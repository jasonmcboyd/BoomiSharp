using System;

namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Account : IBoomiObject, ICanGet, ICanQuery, ICanCreate, ICanDelete
    {
        public string GetId() => this.AccountId;
        public string AccountId { get; set; }
        public string Name { get; set; }
        public AccountStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool WidgetAccount { get; set; }
        public bool SuggestionsEnabled { get; set; }
        public bool SupportAccess { get; set; }
        public SupportLevel SupportLevel { get; set; }
        public AccountLicensing Licensing { get; set; }
    }
}
