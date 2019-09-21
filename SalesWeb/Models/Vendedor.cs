using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public List<Venda> Vendas { get; private set; }

        public Vendedor()
        {
            Vendas = new List<Venda>();
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, decimal salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
            Vendas = new List<Venda>();
        }

        #region AdicionarVenda
        public void AdicionarVenda(Venda venda)
        {
            if (venda == null)
            {
                throw new Exception("Registro de venda inválido.");
            }

            Vendas.Add(venda);
        }
        #endregion

        #region RemoverVenda
        public void RemoverVenda(int codigoVenda)
        {
            var venda = Vendas.Where(v => v.Id == codigoVenda).FirstOrDefault();

            RemoverVenda(venda);
        }

        public void RemoverVenda(Venda venda)
        {
            if (venda == null)
            {
                throw new Exception("Venda informada inválida.");
            }

            Vendas.Remove(venda);
        }
        #endregion

        public decimal ValorTotalDeVendasPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendas.Where(v => v.Data >= dataInicial && v.Data <= dataFinal).Sum(v => v.Valor);
        }
    }
}
