using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class TagRepo : GenericRepo<TagEntity>, ITagRepo
{
    public TagRepo(DbContext context)
        : base(context)
    {
    }
}