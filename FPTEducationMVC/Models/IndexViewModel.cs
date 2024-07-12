using BusinessLogic.Model;
using FPTDTO;

namespace FPTEducationMVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Achievement> Achievements { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<FeedBacks> FeedBacks { get; set; }
        public IEnumerable<FPTHistory> FPTHistorys { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<TopicDTO> TopicDTOs { get; set; }
        public IEnumerable<User> User { get; set; }
        public IEnumerable<TopicCategory> TopicCategoriess { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}
