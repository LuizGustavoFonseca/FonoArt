using Fonoart.SDK.InversaoControle;
using System.Collections.Generic;

namespace AL.NucleoPoliticasComerciais.Mapeamentos
{
    public static class Mapeador
    {
        public static Mapeamento[] Mapeamentos()
        {
            var listaMapeamentos = new List<Mapeamento>();

            #region Mapeamento de Executores
            
            //listaMapeamentos.Add(new Mapeamento(typeof(IExecutorSemResultado<AlterarSituacaoPropostaRequisicao>), typeof(AlterarSituacaoPropostaExecutor)));
            #endregion

            #region Mapeamento de Repositorios
            
            //listaMapeamentos.Add(new Mapeamento(typeof(IPermissaoRepositorio), typeof(PermissaoRepositorio)));
            
            #endregion

            return listaMapeamentos.ToArray();
        }
    }
}
