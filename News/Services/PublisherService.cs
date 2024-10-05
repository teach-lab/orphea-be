using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using News.DataAccess.Repo;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
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
        public async Task<PublisherModel> Add(PublisherModel model)
        {
            var entity = _mapper.Map<PublisherModel, PublisherEntity>(model);
            var addedEntity = await _repo.Add(entity);
            var result = _mapper.Map<PublisherEntity, PublisherModel>(addedEntity);

            return result;
        }

        public async Task<PublisherModel> GetById(Guid id)
        {
            var entity = await _repo.GetById(id);
            var result = _mapper.Map<PublisherEntity, PublisherModel>(entity);
            
            return result;
        }
        
        public async Task<PublisherModel> Update(PublisherModel model)
        {
            var entity = _mapper.Map<PublisherModel, PublisherEntity>(model);
            var updatedEntity = await _repo.Update(entity);
            var result = _mapper.Map<PublisherEntity, PublisherModel>(updatedEntity);

            return result;            
        }
        public async Task Remove(Guid id)
        {
            await _repo.Remove(id);
        }
    }
}
