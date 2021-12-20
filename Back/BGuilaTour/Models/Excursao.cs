using System;
using System.Collections.Generic;

#nullable disable

namespace BGuilaTour.Models
{
    public partial class Excursao
    {
        public Excursao()
        {
            ClienteExcursaos = new HashSet<ClienteExcursao>();
        }

        public int IdExcursao { get; set; }
        public string Descricao { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime DataVolta { get; set; }
        public double Valor { get; set; }

        public virtual ICollection<ClienteExcursao> ClienteExcursaos { get; set; }
    }
}
