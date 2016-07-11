namespace Fronteiras.Dtos
{
    public class AtendimentoAmbulatorialDTO : AtendimentoDTO
    {
        public bool VincularAtendimento { get; set; }
        public string CodigoAtendimentoPai { get; set; }
        public string Observacao { get; set; }        
    }
}
