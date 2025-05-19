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
        public string nome { get; set; }
        public int quantidade { get; set; }
        public string fornecedor { get; set; }
        public string tipo { get; set; }
        public string categoria { get; set; }

        Conexao conexao { get; set; }

        public Produto()
        {
            conexao = new Conexao();
        }
        public void Insere()
        {
            string query = $"INSERT INTO estoque (nome, quantidade, fornecedor, tipo, categoria) VALUES('{nome}','{quantidade}','{fornecedor}','{tipo}','{categoria}');";
            conexao.ExecutaComando(query);
            Console.WriteLine("Produto inserido com sucesso");
        }

        public List<Produto> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM estoque;");
            List<Produto> lista = new List<Produto>();

            foreach (DataRow linha in dt.Rows)
            {
                Produto p = new Produto();
                p.id = int.Parse(linha["id"].ToString());
                p.nome = linha["nome"].ToString();
                p.quantidade = int.Parse(linha["quantidade"].ToString());
                p.fornecedor = linha["fornecedor"].ToString();
                p.tipo = linha["tipo"].ToString();
                p.categoria = linha["categoria"].ToString();
                lista.Add(p);
            }

            return lista;
        }

        public List<Produto> BuscaTodosInsumos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM estoque WHERE tipo = 'insumo';");
            List<Produto> lista = new List<Produto>();

            foreach (DataRow linha in dt.Rows)
            {
                Produto p = new Produto();
                p.id = int.Parse(linha["id"].ToString());
                p.nome = linha["nome"].ToString();
                p.quantidade = int.Parse(linha["quantidade"].ToString());
                p.fornecedor = linha["fornecedor"].ToString();
                p.tipo = linha["tipo"].ToString();
                p.categoria = linha["categoria"].ToString();
                lista.Add(p);
            }

            return lista;
        }

        public List<Produto> BuscaTodosProdutos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM estoque WHERE tipo = 'produto';");
            List<Produto> lista = new List<Produto>();

            foreach (DataRow linha in dt.Rows)
            {
                Produto p = new Produto();
                p.id = int.Parse(linha["id"].ToString());
                p.nome = linha["nome"].ToString();
                p.quantidade = int.Parse(linha["quantidade"].ToString());
                p.tipo = linha["tipo"].ToString();
                p.categoria = linha["categoria"].ToString();
                lista.Add(p);
            }

            return lista;



        }
    }

}
