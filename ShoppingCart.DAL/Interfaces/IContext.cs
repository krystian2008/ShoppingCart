﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Interfaces
{
    /// <summary>
    /// Interface for DbContext class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContext<T> : IDisposable where T : class
    {
        DbContext DbCtx { get; }
        IDbSet<T> DbSet { get; }
    }
}
