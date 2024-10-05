using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
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
    public async Task<TagModel> Add(TagModel model)
    {
        var entity = _mapper.Map<TagModel, TagEntity>(model);
        var addedEntity = await _repo.Add(entity);
        var result = _mapper.Map<TagEntity, TagModel>(addedEntity);

        return result;
    }

    public async Task<TagModel> GetById(Guid id)
    {
        var entity = await _repo.GetById(id);
        var result = _mapper.Map<TagEntity, TagModel>(entity);

        return result;
    }
    public async Task<TagModel> Update(TagModel model)
    {
        var entity = _mapper.Map<TagModel, TagEntity>(model);
        var updatedEntity = await _repo.Update(entity);
        var result = _mapper.Map<TagEntity, TagModel> (updatedEntity);

        return result;
    }

    public async Task Remove(Guid id)
    {
        await _repo.Remove(id);
    }        
}

