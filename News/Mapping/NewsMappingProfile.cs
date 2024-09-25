using AutoMapper;
using News.Entities;
using News.Entities.Models;
using News.Mapping.Resolvers;

namespace News.Mapping;

public class NewsMappingProfile : Profile
{
    public NewsMappingProfile()
    {
        CreateMap<CommentModel, CommentEntity>().ReverseMap();
        CreateMap<UserModel, UserEntity>().ReverseMap();

        CreateMap<UserCreateModel, UserEntity>()
            .ForMember(dest => dest.Password, act => act.Ignore())
            .ForMember(dest => dest.Id, opt => opt.MapFrom<UserEntityIdResolver>())
            .ForMember(dest => dest.Salt, opt => opt.MapFrom<UserEntityPasswordResolver>());
    }
}