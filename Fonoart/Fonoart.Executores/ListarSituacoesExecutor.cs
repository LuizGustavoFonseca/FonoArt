using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System.Linq;

namespace Executores
{
    public class ListarSituacoesExecutor : IExecutorSemRequisicao<ListarSituacoesResultado>
    {
        private ISituacaoRepositorio situacaoRepositorio;

        public ListarSituacoesExecutor(ISituacaoRepositorio situacaoRepositorio)
        {
            this.situacaoRepositorio = situacaoRepositorio;
        }

        public ListarSituacoesResultado Executar()
        {
            return new ListarSituacoesResultado()
            {
                Situacoes = situacaoRepositorio.Listar().Select(situacao => new SituacaoDTO()
                {
                    Codigo = situacao.Codigo,
                    Descricao = situacao.Descricao,
                    Identificador = situacao.Identificador,
                    Tipo = situacao.Tipo
                })
            };
        }
    }
}
