using AutoMapper;
using News.Entities;
using News.Entities.Models;
using News.Mapping.Resolvers;

namespace News.Mapping;

public class NewsMappingProfile : Profile
{
    public NewsMappingProfile()
    {
        CreateMap<CommentEntity, CommentModel>().ReverseMap();
      
        CreateMap<CommentCreateModel, CommentEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom<CommentEntityIdResolver>());
        CreateMap<CommentEntity, CommentResponseModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
        CreateMap<UserModel, UserEntity>().ReverseMap();
        CreateMap<ArticleModel, ArticleEntity>().ReverseMap();
        CreateMap<TagModel, TagEntity>().ReverseMap();
        CreateMap<ArticleTagModel, ArticleTagEntity>().ReverseMap();
        CreateMap<PublisherModel, PublisherEntity>().ReverseMap();
        CreateMap<UserResponseModel, UserEntity>().ReverseMap();
        CreateMap<UserCreateModel, UserEntity>()
            .ForMember(dest => dest.Password, act => act.Ignore())
            .ForMember(dest => dest.Id, opt => opt.MapFrom<UserEntityIdResolver>())
            .ForMember(dest => dest.Salt, opt => opt.MapFrom<UserEntityPasswordResolver>());
    }
    // Update with new mapping and new resolver ? 
}