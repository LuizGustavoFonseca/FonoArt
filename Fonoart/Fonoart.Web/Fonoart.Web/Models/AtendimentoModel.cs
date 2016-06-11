using Fronteiras.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fonoart.Web.Models
{
    public class AtendimentoModel
    {
        public IEnumerable<FonoaudiologaDTO> Fonoaudiologas { get; set; }
    }
}