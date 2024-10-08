﻿using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IPasswordRepo
{
    Task CreatePassword(PasswordEntity password);
}
