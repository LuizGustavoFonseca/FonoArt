using Entidades;
using Fonoart.SDK.Fronteira;
using Fronteiras.Executores;
using Fronteiras.Repositorios;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fronteiras.Dtos;
using System;
using Fonoart.Util.Resource;

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
            ValidarFonoaudiologa(requisicao.Fonoaudiologa);
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

        private void ValidarFonoaudiologa(FonoaudiologaDTO fonoaudiologa)
        {
            if(string.IsNullOrWhiteSpace(fonoaudiologa.Cpf))
            {
                throw new ArgumentException(MensagensErro.ERRO_CPF_OBRIGATORIO);
            }
            if(string.IsNullOrWhiteSpace(fonoaudiologa.Crfa))
            {
                throw new ArgumentException(MensagensErro.ERRO_CRFA_OBRIGATORIO);
            }
            if(string.IsNullOrWhiteSpace(fonoaudiologa.Nome))
            {
                throw new ArgumentException(MensagensErro.ERRO_NOME_OBRIGATORIO);
            }
            IEnumerable<Fonoaudiologa> fonos = fonoaudiologaRepositorio.Listar();            
            if (fonos.Any(fono => fonoaudiologa.Cpf == fono.Cpf))
            {
                throw new ArgumentException(MensagensErro.ERRO_CPF_EXISTENTE);
            }
        }
    }
}
