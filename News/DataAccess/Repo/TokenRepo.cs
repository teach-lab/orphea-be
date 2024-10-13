﻿using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class TokenRepo : ITokenRepo
{
    private readonly DbSet<TokenEntity> _dbSet;
    private readonly DbContext _context;

    public TokenRepo(DbContext context)
    {
        _dbSet = context.Set<TokenEntity>();
        _context = context;
    }

    public async Task<TokenEntity> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task SaveAsync(TokenEntity refreshEntity, CancellationToken cancellationToken)
    {
        var entity = (await _dbSet.AddAsync(refreshEntity, cancellationToken)).Entity;
        await _context.SaveChangesAsync(cancellationToken);        
    }

    public async Task DeleteAsync(Guid tokenId, CancellationToken cancellation)
    {
        var entity = await GetAsync(tokenId, cancellation);

        if (entity == null)
        {
            throw new Exception($"Token with ID {tokenId} not found.");
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellation);
    }
}