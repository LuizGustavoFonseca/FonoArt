using AL.NucleoPoliticasComerciais.Repositorios;
using Entidades;
using Fronteiras.Repositorios;
using MongoDB.Driver;
using Repositorios.Entidades;
using System;
using System.Collections.Generic;

namespace Repositorios
{
    public class FonoaudiologaRepositorio : RepositorioBase<RFonoaudiologa>, IFonoaudiologaRepositorio
    {
        #region Construtor Base
        public FonoaudiologaRepositorio() : base("fono") { }
        #endregion

        #region IFonoaudiologaRepositorio
        public void Atualizar(string cpf, string crfa, DateTime dataNascimento, string endereco, string nome, string telefone)
        {
            var filter = Builders<RFonoaudiologa>.Filter.Eq("Cpf", cpf);
            var update = Builders<RFonoaudiologa>.Update.Set("Crfa", crfa).Set("DataNascimento", dataNascimento).
                Set("Endereco", endereco).Set("Nome", nome).Set("Telefone", telefone).Set("DataNascimento", dataNascimento);            

            Atualizar(filter, update);
        }

        public void Criar(string cpf, string crfa, DateTime dataNascimento, string endereco, string nome, string telefone)
        {
            var entidade = new RFonoaudiologa() { Cpf = cpf, Crfa = crfa, DataNascimento = dataNascimento, Endereco = endereco, Nome = nome, Telefone = telefone };
            Inserir(entidade);
        }

        public IEnumerable<Fonoaudiologa> Listar()
        {
            var filtro = Builders<RFonoaudiologa>.Filter.Empty;
            return Listar(filtro);
        }

        public Fonoaudiologa Obter(string cpf)
        {
            var filtro = Builders<RFonoaudiologa>.Filter.Eq("Cpf", cpf);
            return Obter(filtro);
        }
        #endregion
    }
}
