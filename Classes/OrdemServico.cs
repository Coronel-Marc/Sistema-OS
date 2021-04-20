using System;

namespace OsSistemas.Classes
{
    public class OrdemServico : EntidadeBase
    {
        //Atributos
        private string TituloOS{get; set;}
        private string DescricaoServico {get; set;}
        private decimal Valor{get; set;}
        private string Endereco{get; set;}
        private string NomeCliente{get; set;}
        private int CpfCnpj{get; set;}
        private DateTime DataEmissao{get; set;}
        private FormaDePagamento FormaDePagamento{get; set;}
        private string NomeTecnico {get; set;}
        private bool Excluido {get; set;}

        //Metodos

        public OrdemServico(int id, string tituloOS, string descricaoServico, decimal valor, string endereco,
                            string nomeCliente, int cpfCnpj, DateTime dataEmissao, FormaDePagamento formaDePagamento, string nomeTecnico)
        {
            this.Id = id;
            this.TituloOS = tituloOS;
            this.DescricaoServico = descricaoServico;
            this.Valor = valor;
            this.Endereco = endereco;
            this.NomeCliente = nomeCliente;
            this.CpfCnpj = cpfCnpj;
            this.DataEmissao = dataEmissao;
            this.FormaDePagamento = formaDePagamento;
            this.NomeTecnico = nomeTecnico;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            
            retorno += "Titulo da OS: " + this.TituloOS + Environment.NewLine;
            retorno += "Descrição da OS: " + this.DescricaoServico + Environment.NewLine;
            retorno += "Valor: " + this.Valor + Environment.NewLine;
            retorno += "Endereço: " + this.Endereco + Environment.NewLine;
            retorno += "Nome do Cliente: " + this.NomeCliente + Environment.NewLine;
            retorno += "CPF/CNPJ: " + this.CpfCnpj + Environment.NewLine;
            retorno += "Data de Emissão: " + this.DataEmissao + Environment.NewLine;
            retorno += "Forma de pagamento: " + this.FormaDePagamento + Environment.NewLine;
            retorno += "Nome do Técnico: " + this.NomeTecnico + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido + Environment.NewLine;

            return retorno;
        }


        public string retornaTitulo()
        {
            return this.TituloOS;
        }
        public int retornaNumeroOS()
        {
            return this.Id;
        }
        public bool retornaExcluidoId()
        {
            return this.Excluido;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
    }
}