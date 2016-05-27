using System;

namespace AL.NucleoPoliticasComerciais.Entidades
{
    public class ChaveEntidadeString : IChaveEntidade, IEquatable<ChaveEntidadeString>
    {
        private string valor;

        public ChaveEntidadeString(String valor)
        {
            this.valor = valor;
        }

        public bool TemValor()
        {
            return !String.IsNullOrWhiteSpace(valor);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ChaveEntidadeString))
            {
                return false;
            }

            return obj != null
                && (obj is ChaveEntidadeString)
                && Equals((ChaveEntidadeString)obj);
        }

        public override int GetHashCode()
        {
            return valor.GetHashCode();
        }

        public bool Equals(ChaveEntidadeString other)
        {
            return other != null
                && (
                    (!other.TemValor() && !this.TemValor())
                    ||
                    (other.TemValor() && other.valor.Equals(valor))
                   );
        }
    }
}
