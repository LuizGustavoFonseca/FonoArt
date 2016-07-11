﻿using Executores;
using Fonoart.SDK.Fronteira;
using Fonoart.SDK.InversaoControle;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using Repositorios;
using System.Collections.Generic;

namespace AL.NucleoPoliticasComerciais.Mapeamentos
{
    public static class Mapeador
    {
        public static Mapeamento[] Mapeamentos()
        {
            var listaMapeamentos = new List<Mapeamento>();

            #region Mapeamento de Executores
            
            listaMapeamentos.Add(new Mapeamento(typeof(IExecutorSemResultado<SalvarFonoaudiologaRequisicao>), typeof(SalvarFonoaudiologaExecutor)));
            listaMapeamentos.Add(new Mapeamento(typeof(IExecutorSemRequisicao<ListarFonoaudiologasResultado>), typeof(ListarFonoaudiologasExecutor)));
            listaMapeamentos.Add(new Mapeamento(typeof(IExecutor<ObterFonoaudiologaRequisicao, ObterFonoaudiologaResultado>), typeof(ObterFonoaudiologaExecutor)));
            listaMapeamentos.Add(new Mapeamento(typeof(IExecutorSemRequisicao<ListarSituacoesResultado>), typeof(ListarSituacoesExecutor)));
            listaMapeamentos.Add(new Mapeamento(typeof(IExecutorSemRequisicao<ListarConveniosResultado>), typeof(ListarConveniosExecutor)));
            listaMapeamentos.Add(new Mapeamento(typeof(IExecutor<ObterPacienteRequisicao, ObterPacienteResultado>), typeof(ObterPacienteExecutor)));
            #endregion

            #region Mapeamento de Repositorios

            listaMapeamentos.Add(new Mapeamento(typeof(IFonoaudiologaRepositorio), typeof(FonoaudiologaRepositorio)));
            listaMapeamentos.Add(new Mapeamento(typeof(ISituacaoRepositorio), typeof(SituacaoRepositorio)));
            listaMapeamentos.Add(new Mapeamento(typeof(IConvenioRepositorio), typeof(ConvenioRepositorio)));
            listaMapeamentos.Add(new Mapeamento(typeof(IPacienteRepositorio), typeof(PacienteRepositorio)));
            #endregion

            return listaMapeamentos.ToArray();
        }
    }
}
