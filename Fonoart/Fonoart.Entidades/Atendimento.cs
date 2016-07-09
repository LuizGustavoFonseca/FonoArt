using AL.NucleoPoliticasComerciais.Entidades;
using Fonoart.Util.Enum;
using MongoDB.Bson;
using System;

namespace Entidades
{
    public abstract class Atendimento : IEntidade
    {
        #region Campos
        public virtual ObjectId _id { get; set; }
        public virtual string CodigoAtendimento { get; set; }
        public virtual DateTime DataSolicitacao { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual string UsuarioAlteracao { get; set; }
        public virtual string CodigoPaciente { get; set; }
        public virtual string CpfFonoaudiologa { get; set; }
        public virtual int IdSituacao { get; set; }
        public virtual TipoAtendimento TipoAtendimento { get; set; }

        public abstract Paciente Paciente { get; set; }
        public abstract Fonoaudiologa Fonoaudiologa { get; set; }
        public abstract Situacao Situacao { get; set; }
        #endregion

        public IChaveEntidade ObterChave()
        {
            return new ChaveEntidadeString(CodigoAtendimento);
        }
    }
}
