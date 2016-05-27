using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Fonoart.SDK.Transacao;

namespace Fonoart.SDK.InversaoControle
{
    public class ResolvedorDeDependencias
    {
        private static volatile ResolvedorDeDependencias _instance;
        private static volatile object _sync = new object();
        private readonly IUnityContainer _container;

        private ResolvedorDeDependencias()
        {
            _container = new UnityContainer();
            _container.AddNewExtension<Interception>();
            _container.Configure<Interception>()
                .AddPolicy("policy")
                .AddMatchingRule(new CustomAttributeMatchingRule(typeof(FonoartTransacaoAttribute), false))
                .AddCallHandler(new FonoartTransacaoHandler());
        }

        public static ResolvedorDeDependencias Instance()
        {
            if (_instance != null) return _instance;

            lock (_sync)
            {
                if (_instance == null)
                    _instance = new ResolvedorDeDependencias();
            }

            return _instance;
        }

        public void CarregarMapeamentos(params Mapeamento[] mapeamentos)
        {
            lock (_sync)
            {
                foreach (var mapeamento in mapeamentos)
                    RegistrarMapeamento(mapeamento, false);
            }
        }

        public void CarregarMapeamentosSobrescrevendo(params Mapeamento[] mapeamentos)
        {
            lock (_sync)
            {
                foreach (var mapeamento in mapeamentos)
                    RegistrarMapeamento(mapeamento, true);
            }
        }

        private void RegistrarMapeamento(Mapeamento mapeamento, bool sobreescrever)
        {
            if (string.IsNullOrEmpty(mapeamento.Nome))
            {
                if (!sobreescrever && _container.IsRegistered(mapeamento.De))
                    throw new Exception(string.Format("Já existe registro de mapeamento para este tipo ( {0} ), verifique o tipo ou faça o registro explicitando um nome.", mapeamento.De.FullName));

                _container.RegisterType(mapeamento.De, mapeamento.Para, new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());
            }
            else
            {
                if (!sobreescrever && _container.IsRegistered(mapeamento.De, mapeamento.Nome))
                    throw new Exception(string.Format("Já existe registro de mapeamento nomeado para este tipo ( {0} ), verifique o tipo.", mapeamento.De.FullName));

                _container.RegisterType(mapeamento.De, mapeamento.Para, mapeamento.Nome, new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());
            }
        }

        public void LimparMapeamentos()
        {
            foreach (var registration in _container.Registrations.Where(r => r.LifetimeManager != null))
            {
                if (registration.RegisteredType.Namespace != null && registration.RegisteredType.Namespace.Contains("Microsoft.Practices.Unity")) continue;
                registration.LifetimeManager.RemoveValue();
            }
        }

        /// <summary>
        /// Obtem instância de objeto baseado em um mapeamento que seja nomeado.
        /// Este método é para ser utilizado quando possuir dois mapeamentos onde as interfaces base são iguais.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto que deseja obter a injeção</typeparam>
        /// <returns></returns>
        public T ObterInstanciaDe<T>()
        {
            return ObterInstanciaDe<T>(string.Empty);
        }

        public T ObterInstanciaDe<T>(params ISobrescreverMapeamento[] parametros)
        {
            return ObterInstanciaDe<T>(string.Empty, parametros);
        }

        /// <summary>
        /// Obtem instância de objeto baseado em um mapeamento que seja nomeado.
        /// Este método é para ser utilizado quando possuir dois mapeamentos onde as interfaces base são iguais.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto que deseja obter a injeção</typeparam>
        /// <param name="Nome">Nome do mapeamento para o tipo</param>
        /// <returns></returns>
        public T ObterInstanciaDe<T>(string nome)
        {
            return ObterInstanciaDe<T>(nome, null);
        }

        public T ObterInstanciaDe<T>(string nome, params ISobrescreverMapeamento[] parametros)
        {
            try
            {
                T resolved;

                var parameters = BuildParameters(parametros);

                if (string.IsNullOrEmpty(nome))
                    resolved = parameters == null ? _container.Resolve<T>() : _container.Resolve<T>(parameters);
                else
                    resolved = parameters == null ? _container.Resolve<T>(nome) : _container.Resolve<T>(nome, parameters);

                return resolved;
            }
            catch
            {
                throw new Exception(string.Format("Ocorreu erro ao tentar obter o tipo {0}, verifique o injetor.", typeof(T).Name));
            }
        }

        private static ResolverOverride[] BuildParameters(ISobrescreverMapeamento[] parametros)
        {
            if (parametros == null || !parametros.Any()) return null;

            var resultado = new List<ResolverOverride>();

            resultado.AddRange(BuildParametersTipo(parametros.OfType<SobrescreverMapeamentoTipo>()));
            resultado.AddRange(BuildParametersNome(parametros.OfType<SobrescreverMapeamentoNome>()));

            return resultado.ToArray();
        }

        private static IEnumerable<ResolverOverride> BuildParametersNome(IEnumerable<SobrescreverMapeamentoNome> parametros)
        {
            return
                parametros.Select(parametro => new ParameterOverride(parametro.NomeParametro, parametro.Para)) as IEnumerable<ResolverOverride>;
        }

        private static IEnumerable<ResolverOverride> BuildParametersTipo(IEnumerable<SobrescreverMapeamentoTipo> parametros)
        {
            return parametros.Select(parametro => new DependencyOverride(parametro.De, parametro.Para)) as IEnumerable<ResolverOverride>;
        }
    }
}
