namespace BoomiSharp.Dtos
{
    public class DeleteResult
    {
        public DeleteResult()
        {
            this.Success = true;
        }

        public DeleteResult(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
        }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError => ErrorMessage != null;
    }
}
