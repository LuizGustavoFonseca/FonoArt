namespace Fronteiras.Dtos
{
    public class AtendimentoInternacaoDTO : AtendimentoDTO
    {
        public bool VincularAtendimento { get; set; }
        public string CodigoAtendimentoPai { get; set; }
        public string Observacao { get; set; }
    }
}
