using System;
using System.Collections.Generic;

#nullable disable

namespace BGuilaTour.Models
{
    public partial class ClienteExcursao
    {
        public int IdClieEx { get; set; }
        public int NCliente { get; set; }
        public int NExcursao { get; set; }

        public virtual Cliente NClienteNavigation { get; set; }
        public virtual Excursao NExcursaoNavigation { get; set; }
    }
}
