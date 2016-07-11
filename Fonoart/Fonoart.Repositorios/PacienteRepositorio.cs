using System;
using AL.NucleoPoliticasComerciais.Repositorios;
using Entidades;
using Fronteiras.Repositorios;
using MongoDB.Driver;
using Repositorios.Entidades;

namespace Repositorios
{
    public class PacienteRepositorio : RepositorioBase<RPaciente>, IPacienteRepositorio
    {
        #region Construtor Base
        public PacienteRepositorio() : base("paciente") { }        
        #endregion

        #region IPacienteRepositorio
        public Paciente Obter(string codigoPaciente)
        {
            var filtro = Builders<RPaciente>.Filter.Eq("CodigoPaciente", codigoPaciente);
            return Obter(filtro);
        }

        public void Criar(string codigoConvenio, string codigoPaciente, string nomePaciente, string numeroCarteirinha, string telefonePaciente)
        {
            var entidade = new RPaciente()
            {
                CodigoConvenio = codigoConvenio,
                CodigoPaciente = codigoPaciente,
                NomePaciente = nomePaciente,
                NumeroCarteirinha = numeroCarteirinha,
                TelefonePaciente = telefonePaciente
            };
            Inserir(entidade);
        }
        #endregion
    }
}
