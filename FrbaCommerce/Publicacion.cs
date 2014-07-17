using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class Publicacion
    {
        public Int32 id;
        public string description;
        public Int32 stock;
        public Int32 countForSale;
        public Int32 status;
        public string statusDescription;
        public Int32 type;
        public string typeDescription;
        public Int32 visibility;
        public string visibilityDescription;
        public DateTime dateFrom;
        public DateTime dateTo;
        public bool acceptQuestions;
        public Double prices;
    }
}
