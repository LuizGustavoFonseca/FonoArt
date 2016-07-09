using AL.NucleoPoliticasComerciais.Repositorios;
using Entidades;
using Fronteiras.Repositorios;
using MongoDB.Driver;
using Repositorios.Entidades;
using System.Collections.Generic;

namespace Repositorios
{
    public class SituacaoRepositorio : RepositorioBase<RSituacao>, ISituacaoRepositorio
    {
        #region Construtor Base
        public SituacaoRepositorio() : base("situacao")
        {
        }
        #endregion

        #region ISituacaoRepositorio
        public IEnumerable<Situacao> Listar()
        {
            var filtro = Builders<RSituacao>.Filter.Empty;
            return Listar(filtro);
        }
        #endregion
    }
}
