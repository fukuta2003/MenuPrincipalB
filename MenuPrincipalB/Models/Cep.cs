using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Cep : Db
    {
        public int Loc_nu_sequencial { get; set; }
        public string Logradouro { get; set; }
        public string Cepe { get; set; }
        public string Ufe_sg { get; set; }

        public int Log_nu_sequencial { get; set; }
        public int Log_status_tipo_log { get; set; }
        public string Inicial { get; set; }
        public string Loc_no { get; set; }
        public string Final { get; set; }

        public ArrayList Estados = new ArrayList();
        public string StrQuery = "";

        public SqlDataReader dr;

        public Cep()
        {

        }

        public bool ConsultaCep(string pCep)
        {
            bool ret = false;

            if (!Conecta())
            {
                return ret;
            }
            if (string.IsNullOrEmpty(pCep.ToString()))  // se o parametro pCEP estiver vazio
            {
                return ret;
            }

            Logradouro = "";      // endereço
            Inicial = "Centro";   // bairro
            Loc_no = "";          // cidade 
            Ufe_sg = "";          // estado

            pCep = pCep.Replace("-", "");
            string Procedimento = "buscacep";  // store procedure por logradouro
            if(pCep.ToString().Length > 2)
            {
                if (pCep.Substring(5, 3).ToString() == "000")    
                {
                    Procedimento = "buscalocalidade";
                }
            }

            SqlCommand cmd = new SqlCommand(Procedimento.ToString(), conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CEP", int.Parse(pCep.ToString()));

            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)  // tem linhas ? registros
            {
                if (Procedimento == "buscacep")
                {
                    Logradouro = dr["LOGRADOURO"].ToString();  // endereco
                    Inicial = dr["INICIAL"].ToString();   // bairro
                }

                Loc_no = dr["LOC_NO"].ToString(); // cidade
                Ufe_sg = dr["UFE_SG"].ToString();  // ESTADO

                ret = true;

            } else
            {
                ret = false;   // QUANDO NAO ACHAR
            }

            dr.Close();
            conn.Close();

            return ret;
        }



        // --------------- carrega os estados brasileiros em uma arraylist

        public bool Carrega_Estados()
        {
            if (!Conecta())
            {
                return false;
            }

            bool ret = false;

            StrQuery = "SELECT TOP 200 * FROM log_faixa_uf ORDER BY ufe_sg";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            while (dr.Read())
            {
                Estados.Add(dr["ufe_sg"].ToString());
                ret = true;
            }

            dr.Close();
            conn.Close();
            return ret;
        }




    }  // final da classe
}
