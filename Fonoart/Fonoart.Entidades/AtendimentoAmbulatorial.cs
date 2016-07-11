namespace Entidades
{
    public abstract class AtendimentoAmbulatorial : Atendimento
    {
        #region Campos
        public virtual bool VincularAtendimento { get; set; }
        public virtual string CodigoAtendimentoPai { get; set; }
        public virtual string Observacao { get; set; }        
        #endregion
    }
}
