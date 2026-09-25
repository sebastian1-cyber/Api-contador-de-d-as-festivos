using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDiasFestivosDominio.DTos
{
    public class FestivosDTos
    {

        public string Festivo { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; } // Se serializa automáticamente como "YYYY-MM-DD"

        public FestivosDTos(string festivo, DateOnly fecha)
        {
            Festivo = festivo;
            Fecha = fecha;
        }
    }
}
