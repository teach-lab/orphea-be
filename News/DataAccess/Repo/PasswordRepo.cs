using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class PasswordRepo : GenericRepo<PasswordEntity>, IPasswordRepo
{
    public PasswordRepo(DbContext context)
        : base(context)
    {
    }
}