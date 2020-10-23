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
    class Transportadores : Db
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpfcnpj { get; set; }
        public string Rginscricao { get; set; }
        public string Ecorreio { get; set; }
        public string Ativa { get; set; }
        public double Taxa { get; set; }

        public SqlDataReader Dr;
        public string StrQuery="";
        public bool ret = false;

        public Transportadores()
        {

        }

        public bool Consulta(int pId)
        {
            ret = false;
            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "select * from transportadores where id=" + pId.ToString();

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                Dr = cmd.ExecuteReader();
                Dr.Read();
                if (Dr.HasRows)
                {
                    Id = int.Parse(Dr["id"].ToString());
                    Descricao = Dr["descricao"].ToString();
                    Endereco = Dr["endereco"].ToString();
                    Bairro = Dr["bairro"].ToString();
                    Cidade = Dr["cidade"].ToString();
                    Estado = Dr["estado"].ToString();
                    Cep = Dr["cep"].ToString();
                    Telefone = Dr["telefone"].ToString();
                    Email = Dr["email"].ToString();
                    Cpfcnpj = Dr["cpfcnpj"].ToString();
                    Rginscricao = Dr["rginscricao"].ToString();
                    Ecorreio = Dr["ecorreio"].ToString();
                    Ativa = Dr["ativa"].ToString();
                    Taxa = double.Parse(Dr["taxa"].ToString());

                    ret = true;

                }
            }

            Dr.Close();
            conn.Close();

            return ret;

        }


        public bool Salvar(bool pIncluir)
        {
            ret = false;

            if (!Conecta())
            {
                return ret;
            }

            if (pIncluir)
            {
                StrQuery = "INSERT INTO transportadores (descricao," +
                    "endereco,bairro,cidade,estado,cep,telefone,email,cpfcnpj,rginscricao,ecorreio,ativa,taxa" +
                    " values (@endereco,@bairro,@cidade,@estado,@cep,@telefone,@email,@cpf,@rg,@ecorreio,@ativa,@taxa)";
            }
            else
            {
                StrQuery = "UPDATE transportadores SET descricao=@descricao," +
                    "endereco=@endereco,bairro=@bairro,cidade=@cidade,estado=@estado,cep=@cep,telefone=@telefone," +
                    "email=@email,cpfcnpj=@cpf,rginscricao=@rg,ecorreio=@ecorreio,ativa=@ativa,taxa=@taxa" +
                    " WHERE id=" + Id.ToString();
            }


            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.Parameters.AddWithValue("@descricao", Descricao.ToString());
                cmd.Parameters.AddWithValue("@endereco", Endereco.ToString());
                cmd.Parameters.AddWithValue("@bairro", Bairro.ToString());
                cmd.Parameters.AddWithValue("@cidade", Cidade.ToString());
                cmd.Parameters.AddWithValue("@estado", Estado.ToString());
                cmd.Parameters.AddWithValue("@cep", Cep.ToString());
                cmd.Parameters.AddWithValue("@telefone", Telefone.ToString());
                cmd.Parameters.AddWithValue("@email", Email.ToString());
                cmd.Parameters.AddWithValue("@cpf", Cpfcnpj.ToString());
                cmd.Parameters.AddWithValue("@rg", Rginscricao.ToString());
                cmd.Parameters.AddWithValue("@ecorreio", Ecorreio.ToString());
                cmd.Parameters.AddWithValue("@ativa", Ativa.ToString());
                cmd.Parameters.AddWithValue("@taxa", Taxa.ToString());

                cmd.CommandType = System.Data.CommandType.Text;

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

            StrQuery = "DELETE FROM FORMASPAGAMENTO WHERE ID=" + pId.ToString() + "";

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



        // FIM DA CLASSE
    }
}
