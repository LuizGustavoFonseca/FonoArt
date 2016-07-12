using AL.NucleoPoliticasComerciais.WebUI.Util.Atributo;
using Fonoart.SDK.Fronteira;
using Fonoart.SDK.InversaoControle;
using Fonoart.Web.Models;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fonoart.Web.Controllers
{
    public class AtendimentoController : Controller
    {
        public ActionResult Index()
        {
            AtendimentoModel model = new AtendimentoModel();
            var resultadoFono = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarFonoaudiologasResultado>>().Executar();
            var resultadoConvenios = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarConveniosResultado>>().Executar();
            var resultadoSituacao = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarSituacoesResultado>>().Executar();
            model.Fonoaudiologas = resultadoFono.Fonoaudiologas;
            model.Convenios = resultadoConvenios.Convenios;
            model.Situacoes = resultadoSituacao.Situacoes;

            return View("Listagem", model);
        }        

        public ActionResult CadastroAtendimento(string codigoAtendimento)
        {
            AtendimentoCadastroModel model = new AtendimentoCadastroModel();
            var resultadoFono = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarFonoaudiologasResultado>>().Executar();
            var resultadoConvenios = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarConveniosResultado>>().Executar();
            var resultadoSituacao = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarSituacoesResultado>>().Executar();
            model.Fonoaudiologas = resultadoFono.Fonoaudiologas;
            model.Convenios = resultadoConvenios.Convenios;
            model.Situacoes = resultadoSituacao.Situacoes;
            model.CodigoAtendimento = codigoAtendimento;

            return View("Cadastro", model);
        }

        public JsonResult SalvarAtendimentoInternacao([JsonBinder]AtendimentoInternacaoDTO atendimento)
        {
            ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemResultado<SalvarAtendimentoInternacaoRequisicao>>().
                Executar(new SalvarAtendimentoInternacaoRequisicao() {
                    AtendimentoInternacao = atendimento
                });

            return Json(new { });
        }

        public JsonResult ObterPaciente(string codigoPaciente)
        {
            var resultado = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutor<ObterPacienteRequisicao, ObterPacienteResultado>>().
                Executar(new ObterPacienteRequisicao()
                {
                    CodigoPaciente = codigoPaciente
                });

            return Json(new { Paciente = resultado.Paciente });
        }

        public JsonResult FiltrarAtendimento(string codigoPaciente, string codigoConvenio, string cpfFonoaudiologa, int? idSituacao, 
            DateTime? dataInicioSolicitacao, DateTime? dataFimSolicitacao, DateTime? dataInicioAltaAdministrativa, DateTime? dataFimAltaAdministrativa)
        {
            var resultado = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutor<FiltrarAtendimentoRequisicao, FiltrarAtendimentoResultado>>().
                Executar(new FiltrarAtendimentoRequisicao()
                {
                    CodigoConvenio = codigoConvenio,
                    CodigoPaciente = codigoPaciente,
                    CpfFono = cpfFonoaudiologa,
                    DataFimAltaAdministrativa = dataFimAltaAdministrativa,
                    DataFimSolicitacao = dataFimSolicitacao,
                    DataInicioAltaAdministrativa = dataInicioAltaAdministrativa,
                    DataInicioSolicitacao = dataInicioSolicitacao,
                    IdSituacao = idSituacao
                });

            return Json(new { AtendimentosAmbulatoriais = resultado.AtendimentosAmbulatoriais, AtendimentosInternacao = resultado.AtendimentosInternacao });
        }
    }
}