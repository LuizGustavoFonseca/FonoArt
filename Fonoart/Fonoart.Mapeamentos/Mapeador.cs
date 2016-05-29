using Executores;
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
            #endregion

            #region Mapeamento de Repositorios

            listaMapeamentos.Add(new Mapeamento(typeof(IFonoaudiologaRepositorio), typeof(FonoaudiologaRepositorio)));
            
            #endregion

            return listaMapeamentos.ToArray();
        }
    }
}
