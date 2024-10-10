﻿namespace News.Infrastructure;

public interface ITokenHelper
{
    public Guid GetTokenIdFromRefresh(string refresh);

    public Guid GetUserIdFromRefresh(string refresh);
}