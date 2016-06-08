using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace AL.NucleoPoliticasComerciais.WebUI.Util.Atributo
{
    public class JsonBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }

        public class JsonModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext cc, ModelBindingContext bc)
            {
                //StreamReader v = new StreamReader(cc.HttpContext.Request.InputStream);
                //string linha = v.ReadToEnd();
                return new DataContractJsonSerializer(bc.ModelType)
                .ReadObject(cc.HttpContext.Request.InputStream);
            }
        }
    }
}