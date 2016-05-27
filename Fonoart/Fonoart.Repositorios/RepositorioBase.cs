using AL.NucleoPoliticasComerciais.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AL.NucleoPoliticasComerciais.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : IEntidade
    {
        private string nomeTabela;

        public RepositorioBase(string nomeTabela)
        {
            this.nomeTabela = nomeTabela;
        }

        public void Atualizar(FilterDefinition<TEntidade> filtro, UpdateDefinition<TEntidade> update)
        {
            IMongoDatabase dataBase = ObterBaseDeDados();
            var colecao = dataBase.GetCollection<TEntidade>(nomeTabela);            
            var result = colecao.UpdateOne(filtro, update);
        }

        public void Excluir(FilterDefinition<TEntidade> filtro)
        {
            IMongoDatabase dataBase = ObterBaseDeDados();
            var collection = dataBase.GetCollection<TEntidade>(nomeTabela);            
            var result = collection.DeleteOne(filtro);
        }

        public void Inserir(TEntidade entidade)
        {
            IMongoDatabase dataBase = ObterBaseDeDados();
            var colecao = dataBase.GetCollection<TEntidade>(nomeTabela);            
            colecao.InsertOne(entidade);
        }

        public IEnumerable<TEntidade> Listar(FilterDefinition<TEntidade> filtro)
        {
            IMongoDatabase dataBase = ObterBaseDeDados();
            var collection = dataBase.GetCollection<TEntidade>(nomeTabela);
            return collection.Find<TEntidade>(filtro).ToList();
        }

        public TEntidade Obter(FilterDefinition<TEntidade> filtro)
        {
            IMongoDatabase dataBase = ObterBaseDeDados();
            var collection = dataBase.GetCollection<TEntidade>(nomeTabela);
            return collection.Find<TEntidade>(filtro).First();
        }

        private IMongoDatabase ObterBaseDeDados()
        {
            var connectionString = "mongodb://luiz:1234@ds036789.mlab.com:36789/fonoart_db";
            var client = new MongoClient(connectionString);
            return client.GetDatabase("fonoart_db");            
        }
    }    
}
