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
                    DataInternacao = atAmbu.DataInternacao,
                    DataSolicitacao = atAmbu.DataSolicitacao,
                    Fonoaudiologa = new FonoaudiologaDTO()
                    {
                        Cpf = atAmbu.Fonoaudiologa.Cpf,
                        Crfa = atAmbu.Fonoaudiologa.Crfa,
                        DataNascimento = atAmbu.Fonoaudiologa.DataNascimento,
                        Endereco = atAmbu.Fonoaudiologa.Endereco,
                        Nome = atAmbu.Fonoaudiologa.Nome,
                        NovaFonoaudiologa = false,
                        Telefone = atAmbu.Fonoaudiologa.Telefone
                    },
                    Paciente = new PacienteDTO()
                    {

                    },
                    Quarto = atAmbu.Quarto,
                    Situacao = new SituacaoDTO()
                    {

                    },
                    UsuarioAlteracao = atAmbu.UsuarioAlteracao
                }),
                AtendimentosInternacao = atendimentosInternacao.Select(atInter => new AtendimentoInternacaoDTO()
                {
                    CodigoAtendimento = atInter.CodigoAtendimento,
                    DataAlteracao = atInter.DataAlteracao,
                    DataSolicitacao = atInter.DataSolicitacao,
                    Fonoaudiologa = new FonoaudiologaDTO()
                    {
                        Cpf = atInter.Fonoaudiologa.Cpf,
                        Crfa = atInter.Fonoaudiologa.Crfa,
                        DataNascimento = atInter.Fonoaudiologa.DataNascimento,
                        Endereco = atInter.Fonoaudiologa.Endereco,
                        Nome = atInter.Fonoaudiologa.Nome,
                        NovaFonoaudiologa = false,
                        Telefone = atInter.Fonoaudiologa.Telefone
                    },
                    Paciente = new PacienteDTO()
                    {

                    },
                    Situacao = new SituacaoDTO()
                    {

                    },
                    UsuarioAlteracao = atInter.UsuarioAlteracao
                })
            };

        }
    }
}
