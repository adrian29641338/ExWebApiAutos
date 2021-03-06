﻿using ExWebApiAutos.Model.ExWebApiAutos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model
{
    public interface IAutoRepository
    {
        IQueryable<TAuto> Autos { get; }
        Task SaveProject(TAuto auto);
        void DeleteProyecto(Guid AutoID);
    }
}
