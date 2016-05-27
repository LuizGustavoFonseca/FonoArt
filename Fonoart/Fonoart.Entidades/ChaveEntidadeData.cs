using System;

namespace AL.NucleoPoliticasComerciais.Entidades
{
    public class ChaveEntidadeData : IChaveEntidade, IEquatable<ChaveEntidadeData>
    {
        private DateTime valor;

        public ChaveEntidadeData(DateTime valor)
        {
            this.valor = valor;
        }

        public bool TemValor()
        {
            return this.valor != DateTime.MinValue;
        }

        public override bool Equals(object obj)
        {
            return obj != null
                && (obj is ChaveEntidadeData)
                && Equals((ChaveEntidadeData)obj);
        }

        public override int GetHashCode()
        {
            return valor.GetHashCode();
        }

        public bool Equals(ChaveEntidadeData other)
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
