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
    public class ListarFonoaudiologasExecutor : IExecutorSemRequisicao<ListarFonoaudiologasResultado>
    {
        private IFonoaudiologaRepositorio fonoaudiologaRepositorio;

        public ListarFonoaudiologasExecutor(IFonoaudiologaRepositorio fonoaudiologaRepositorio)
        {
            this.fonoaudiologaRepositorio = fonoaudiologaRepositorio;
        }

        public ListarFonoaudiologasResultado Executar()
        {
            return new ListarFonoaudiologasResultado()
            {
                Estado = EstadoResultado.OK,
                Fonoaudiologas =  fonoaudiologaRepositorio.Listar().Select(item => new FonoaudiologaDTO()
                {
                    Cpf = item.Cpf,
                    Crfa= item.Crfa,
                    DataNascimento = item.DataNascimento,
                    Endereco = item.Endereco,
                    Nome = item.Nome,
                    Telefone = item.Telefone,
                    _id = item._id
                })
            };
        }
    }
}
