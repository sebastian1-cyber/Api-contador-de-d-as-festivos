using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiDiasFestivosDominio
{
    [Table("Festivo")]

    public class Festivo

    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NombreFestivo")]
        public required string NombreFestivo { get; set; }

        [Column("Dia")]
        public int Dia { get; set; }
        [Column("Mes")]
        public int Mes { get; set; }
        [Column("Año")]
        public int Año { get; set; }

        [Column("DiasPascua")]
        public int DiasPascua { get; set; }
        [Column("IdPais")]
        public int IdPais { get; set; }
        [Column("IdTipo")]
        public int IdTipo { get; set; }
        public TipoFestivo? Tipo { get; set; }
        public Pais? Pais { get; set; }



    }
}
