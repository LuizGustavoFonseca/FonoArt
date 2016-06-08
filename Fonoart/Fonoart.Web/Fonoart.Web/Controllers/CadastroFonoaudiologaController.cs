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
    public class CadastroFonoaudiologaController : Controller
    {
        public ActionResult Index()
        {
            return View("Listagem");
        }

        public ActionResult Cadastro(string cpf)
        {
            return View("Cadastro", new CadastroFonoaudiologaModel() { Cpf = cpf });
        }

        public JsonResult ListarFonos()
        {
            var resultado = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemRequisicao<ListarFonoaudiologasResultado>>().Executar();

            return Json(new { Fonoaudiologas = resultado.Fonoaudiologas });
        }

        public JsonResult ObterFono(string cpf)
        {
            var resultado = ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutor<ObterFonoaudiologaRequisicao, ObterFonoaudiologaResultado>>().
                Executar(new ObterFonoaudiologaRequisicao() { Cpf = cpf });

            return Json(new { Fonoaudiologa = resultado.Fonoaudiologa });
        }

        public JsonResult SalvarFonoaudiologa([JsonBinder]FonoaudiologaDTO fonoaudiologa)
        {
            ResolvedorDeDependencias.Instance().ObterInstanciaDe<IExecutorSemResultado<SalvarFonoaudiologaRequisicao>>().
                Executar(new SalvarFonoaudiologaRequisicao() { Fonoaudiologa = fonoaudiologa, NovaFonoaudiologa = fonoaudiologa.NovaFonoaudiologa });

            return Json(new { });
        }
    }

    
}