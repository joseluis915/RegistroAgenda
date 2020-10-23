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
        public int ContactoId { get; set; }
        public String TipoEvento { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public String Lugar { get; set; }

        //———————————————————————————[ ForeingKeys ]———————————————————————————
        [ForeignKey("ContactoId")]
        public Contactos contactos { get; set; }
    }
}