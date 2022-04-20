﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SPP.Lab2.DB
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get entities with indent
        /// </summary>
        /// <param name="indent"></param>
        /// <returns></returns>
        public List<T> Get(int indent, int take);

        /// <summary>
        /// Create new enitity in database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Create(T item);

        /// <summary>
        /// Find item at database and update them
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(T item);

        /// <summary>
        /// Find items at database and update them
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<T> UpdateRange(List<T> items);

        /// <summary>
        /// Remove item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Remove item by id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteRange(List<int> ids);
        
        /// <summary>
        /// Remove item by entity
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteRange(List<T> items);

        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll();

        /// <summary>
        /// Find element by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Include additional entity
        /// </summary>
        /// <param name="children"></param>
        /// <returns></returns>
        public IQueryable<T> Include(params Expression<Func<T, object>>[] children);
    }
}