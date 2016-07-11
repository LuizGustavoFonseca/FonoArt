using AL.NucleoPoliticasComerciais.Repositorios;
using Fronteiras.Repositorios;
using MongoDB.Driver;
using Repositorios.Entidades;
using System;
using System.Collections.Generic;
using Entidades;
using Fonoart.Util.Enum;

namespace Repositorios
{
    public class AtendimentoInternacaoRepositorio : RepositorioBase<RAtendimentoInternacao>, IAtendimentoInternacaoRepositorio
    {
        #region Construtor Base
        public AtendimentoInternacaoRepositorio() : base("aten_inter") { }        
        #endregion

        #region IAtendimentoInternacaoRepositorio
        public IEnumerable<AtendimentoInternacao> Filtrar(string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, DateTime? dataInicioSolicitacao, DateTime? dataFimSolicitacao, DateTime? dataInicioAltaAdministrativa, DateTime? dataFimAltaAdministrativa)
        {
            var filtro = Builders<RAtendimentoInternacao>.Filter.Where(atendimento => ObterCondicoes(atendimento, codigoPaciente, codigoConvenio, cpfFono, idSituacao,
                dataInicioSolicitacao, dataFimSolicitacao, dataInicioAltaAdministrativa, dataFimAltaAdministrativa));
            return Listar(filtro);
        }

        public void Criar(string codigoAtendimento, string quarto, string codigoPaciente, string cpfFonoaudiologa, DateTime dataCriacao, DateTime dataSolicitacao,
            int idSituacao, DateTime dataInternacao, string usuarioCriacao, TipoAtendimento tipoAtendimento)
        {
            var entidade = new RAtendimentoInternacao()
            {
                CodigoAtendimento = codigoAtendimento,
                Quarto = quarto,
                CodigoPaciente = codigoPaciente,
                CpfFonoaudiologa = cpfFonoaudiologa,
                DataAlteracao = dataCriacao,
                DataSolicitacao = dataSolicitacao,
                IdSituacao = idSituacao,                
                TipoAtendimento = tipoAtendimento,
                UsuarioAlteracao = usuarioCriacao,
                DataInternacao = dataInternacao
            };
            Inserir(entidade);
        }

        public void Atualizar(string codigoAtendimento, string quarto, string codigoPaciente, string cpfFonoaudiologa, DateTime dataAtualizacao, DateTime dataSolicitacao,
            int idSituacao, DateTime dataInternacao, string usuarioAlteracao, TipoAtendimento tipoAtendimento)
        {
            var filtro = Builders<RAtendimentoInternacao>.Filter.Eq("CodigoAtendimento", codigoAtendimento);
            var update = Builders<RAtendimentoInternacao>.Update.Set("Quarto", quarto).
                Set("CodigoPaciente", codigoPaciente).Set("CpfFonoaudiologa", cpfFonoaudiologa).Set("DataAlteracao", dataAtualizacao).
                Set("DataSolicitacao", dataSolicitacao).Set("IdSituacao", idSituacao).
                Set("DataInternacao", dataInternacao).Set("TipoAtendimento", tipoAtendimento).Set("UsuarioAlteracao", usuarioAlteracao);

            Atualizar(filtro, update);
        }

        public AtendimentoInternacao Obter(string codigoAtendimento)
        {
            var filtro = Builders<RAtendimentoInternacao>.Filter.Eq("CodigoAtendimento", codigoAtendimento);
            return Obter(filtro);
        }
        #endregion

        #region Métodos Privados
        private bool ObterCondicoes(RAtendimentoInternacao atendimento, string codigoPaciente, string codigoConvenio, string cpfFono, int? idSituacao, 
            DateTime? dataInicioSolicitacao, DateTime? dataFimSolicitacao, DateTime? dataInicioAltaAdministrativa, DateTime? dataFimAltaAdministrativa)
        {
            bool condicao = true;
            if (!string.IsNullOrWhiteSpace(codigoPaciente))
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
            if (idSituacao.HasValue)
            {
                condicao &= atendimento.Situacao?.Identificador == idSituacao.Value;
            }
            if (dataInicioSolicitacao.HasValue)
            {
                condicao &= atendimento.DataSolicitacao > dataInicioSolicitacao.Value;
            }
            if (dataFimSolicitacao.HasValue)
            {
                condicao &= atendimento.DataSolicitacao <= dataFimSolicitacao.Value;
            }
            if (dataInicioAltaAdministrativa.HasValue)
            {
                condicao &= atendimento.DataSolicitacao > dataInicioAltaAdministrativa.Value;
            }
            if (dataFimAltaAdministrativa.HasValue)
            {
                condicao &= atendimento.DataSolicitacao <= dataFimAltaAdministrativa.Value;
            }
            return condicao;
        }
        #endregion
    }
}
