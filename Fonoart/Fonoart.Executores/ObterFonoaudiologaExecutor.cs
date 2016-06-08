using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Dtos;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executores
{
    public class ObterFonoaudiologaExecutor : IExecutor<ObterFonoaudiologaRequisicao, ObterFonoaudiologaResultado>
    {
        private IFonoaudiologaRepositorio fonoaudiologaRepositorio;

        public ObterFonoaudiologaExecutor(IFonoaudiologaRepositorio fonoaudiologaRepositorio)
        {
            this.fonoaudiologaRepositorio = fonoaudiologaRepositorio;
        }

        public ObterFonoaudiologaResultado Executar(ObterFonoaudiologaRequisicao requisicao)
        {
            Fonoaudiologa fonoaudiologa = fonoaudiologaRepositorio.Obter(requisicao.Cpf);

            return new ObterFonoaudiologaResultado()
            {
                Fonoaudiologa = new FonoaudiologaDTO()
                {
                    Cpf = fonoaudiologa.Cpf,
                    Crfa = fonoaudiologa.Crfa,
                    DataNascimento = fonoaudiologa.DataNascimento,
                    Endereco = fonoaudiologa.Endereco,
                    Nome = fonoaudiologa.Nome,
                    Telefone = fonoaudiologa.Telefone
                }
            };
        }
    }
}
