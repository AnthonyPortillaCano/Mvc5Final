using ExamenParcialTotal.Data.DataAccess.Interfaces;
using ExamenParcialTotal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.Data.DataAccess
{
    public class SolicitudesDA : ISolicitudesDA
    {

        public IEnumerable<Solicitudes> GetAll()
        {

            var result = new List<Solicitudes>();
            using (var db = new ApplicationDbContext())
            {
                result = db.Solicitudes.ToList();
            }

            return result;

        }

    }
}
