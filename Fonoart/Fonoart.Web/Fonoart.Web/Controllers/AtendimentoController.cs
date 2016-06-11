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
            var resultado = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarFonoaudiologasResultado>>().Executar();
            model.Fonoaudiologas = resultado.Fonoaudiologas;

            return View("Listagem", model);
        }        

        public ActionResult CadastroAtendimento(string codigoAtendimento)
        {
            return View("Cadastro", codigoAtendimento);
        }
    }
}