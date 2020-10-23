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
    public class Fornecedores : Db
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }   // cpf ou cnpj
        public string Ie { get; set; } // inscriçao estadual / rg
        public string Pessoa { get; set; }  // pessoa fisica ou juridica
        public string Obs { get; set; }  // observacao

        public string StrQuery = "";

        public SqlDataReader dr;

        // construtor padrão da classe fornecedores
        public Fornecedores()
        {
        }

        // evento de pesquisa de cliente por id

        public bool ConsultaFornecedorId(int pId)
        {
            bool ret = false;

            if (!Conecta())
            {
                ret = false;
                return ret;
            }

            StrQuery = "SELECT * FROM FORNECEDORES WHERE id=" + pId.ToString() + "";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();  // move o ponteiro do registro para o 1. registro
                if (dr.HasRows)
                {
                    if(dr["id"].ToString() == pId.ToString())
                    {
                        Nome = dr["nome"].ToString();
                        Endereco = dr["endereco"].ToString();
                        Bairro = dr["bairro"].ToString();
                        Cidade = dr["cidade"].ToString();
                        Estado = dr["estado"].ToString();
                        Cep = dr["cep"].ToString();
                        Telefone = dr["telefone"].ToString();
                        Celular = dr["celular"].ToString();
                        Email = dr["email"].ToString();
                        Cnpj = dr["cnpj"].ToString();
                        Ie = dr["ie"].ToString();
                        Pessoa = dr["pessoa"].ToString();
                        Obs = dr["obs"].ToString();
                        
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


        public bool Salvar(bool pIncluir)
        {
            bool ret = false;
            if (!Conecta())
            {
                return ret;
            }

            if (pIncluir) // se pincluir for verdadeiro criar a query para incluir os dados
            {
                StrQuery = "INSERT INTO FORNECEDORES (Nome,Endereco,Bairro,Cidade,Estado," +
                    "Cep,Telefone,Celular,Email,Pessoa,Cnpj,Ie,Obs) VALUES (" +
                    "@Nome,@Endereco,@Bairro,@Cidade,@Estado,@Cep,@Telefone,@Celular," +
                    "@Email,@Pessoa,@Cnpj,@Ie,@Obs)";
            } else
            {
                StrQuery = "UPDATE FORNECEDORES SET Nome=@Nome,Endereco=@Endereco," +
                    "Bairro=@Bairro,Cidade=@Cidade,Estado=@Estado,Cep=@Cep,Telefone=@Telefone," +
                    "Celular=@Celular,Email=@Email," +
                    "Pessoa=@Pessoa,Cnpj=@Cnpj,Ie=@Ie,Obs=@Obs WHERE ID=" + Id.ToString();
            }

            SqlCommand cmd = new SqlCommand(StrQuery, conn);

            cmd.Parameters.AddWithValue("@Nome", Nome.ToString());
            cmd.Parameters.AddWithValue("@Endereco", Endereco.ToString());
            cmd.Parameters.AddWithValue("@Bairro", Bairro.ToString());
            cmd.Parameters.AddWithValue("@Cidade", Cidade.ToString());
            cmd.Parameters.AddWithValue("@Estado", Estado.ToString());
            cmd.Parameters.AddWithValue("@Cep", Cep.ToString());
            cmd.Parameters.AddWithValue("@Telefone", Telefone.ToString());
            cmd.Parameters.AddWithValue("@Celular", Celular.ToString());
            cmd.Parameters.AddWithValue("@Email", Email.ToString());
            cmd.Parameters.AddWithValue("@Pessoa", Pessoa.ToString());
            cmd.Parameters.AddWithValue("@Cnpj", Cnpj.ToString());
            cmd.Parameters.AddWithValue("@Ie", Ie.ToString());
            cmd.Parameters.AddWithValue("@Obs", Obs.ToString());

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

        public bool Excluir(int pId)
        {
            bool ret = false;
            if (!Conecta())
            {
                ret = false;
            }

            StrQuery = "DELETE FROM FORNECEDORES WHERE ID=" + pId.ToString() + "";

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
