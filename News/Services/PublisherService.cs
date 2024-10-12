using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using News.DataAccess.Repo;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepo _repo;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<PublisherCreateModel> Add(PublisherCreateModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PublisherCreateModel, PublisherEntity>(model);
            var addedEntity = await _repo.Add(entity, cancellationToken);
            var result = _mapper.Map<PublisherEntity, PublisherCreateModel>(addedEntity);

            return result;
        }

        public async Task<PublisherModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetById(id, cancellationToken);
            var result = _mapper.Map<PublisherEntity, PublisherModel>(entity);
            
            return result;
        }
        
        public async Task<PublisherModel> Update(PublisherModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PublisherModel, PublisherEntity>(model);
            var updatedEntity = await _repo.Update(entity, cancellationToken);
            var result = _mapper.Map<PublisherEntity, PublisherModel>(updatedEntity);

            return result;            
        }
        public async Task Remove(Guid id, CancellationToken cancellationToken)
        {
            await _repo.Remove(id, cancellationToken);
        }
    }
}
