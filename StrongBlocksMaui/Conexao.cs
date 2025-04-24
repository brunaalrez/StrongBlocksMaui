using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace StrongBlocksMaui
{
    class Conexao
    {
        string dadosConexao = "server=localhost;user=root;database=strong_blocks;port=3306;password=";

        public int ExecutaComando(string query)
        {
            //Criar e abre conexão
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            //rodar a query 
            MySqlCommand comando = new MySqlCommand(query, conexao);
            int linhasAfetadas = comando.ExecuteNonQuery();
            conexao.Close();
            return linhasAfetadas;
        }

        public DataTable ExecutaSelect(string query)
        {
            //Criar e abre con~exão
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            //rodar a query 
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter dados = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            dados.Fill(dt);
            conexao.Close();
            return dt;
        }
    }
}