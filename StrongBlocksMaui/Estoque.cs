using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongBlocksMaui
{
    internal class Produto
    {
        public int id { get; set; }
        public string tipo_insumo { get; set; }
        public int quantidade { get; set; }
        public string fornecedor { get; set; }
        public string tipo_produto { get; set; }
        public DateTime data { get; set; }

        Conexao conexao { get; set; }

        public Produto()
        {
            conexao = new Conexao();
        }
        public void Insere()
        {
            string query = $"INSERT INTO produtos (nome, preco) VALUES('{tipo_insumo}','{quantidade}', {data}, '{fornecedor}', '{tipo_produto}');";
            conexao.ExecutaComando(query);
            Console.WriteLine("Produto inserido com sucesso");
        }

        public List<Produto> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM produtos;");
            List<Produto> lista = new List<Produto>();

            foreach (DataRow linha in dt.Rows)
            {
                Produto p = new Produto();
                p.id = int.Parse(linha["id"].ToString());
                p.tipo_insumo = linha["tipo_de_insumo"].ToString();
                p.quantidade = int.Parse(linha["quantidade"].ToString());
                p.fornecedor = linha["fornecedor"].ToString();
                p.tipo_produto = linha["tipo_de_produto"].ToString();
                p.data = DateTime.Parse(linha["data"].ToString());
                lista.Add(p);
            }

            return lista;
        }
    }
}