using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class UserRepo : GenericRepo<UserEntity>, IUserRepo
{
    public UserRepo(DbContext context)
        : base(context)
    {
    }

    public async Task<UserEntity> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken
        )
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Email == email, cancellationToken);

        return entity;
    }

    public async Task<UserEntity> GetLoginAsync(
        string login,
        CancellationToken cancellationToken
        )
    {
        var entity = await _dbSet
            .FirstOrDefaultAsync(e => e.Login == login, cancellationToken);

        return entity;
    }
}