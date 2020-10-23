using System;
using System.Collections.Generic;
using System.Text;
//Using agregados
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroAgenda.Entidades;

namespace RegistroAgenda.Entidades
{
    public class Eventos
    {
        [Key]
        public int EventoId { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        [ForeignKey("EventoId")]
        public virtual List<EventosDetalle> Detalle { get; set; } = new List<EventosDetalle>();
    }
}