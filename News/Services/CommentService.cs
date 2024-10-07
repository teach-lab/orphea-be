using AutoMapper;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;

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

    public async Task<CommentModel> GetCommentById(Guid id)
    {
        var entity = await _repo.GetCommentById(id);
        var result = _mapper.Map<CommentEntity, CommentModel>(entity);

        return result;
    }

    public async Task<CommentResponseModel> CreateComment(CommentCreateModel comment)
    {
        var entity = _mapper.Map<CommentCreateModel, CommentEntity>(comment);
        var addedEntity = await _repo.CreateComment(entity);
        var result = _mapper.Map<CommentEntity, CommentResponseModel>(addedEntity);

        return result;
    }

    public async Task<CommentResponseModel> UpdateComment(CommentUpdateModel comment, string id)
    {
        var entity = await _repo.GetCommentById(Guid.Parse(id));

        entity.Content = comment.Content;

        var updatedEntity = await _repo.UpdateComment(entity);
        var result = _mapper.Map<CommentEntity, CommentResponseModel>(updatedEntity);

        return result;
    }

    public async Task DeleteComment(Guid id)
    {
        await _repo.DeleteComment(id);
    }
}