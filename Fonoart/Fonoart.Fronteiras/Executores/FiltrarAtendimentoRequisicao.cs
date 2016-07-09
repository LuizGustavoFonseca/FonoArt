using System;

namespace Fronteiras.Executores
{
    public class FiltrarAtendimentoRequisicao
    {
        public string CodigoPaciente { get; set; }
        public string CodigoConvenio { get; set; }
        public string CpfFono { get; set; }
        public int? IdSituacao { get; set; }
        public DateTime? DataInicioSolicitacao { get; set; }
        public DateTime? DataFimSolicitacao { get; set; }
        public DateTime? DataInicioAltaAdministrativa { get; set; }
        public DateTime? DataFimAltaAdministrativa { get; set; }
    }
}
