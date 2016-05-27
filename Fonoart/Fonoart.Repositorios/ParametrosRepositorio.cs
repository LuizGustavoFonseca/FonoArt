using AL.NucleoPoliticasComerciais.Repositorios.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.NucleoPoliticasComerciais.Repositorios
{
    public class ParametrosRepositorio : AdoHelper
    {
        public const string COD_PARAMETRO_TEMPO_SEM_LOCACAO = "PC_TEMPO_SEM_LOCACAO";
        public const string COD_PARAMETRO_TEMPO_ULTIMA_LOCACAO = "PC_TEMPO_ULT_LOCACAO";

        public const string CONSULTAR_NUM_DECIMAL = @"
            SELECT 
	            ipr.num_decimal
            FROM
	            itens_parametros ipr
            WHERE
	            ipr.cod_parametro = @CodigoParametro";

        public ParametrosRepositorio() : base(TipoConexao.Aguia)
        {
        }

        public int? ObterTempoSemLocacao()
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CodigoParametro", COD_PARAMETRO_TEMPO_SEM_LOCACAO, TipoParametro.StringComTamanhoVariavel);

            return Query<int>(CONSULTAR_NUM_DECIMAL, parametros).FirstOrDefault();
        }

        internal double? ObterParametroTempoUltimaLocacao()
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CodigoParametro", COD_PARAMETRO_TEMPO_SEM_LOCACAO, TipoParametro.StringComTamanhoVariavel);

            return Query<double>(CONSULTAR_NUM_DECIMAL, parametros).FirstOrDefault();
        }
    }
}
