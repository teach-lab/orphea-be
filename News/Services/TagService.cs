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
    public TagModel Add(TagModel model)
    {
        var entity = _mapper.Map<TagModel, TagEntity>(model);

        _repo.Add(entity);
        _repo.SaveChanges();

        return _mapper.Map<TagEntity, TagModel>(entity);
    }

    public TagModel GetById(Guid id)
    {
        var entity = _repo.GetById(id);

        if (entity is null)
        {
            return null;
        }

        return _mapper.Map<TagEntity, TagModel>(entity);
    }
    public void Update(TagModel model)
    {
        var entity = _mapper.Map<TagModel, TagEntity>(model);

        _repo.Update(entity);
        _repo.SaveChanges();
    }

    public void Remove(Guid id)
    {
        var entity = _repo.GetById(id);                      

        _repo.Remove(entity);
        _repo.SaveChanges();
    }        
}

