﻿using System.ComponentModel.DataAnnotations.Schema;

namespace News.Entities;

public class UserEntity
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public byte[]? Salt { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public List<CommentEntity>? Comments { get; set; }
}