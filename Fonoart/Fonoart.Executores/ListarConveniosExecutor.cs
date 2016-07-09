using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System.Linq;

namespace Executores
{
    public class ListarConveniosExecutor : IExecutorSemRequisicao<ListarConveniosResultado>
    {
        private IConvenioRepositorio convenioRepositorio;

        public ListarConveniosExecutor(IConvenioRepositorio convenioRepositorio)
        {
            this.convenioRepositorio = convenioRepositorio;
        }

        public ListarConveniosResultado Executar()
        {
            return new ListarConveniosResultado()
            {
                Convenios = convenioRepositorio.Listar().Select(conv => new ConvenioDTO()
                {
                    CodigoConvenio = conv.CodigoConvenio,
                    NomeConvenio = conv.NomeConvenio
                })
            };
        }
    }
}
