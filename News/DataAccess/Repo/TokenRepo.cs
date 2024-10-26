using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class TokenRepo : GenericRepo<TokenEntity>, ITokenRepo
{
    public TokenRepo(DbContext context)
        : base(context)
    {
    }

    public async Task SaveAsync(
         TokenEntity refreshEntity,
        CancellationToken cancellationToken
        )
    {
        var entity = (await _dbSet.AddAsync(refreshEntity, cancellationToken)).Entity;

        await _context.SaveChangesAsync(cancellationToken);
    }
}