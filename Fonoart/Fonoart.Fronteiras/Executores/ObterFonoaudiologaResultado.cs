using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fronteiras.Executores
{
    public class ObterFonoaudiologaResultado : IResultado
    {
        public EstadoResultado Estado { get; set; }
        public FonoaudiologaDTO Fonoaudiologa { get; set; }        
    }
}
