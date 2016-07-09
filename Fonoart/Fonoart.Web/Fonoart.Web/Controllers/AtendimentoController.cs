using Fonoart.SDK.Fronteira;
using Fonoart.SDK.InversaoControle;
using Fonoart.Web.Models;
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
            return View("Cadastro", codigoAtendimento);
        }
    }
}