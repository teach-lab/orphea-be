﻿using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface IArticleService
    {
        Task<ArticleModel> Add(ArticleModel model, CancellationToken cancellationToken);
        Task<ArticleModel> GetById(Guid id, CancellationToken cancellationToken);
        Task<ArticleModel> Update(ArticleModel model, CancellationToken cancellationToken);
        Task Remove(Guid id, CancellationToken cancellationToken);
    }
}
