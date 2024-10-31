using News.DataAccess.Repo.GenericRepositories;
using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IPasswordRepo : IGenericRepo<PasswordEntity>
{
    Task<PasswordEntity> GetByIdAsync(Guid? id, CancellationToken cancellationToken);
}