using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;

namespace Fronteiras.Executores
{
    public class ObterPacienteResultado : IResultado
    {
        public EstadoResultado Estado { get; set; }

        public PacienteDTO Paciente { get; set; }
    }
}
