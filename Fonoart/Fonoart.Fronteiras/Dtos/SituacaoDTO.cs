using Fonoart.Util.Enum;

namespace Fronteiras.Dtos
{
    public class SituacaoDTO
    {
        public int Identificador { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public TipoSituacao Tipo { get; set; }
    }
}
