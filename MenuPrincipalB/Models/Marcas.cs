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
    class Marcas : Db
    {

        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool ret;
        public SqlDataReader dr;
        public string StrQuery = "";

        public Marcas()
        {

        }


        public bool Consulta(int pid)
        {
            ret = false;

            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "SELECT * FROM MARCAS WHERE ID=" + pid.ToString();

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Descricao = dr["descricao"].ToString();
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }

            dr.Close();
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
                StrQuery = "INSERT INTO MARCAS (descricao) values (@descricao)";
            }
            else
            {
                StrQuery = "UPDATE MARCAS SET descricao=@descricao";
            }


            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.Parameters.AddWithValue("@descricao", Descricao.ToString());

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
            dr.Close();
            return ret;

        }

        public bool Excluir(int pId)
        {
            bool ret = false;
            if (!Conecta())
            {
                ret = false;
            }

            StrQuery = "DELETE FROM MARCAS WHERE ID=" + pId.ToString() + "";

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





        // fim da classe
    }
}
