using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Models
{
    public class Vendedores : Db
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
        public string Cpf { get; set; }   // cpf ou cnpj
        public string Rg { get; set; } // inscriçao estadual / rg
        public double Comissao { get; set; }

        public string StrQuery = "";

        public SqlDataReader dr;

        // construtor padrão da classe fornecedores
        public Vendedores()
        {
        }

        // evento de pesquisa de cliente por id

        public bool ConsultaId(int pId)
        {
            bool ret = false;

            if (!Conecta())
            {
                ret = false;
                return ret;
            }

            StrQuery = "SELECT * FROM VENDEDORES WHERE id=" + pId.ToString() + "";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();  // move o ponteiro do registro para o 1. registro
                if (dr.HasRows)
                {
                    if (dr["id"].ToString() == pId.ToString())
                    {
                        Nome = dr["nome"].ToString();
                        Endereco = dr["endereco"].ToString();
                        Bairro = dr["bairro"].ToString();
                        Cidade = dr["cidade"].ToString();
                        Estado = dr["estado"].ToString();
                        Cep = dr["cep"].ToString();
                        Telefone = dr["telefone"].ToString();
                        Celular = dr["celular"].ToString();
                        Cpf = dr["cpf"].ToString();
                        Rg = dr["rg"].ToString();
                        Comissao = double.Parse(dr["comissao"].ToString());

                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }

                }
                else
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
                StrQuery = "INSERT INTO VENDEDORES (Nome,Endereco,Bairro,Cidade,Estado," +
                    "Cep,Telefone,Celular,Cpf,Rg,Comissao) VALUES (" +
                    "@Nome,@Endereco,@Bairro,@Cidade,@Estado,@Cep,@Telefone,@Celular," +
                    "@Cpf,@Rg,@Comissao)";
            }
            else
            {
                StrQuery = "UPDATE VENDEDORES SET Nome=@Nome,Endereco=@Endereco," +
                    "Bairro=@Bairro,Cidade=@Cidade,Estado=@Estado,Cep=@Cep,Telefone=@Telefone," +
                    "Celular=@Celular," +
                    "Cpf=@Cpf,Rg=@Rg,Comissao=@Comissao WHERE ID=" + Id.ToString();
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
            cmd.Parameters.AddWithValue("@Cpf", Cpf.ToString());
            cmd.Parameters.AddWithValue("@Rg", Rg.ToString());
            cmd.Parameters.AddWithValue("@Comissao", double.Parse(Comissao.ToString()));

            cmd.CommandType = CommandType.Text;

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
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

            StrQuery = "DELETE FROM VENDEDORES WHERE ID=" + pId.ToString() + "";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    ret = true;
                }
                else
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
