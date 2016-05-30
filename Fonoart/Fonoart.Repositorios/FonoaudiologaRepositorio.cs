﻿using System;
using AL.NucleoPoliticasComerciais.Repositorios;
using Fronteiras.Repositorios;
using Repositorios.Entidades;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections;
using Entidades;

namespace Repositorios
{
    public class FonoaudiologaRepositorio : RepositorioBase<RFonoaudiologa>, IFonoaudiologaRepositorio
    {
        #region Construtor Base
        public FonoaudiologaRepositorio() : base("fono") { }
        #endregion

        #region IFonoaudiologaRepositorio
        public void Atualizar(string cpf, string crfa, DateTime dataNascimento, string endereco, string nome, string telefone)
        {
            var filter = Builders<RFonoaudiologa>.Filter.Eq("Cpf", cpf);
            List<UpdateDefinitionBuilder<RFonoaudiologa>> lista = new List<UpdateDefinitionBuilder<RFonoaudiologa>>();
            var update = new UpdateDefinitionBuilder<RFonoaudiologa>().AddToSet("Crfa", crfa).AddToSet("DataNascimento", dataNascimento).
                AddToSet("Endereco", endereco).AddToSet("Nome", nome).AddToSet("Telefone", telefone);
            update.Set("DataNascimento", dataNascimento);

            Atualizar(filter, update);
        }

        public void Criar(string cpf, string crfa, DateTime dataNascimento, string endereco, string nome, string telefone)
        {
            var entidade = new RFonoaudiologa() { Cpf = cpf, Crfa = crfa, DataNascimento = dataNascimento, Endereco = endereco, Nome = nome, Telefone = telefone };
            Inserir(entidade);            
        }

        public IEnumerable<Fonoaudiologa> Listar()
        {
            var filtro = Builders<RFonoaudiologa>.Filter.Empty;
            return Listar(filtro);
        }

        public Fonoaudiologa Obter(string cpf)
        {
            var filtro = Builders<RFonoaudiologa>.Filter.Eq("Cpf", cpf);
            return Obter(filtro);
        }
        #endregion
    }
}
