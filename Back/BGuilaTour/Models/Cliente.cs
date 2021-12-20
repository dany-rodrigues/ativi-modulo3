using System;
using System.Collections.Generic;

#nullable disable

namespace BGuilaTour.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Acomapanhantes = new HashSet<Acomapanhante>();
            ClienteExcursaos = new HashSet<ClienteExcursao>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Acomapanhante> Acomapanhantes { get; set; }
        public virtual ICollection<ClienteExcursao> ClienteExcursaos { get; set; }
    }
}
