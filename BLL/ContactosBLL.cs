using System;
using System.Collections.Generic;
//Using agregados
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using RegistroAgenda.DAL;
using RegistroAgenda.Entidades;

namespace RegistroAgenda.BLL
{
    public class ContactosBLL
    {
        //——————————————————————————————————————————————[ GUARDAR ]——————————————————————————————————————————————
        public static bool Guardar(Contactos contactos)
        {
            if (!Existe(contactos.ContactoId))
                return Insertar(contactos);
            else
                return Modificar(contactos);
        }
        //——————————————————————————————————————————————[ INSERTAR ]——————————————————————————————————————————————
        private static bool Insertar(Contactos contactos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Contactos.Add(contactos);
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
        //——————————————————————————————————————————————[ MODIFICAR ]——————————————————————————————————————————————
        public static bool Modificar(Contactos contactos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(contactos).State = EntityState.Modified;
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
        //——————————————————————————————————————————————[ ELIMINAR ]——————————————————————————————————————————————
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var contactos = contexto.Contactos.Find(id);
                if (contactos != null)
                {
                    contexto.Contactos.Remove(contactos);
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
        //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        public static Contactos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Contactos contactos;

            try
            {
                contactos = contexto.Contactos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return contactos;
        }
        //——————————————————————————————————————————————[ GETLIST ]——————————————————————————————————————————————
        public static List<Contactos> GetList(Expression<Func<Contactos, bool>> criterio)
        {
            List<Contactos> lista = new List<Contactos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Contactos.Where(criterio).ToList();
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
        //——————————————————————————————————————————————[ EXISTE ]——————————————————————————————————————————————
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Contactos.Any(c => c.ContactoId == id);
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
        //——————————————————————————————————————————————[ GetList ]——————————————————————————————————————————————
        public static List<Contactos> GetList()
        {
            List<Contactos> contactos = new List<Contactos>();
            Contexto contexto = new Contexto();

            try
            {
                contactos = contexto.Contactos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return contactos;
        }
        //——————————————————————————————————————————————[ GET ]——————————————————————————————————————————————
        public static List<Contactos> GetContactos()
        {
            List<Contactos> lista = new List<Contactos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Contactos.ToList();
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
    }
}