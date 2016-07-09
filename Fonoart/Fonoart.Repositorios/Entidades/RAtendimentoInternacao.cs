using Entidades;

namespace Repositorios.Entidades
{
    public class RAtendimentoInternacao : AtendimentoInternacao
    {
        public override Fonoaudiologa Fonoaudiologa { get; set; }        

        public override Paciente Paciente { get; set; }        

        public override Situacao Situacao { get; set; }        
    }
}
