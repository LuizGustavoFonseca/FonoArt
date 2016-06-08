using Fonoart.SDK.Fronteira;
using Fronteiras.Executores;
using Fronteiras.Repositorios;

namespace Executores
{
    public class SalvarFonoaudiologaExecutor : IExecutorSemResultado<SalvarFonoaudiologaRequisicao>
    {
        private IFonoaudiologaRepositorio fonoaudiologaRepositorio;

        public SalvarFonoaudiologaExecutor(IFonoaudiologaRepositorio fonoaudiologaRepositorio)
        {
            this.fonoaudiologaRepositorio = fonoaudiologaRepositorio;
        }

        public void Executar(SalvarFonoaudiologaRequisicao requisicao)
        {
            if(requisicao.NovaFonoaudiologa)
            {
                fonoaudiologaRepositorio.Criar(requisicao.Fonoaudiologa.Cpf, requisicao.Fonoaudiologa.Crfa, requisicao.Fonoaudiologa.DataNascimento, requisicao.Fonoaudiologa.Endereco,
                    requisicao.Fonoaudiologa.Nome, requisicao.Fonoaudiologa.Telefone);
            }
            else
            {
                fonoaudiologaRepositorio.Atualizar(requisicao.Fonoaudiologa.Cpf, requisicao.Fonoaudiologa.Crfa, requisicao.Fonoaudiologa.DataNascimento, requisicao.Fonoaudiologa.Endereco,
                    requisicao.Fonoaudiologa.Nome, requisicao.Fonoaudiologa.Telefone);
            }
        }
    }
}
