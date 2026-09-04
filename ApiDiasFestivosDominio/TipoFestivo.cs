using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiDiasFestivosDominio
{

    [Table("TipoFestivo")]
    public class TipoFestivo

    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        public required string Tipo { get; set; }


    }
}