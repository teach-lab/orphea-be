using News.Entities;
using News.Entities.Models;
using News.Infrastructure;
using AutoMapper;

namespace News.Mapping.Resolvers;

internal class UserEntityPasswordResolver : IValueResolver<UserCreateModel, UserEntity, byte[]>
{
    private readonly IPasswordEncryptionHelper _passwordEncryptionHelper;

    public UserEntityPasswordResolver(IPasswordEncryptionHelper passwordEncryptionHelper)
    {
        _passwordEncryptionHelper = passwordEncryptionHelper;
    }

    public byte[] Resolve(
        UserCreateModel source,
        UserEntity destination,
        byte[] destMember,
        ResolutionContext context)
    {
        byte[] salt = _passwordEncryptionHelper.GenerateSalt(source.Password!);

        var passwordHash = _passwordEncryptionHelper.HashPassword(source.Password!, salt);

        destination.Password = passwordHash;
        
        return salt;
    }
}
