using System.Collections.Generic;
using Fronteiras.Dtos;
using Entidades;

namespace Fronteiras.Repositorios
{
    public interface IConvenioRepositorio
    {
        IEnumerable<Convenio> Listar();
    }
}
