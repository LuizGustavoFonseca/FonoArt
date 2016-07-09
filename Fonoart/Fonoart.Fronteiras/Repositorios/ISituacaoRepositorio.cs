using Entidades;
using System.Collections.Generic;

namespace Fronteiras.Repositorios
{
    public interface ISituacaoRepositorio
    {
        IEnumerable<Situacao> Listar();
    }
}
