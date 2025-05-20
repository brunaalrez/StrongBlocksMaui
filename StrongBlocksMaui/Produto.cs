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

        public void Atualiza()
        {
            string query = $"UPDATE estoque SET quantidade = quantidade + {quantidade} WHERE nome = '{nome}';";
            conexao.ExecutaComando(query);
            Console.WriteLine("Produto atualizado com sucesso");
        }

        public void Remove()
        {
            string query = $"DELETE FROM estoque WHERE nome = '{nome}' AND tipo = 'insumo';";
            conexao.ExecutaComando(query);
            Console.WriteLine("Produto removido com sucesso");
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

        public bool ExisteInsumo(string nomeInsumo)
        {
            string query = $"SELECT COUNT(*) FROM estoque WHERE nome = '{nomeInsumo}' AND tipo = 'insumo';";
            DataTable dt = conexao.ExecutaSelect(query);

            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }

            return false;
        }

        public int BuscaQuantidade(string nomeInsumo)
        {
            string query = $"SELECT quantidade FROM estoque WHERE nome = '{nomeInsumo}' AND tipo = 'insumo';";
            DataTable dt = conexao.ExecutaSelect(query);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["quantidade"]);
            }

            return 0;
        }

        public void RemoverQuantidade()
        {
            string query = $"UPDATE estoque SET quantidade = quantidade - {quantidade} WHERE nome = '{nome}' AND tipo = 'insumo';";
            conexao.ExecutaComando(query);
        }

        // ✅ NOVOS MÉTODOS PARA PRODUTOS:

        public bool ExisteProduto(string nomeProduto)
        {
            string query = $"SELECT COUNT(*) FROM estoque WHERE nome = '{nomeProduto}' AND tipo = 'produto';";
            DataTable dt = conexao.ExecutaSelect(query);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public int BuscaQuantidadeProduto(string nomeProduto)
        {
            string query = $"SELECT quantidade FROM estoque WHERE nome = '{nomeProduto}' AND tipo = 'produto';";
            DataTable dt = conexao.ExecutaSelect(query);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["quantidade"]) : 0;
        }

        public void RemoverQuantidadeProduto()
        {
            string query = $"UPDATE estoque SET quantidade = quantidade - {quantidade} WHERE nome = '{nome}' AND tipo = 'produto';";
            conexao.ExecutaComando(query);
        }
    }
}
