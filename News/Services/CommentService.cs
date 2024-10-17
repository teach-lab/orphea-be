using AutoMapper;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;
using System.Threading;

namespace News.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepo _repo;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<CommentResponseModel> CreateAsync(
        CommentCreateModel comment,
        CancellationToken cancellationToken
        )
    {
        var entity = _mapper.Map<CommentCreateModel, CommentEntity>(comment);
        var addedEntity = await _repo.CreateAsync(entity, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<CommentEntity, CommentResponseModel>(addedEntity);

        return result;
    }

    public async Task<CommentModel> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _repo.GetByIdAsync(id, cancellationToken);
        var result = _mapper.Map<CommentEntity, CommentModel>(entity);

        return result;
    }   

    public async Task<CommentResponseModel> UpdateAsync(
        CommentUpdateModel comment,
        string id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _repo.GetByIdAsync(Guid.Parse(id), cancellationToken);
        entity.Content = comment.Content;
        var updatedEntity = await _repo.UpdateAsync(entity, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<CommentEntity, CommentResponseModel>(updatedEntity);

        return result;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(id, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
    }
}