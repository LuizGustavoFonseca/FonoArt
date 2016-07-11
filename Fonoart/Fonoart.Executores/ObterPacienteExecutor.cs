using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using Fronteiras.Repositorios;

namespace Executores
{
    public class ObterPacienteExecutor : IExecutor<ObterPacienteRequisicao, ObterPacienteResultado>
    {
        private IPacienteRepositorio pacienteRepositorio;

        public ObterPacienteExecutor(IPacienteRepositorio pacienteRepositorio)
        {
            this.pacienteRepositorio = pacienteRepositorio;
        }

        public ObterPacienteResultado Executar(ObterPacienteRequisicao requisicao)
        {
            Paciente paciente = pacienteRepositorio.Obter(requisicao.CodigoPaciente);

            return new ObterPacienteResultado()
            {
                Paciente = paciente != null ? new PacienteDTO()
                {
                    CodigoConvenio = paciente.CodigoConvenio,
                    CodigoPaciente = paciente.CodigoPaciente,
                    NomePaciente = paciente.NomePaciente,
                    NumeroCarteirinha = paciente.NumeroCarteirinha,
                    TelefonePaciente = paciente.TelefonePaciente
                } : null
            };
        }
    }
}
