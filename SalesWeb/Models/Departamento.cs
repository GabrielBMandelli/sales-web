using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Vendedor> Vendedores { get; private set; }

        public Departamento()
        {
            Vendedores = new List<Vendedor>();
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Vendedores = new List<Vendedor>();
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            if (vendedor == null)
            {
                throw new Exception("Vendedor inválido.");
            }

            if (Vendedores.Where(v => v.Id == vendedor.Id).Any())
            {
                var vendedorRemovido = Vendedores.Where(v => v.Id == vendedor.Id).FirstOrDefault();

                RemoverVendedor(vendedorRemovido);
            }

            Vendedores.Add(vendedor);
        }

        public void RemoverVendedor(Vendedor vendedor)
        {
            if (vendedor == null)
            {
                throw new Exception("Vendedor inválido.");
            }

            Vendedores.Remove(vendedor);
        }

        public void RemoverVendedor(int codigoVendedor)
        {
            var vendedor = Vendedores.Where(v => v.Id == codigoVendedor).FirstOrDefault();

            RemoverVendedor(vendedor);
        }

        public decimal ValorTotalDeVendasPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendedores.Sum(v => v.ValorTotalDeVendasPorPeriodo(dataInicial, dataFinal));
        }
    }
}
