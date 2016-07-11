using Entidades;

namespace Fronteiras.Repositorios
{
    public interface IPacienteRepositorio
    {
        Paciente Obter(string codigoPaciente);
        void Criar(string codigoConvenio, string codigoPaciente, string nomePaciente, string numeroCarteirinha, string telefonePaciente);
    }
}
