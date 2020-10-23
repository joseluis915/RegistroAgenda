using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RegistroAgenda.Entidades
{
    public class EventosDetalle
    {
        [Key]
        public int EventoDetalle { get; set; }
        public int EventoId { get; set; }
        public int ContactoId { get; set; }
        public string TipoEvento { get; set; }
        public string NombreEvento { get; set; }
        public string Lugar { get; set; }

        [ForeignKey("ContactoId")]
        public Contactos contactos { get; set; } = new Contactos();
    }
}