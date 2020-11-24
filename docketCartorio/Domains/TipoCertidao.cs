using System;
using System.Collections.Generic;

namespace docketCartorio.Domains
{
    public partial class TipoCertidao
    {
        public TipoCertidao()
        {
            Cartorio = new HashSet<Cartorio>();
        }

        public int IdTipoCerdidao { get; set; }
        public string Certidao { get; set; }

        public ICollection<Cartorio> Cartorio { get; set; }
    }
}
