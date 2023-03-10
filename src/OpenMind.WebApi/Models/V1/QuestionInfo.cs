namespace OpenMind.WebApi.Models.V1
{
    public class QuestionInfo
    {
        public int QuesitonId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<AnswerInfo> Answers { get; set; }
    }
}
