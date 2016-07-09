using AL.NucleoPoliticasComerciais.Entidades;
using MongoDB.Bson;

namespace Entidades
{
    public abstract class Convenio : IEntidade
    {
        #region Campos
        public virtual ObjectId _id { get; set; }
        public virtual string CodigoConvenio { get; set; }
        public virtual string NomeConvenio { get; set; }
        #endregion

        #region IEntidade
        public IChaveEntidade ObterChave()
        {
            return new ChaveEntidadeString(CodigoConvenio);
        }
        #endregion

        #region Regras de Negócio
        #endregion        
    }
}
