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
    class FormasPagamento : Db
    {

        public int ID { get; set; }
        public string Descricao { get; set; }
        public int Parc01 { get; set; }  // parcela
        public int Parc02 { get; set; }  // parcela
        public int Parc03 { get; set; }  // parcela
        public int Parc04 { get; set; }  // parcela
        public int Parc05 { get; set; }  // parcela
        public int Parc06 { get; set; }  // parcela
        public double Porc01 { get; set; }  // Porcentagem da parcela
        public double Porc02 { get; set; }  // Porcentagem da parcela
        public double Porc03 { get; set; }  // Porcentagem da parcela
        public double Porc04 { get; set; }  // Porcentagem da parcela
        public double Porc05 { get; set; }  // Porcentagem da parcela
        public double Porc06 { get; set; }  // Porcentagem da parcela

        public SqlDataReader Dr;
        public string StrQuery = "";
        public bool ret = false;
        public FormasPagamento()
        {

        }

        public bool Consulta(int pId)
        {
            ret = false;
            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "select * from formaspagamento where id=" + pId.ToString();

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                Dr = cmd.ExecuteReader();
                Dr.Read();
                if (Dr.HasRows)
                {
                    ID = int.Parse(Dr["id"].ToString());
                    Descricao = Dr["descricao"].ToString();
                    Parc01 = int.Parse(Dr["parc01"].ToString());
                    Parc02 = int.Parse(Dr["parc02"].ToString());
                    Parc03 = int.Parse(Dr["parc03"].ToString());
                    Parc04 = int.Parse(Dr["parc04"].ToString());
                    Parc05 = int.Parse(Dr["parc05"].ToString());
                    Parc06 = int.Parse(Dr["parc06"].ToString());
                    Porc01 = double.Parse(Dr["porc01"].ToString());
                    Porc02 = double.Parse(Dr["porc02"].ToString());
                    Porc03 = double.Parse(Dr["porc03"].ToString());
                    Porc04 = double.Parse(Dr["porc04"].ToString());
                    Porc05 = double.Parse(Dr["porc05"].ToString());
                    Porc06 = double.Parse(Dr["porc06"].ToString());
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
                StrQuery = "INSERT INTO FORMASPAGAMENTO (descricao," +
                    "parc01,parc02,parc03,parc04,parc05,parc06," +
                    "porc01,porc02,porc03,porc04,porc05,porc06) values (@descricao," +
                    "@parc01,@parc02,@parc03,@parc04,@parc05,@parc06," +
                    "@porc01,@porc02,@porc03,@porc04,@porc05,@porc06)";
            }
            else
            {
                StrQuery = "UPDATE FORMASPAGAMENTO SET descricao=@descricao," +
                    "parc01=@parc01,parc02=@parc02,parc03=@parc03,parc04=@parc04,parc05=@parc05,parc06=@parc06," +
                    "porc01=@porc01,porc02=@porc02,porc03=@porc03,porc04=@porc04,porc05=@porc05,porc06=@porc06" +
                    " WHERE id=" + ID.ToString();
            }


            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.Parameters.AddWithValue("@descricao", Descricao.ToString());
                cmd.Parameters.AddWithValue("@parc01", int.Parse(Parc01.ToString()));
                cmd.Parameters.AddWithValue("@parc02", int.Parse(Parc02.ToString()));
                cmd.Parameters.AddWithValue("@parc03", int.Parse(Parc03.ToString()));
                cmd.Parameters.AddWithValue("@parc04", int.Parse(Parc04.ToString()));
                cmd.Parameters.AddWithValue("@parc05", int.Parse(Parc05.ToString()));
                cmd.Parameters.AddWithValue("@parc06", int.Parse(Parc06.ToString()));
                cmd.Parameters.AddWithValue("@porc01", double.Parse(Porc01.ToString()));
                cmd.Parameters.AddWithValue("@porc02", double.Parse(Porc02.ToString()));
                cmd.Parameters.AddWithValue("@porc03", double.Parse(Porc03.ToString()));
                cmd.Parameters.AddWithValue("@porc04", double.Parse(Porc04.ToString()));
                cmd.Parameters.AddWithValue("@porc05", double.Parse(Porc05.ToString()));
                cmd.Parameters.AddWithValue("@porc06", double.Parse(Porc06.ToString()));

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




    }
}
