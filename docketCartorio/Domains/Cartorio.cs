using System;
using System.Collections.Generic;

namespace docketCartorio.Domains
{
    public partial class Cartorio
    {
        public int IdCartorio { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int FkTipoCertidao { get; set; }

        public TipoCertidao FkTipoCertidaoNavigation { get; set; }
    }
}
