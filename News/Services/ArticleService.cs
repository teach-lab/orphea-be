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
        public async Task<ArticleModel> Add(ArticleModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ArticleModel, ArticleEntity>(model);
            var addedEntity = await _repo.Add(entity, cancellationToken);
            var result = _mapper.Map<ArticleEntity, ArticleModel>(addedEntity);

            return result;
        }

        public async Task<ArticleModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetById(id, cancellationToken);                
            var result = _mapper.Map<ArticleEntity, ArticleModel>(entity);

            return result;
        }
        public async Task<ArticleModel> Update(ArticleModel model, CancellationToken cancellationToken)
        {   
            var entity = _mapper.Map<ArticleModel, ArticleEntity>(model);
            var updatedEntity = await _repo.Update(entity, cancellationToken);
            var result = _mapper.Map<ArticleEntity, ArticleModel>(updatedEntity);

            return result;
        }
        public async Task Remove(Guid id, CancellationToken cancellationToken)
        {
            await _repo.Remove(id, cancellationToken);       
        }

        
    }
}
