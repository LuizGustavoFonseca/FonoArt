using AL.NucleoPoliticasComerciais.Entidades;

namespace Entidades
{
    public abstract class Convenio : IEntidade
    {
        #region Campos
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
