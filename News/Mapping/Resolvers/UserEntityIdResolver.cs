using News.Entities.Models;
using News.Entities;
using AutoMapper;

namespace News.Mapping.Resolvers;

internal class UserEntityIdResolver : IValueResolver<UserCreateModel, UserEntity, Guid>
{
    public Guid Resolve(UserCreateModel source, UserEntity destination, Guid destMember, ResolutionContext context)
    {
        return Guid.NewGuid();
    }
}