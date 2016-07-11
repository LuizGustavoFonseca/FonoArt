using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace Executores
{
    public class FiltrarAtendimentoExecutor : IExecutor<FiltrarAtendimentoRequisicao, FiltrarAtendimentoResultado>
    {
        private IAtendimentoAmbulatorialRepositorio atendimentoAmbulatorialRepositorio;
        private IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio;

        public FiltrarAtendimentoExecutor(IAtendimentoAmbulatorialRepositorio atendimentoAmbulatorialRepositorio, IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio)
        {
            this.atendimentoAmbulatorialRepositorio = atendimentoAmbulatorialRepositorio;
            this.atendimentoInternacaoRepositorio = atendimentoInternacaoRepositorio;
        }

        public FiltrarAtendimentoResultado Executar(FiltrarAtendimentoRequisicao requisicao)
        {
            IEnumerable<AtendimentoInternacao> atendimentosInternacao = atendimentoInternacaoRepositorio.Filtrar(requisicao.CodigoPaciente, requisicao.CodigoConvenio,
                requisicao.CpfFono, requisicao.IdSituacao, requisicao.DataInicioSolicitacao, requisicao.DataFimSolicitacao, requisicao.DataInicioAltaAdministrativa,
                requisicao.DataFimAltaAdministrativa);
            IEnumerable<AtendimentoAmbulatorial> atendimentosAmbulatoriais = atendimentoAmbulatorialRepositorio.Filtrar(requisicao.CodigoPaciente, requisicao.CodigoConvenio,
                requisicao.CpfFono, requisicao.IdSituacao, requisicao.DataInicioSolicitacao, requisicao.DataFimSolicitacao);

            return new FiltrarAtendimentoResultado()
            {
                AtendimentosAmbulatoriais = atendimentosAmbulatoriais.Select(atAmbu => new AtendimentoAmbulatorialDTO()
                {
                    CodigoAtendimento = atAmbu.CodigoAtendimento,
                    DataAlteracao = atAmbu.DataAlteracao,                    
                    DataSolicitacao = atAmbu.DataSolicitacao,
                    CodigoAtendimentoPai = atAmbu.CodigoAtendimentoPai,
                    CodigoPaciente = atAmbu.CodigoPaciente,
                    CpfFonoaudiologa = atAmbu.CpfFonoaudiologa,
                    IdSituacao = atAmbu.IdSituacao,
                    Observacao = atAmbu.Observacao,
                    TipoAtendimento = atAmbu.TipoAtendimento,
                    VincularAtendimento = atAmbu.VincularAtendimento,                   
                    UsuarioAlteracao = atAmbu.UsuarioAlteracao
                }),
                AtendimentosInternacao = atendimentosInternacao.Select(atInter => new AtendimentoInternacaoDTO()
                {
                    CodigoAtendimento = atInter.CodigoAtendimento,
                    DataAlteracao = atInter.DataAlteracao,
                    DataSolicitacao = atInter.DataSolicitacao,
                    DataInternacao = atInter.DataInternacao,
                    Quarto = atInter.Quarto,
                    CodigoPaciente = atInter.CodigoPaciente,
                    CpfFonoaudiologa = atInter.CpfFonoaudiologa,
                    IdSituacao = atInter.IdSituacao,
                    TipoAtendimento = atInter.TipoAtendimento,                    
                    UsuarioAlteracao = atInter.UsuarioAlteracao
                })
            };

        }
    }
}
