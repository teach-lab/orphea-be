using Microsoft.EntityFrameworkCore;
using News.Entities;

namespace News.DataAccess;

public class UserRepo : IUserRepo
{
    private readonly DbSet<UserEntity> _dbSet;
    private readonly DbContext _context;

    public UserRepo(DbContext context)
    {
        _dbSet = context.Set<UserEntity>();
        _context = context;
    }
}