using AL.NucleoPoliticasComerciais.Entidades;
using MongoDB.Bson;

namespace Entidades
{
    public abstract class Paciente : IEntidade
    {
        #region Campos
        public virtual ObjectId _id { get; set; }
        public virtual string CodigoPaciente { get; set; }
        public virtual string NomePaciente { get; set; }
        public virtual string TelefonePaciente { get; set; }
        public virtual string CodigoConvenio { get; set; }
        public virtual string NumeroCarteirinha { get; set; }

        public abstract Convenio Convenio { get; set; }

        #endregion

        #region IEntidade
        public IChaveEntidade ObterChave()
        {
            return new ChaveEntidadeString(CodigoPaciente);
        }
        #endregion

        #region Regras de Negócio
        #endregion
    }
}
