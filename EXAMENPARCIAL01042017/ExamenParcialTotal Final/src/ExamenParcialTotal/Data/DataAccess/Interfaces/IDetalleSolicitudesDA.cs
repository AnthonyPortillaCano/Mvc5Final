using ExamenParcialTotal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.Data.DataAccess.Interfaces
{
    public interface IDetalleSolicitudesDA
    {
        IEnumerable<DetalleSolicitudes> GetAll();
        int Insert(DetalleSolicitudes entity);
        DetalleSolicitudes Get(int id);
        bool Update(DetalleSolicitudes entity);
    }
}
