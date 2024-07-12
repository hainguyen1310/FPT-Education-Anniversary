using AutoMapper;
using BusinessLogic.Model;
using FPTDTO;
using System.Reflection.Metadata;

namespace Lab1API.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
/*            CreateMap<Blog, BlogDTO>().ForMember(d=> d.UserName, o => o.MapFrom(src => src.UserPost.UserName));*/
            CreateMap<Topic, TopicDTO>().ForMember(d => d.TopicCategoryName, o => o.MapFrom(src => src.TopicCategory.TopicName));
		}
    }
}
