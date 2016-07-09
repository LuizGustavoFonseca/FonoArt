using AL.NucleoPoliticasComerciais.Entidades;
using Fonoart.Util.Enum;
using MongoDB.Bson;

namespace Entidades
{
    public abstract class Situacao : IEntidade
    {
        #region Campos
        public virtual ObjectId _id { get; set; }

        public virtual int Identificador { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual TipoSituacao Tipo { get; set; }
        #endregion
        public IChaveEntidade ObterChave()
        {
            return new ChaveEntidadeNumerica(Identificador);
        }
    }
}
