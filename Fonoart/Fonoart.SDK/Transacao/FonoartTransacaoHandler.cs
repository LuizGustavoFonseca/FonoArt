using Fonoart.SDK.AcessoDados;
using Fonoart.SDK.Fronteira;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Transactions;

namespace Fonoart.SDK.Transacao
{
    internal class FonoartTransacaoHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            using (var tx = new TransactionScope())
            {
                ConnectionFactory.Instance.Begin();

                var result = getNext()(input, getNext);
                var resultMessage = result as IResultado;

                if (result.Exception == null || (resultMessage != null && resultMessage.Estado == EstadoResultado.OK))
                    tx.Complete();

                ConnectionFactory.Instance.End();
                ConnectionFactory.Instance.Dispose();

                return result;
            }
        }

        public int Order { get; set; }
    }
}