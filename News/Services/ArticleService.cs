using AutoMapper;
using News.DataAccess.Repo;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
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
        public async Task<ArticleCreateModel> CreateAsync(ArticleCreateModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ArticleCreateModel, ArticleEntity>(model);
            var addedEntity = await _repo.CreateAsync(entity, cancellationToken);
            var result = _mapper.Map<ArticleEntity, ArticleCreateModel>(addedEntity);

            return result;
        }

        public async Task<ArticleModel> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetAsync(id, cancellationToken);                
            var result = _mapper.Map<ArticleEntity, ArticleModel>(entity);

            return result;
        }
        public async Task<ArticleModel> UpdateAsync(ArticleModel model, CancellationToken cancellationToken)
        {   
            var entity = _mapper.Map<ArticleModel, ArticleEntity>(model);
            var updatedEntity = await _repo.UpdateAsync(entity, cancellationToken);
            var result = _mapper.Map<ArticleEntity, ArticleModel>(updatedEntity);

            return result;
        }
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(id, cancellationToken);       
        }

        
    }
}
