using System;

namespace Fonoart.SDK.InversaoControle
{
    public class SobrescreverMapeamentoTipo : ISobrescreverMapeamento
    {
        public Type De { get; set; }

        public object Para { get; set; }
    }
}