using System;

namespace Entidades
{
    public abstract class AtendimentoAmbulatorial : Atendimento
    {
        #region Campos
        public virtual string Quarto { get; set; }
        public virtual DateTime DataInternacao { get; set; }
        #endregion
    }
}
