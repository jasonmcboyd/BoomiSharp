namespace BoomiSharp.Dtos.BoomiObjects
{
    public class Field
    {
        public string Id { get; set; }
        public bool ComponentOverride { get; set; }
        public bool EncryptedValueSet { get; set; }
        public bool UsesEncryption { get; set; }
        public string Value { get; set; }

    }
}
