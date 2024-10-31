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

    public async Task<PasswordEntity> GetByIdAsync(
        Guid? id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _dbSet
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }
}