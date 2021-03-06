﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeApplication.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        T Insert(T entity);
        T Upsert(T entity);
        bool Delete(int id);
        IQueryable<T> GetAllQueryable();
    }
}