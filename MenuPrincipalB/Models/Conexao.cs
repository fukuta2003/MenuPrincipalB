using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sistema.Models
{
    public class Db
    {

        public SqlConnection conn;

        string host = "192.168.1.250";
        //string host = "sqlserverflex.ddns.net"; // para acesso externo


        string DB = "OFICINA2";   // nome do banco de dados

        // string port = "1433";

        public string user = "dev078";    // usuario do banco de dados
        public string password = "etec078";  // senha do banco de dados

        public Db()  // FUNÇÃO DE CONEXÃO DO BANCO DE DADOS
        {
        
            string constring = "server=" + host + "; Connection Timeout=10 ; Integrated Security=false ;"
                             + "database=" + DB + ";"
                             + "user=" + user + ";"
                             + "password=" + password;

            conn = new SqlConnection(constring);

        }


        public bool Conecta()
        {
            bool conecta = true;

            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    conecta = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro de Conexão com Banco de Dados !", ex.ToString());
                    conecta = false;
                }
                finally
                {
                    if (conecta == false)
                    {
                        Application.Exit();
                    }
                }

            }

            return conecta;

        }




    }

}
