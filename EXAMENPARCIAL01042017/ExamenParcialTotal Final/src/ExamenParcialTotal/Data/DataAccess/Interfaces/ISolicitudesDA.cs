using ExamenParcialTotal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.Data.DataAccess.Interfaces
{
    public interface ISolicitudesDA
    {
        IEnumerable<Solicitudes> GetAll();
    }
}
