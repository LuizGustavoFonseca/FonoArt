using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System;

namespace Executores
{
    public class SalvarAtendimentoInternacaoExecutor : IExecutorSemResultado<SalvarAtendimentoInternacaoRequisicao>
    {
        private IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio;
        private IPacienteRepositorio pacienteRepositorio;

        public SalvarAtendimentoInternacaoExecutor(IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio, IPacienteRepositorio pacienteRepositorio)
        {
            this.atendimentoInternacaoRepositorio = atendimentoInternacaoRepositorio;
            this.pacienteRepositorio = pacienteRepositorio;
        }

        public void Executar(SalvarAtendimentoInternacaoRequisicao requisicao)
        {
            AtendimentoInternacao atendimento = atendimentoInternacaoRepositorio.Obter(requisicao.AtendimentoInternacao.CodigoAtendimento);
            if(atendimento != null)
            {
                atendimentoInternacaoRepositorio.Atualizar(requisicao.AtendimentoInternacao.CodigoAtendimento, requisicao.AtendimentoInternacao.Quarto,
                    requisicao.AtendimentoInternacao.CodigoPaciente, requisicao.AtendimentoInternacao.CpfFonoaudiologa, DateTime.Now,
                    requisicao.AtendimentoInternacao.DataSolicitacao, requisicao.AtendimentoInternacao.IdSituacao, requisicao.AtendimentoInternacao.DataInternacao,
                    "Luiz Gustavo", requisicao.AtendimentoInternacao.TipoAtendimento);
            }
            else
            {
                atendimentoInternacaoRepositorio.Criar(requisicao.AtendimentoInternacao.CodigoAtendimento, requisicao.AtendimentoInternacao.Quarto,
                    requisicao.AtendimentoInternacao.CodigoPaciente, requisicao.AtendimentoInternacao.CpfFonoaudiologa, DateTime.Now,
                    requisicao.AtendimentoInternacao.DataSolicitacao, requisicao.AtendimentoInternacao.IdSituacao, requisicao.AtendimentoInternacao.DataInternacao,
                    "Luiz Gustavo", requisicao.AtendimentoInternacao.TipoAtendimento);

                if (requisicao.AtendimentoInternacao.Paciente.NovoPaciente)
                {
                    pacienteRepositorio.Criar(requisicao.AtendimentoInternacao.Paciente.CodigoConvenio, requisicao.AtendimentoInternacao.Paciente.CodigoPaciente,
                        requisicao.AtendimentoInternacao.Paciente.NomePaciente, requisicao.AtendimentoInternacao.Paciente.NumeroCarteirinha,
                        requisicao.AtendimentoInternacao.Paciente.TelefonePaciente);
                }                
            }
        }
    }
}
