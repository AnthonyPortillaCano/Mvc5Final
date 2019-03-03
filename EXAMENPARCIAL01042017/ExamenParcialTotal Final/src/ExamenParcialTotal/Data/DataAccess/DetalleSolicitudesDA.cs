using ExamenParcialTotal.Data.DataAccess;
using ExamenParcialTotal.Data.DataAccess.Interfaces;
using ExamenParcialTotal.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.Data.DataAccess
{
    public class DetalleSolicitudesDA :IDetalleSolicitudesDA 
    {
        public IEnumerable<DetalleSolicitudes> GetAll()
        {
            var result = new List<DetalleSolicitudes>();
            /*Usando Entity Framework*/
            using (var db = new ApplicationDbContext())
            {

                result = db.DetalleSolicitudes
                            .Include(item=>item.Solicitudes)
                            .ToList();


            } 

            return result;
        }


        public int Insert(DetalleSolicitudes entity)
        {
            var result = 1;
            using (var db = new ApplicationDbContext())
            {
               
                if(entity.SolicitudID==1)
                {
                    entity.MotivoViaje = "Capacitación del personal y nuevos proyectos";
                }
               else if (entity.SolicitudID == 2)
                {
                    entity.MotivoViaje = "otros";
                }
                db.Add(entity);
                result = db.SaveChanges();
            }

            return result;

        }
        public DetalleSolicitudes Get(int id)
        {
            var result = new DetalleSolicitudes();
            /*Usando Entity Framework*/
            using (var db = new ApplicationDbContext())
            {
                result = db.DetalleSolicitudes.Where(i => i.DetalleSolicitudID == id)
                        .FirstOrDefault();
            }

            return result;
        }

        public bool Update(DetalleSolicitudes entity)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                if (entity.SolicitudID == 1)
                {
                    entity.MotivoViaje = "Capacitación del personal y nuevos proyectos";
                }
                else if (entity.SolicitudID == 2)
                {
                    entity.MotivoViaje = "otros";
                }
                db.DetalleSolicitudes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
               
                
                result = db.SaveChanges() != 0;
            }

            return result;

        }

    }
}
