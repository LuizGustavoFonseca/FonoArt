using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.NucleoPoliticasComerciais.Repositorios.Util
{
    public class MapeadorPrefixoColunas : SqlMapper.ITypeMap
    {
        public static void RegistrarPrefixos<Tipo>(params String[] prefixos)
        {
            SqlMapper.SetTypeMap(typeof(Tipo), new MapeadorPrefixoColunas(typeof(Tipo), prefixos));
        }

        private IEnumerable<String> prefixos;
        private SqlMapper.ITypeMap mapeadorBase;

        private MapeadorPrefixoColunas(Type tipo, params String[] prefixos)
        {
            this.mapeadorBase = new DefaultTypeMap(tipo);
            this.prefixos = prefixos;
        }

        public System.Reflection.ConstructorInfo FindConstructor(String[] names, Type[] types)
        {
            return this.mapeadorBase.FindConstructor(names, types);
        }

        public System.Reflection.ConstructorInfo FindExplicitConstructor()
        {
            return this.mapeadorBase.FindExplicitConstructor();
        }

        public SqlMapper.IMemberMap GetConstructorParameter(System.Reflection.ConstructorInfo constructor, String columnName)
        {
            return this.mapeadorBase.GetConstructorParameter(constructor, columnName);
        }

        public SqlMapper.IMemberMap GetMember(String columnName)
        {
            if (prefixos == null || prefixos.Count() == 0)
            {
                return this.mapeadorBase.GetMember(columnName);
            }

            String encontrado = prefixos.FirstOrDefault(prefixo => columnName.StartsWith(prefixo + "."));
            if (!String.IsNullOrWhiteSpace(encontrado))
            {
                columnName = columnName.Substring(encontrado.Length + 1);
            }

            return this.mapeadorBase.GetMember(columnName);
        }
    }
}
