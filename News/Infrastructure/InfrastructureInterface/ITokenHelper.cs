﻿namespace News.Infrastructure.IInfrastructure;

public interface ITokenHelper
{
    public Guid GetTokenIdFromRefresh(string refresh);

    public Guid GetUserIdFromRefresh(string refresh);
}