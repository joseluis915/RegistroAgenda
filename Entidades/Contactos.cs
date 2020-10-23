using System;
//Using agregados
using System.ComponentModel.DataAnnotations;

namespace RegistroAgenda.Entidades
{
    public class Contactos
    {
        [Key]
        public int ContactoId { get; set; }
        public string NickName { get; set; }
        public string NombreCompleto { get; set; }
        public long Telefono { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}