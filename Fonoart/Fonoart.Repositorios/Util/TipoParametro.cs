using System;
using System.Configuration;
using System.Data;

namespace AL.NucleoPoliticasComerciais.Repositorios.Util
{
    public static class TipoParametro
    {
        public static DbType Inteiro { get { return DbType.Int32; } }
        public static DbType InteiroCurto { get { return DbType.Int16; } }
        public static DbType InteiroLongo { get { return DbType.Int64; } }
        public static DbType StringComTamanhoFixo { get { return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["projetoTeste"]) ? DbType.AnsiStringFixedLength : DbType.String; } }
        public static DbType StringComTamanhoVariavel { get { return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["projetoTeste"]) ? DbType.AnsiString : DbType.String; } }
        public static DbType DataETempo { get { return DbType.DateTime; } }
        public static DbType Boleano { get { return DbType.Boolean; } }
        public static DbType Double { get { return DbType.Double; } }
        public static DbType Guid { get { return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["projetoTeste"]) ? DbType.Guid : DbType.String; } }
    }
}
