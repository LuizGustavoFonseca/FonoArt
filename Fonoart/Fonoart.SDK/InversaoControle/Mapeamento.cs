using System;

namespace Fonoart.SDK.InversaoControle
{
    public class Mapeamento
    {
        public string Nome { get; private set; }
        public Type De { get; private set; }
        public Type Para { get; private set; }

        public Mapeamento(Type de, Type para) : this(string.Empty, de, para) { }

        public Mapeamento(string nome, Type de, Type para)
        {
            Nome = nome;
            De = de;
            Para = para;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", De.Name, Para.Name);
        }
    }
}