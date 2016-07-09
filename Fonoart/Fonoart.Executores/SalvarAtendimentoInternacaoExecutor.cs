using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executores
{
    public class SalvarAtendimentoInternacaoExecutor : IExecutorSemResultado<SalvarAtendimentoInternacaoRequisicao>
    {
        private IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio;

        public SalvarAtendimentoInternacaoExecutor(IAtendimentoInternacaoRepositorio atendimentoInternacaoRepositorio)
        {
            this.atendimentoInternacaoRepositorio = atendimentoInternacaoRepositorio;
        }

        public void Executar(SalvarAtendimentoInternacaoRequisicao requisicao)
        {
            AtendimentoInternacao atendimento = atendimentoInternacaoRepositorio.Obter(requisicao.AtendimentoInternacao.CodigoAtendimento);
            if(atendimento != null)
            {
                atendimentoInternacaoRepositorio.Criar(requisicao.AtendimentoInternacao.CodigoAtendimento, requisicao.AtendimentoInternacao.CodigoAtendimentoPai,
                    requisicao.AtendimentoInternacao.CodigoPaciente, requisicao.AtendimentoInternacao.CpfFonoaudiologa, DateTime.Now,
                    requisicao.AtendimentoInternacao.DataSolicitacao, requisicao.AtendimentoInternacao.IdSituacao, requisicao.AtendimentoInternacao.Observacao,
                    "Luiz Gustavo", requisicao.AtendimentoInternacao.VincularAtendimento, requisicao.AtendimentoInternacao.TipoAtendimento);
            }
            else
            {
                atendimentoInternacaoRepositorio.Atualizar(requisicao.AtendimentoInternacao.CodigoAtendimento, requisicao.AtendimentoInternacao.CodigoAtendimentoPai,
                    requisicao.AtendimentoInternacao.CodigoPaciente, requisicao.AtendimentoInternacao.CpfFonoaudiologa, DateTime.Now,
                    requisicao.AtendimentoInternacao.DataSolicitacao, requisicao.AtendimentoInternacao.IdSituacao, requisicao.AtendimentoInternacao.Observacao,
                    "Luiz Gustavo", requisicao.AtendimentoInternacao.VincularAtendimento, requisicao.AtendimentoInternacao.TipoAtendimento);
            }
        }
    }
}
