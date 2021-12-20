using System;
using System.Collections.Generic;

#nullable disable

namespace BGuilaTour.Models
{
    public partial class Acomapanhante
    {
        public int IdAcompanhante { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Cpf { get; set; }
        public int Responsavel { get; set; }

        public virtual Cliente ResponsavelNavigation { get; set; }
    }
}
