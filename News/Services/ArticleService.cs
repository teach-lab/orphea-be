using AutoMapper;
using News.DataAccess.Repo;
using News.Entities;
using News.Entities.Models;
using News.Services.ServicesInterface;
using System.IO;

namespace News.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepo _repo;
        private readonly IMapper _mapper;
        public ArticleService(IArticleRepo repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        public ArticleModel Add(ArticleModel model)
        {
            var entity = _mapper.Map<ArticleModel, ArticleEntity>(model);

            _repo.Add(entity);
            _repo.SaveChanges();

            return _mapper.Map<ArticleEntity, ArticleModel>(entity);
        }

        public ArticleModel GetById(Guid id)
        {
            var entity = _repo.GetById(id);
            

            return _mapper.Map<ArticleEntity, ArticleModel>(entity);
        }
        public void Update(ArticleModel model)
        {
            var entity = _mapper.Map<ArticleModel, ArticleEntity>(model);

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
