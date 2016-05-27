using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Fonoart.SDK.AcessoDados
{
    public class ConnectionFactory : IDisposable
    {
        private IDbConnection _connectionSybase;

        private bool InTransaction { get; set; }

        [ThreadStatic]
        private static volatile ConnectionFactory _instance;
        private static readonly object SYNC_ROOT = new object();

        private ConnectionFactory()
        {
            _connectionSybase = null;
        }

        public static ConnectionFactory Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (SYNC_ROOT)
                {
                    if (_instance == null)
                        _instance = new ConnectionFactory();
                }

                return _instance;
            }
        }

        public IDbConnection GetConnection(string name)
        {
            var configuration = ConfigurationManager.ConnectionStrings[name];

            if (configuration == null)
                throw new Exception(string.Format("Não foi possível criar uma conexão para a connectionstring ( {0} )", name));

            var key = GetKey(configuration);

            var connection = key == "SYBASE" ? GetConnectionSybase(configuration) : CreateConnection(configuration);

            return connection;
        }

        private IDbConnection GetConnectionSybase(ConnectionStringSettings configuration)
        {
            IDbConnection connection;

            lock (SYNC_ROOT)
            {
                if (ReferenceEquals(_connectionSybase, null))
                {
                    connection = CreateConnection(configuration);

                    if (!InTransaction) return connection;

                    _connectionSybase = connection;
                    _connectionSybase.Open();
                }
                else
                {
                    connection = _connectionSybase;

                    if (connection == null || connection.State != ConnectionState.Closed) return connection;
                    connection.Dispose();
                    connection = CreateConnection(configuration);
                }
            }

            return connection;
        }

        private static IDbConnection CreateConnection(ConnectionStringSettings configuration)
        {
            var factory = DbProviderFactories.GetFactory(configuration.ProviderName);
            var connection = factory.CreateConnection();

            if (connection == null)
                throw new Exception(string.Format("Não foi possível criar uma conexão para a connectionstring ( {0} )", configuration.Name));

            connection.ConnectionString = configuration.ConnectionString;

            return connection;
        }

        private static string GetKey(ConnectionStringSettings configuration)
        {
            return configuration.ProviderName.ToUpper().Contains("SYBASE") ? "SYBASE" : configuration.Name;
        }

        public void Dispose()
        {
            if (_connectionSybase == null) return;

            if (_connectionSybase.State != ConnectionState.Closed)
                _connectionSybase.Close();

            _connectionSybase.Dispose();
            _connectionSybase = null;
        }

        public void Begin()
        {
            InTransaction = true;
        }

        public void End()
        {
            InTransaction = false;
        }
    }
}
