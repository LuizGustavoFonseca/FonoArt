using Localiza.SDK.AcessoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AL.NucleoPoliticasComerciais.Repositorios
{
    public class AdoHelper
    {
        public enum TipoConexao
        {
            CorpDB,
            Aguia
        }

        private TipoConexao _conexao;

        public AdoHelper(TipoConexao conexao)
        {
            _conexao = conexao;
        }

        #region Métodos de Query
        public IEnumerable<T> Query<T>(String sql)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<T>(conexao, sql, null, null, true, null, null);
            }
        }

        public IEnumerable<T> Query<T>(String sql, Object parametro)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<T>(conexao, sql, parametro, null, true, null, null);
            }
        }

        public IEnumerable<T> Query<T>(String sql, Object parametro, bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<T>(conexao, sql, parametro, null, bufferizado, timeoutComando, tipoComando);
            }
        }
        #endregion

        #region Métodos de Query com múltiplos objetos por linha
        public IEnumerable<TRetorno> Query<TRetorno, TSegundo>(String sql, Func<TRetorno, TSegundo, TRetorno> funcaoMapeamento, Object parametro, String colunaDemarcacao = "Id", bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<TRetorno, TSegundo, TRetorno>(conexao, sql, funcaoMapeamento, parametro, null, bufferizado, colunaDemarcacao, timeoutComando, tipoComando);
            }
        }

        public IEnumerable<TRetorno> Query<TRetorno, TSegundo, Terceiro>(String sql, Func<TRetorno, TSegundo, Terceiro, TRetorno> funcaoMapeamento, Object parametro, String colunaDemarcacao = "Id", bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<TRetorno, TSegundo, Terceiro, TRetorno>(conexao, sql, funcaoMapeamento, parametro, null, bufferizado, colunaDemarcacao, timeoutComando, tipoComando);
            }
        }

        public IEnumerable<TRetorno> Query<TRetorno, TSegundo, Terceiro, TQuarto>(String sql, Func<TRetorno, TSegundo, Terceiro, TQuarto, TRetorno> funcaoMapeamento, Object parametro, String colunaDemarcacao = "Id", bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<TRetorno, TSegundo, Terceiro, TQuarto, TRetorno>(conexao, sql, funcaoMapeamento, parametro, null, bufferizado, colunaDemarcacao, timeoutComando, tipoComando);
            }
        }

        public IEnumerable<TRetorno> Query<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto>(String sql, Func<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TRetorno> funcaoMapeamento, Object parametro, String colunaDemarcacao = "Id", bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TRetorno>(conexao, sql, funcaoMapeamento, parametro, null, bufferizado, colunaDemarcacao, timeoutComando, tipoComando);
            }
        }

        public IEnumerable<TRetorno> Query<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TSexto>(String sql, Func<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TSexto, TRetorno> funcaoMapeamento, Object parametro, String colunaDemarcacao = "Id", bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TSexto, TRetorno>(conexao, sql, funcaoMapeamento, parametro, null, bufferizado, colunaDemarcacao, timeoutComando, tipoComando);
            }
        }

        public IEnumerable<TRetorno> Query<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TSexto, TSetimo>(String sql, Func<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TSexto, TSetimo, TRetorno> funcaoMapeamento, Object parametro, String colunaDemarcacao = "Id", bool bufferizado = true, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Query<TRetorno, TSegundo, Terceiro, TQuarto, TQuinto, TSexto, TSetimo, TRetorno>(conexao, sql, funcaoMapeamento, parametro, null, bufferizado, colunaDemarcacao, timeoutComando, tipoComando);
            }
        }
        #endregion

        #region Métodos de Execute
        public int Execute(String sql, Object parametro)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Execute(conexao, sql, parametro);
            }
        }

        public int Execute(String sql, Object parametro, CommandType tipoComando)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                return Dapper.SqlMapper.Execute(conexao, sql, parametro, null, null, tipoComando);
            }
        }

        public int ExecuteRetornandoIdentity(String sql, Object parametro)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                Dapper.SqlMapper.Execute(conexao, sql, parametro, null, null);
                return Dapper.SqlMapper.ExecuteScalar<int>(conexao, "SELECT @@IDENTITY AS int");
            }
        }

        public int ExecuteIgnorandoIdentity(String sql, Object parametro, String nomeTabela)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                Dapper.SqlMapper.Execute(conexao, String.Format("SET IDENTITY_INSERT {0} ON", nomeTabela), null, null, null);
                int retorno = Dapper.SqlMapper.Execute(conexao, sql, parametro, null, null);
                Dapper.SqlMapper.Execute(conexao, String.Format("SET IDENTITY_INSERT {0} OFF", nomeTabela), null, null, null);
                return retorno;
            }
        }

        public void ExecuteBulkInsert(DataTable tabela, string nomeTabela)
        {
            using (IDbConnection conexao = ObterConexao())
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                var bulkCopy = new SqlBulkCopy((SqlConnection)conexao)
                {
                    DestinationTableName = nomeTabela,
                    BatchSize = 5000
                };
                bulkCopy.WriteToServer(tabela);
            }            
        }

        #endregion

        private IDbConnection ObterConexao()
        {
            return ConnectionFactory.Instance.GetConnection(Enum.GetName(typeof(TipoConexao), _conexao));
        }
    }
}
