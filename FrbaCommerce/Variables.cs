using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class Variables
    {
        public static DateTime FechaHoraSistema = DateTime.ParseExact(Properties.Settings.Default.fechaSistema, Properties.Settings.Default.formatoFecha, null);
    }
}
