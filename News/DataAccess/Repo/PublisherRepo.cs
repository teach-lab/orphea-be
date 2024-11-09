using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class PublisherRepo : GenericRepo<PublisherEntity>, IPublisherRepo
{
    public PublisherRepo(DbContext context)
        : base(context)
    {
    }
}