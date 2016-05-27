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
            return View("Listagem");
        }

        public ActionResult CadastroAtendimento(string codigoAtendimento)
        {
            return View("Cadastro", codigoAtendimento);
        }
    }
}