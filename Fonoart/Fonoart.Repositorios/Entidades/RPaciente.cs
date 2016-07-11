using Entidades;

namespace Repositorios.Entidades
{
    public class RPaciente : Paciente
    {
        public override Convenio Convenio { get; set; }        
    }
}
