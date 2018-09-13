namespace BoomiSharp.Dtos.BoomiObjects
{
    public class ListenerStatus : IBoomiObject, ICanGet, ICanQuery
    {
        public string GetId()
        {
            throw new System.NotImplementedException();
        }

        public string ResponseStatusCode { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string ListenerId { get; set; }
    }
}
