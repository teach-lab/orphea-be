using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Services;

public class TagService : ITagService
{
    private readonly ITagRepo _repo;
    private readonly IMapper _mapper;
    public TagService(ITagRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<TagCreateModel> CreateAsync(
        TagCreateModel model,
        CancellationToken cancellationToken
        )
    {
        var entity = _mapper.Map<TagCreateModel, TagEntity>(model);
        var addedEntity = await _repo.CreateAsync(entity, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<TagEntity, TagCreateModel>(addedEntity);

        return result;
    }

    public async Task<TagModel> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _repo.GetByIdAsync(id, cancellationToken);
        var result = _mapper.Map<TagEntity, TagModel>(entity);

        return result;
    }
    public async Task<TagModel> UpdateAsync(
        TagModel model,
        CancellationToken cancellationToken
        )
    {
        var entity = _mapper.Map<TagModel, TagEntity>(model);
        var updatedEntity = await _repo.UpdateAsync(entity, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<TagEntity, TagModel> (updatedEntity);

        return result;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(id, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
    }        
}

