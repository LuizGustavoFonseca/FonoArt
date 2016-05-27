using System;

namespace AL.NucleoPoliticasComerciais.Entidades
{
    public class ChaveEntidadeGuid : IChaveEntidade, IEquatable<ChaveEntidadeGuid>
    {
        private Guid valor;

        public ChaveEntidadeGuid(Guid valor)
        {
            this.valor = valor;
        }

        public bool TemValor()
        {
            return Guid.Empty != this.valor;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ChaveEntidadeGuid))
            {
                return false;
            }

            return obj != null
                && (obj is ChaveEntidadeGuid)
                && Equals((ChaveEntidadeGuid)obj);
        }

        public override int GetHashCode()
        {
            return valor.GetHashCode();
        }

        public bool Equals(ChaveEntidadeGuid other)
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
