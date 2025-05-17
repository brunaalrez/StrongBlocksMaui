using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace StrongBlocksMaui
{
    class Conexao
    {
        string dadosConexao = "server=localhost;user=root;database=strongblocksproject;port=3306;password=";

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
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(dadosConexao))
                {
                    conexao.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexao);
                    MySqlDataAdapter dados = new MySqlDataAdapter(comando);
                    dados.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar SELECT: " + ex.Message);
            }

            return dt;
        }

    }
}