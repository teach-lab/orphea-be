using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using News.DataAccess.Repo;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepo _repo;
    private readonly IMapper _mapper;

    public PublisherService(IPublisherRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<PublisherCreateModel> CreateAsync(
        PublisherCreateModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<PublisherCreateModel, PublisherEntity>(model);
        var addedEntity = await _repo.CreateAsync(entity, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<PublisherEntity, PublisherCreateModel>(addedEntity);

        return result;
    }

    public async Task<PublisherModel> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _repo.GetByIdAsync(id, cancellationToken);
        var result = _mapper.Map<PublisherEntity, PublisherModel>(entity);
        
        return result;
    }
    
    public async Task<PublisherModel> UpdateAsync(
        PublisherModel model,
        CancellationToken cancellationToken
        )
    {
        var entity = _mapper.Map<PublisherModel, PublisherEntity>(model);
        var updatedEntity = await _repo.UpdateAsync(entity, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<PublisherEntity, PublisherModel>(updatedEntity);

        return result;            
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(id, cancellationToken);
        await _repo.SaveChangesAsync(cancellationToken);
    }
}
