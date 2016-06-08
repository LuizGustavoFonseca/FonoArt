using AL.NucleoPoliticasComerciais.Entidades;
using MongoDB.Bson;
using System;

namespace Entidades
{
    public abstract class Fonoaudiologa : IEntidade
    {
        #region Campos
        public virtual ObjectId _id { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Crfa { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Telefone { get; set; }
        #endregion

        public IChaveEntidade ObterChave()
        {
            return new ChaveEntidadeString(Cpf);
        }
    }
}
