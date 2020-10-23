using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sistema.Models
{
    public class Clientes : Db
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool Whatsapp { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Pessoa { get; set; }

        public string StrQuery = "";

        public SqlDataReader dr;

        // construtor padrão da classe clientes
        public Clientes()
        {
        }

        // evento de pesquisa de cliente por id

        public bool ConsultaClienteId(int pId)
        {
            bool ret = false;

            if (!Conecta())
            {
                ret = false;
                return ret;
            }

            StrQuery = "SELECT * FROM CLIENTE WHERE id=" + pId.ToString() + "";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if(dr["id"].ToString() == pId.ToString())
                    {
                        Nome = dr["nome"].ToString();
                        Endereco = dr["endereco"].ToString();
                        Numero = dr["numero"].ToString();
                        Bairro = dr["bairro"].ToString();
                        Cidade = dr["cidade"].ToString();
                        Estado = dr["estado"].ToString();
                        Cep = dr["cep"].ToString();
                        Telefone = dr["telefone"].ToString();
                        Celular = dr["celular"].ToString();
                        if (dr["whatsapp"].ToString() == "False")
                        {
                            Whatsapp = false;
                        } else
                        {
                            Whatsapp = true;
                        }
                        Email = dr["email"].ToString();
                        Cpf = dr["cpf"].ToString();
                        Rg = dr["rg"].ToString();
                        Nascimento = DateTime.Parse(dr["nascimento"].ToString());
                        Pessoa = dr["pessoa"].ToString();
                        ret = true;
                    } else
                    {
                        ret = false;
                    }

                } else
                {
                    ret = false;
                }

                dr.Close();
                conn.Close();


            }
                return ret;
        }


        // evento de salvar os dados no banco de dados


        public bool SalvarDadosCliente(bool pIncluir)
        {
            bool ret = false;
            if (!Conecta())
            {
                return ret;
            }

            if (pIncluir) // se pincluir for verdadeiro criar a query para incluir os dados
            {
                StrQuery = "INSERT INTO CLIENTE (Nome,Endereco,Numero,Bairro,Cidade,Estado," +
                    "Cep,Telefone,Celular,Whatsapp,Email,Nascimento,Pessoa,Cpf,Rg) VALUES (" +
                    "@Nome,@Endereco,@Numero,@Bairro,@Cidade,@Estado,@Cep,@Telefone,@Celular," +
                    "@Whatsapp,@Email,@Nascimento,@Pessoa,@Cpf,@Rg)";
            } else
            {
                StrQuery = "UPDATE CLIENTE SET Nome=@Nome,Endereco=@Endereco,Numero=@Numero," +
                    "Bairro=@Bairro,Cidade=@Cidade,Estado=@Estado,Cep=@Cep,Telefone=@Telefone," +
                    "Celular=@Celular,Whatsapp=@Whatsapp,Email=@Email,Nascimento=@Nascimento," +
                    "Pessoa=@Pessoa,Cpf=@Cpf,Rg=@Rg WHERE ID=" + Id.ToString();
            }

            SqlCommand cmd = new SqlCommand(StrQuery, conn);

            cmd.Parameters.AddWithValue("@Nome", Nome.ToString());
            cmd.Parameters.AddWithValue("@Endereco", Endereco.ToString());
            cmd.Parameters.AddWithValue("@Numero", Numero.ToString());
            cmd.Parameters.AddWithValue("@Bairro", Bairro.ToString());
            cmd.Parameters.AddWithValue("@Cidade", Cidade.ToString());
            cmd.Parameters.AddWithValue("@Estado", Estado.ToString());
            cmd.Parameters.AddWithValue("@Cep", Cep.ToString());
            cmd.Parameters.AddWithValue("@Telefone", Telefone.ToString());
            cmd.Parameters.AddWithValue("@Celular", Celular.ToString());
            cmd.Parameters.AddWithValue("@Whatsapp", Whatsapp.ToString());
            cmd.Parameters.AddWithValue("@Email", Email.ToString());
            cmd.Parameters.AddWithValue("@Nascimento", Nascimento.ToString());
            cmd.Parameters.AddWithValue("@Pessoa", Pessoa.ToString());
            cmd.Parameters.AddWithValue("@Cpf", Cpf.ToString());
            cmd.Parameters.AddWithValue("@Rg", Rg.ToString());

            cmd.CommandType = CommandType.Text;

            try
            {
                int i = cmd.ExecuteNonQuery();
                if(i > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: Exceção: " + ex.ToString());
                ret = false;
            }

            conn.Close();

            return ret;
        }

        public bool ExcluirClientes(int pId)
        {
            bool ret = false;
            if (!Conecta())
            {
                ret = false;
            }

            StrQuery = "DELETE FROM CLIENTE WHERE ID=" + pId.ToString() + "";

            using(SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    ret = true;
                } else
                {
                    ret = false;
                }
            }

            conn.Close();
            return ret;
        }



        // -----> final da classe
    }
}
