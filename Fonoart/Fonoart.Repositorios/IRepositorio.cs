using AL.NucleoPoliticasComerciais.Entidades;
using MongoDB.Driver;
using System.Collections.Generic;

namespace AL.NucleoPoliticasComerciais.Repositorios
{
    public interface IRepositorio<TEntidade> where TEntidade : IEntidade
    {
        IEnumerable<TEntidade> Listar(FilterDefinition<TEntidade> filtro);

        TEntidade Obter(FilterDefinition<TEntidade> filtro);

        void Inserir(TEntidade entidade);

        void Atualizar(FilterDefinition<TEntidade> filtro, UpdateDefinition<TEntidade> update);

        void Excluir(FilterDefinition<TEntidade> filtro);
    }
}
