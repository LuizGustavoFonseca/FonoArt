using System.Collections.Generic;
using Entidades;
using System;
using Fonoart.Util.Enum;

namespace Fronteiras.Repositorios
{
    public interface IAtendimentoInternacaoRepositorio
    {
        IEnumerable<AtendimentoInternacao> Filtrar(string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, DateTime? dataInicioSolicitacao, 
            DateTime? dataFimSolicitacao, DateTime? dataInicioAltaAdministrativa, DateTime? dataFimAltaAdministrativa);
        AtendimentoInternacao Obter(string codigoAtendimento);
                
        void Criar(string codigoAtendimento, string quarto, string codigoPaciente, string cpfFonoaudiologa, DateTime dataCriacao, DateTime dataSolicitacao, 
            int idSituacao, DateTime dataInternacao, string usuarioCriacao, TipoAtendimento tipoAtendimento);

        void Atualizar(string codigoAtendimento, string quarto, string codigoPaciente, string cpfFonoaudiologa, DateTime dataAtualizacao, DateTime dataSolicitacao, 
            int idSituacao, DateTime dataInternacao, string usuarioAlteracao, TipoAtendimento tipoAtendimento);
    }
}
