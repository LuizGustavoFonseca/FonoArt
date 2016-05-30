using MongoDB.Bson;
using System;

namespace Fronteiras.Dtos
{
    public class FonoaudiologaDTO
    {
        public ObjectId _id { get; set; }
        public string Cpf { get; set; }
        public string Crfa { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string DataNascimentoFormatada { get { return DataNascimento.ToShortDateString(); } }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public bool NovaFonoaudiologa { get; set; }
    }
}
