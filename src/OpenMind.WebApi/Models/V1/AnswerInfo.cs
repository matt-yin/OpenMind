namespace OpenMind.WebApi.Models.V1
{
    public class AnswerInfo
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
