using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiDiasFestivosDominio


{

    [Table("Pais")]
    public class Pais
    {

        [Column("Id")]
        public int Id { get; set; }

        [Column("NombrePais")]
        public required string Nombre { get; set; }

    }
}
