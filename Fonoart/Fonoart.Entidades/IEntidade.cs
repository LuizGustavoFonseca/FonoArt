using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.NucleoPoliticasComerciais.Entidades
{
    public interface IEntidade
    {
        IChaveEntidade ObterChave();
    }
}
