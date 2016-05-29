using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fronteiras.Repositorios
{
    public interface IFonoaudiologaRepositorio
    {
        void Criar(string cpf, string crfa, DateTime dataNascimento, string endereco, string nome, string telefone);
        void Atualizar(string cpf, string crfa, DateTime dataNascimento, string endereco, string nome, string telefone);
        IEnumerable<Fonoaudiologa> Listar();
    }
}
