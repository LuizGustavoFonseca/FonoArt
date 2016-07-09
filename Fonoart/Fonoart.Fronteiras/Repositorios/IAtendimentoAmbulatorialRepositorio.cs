using System.Collections.Generic;
using Entidades;
using System;

namespace Fronteiras.Repositorios
{
    public interface IAtendimentoAmbulatorialRepositorio
    {
        IEnumerable<AtendimentoAmbulatorial> Filtrar(string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, DateTime? dataInicioSolicitacao,
            DateTime? dataFimSolicitacao);
    }
}
