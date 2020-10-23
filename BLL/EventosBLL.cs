using System;
using System.Collections.Generic;
using System.Text;
//Using agregados
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroAgenda.DAL;
using RegistroAgenda.Entidades;

namespace RegistroAgenda.BLL
{
    public class EventosBLL
    {
        //—————————————————————————————————————————————————————[ GUARDAR ]—————————————————————————————————————————————————————
        public static bool Guardar(Eventos eventos)
        {
            bool paso;

            if (!Existe(eventos.EventoId))
                paso = Insertar(eventos);
            else
                paso = Modificar(eventos);

            return paso;
        }
        //—————————————————————————————————————————————————————[ INSERTAR ]—————————————————————————————————————————————————————
        public static bool Insertar(Eventos eventos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                foreach (var item in eventos.Detalle)
                {
                    contexto.Entry(item.contactos).State = EntityState.Modified;
                }

                contexto.Eventos.Add(eventos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //—————————————————————————————————————————————————————[ MODIFICAR ]—————————————————————————————————————————————————————
        public static bool Modificar(Eventos eventos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM EventosDetalle WHERE EventoId={eventos.EventoId}");

                foreach (var item in eventos.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(eventos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //—————————————————————————————————————————————————————[ ELIMINAR ]—————————————————————————————————————————————————————
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var devolucion = EventosBLL.Buscar(id);
                if (devolucion != null)
                {
                    contexto.Eventos.Remove(devolucion);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //—————————————————————————————————————————————————————[ GETLIST ]—————————————————————————————————————————————————————
        public static List<Eventos> GetList(Expression<Func<Eventos, bool>> criterio)
        {
            List<Eventos> lista = new List<Eventos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Eventos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
        //—————————————————————————————————————————————————————[ EXISTE ]—————————————————————————————————————————————————————
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Eventos.Any(o => o.EventoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        //—————————————————————————————————————————————————————[ BUSCAR ]————————————————————————————————————————————————————
        public static Eventos Buscar(int id)
        {
            Eventos eventos = new Eventos();
            Contexto contexto = new Contexto();

            try
            {
                eventos = contexto.Eventos
                    .Where(e => e.EventoId == id)
                    .Include(d => d.Detalle)
                    .ThenInclude(p => p.contactos)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eventos;
        }
    }
}
