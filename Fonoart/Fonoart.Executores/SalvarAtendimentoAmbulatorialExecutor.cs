using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System;

namespace Executores
{
    public class SalvarAtendimentoAmbulatorialExecutor : IExecutorSemResultado<SalvarAtendimentoAmbulatorialRequisicao>
    {

        private IAtendimentoAmbulatorialRepositorio atendimentoAmbulatorialRepositorio;
        private IPacienteRepositorio pacienteRepositorio;

        public SalvarAtendimentoAmbulatorialExecutor(IAtendimentoAmbulatorialRepositorio atendimentoAmbulatorialRepositorio, IPacienteRepositorio pacienteRepositorio)
        {
            this.atendimentoAmbulatorialRepositorio = atendimentoAmbulatorialRepositorio;
            this.pacienteRepositorio = pacienteRepositorio;
        }

        public void Executar(SalvarAtendimentoAmbulatorialRequisicao requisicao)
        {
            AtendimentoAmbulatorial atendimento = atendimentoAmbulatorialRepositorio.Obter(requisicao.AtendimentoAmbulatorial.CodigoAtendimento);
            if (atendimento != null)
            {
                atendimentoAmbulatorialRepositorio.Atualizar(requisicao.AtendimentoAmbulatorial.CodigoAtendimento, requisicao.AtendimentoAmbulatorial.CodigoAtendimentoPai,
                    requisicao.AtendimentoAmbulatorial.CodigoPaciente, requisicao.AtendimentoAmbulatorial.CpfFonoaudiologa, DateTime.Now,
                    requisicao.AtendimentoAmbulatorial.DataSolicitacao, requisicao.AtendimentoAmbulatorial.IdSituacao, requisicao.AtendimentoAmbulatorial.Observacao,
                    "Luiz Gustavo", requisicao.AtendimentoAmbulatorial.TipoAtendimento);
            }
            else
            {
                atendimentoAmbulatorialRepositorio.Criar(requisicao.AtendimentoAmbulatorial.CodigoAtendimento, requisicao.AtendimentoAmbulatorial.CodigoAtendimentoPai,
                    requisicao.AtendimentoAmbulatorial.CodigoPaciente, requisicao.AtendimentoAmbulatorial.CpfFonoaudiologa, DateTime.Now,
                    requisicao.AtendimentoAmbulatorial.DataSolicitacao, requisicao.AtendimentoAmbulatorial.IdSituacao, requisicao.AtendimentoAmbulatorial.Observacao,
                    "Luiz Gustavo", requisicao.AtendimentoAmbulatorial.TipoAtendimento);

                if (requisicao.AtendimentoAmbulatorial.Paciente.NovoPaciente)
                {
                    pacienteRepositorio.Criar(requisicao.AtendimentoAmbulatorial.Paciente.CodigoConvenio, requisicao.AtendimentoAmbulatorial.Paciente.CodigoPaciente,
                        requisicao.AtendimentoAmbulatorial.Paciente.NomePaciente, requisicao.AtendimentoAmbulatorial.Paciente.NumeroCarteirinha,
                        requisicao.AtendimentoAmbulatorial.Paciente.TelefonePaciente);
                }
            }
        }
    }
}
