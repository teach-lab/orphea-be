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
        public PublisherModel Add(PublisherModel model)
        {
            var entity = _mapper.Map<PublisherModel, PublisherEntity>(model);

            _repo.Add(entity);
            _repo.SaveChanges();

            return _mapper.Map<PublisherEntity, PublisherModel>(entity);
        }

        public PublisherModel GetById(Guid id)
        {
            var entity = _repo.GetById(id);
            var result = _mapper.Map<PublisherEntity, PublisherModel>(entity);

            //foreach for article
            return result;
        }
        
        public void Update(PublisherModel model)
        {
            var entity = _mapper.Map<PublisherModel, PublisherEntity>(model);

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
}
