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

        Conexao conexao { get; set; }

        public Estoque()
        {
            conexao = new Conexao();
        }
        public void Insere()
        {
            string query = $"INSERT INTO estoque (tipo_de_insumo, quantidade, fornecedor, tipo_de_produto) VALUES('{tipo_insumo}','{quantidade}','{fornecedor}', '{tipo_produto}');";
            conexao.ExecutaComando(query);
            Console.WriteLine("Estoque inserido com sucesso");
        }

        public List<Estoque> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM estoque;");
            List<Estoque> lista = new List<Estoque>();

            foreach (DataRow linha in dt.Rows)
            {
                Estoque p = new Estoque();
                p.id = int.Parse(linha["id"].ToString());
                p.tipo_insumo = linha["tipo_de_insumo"].ToString();
                p.quantidade = int.Parse(linha["quantidade"].ToString());
                p.fornecedor = linha["fornecedor"].ToString();
                p.tipo_produto = linha["tipo_de_produto"].ToString();
                lista.Add(p);
            }

            return lista;
        }
    }

}
