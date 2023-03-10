namespace OpenMind.WebApi.Models.V2
{
    public class AnswerInfo
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
    }
}
