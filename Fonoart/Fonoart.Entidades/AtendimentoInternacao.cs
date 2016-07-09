using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class AtendimentoInternacao : Atendimento
    {
        #region Campos
        public virtual bool VincularAtendimento { get; set; }
        public virtual string CodigoAtendimentoPai { get; set; }
        public virtual string Observacao { get; set; }
        #endregion
    }
}
