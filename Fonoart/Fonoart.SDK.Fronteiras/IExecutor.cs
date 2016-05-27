namespace Fonoart.SDK.Fronteira
{
    public interface IExecutor<TRequisicao, TResultado> where TResultado : IResultado
    {
        TResultado Executar(TRequisicao requisicao);
    }

    public interface IExecutorSemRequisicao<TResultado> where TResultado : IResultado
    {
        TResultado Executar();
    }

    public interface IExecutorSemResultado<TRequisicao>
    {
        void Executar(TRequisicao requisicao);
    }
}