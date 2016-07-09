using System;
using System.Collections.Generic;
using AL.NucleoPoliticasComerciais.Repositorios;
using Entidades;
using Fronteiras.Repositorios;
using Repositorios.Entidades;
using MongoDB.Driver;

namespace Repositorios
{
    public class AtendimentoAmbulatorialRepositorio : RepositorioBase<RAtendimentoAmbulatorial>, IAtendimentoAmbulatorialRepositorio
    {
        #region Construtor Base
        public AtendimentoAmbulatorialRepositorio() : base("aten_ambu") { }
        #endregion

        #region IAtendimentoAmbulatorialRepositorio
        public IEnumerable<AtendimentoAmbulatorial> Filtrar(string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, DateTime? dataInicioSolicitacao, DateTime? dataFimSolicitacao)
        {
            var filtro = Builders<RAtendimentoAmbulatorial>.Filter.Where(atendimento => ObterCondicoes(atendimento, codigoPaciente, codigoConvenio, cpfFono, idSituacao, dataInicioSolicitacao, dataFimSolicitacao));
            return Listar(filtro);
        }
        #endregion

        #region Métodos Privados
        private bool ObterCondicoes(RAtendimentoAmbulatorial atendimento, string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, DateTime? dataInicioSolicitacao, DateTime? dataFimSolicitacao)
        {
            bool condicao = true;
            if(!string.IsNullOrWhiteSpace(codigoPaciente))
            {
                condicao &= atendimento.Paciente?.CodigoPaciente == codigoPaciente;
            }
            if (!string.IsNullOrWhiteSpace(codigoConvenio))
            {
                condicao &= atendimento.Paciente?.CodigoConvenio == codigoConvenio;
            }
            if (!string.IsNullOrWhiteSpace(cpfFono))
            {
                condicao &= atendimento.Fonoaudiologa?.Cpf == cpfFono;
            }
            if(idSituacao.HasValue)
            {
                condicao &= atendimento.Situacao?.Identificador == idSituacao.Value;
            }
            if(dataInicioSolicitacao.HasValue)
            {
                condicao &= atendimento.DataSolicitacao > dataInicioSolicitacao.Value;
            }
            if(dataFimSolicitacao.HasValue)
            {
                condicao &= atendimento.DataSolicitacao <= dataFimSolicitacao.Value;
            }
            return condicao;
        }
        #endregion
    }
}
