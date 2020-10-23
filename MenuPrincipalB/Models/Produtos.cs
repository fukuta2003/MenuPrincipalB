using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Models
{
    class Produtos : Db
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string Codebar { get; set; }
        public string Local_Estoque { get; set; }
        public decimal Preco_Venda { get; set; }
        public decimal Desconto_Vista { get; set; }
        public decimal Custo_Atual { get; set; }
        public decimal Custo_Medio { get; set; }
        public decimal Custo_Anterior { get; set; }
        public decimal Estoque_Atual { get; set; }
        public decimal Estoque_Minimo { get; set; }
        public decimal Estoque_Maximo { get; set; }
        public int Grupo { get; set; }
        public int Marca { get; set; }
        public int Ultimo_Cliente { get; set; }
        public DateTime Ultima_Venda { get; set; }
        public string Cest { get; set; }
        public string Ncm { get; set; }
        public string Cest_Descricao { get; set; }
        public string Ncm_Descricao { get; set; }
        public byte[] Imagem { get; set; }
        
        public SqlDataReader dr;
        public bool ret = false;
        public string StrQuery = "";
        public Produtos() { 
        
        }

        public bool Consulta(int pProduto=0,string pBarra="")
        {

            ret = false;
            if (!Conecta())
            {
                return ret;
            }

            if (pProduto > 0)
            {
                StrQuery = "SELECT * FROM PRODUTOS WHERE ID=" + pProduto.ToString();

            } else
            {
                StrQuery = "SELECT * FROM PRODUTOS WHERE codebar=" + pBarra.ToString();

            }

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Id = int.Parse(dr["id"].ToString());
                    Descricao = dr["descricao"].ToString();
                    Unidade = dr["unidade"].ToString();
                    Codebar = dr["codebar"].ToString();
                    Local_Estoque = dr["local_estoque"].ToString();
                    Preco_Venda = decimal.Parse(dr["preco_venda"].ToString());
                    Desconto_Vista = decimal.Parse(dr["desconto_vista"].ToString());
                    Custo_Atual = decimal.Parse(dr["custo_atual"].ToString());
                    Custo_Medio = decimal.Parse(dr["custo_medio"].ToString());
                    Custo_Anterior = decimal.Parse(dr["custo_anterior"].ToString());
                    Estoque_Atual = decimal.Parse(dr["estoque_atual"].ToString());
                    Estoque_Minimo = decimal.Parse(dr["estoque_minimo"].ToString());
                    Estoque_Maximo = decimal.Parse(dr["estoque_maximo"].ToString());
                    Grupo = int.Parse(dr["grupo"].ToString());
                    Marca = int.Parse(dr["marca"].ToString());
                    Ultimo_Cliente = int.Parse(dr["ultimo_cliente"].ToString());
                    Ultima_Venda = DateTime.Parse(dr["ultima_venda"].ToString());
                    Cest = dr["cest"].ToString();
                    Ncm = dr["ncm"].ToString();

                    // buscando a imagem no banco de dados
                    if (dr[19] == DBNull.Value)
                    {
                    }
                    else
                    {
                        Imagem = (byte[])dr[19];  // 19 é o numero do campo no banco de dados
                    }

                    ret = true;

                }
            }

            dr.Close();
            conn.Close();
            return ret;

        }

        public bool Salvar(bool pIncluir,bool pAltImagem)
        {
            ret = false;

            if (!Conecta())
            {
                return ret;
            }

            if (pIncluir) // se pincluir for verdadeiro fazer a inclusao, senão alteração
            {
                StrQuery = "INSERT INTO PRODUTOS (descricao,unidade,codebar," +
                    "local_estoque,preco_venda,desconto_vista,custo_atual," +
                    "custo_medio,custo_anterior,estoque_atual,estoque_minimo," +
                    "estoque_maximo,grupo,marca,ultimo_cliente,ultima_venda," +
                    "cest,ncm,imagem) values (@descricao,@unidade,@codebar," +
                    "@local_estoque,@preco_venda,@desconto_vista,@custo_atual," +
                    "@custo_medio,@custo_anterior,@estoque_atual,@estoque_minimo," +
                    "@estoque_maximo,@grupo,@marca,@ultimo_cliente,@ultima_venda," +
                    "@cest,@ncm,@imagem)";
            }
            else
            {

                if (pAltImagem)
                {
                    StrQuery = "UPDATE PRODUTOS SET descricao=@descricao,codebar=@codebar," +
                                 "local_estoque=@local_estoque,preco_venda=@preco_venda,desconto_vista=@desconto_vista," +
                                 "custo_atual=@custo_atual,custo_medio=@custo_medio,custo_anterior=@custo_anterior," +
                                 "estoque_atual=@estoque_atual,estoque_minimo=@estoque_minimo,estoque_maximo=@estoque_maximo," +
                                 "grupo=@grupo,marca=@marca,ultimo_cliente=@ultimo_cliente,ultima_venda=@ultima_venda," +
                                 "cest=@cest,ncm=@ncm,imagem=@imagem WHERE ID=" + Id.ToString();

                }
                else
                {
                    // sem gravar alteraçao de imagem
                    StrQuery = "UPDATE PRODUTOS SET descricao=@descricao,codebar=@codebar," +
                                 "local_estoque=@local_estoque,preco_venda=@preco_venda,desconto_vista=@desconto_vista," +
                                 "custo_atual=@custo_atual,custo_medio=@custo_medio,custo_anterior=@custo_anterior," +
                                 "estoque_atual=@estoque_atual,estoque_minimo=@estoque_minimo,estoque_maximo=@estoque_maximo," +
                                 "grupo=@grupo,marca=@marca,ultimo_cliente=@ultimo_cliente,ultima_venda=@ultima_venda," +
                                 "cest=@cest,ncm=@ncm WHERE ID=" + Id.ToString();
                }

            }

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@descricao", Descricao.ToString());
                cmd.Parameters.AddWithValue("@unidade", Unidade.ToString());
                cmd.Parameters.AddWithValue("@codebar", Codebar.ToString());
                cmd.Parameters.AddWithValue("@local_estoque", Local_Estoque.ToString());
                cmd.Parameters.AddWithValue("@preco_venda", decimal.Parse(Preco_Venda.ToString("N")));
                cmd.Parameters.AddWithValue("@desconto_vista", decimal.Parse(Desconto_Vista.ToString("N")));
                cmd.Parameters.AddWithValue("@custo_atual", decimal.Parse(Custo_Atual.ToString("N")));
                cmd.Parameters.AddWithValue("@custo_medio", decimal.Parse(Custo_Medio.ToString("N")));
                cmd.Parameters.AddWithValue("@custo_anterior", decimal.Parse(Custo_Anterior.ToString("N")));
                cmd.Parameters.AddWithValue("@estoque_atual", decimal.Parse(Estoque_Atual.ToString("N")));
                cmd.Parameters.AddWithValue("@estoque_minimo", decimal.Parse(Estoque_Minimo.ToString("N")));
                cmd.Parameters.AddWithValue("@estoque_maximo", decimal.Parse(Estoque_Maximo.ToString("N")));
                cmd.Parameters.AddWithValue("@grupo", int.Parse(Grupo.ToString()));
                cmd.Parameters.AddWithValue("@marca", int.Parse(Marca.ToString()));
                cmd.Parameters.AddWithValue("@ultimo_cliente", int.Parse(Ultimo_Cliente.ToString()));
                if (Ultima_Venda.ToString()=="01/01/0001 00:00:00")
                {
                    Ultima_Venda = DateTime.Now;
                }
                cmd.Parameters.AddWithValue("@ultima_venda", DateTime.Parse(Ultima_Venda.ToString()));
                cmd.Parameters.AddWithValue("@cest", Cest.ToString());
                cmd.Parameters.AddWithValue("@ncm", Ncm.ToString());
   
                if(pIncluir || pAltImagem)
                {
                    cmd.Parameters.AddWithValue("@imagem", Imagem);
                }

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ret = true;
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Erro:" + e.ToString());
                }

            }

            conn.Close();

            return ret;
        }


        public bool Excluir(int pId)
        {
            ret = false;
            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "DELETE FROM PRODUTOS WHERE id=" + pId.ToString();

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ret = true;
                    }
                }
                catch { }

            }
            conn.Close();
            return ret;
        }



        // consultas NCM e CEST

        public bool Consulta_Cest(string pCodigo)
        {
            ret = false;
            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "SELECT * FROM TAB_CEST WHERE CEST='" + pCodigo.ToString() + "'";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Cest = pCodigo.ToString();
                    if (!string.IsNullOrEmpty(Ncm.ToString())) {
                        Ncm = dr["ncm"].ToString();
                    }
                    Cest_Descricao = dr["descricao"].ToString();
                    ret = true;
                }

            }

            dr.Close();
            conn.Close();

            return ret;
        }


        public bool Consulta_Ncm(string pCodigo)
        {
            ret = false;
            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "SELECT * FROM NCM WHERE NCM='" + pCodigo.ToString() + "'";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Ncm = dr["ncm"].ToString();
                    Ncm_Descricao = dr["nome"].ToString();
                    ret = true;
                }

            }

            dr.Close();
            conn.Close();

            return ret;
        }


        // final da classe
    }
}
