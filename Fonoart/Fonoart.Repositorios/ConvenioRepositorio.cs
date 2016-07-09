using AL.NucleoPoliticasComerciais.Repositorios;
using Entidades;
using Fronteiras.Repositorios;
using MongoDB.Driver;
using Repositorios.Entidades;
using System.Collections.Generic;

namespace Repositorios
{
    public class ConvenioRepositorio : RepositorioBase<RConvenio>, IConvenioRepositorio
    {
        #region Construtor Base
        public ConvenioRepositorio() : base("convenio")
        {
        }
        #endregion

        #region IConvenioRepositorio
        public IEnumerable<Convenio> Listar()
        {
            var filtro = Builders<RConvenio>.Filter.Empty;
            return Listar(filtro);
        }
        #endregion
    }
}
