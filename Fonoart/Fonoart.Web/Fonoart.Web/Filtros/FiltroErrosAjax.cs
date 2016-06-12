using Fonoart.Util.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Fonoart.Web.Filtros
{
    public class FiltroErrosAjax : HandleErrorAttribute
    {
        public FiltroErrosAjax()
        {
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                if (filterContext.Exception is ArgumentException)
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            Mensagem = filterContext.Exception.Message,
                            Sucesso = false
                        }
                    };
                    filterContext.ExceptionHandled = true;
                    return;
                }
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Mensagem = MensagensErro.ERRO_INESPERADO,
                        Debug = filterContext.Exception.Message + " - stacktrace " + filterContext.Exception.StackTrace,
                        Sucesso = false
                    }
                };
                filterContext.ExceptionHandled = true;
            }
            else
            {
                base.OnException(filterContext);
            }            
            //Elmah.ErrorSignal.FromContext(filterContext.HttpContext.ApplicationInstance.Context).Raise(filterContext.Exception, filterContext.HttpContext.ApplicationInstance.Context);
        }
    }
}