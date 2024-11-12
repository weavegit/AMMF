
namespace Common.Entities
{
    public class TopicDto
    {
        public string TopicId { get; set; }

        public string TopicName { get; set; }


        public TopicDto()
        {
            TopicId = string.Empty;
            TopicName = string.Empty;

        }
        public TopicDto(string topicId, string topicName)
        {
            TopicId = topicId;
            TopicName = topicName;
        }
    }
}
