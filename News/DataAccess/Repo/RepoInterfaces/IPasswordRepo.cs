using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IPasswordRepo
{
    Task CreateAsync(PasswordEntity password);
    Task<PasswordEntity> GetAsync(Guid id);
}