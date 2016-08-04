using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System;

namespace Executores
{
    public class ObterAtendimentoExecutor : IExecutor<ObterAtendimentoRequisicao, ObterAtendimentoResultado>
    {
        private IAtendimentoAmbulatorialRepositorio atendimentoAmbulatorialRepositorio;
        private IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio;

        public ObterAtendimentoExecutor(IAtendimentoAmbulatorialRepositorio atendimentoAmbulatorialRepositorio,
            IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio)
        {
            this.atendimentoAmbulatorialRepositorio = atendimentoAmbulatorialRepositorio;
            this.atendimentoInternacaoRepositorio = atendimentoInternacaoRepositorio;
        }

        public ObterAtendimentoResultado Executar(ObterAtendimentoRequisicao requisicao)
        {
            var atendimentoAmbulatorial = atendimentoAmbulatorialRepositorio.Obter(requisicao.CodigoAtendimento);
            if (atendimentoAmbulatorial != null)
            {
                return new ObterAtendimentoResultado()
                {
                    Atendimento = new AtendimentoAmbulatorialDTO()
                    {
                        CodigoAtendimento = atendimentoAmbulatorial.CodigoAtendimento,
                        CodigoAtendimentoPai = atendimentoAmbulatorial.CodigoAtendimentoPai,
                        CodigoPaciente = atendimentoAmbulatorial.CodigoPaciente,
                        CpfFonoaudiologa = atendimentoAmbulatorial.CpfFonoaudiologa,
                        DataAlteracao = atendimentoAmbulatorial.DataAlteracao,
                        DataSolicitacao = atendimentoAmbulatorial.DataSolicitacao,
                        IdSituacao = atendimentoAmbulatorial.IdSituacao,
                        Observacao = atendimentoAmbulatorial.Observacao,
                        TipoAtendimento = atendimentoAmbulatorial.TipoAtendimento,
                        UsuarioAlteracao = atendimentoAmbulatorial.UsuarioAlteracao,
                        VincularAtendimento = atendimentoAmbulatorial.VincularAtendimento
                    }
                };
            }

            var atendimentoInternacao = atendimentoInternacaoRepositorio.Obter(requisicao.CodigoAtendimento);
            if (atendimentoInternacao != null)
            {
                return new ObterAtendimentoResultado()
                {
                    Atendimento = new AtendimentoInternacaoDTO()
                    {
                        CodigoAtendimento = atendimentoInternacao.CodigoAtendimento,
                        CodigoPaciente = atendimentoInternacao.CodigoPaciente,
                        CpfFonoaudiologa = atendimentoInternacao.CpfFonoaudiologa,
                        DataAlteracao = atendimentoInternacao.DataAlteracao,
                        DataInternacao = atendimentoInternacao.DataInternacao,
                        DataSolicitacao = atendimentoInternacao.DataSolicitacao,
                        IdSituacao = atendimentoInternacao.IdSituacao,
                        Quarto = atendimentoInternacao.Quarto,
                        TipoAtendimento = atendimentoInternacao.TipoAtendimento,
                        UsuarioAlteracao = atendimentoInternacao.UsuarioAlteracao
                    }
                };
            }

            throw new Exception("Atendimento não encontrado.");
        }
    }
}
