using System;

namespace AL.NucleoPoliticasComerciais.Entidades
{
    public class ChaveEntidadeNumerica : IChaveEntidade, IEquatable<ChaveEntidadeNumerica>
    {
        private double valor;

        public ChaveEntidadeNumerica(double valor)
        {
            this.valor = valor;
        }

        public bool TemValor()
        {
            return this.valor > 0;
        }

        public override bool Equals(object obj)
        {
            return obj != null
                && (obj is ChaveEntidadeNumerica)
                && Equals((ChaveEntidadeNumerica)obj);
        }

        public override int GetHashCode()
        {
            return valor.GetHashCode();
        }

        public bool Equals(ChaveEntidadeNumerica other)
        {
            return other != null
                && (
                    (!other.TemValor() && !this.TemValor())
                    ||
                    (other.TemValor() && other.valor == this.valor)
                   );
        }
    }
}
