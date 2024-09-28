using News.Entities.Models;
using News.Entities;
using AutoMapper;

namespace News.Mapping.Resolvers;

internal class CommentEntityIdResolver : IValueResolver<CommentCreateModel, CommentEntity, Guid>
{
    public Guid Resolve(CommentCreateModel source, CommentEntity destination, Guid destMember, ResolutionContext context)
    {
        return Guid.NewGuid();
    }
}