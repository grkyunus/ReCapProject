﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    // generic constraint || generic kısıtlama
    //class : Referans tip olmak zorunda (int )vs kabul etmez T yerine.
    // IEntity : T nin yerine ya IEntity gelecek ya da IEntityden implemente eden bir nesne olmalıdır şartını veriyor.
    // new() : new özelliği kullanılabilir olmak zorunda şartı verilir ve IEntity interface olduğu için gelemez.
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
