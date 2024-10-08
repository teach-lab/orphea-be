﻿using AutoMapper;
using News.Entities;
using News.Entities.Models;

namespace News.Mapping;

public class NewsMappingProfile : Profile
{
    public NewsMappingProfile()
    {
        CreateMap<CommentEntity, CommentModel>().ReverseMap();
        CreateMap<CommentUpdateModel, CommentEntity>().ReverseMap();
        CreateMap<CommentCreateModel, CommentEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<CommentEntity, CommentResponseModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
        CreateMap<UserModel, UserEntity>().ReverseMap();
        CreateMap<ArticleModel, ArticleEntity>().ReverseMap();
        CreateMap<TagModel, TagEntity>().ReverseMap();
        CreateMap<ArticleTagModel, ArticleTagEntity>().ReverseMap();
        CreateMap<PublisherModel, PublisherEntity>().ReverseMap();
        CreateMap<UserResponseModel, UserEntity>().ReverseMap();
    }
}