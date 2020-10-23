using Sistema.Models;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Sistema.Models
{
    class CLogin : Db
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Ativo { get; set; }
        public string NomeUsuario { get; set; }
        public string Operador { get; set; }

        public SqlDataReader dr;

        public bool Abre_BancoDados()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex);
                return false;
            }
            finally
            {

            }
        }

        public bool FechaBancoDeDados()
        {
            bool ret = false;
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
                ret = true;
            }

            return ret;
        }

        public bool Consulta_Login()
        {
            bool ret = false;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();

            }

            using (SqlCommand cmd = new SqlCommand())
            {
                
                cmd.CommandText = "SELECT * FROM TABELA_LOGIN WHERE login='" + Login + "' AND password='" + Password + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                dr = cmd.ExecuteReader(); // executa a instrução sql na conexao passada por parametro
                dr.Read();  // vai para o primeiro registro
                if (dr.HasRows)
                {
                    if (dr["login"].ToString() == Login)
                    {

                        if (dr["password"].ToString() == Password)
                        {
                            if (dr["ativo"].ToString() == "S")
                            {
                                //  ((MenuStrip)Application.OpenForms["fMenu"].Controls["menuStrip1"]).Enabled = true;
                                //  ((ToolStrip)Application.OpenForms["fMenu"].Controls["toolStrip1"]).Enabled = true;

                                Login = dr["login"].ToString();
                                Password = dr["password"].ToString();
                                NomeUsuario = dr["nome"].ToString();
                                Operador = dr["operacao"].ToString();

                                ret=true;

                            } else
                            {

                                MessageBox.Show("Este usuário não está ativo, consulte o administrador do sistema");
                                ret=false;

                            }
                        }
                        else
                        {

                            ret=false;
                        }
                    } else
                    {
                        ret = false;
                    }

                }
                dr.Close();
                conn.Close();
                return ret;
            }

        }
    }


}

