using System.Collections.Generic;
using Entidades;
using System;
using Fonoart.Util.Enum;

namespace Fronteiras.Repositorios
{
    public interface IAtendimentoAmbulatorialRepositorio
    {
        IEnumerable<AtendimentoAmbulatorial> Filtrar(string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, DateTime? dataInicioSolicitacao,
            DateTime? dataFimSolicitacao);
        AtendimentoAmbulatorial Obter(string codigoAtendimento);
        void Atualizar(object codigoAtendimento, object quarto, object codigoPaciente, object cpfFonoaudiologa, DateTime now, object dataSolicitacao, object idSituacao, object dataInternacao, string v, object tipoAtendimento);
        void Criar(string codigoAtendimento, string codigoAtendimentoPai, string codigoPaciente, string cpfFonoaudiologa, DateTime now, DateTime dataSolicitacao, int idSituacao, string observacao, string v, TipoAtendimento tipoAtendimento);
    }
}
