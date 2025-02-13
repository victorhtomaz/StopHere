﻿namespace StopHere.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
}
