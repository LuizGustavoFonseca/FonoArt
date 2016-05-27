using System;

namespace Fonoart.SDK.InversaoControle
{
    public class SobrescreverMapeamentoNome : ISobrescreverMapeamento
    {
        public string NomeParametro { get; set; }

        public object Para { get; set; }
    }
}