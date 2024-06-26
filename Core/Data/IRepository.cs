﻿using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IRepository<T> where T : Entity
    {
        Task<bool> Commit();
    }
}
