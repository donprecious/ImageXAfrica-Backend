namespace ImageAfricaProject.Dto
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public string Status { get; set; } 
        public virtual object Data { get; set; }
    }
}