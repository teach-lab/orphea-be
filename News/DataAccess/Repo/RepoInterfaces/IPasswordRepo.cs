using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IPasswordRepo
{
    Task CreateAsync(PasswordEntity password, CancellationToken cancellationToken);
    Task<PasswordEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}