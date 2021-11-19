using inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inventario.Dato
{
    public class InventarioAdmin
    {
        public IEnumerable<registros> Consultar()
        {
            using (crudEntities contexto = new crudEntities())
            {
                return contexto.registros.AsNoTracking().ToList();
            }
        }

        //guarda un registro en la base de datos
        public void Guardar(registros modelo)
        {
            using (crudEntities contexto = new crudEntities())
            {
                contexto.registros.Add(modelo);
                contexto.SaveChanges();
            }
        }

        // detalles de los registros
        public registros Consultar(int ID)
        {
            using (crudEntities contexto = new crudEntities())
            {
                return contexto.registros.FirstOrDefault(r => r.ID == ID);
            }
        }

        //modificar los registros
        public void Modificar(registros modelo)
        {
            using (crudEntities contexto = new crudEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }

        }

        public void Eliminar(registros modelo)
        {
            using (crudEntities contexto = new crudEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }

        }


    }
}