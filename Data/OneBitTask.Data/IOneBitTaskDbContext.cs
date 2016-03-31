﻿namespace OneBitTask.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IOneBitTaskDbContext
    {
        IDbSet<Contact> Contacts { get; set; }

        int SaveChanges();

        void Dispose();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
