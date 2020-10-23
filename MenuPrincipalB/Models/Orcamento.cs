using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Models
{
    public class Orcamento : Db
    {

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Cliente_id { get; set; }
        public int Vendedor_id { get; set; }
        public int FormaPagamento_id { get; set; }
        public int Transportadores_id { get; set; }
        public double TotalBruto { get; set; }
        public double DescontoReal { get; set; }
        public double DescontoPorc { get; set; }
        public double TaxaEntrega { get; set; }
        public double TotalLiquido { get; set; }
        public string Observacao { get; set; }
        
        // campos da tabela orcamento_compl

        public int Id_Compl { get; set; }
        public int Produto_id { get; set; }
        public string Produto_Descricao { get; set; }
        public string Produto_Unidade { get; set; }
        public double Produto_Unitario { get; set; }
        public double Produto_Quantidade { get; set; }
        public double Produto_Total { get; set; }
        public string Produto_Observacao { get; set; }

        public ListView OrcDadosPro;
        public ListViewItem grdProdutos;

        public string[,] ListaPro = new string[100,7];
        public bool ret;
        public SqlDataReader dr;
        public string StrQuery = "";
        public int Ultimo_ID = 0;

        public Orcamento()
        {
           
        }

        public bool Consulta(int pid)
        {
            ret = false;

            if (!Conecta())
            {
                return ret;
            }

            StrQuery = "dbo.consultaorcamento";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", pid.ToString());

                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Id = int.Parse(dr["id"].ToString());
                    Data = DateTime.Parse(dr["data"].ToString());
                    Cliente_id = int.Parse(dr["cliente_id"].ToString());
                    Vendedor_id = int.Parse(dr["vendedor_id"].ToString());
                    FormaPagamento_id = int.Parse(dr["formapagamento_id"].ToString());
                    Transportadores_id = int.Parse(dr["transportadores_id"].ToString());
                    TotalBruto = double.Parse(dr["totalbruto"].ToString());
                    DescontoPorc = double.Parse(dr["descontoporc"].ToString());
                    DescontoReal = double.Parse(dr["descontoreal"].ToString());
                    TaxaEntrega = double.Parse(dr["taxaentrega"].ToString());
                    TotalLiquido = double.Parse(dr["totalliquido"].ToString());
                    Observacao = dr["observacao"].ToString();

                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }

            dr.Close();
            conn.Close();

            // consulta produtos do orçamento e carrega na listviewitem


            if (!Conecta())
            {
                return ret;
            }

            Array.Clear(ListaPro, 0, ListaPro.Length);

            StrQuery = "dbo.consultaprodutosorcamento";
            
            using (SqlCommand cmd2 = new SqlCommand(StrQuery, conn))
            {
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@id", pid.ToString());

                dr = cmd2.ExecuteReader();
               // dr.Read();
                int x = 0;
                while (dr.Read())
                {

                    ListaPro[x, 0] = dr["produto_id"].ToString();
                    ListaPro[x, 1] = dr["descricao"].ToString();
                    ListaPro[x, 2] = dr["unidade"].ToString();
                    ListaPro[x, 3] = dr["preco_venda"].ToString();
                    ListaPro[x, 4] = dr["produto_quantidade"].ToString();

                    Produto_Total = (double.Parse(dr["preco_venda"].ToString()) * double.Parse(dr["produto_quantidade"].ToString()));

                    ListaPro[x, 5] = Produto_Total.ToString("N");
                    
                    ListaPro[x, 6] = dr["produto_observacao"].ToString();

                    x++;

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
                StrQuery = "INSERT INTO ORCAMENTO (" +
                    "data,cliente_id,vendedor_id,formapagamento_id,transportadores_id," +
                    "totalbruto,descontoporc,descontoreal,taxaentrega,totalliquido,observacao" +
                    ") values " +
                    "(" +
                    "@data,@cliente_id,@vendedor_id,@formapagamento_id,@transportadores_id," +
                    "@totalbruto,@descontoporc,@descontoreal,@taxaentrega,@totalliquido,@observacao" +
                    ")";
            }
            else
            {
                StrQuery = "UPDATE ORCAMENTO SET " +
                    "data=@data,cliente_id=@cliente_id,vendedor_id=@vendedor_id," +
                    "formapagamento_id=@formapagamento_id, transportadores_id=@transportadores_id," +
                    "totalbruto=@totalbruto,descontoporc=@descontoporc,descontoreal=@descontoreal," +
                    "taxaentrega=@taxaentrega,totalliquido=@totalliquido,observacao=@observacao" +
                    " WHERE id=" + Id.ToString();
            }


            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.Parameters.AddWithValue("@data", Data.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@cliente_id", int.Parse(Cliente_id.ToString()));
                cmd.Parameters.AddWithValue("@vendedor_id", int.Parse(Vendedor_id.ToString()));
                cmd.Parameters.AddWithValue("@formapagamento_id", int.Parse(FormaPagamento_id.ToString()));
                cmd.Parameters.AddWithValue("@transportadores_id", int.Parse(Transportadores_id.ToString()));
                cmd.Parameters.AddWithValue("@totalbruto", double.Parse(TotalBruto.ToString("N")));
                cmd.Parameters.AddWithValue("@descontoporc", double.Parse(DescontoPorc.ToString("N")));
                cmd.Parameters.AddWithValue("@descontoreal", double.Parse(DescontoReal.ToString("N")));
                cmd.Parameters.AddWithValue("@taxaentrega", double.Parse(TaxaEntrega.ToString("N")));
                cmd.Parameters.AddWithValue("@totalliquido", double.Parse(TotalLiquido.ToString("N")));
                cmd.Parameters.AddWithValue("@observacao", Observacao.ToString());

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

            if (ret)
            {
                if (!Conecta())
                {
                    ret=false;
                }

                if (pIncluir) // pegar o ultimo id quando for inclusao
                {
                    StrQuery = "SELECT max([Id]) as ultimo FROM[dbo].[Orcamento]";
                    using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        Ultimo_ID = 0;
                        if (dr.HasRows)
                        {
                            Ultimo_ID = int.Parse(dr["ultimo"].ToString());
                        }
                    }

                    dr.Close();
                    conn.Close();

                }

                if (!pIncluir) {
                    if (!Conecta())
                    {
                        ret = false;
                    }
                    // verificando se existe produtos lançados no orçamento_compl para deletar

                    int temPro = TemProdutosnoOrcamento(Id);
                    if(temPro > 0) { // somente se tiver produtos é que ele vai deletar
                            StrQuery = "DELETE FROM ORCAMENTO_COMPL WHERE Orcamento_Id=" + Id.ToString();
                            using (SqlCommand cmd_compl = new SqlCommand(StrQuery, conn))
                            {
                                cmd_compl.CommandType = System.Data.CommandType.Text;
                                int i = cmd_compl.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    ret = true;
                                }
                                else
                                {
                                    ret = false;
                                }
                            }
                    }

                    conn.Close();
                }

                if (ret)
                {
                    if (!Conecta())
                    {
                        ret = false;
                    }
             
                        SqlCommand cmd_compl = new SqlCommand();
                        cmd_compl.CommandType = System.Data.CommandType.Text;
                        cmd_compl.Connection = conn;

                    foreach (ListViewItem item in OrcDadosPro.Items)
                    {
                        if (pIncluir)
                        {
                            Id = Ultimo_ID;
                        }

                        Produto_id = int.Parse(item.SubItems[0].Text);
                        Produto_Quantidade = double.Parse(item.SubItems[4].Text);
                        Produto_Observacao = item.SubItems[6].Text;

                        StrQuery = "INSERT INTO ORCAMENTO_COMPL (orcamento_id," +
                         "produto_id,produto_quantidade,produto_observacao) values" +
                         " (" + int.Parse(Id.ToString()) + "," + int.Parse(Produto_id.ToString()) + "," + double.Parse(Produto_Quantidade.ToString()) + ",'" + Produto_Observacao.ToString() + "')";

                       // MessageBox.Show(StrQuery.ToString());
                        
                        cmd_compl.CommandText = StrQuery.ToString();

                        try
                        {
                            int i = cmd_compl.ExecuteNonQuery();
                            if (i > 0)
                            {
                                ret = true;

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao SALVAR ORCAMENTO->PRODUTOS Exceção: " + ex.ToString());
                            ret = false;
                        }

                    }

                }

                conn.Close();

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
            // deletar todos os registros dos orçamentos pelo id
            // 1º DELETA registros do orçamento_compl
            // 2º DELETA registros do orcamento
            // deletando todos os registros da tabela orcamento_compl com o ID passado
            StrQuery = "DELETE FROM ORCAMENTO_COMPL WHERE ID=" + pId.ToString();

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
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

            if (!Conecta())
            {
                ret = false;
            }

            StrQuery = "DELETE FROM ORCAMENTO WHERE ID=" + pId.ToString() + "";

            using (SqlCommand cmd = new SqlCommand(StrQuery, conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
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


        // retorna a quantidade de produtos lançados em cada orçamento consultado
        
        private int TemProdutosnoOrcamento(int pid)
        {
            StrQuery = "dbo.consultaprodutosorcamento";

            int x = 0;

            using (SqlCommand cmd2 = new SqlCommand(StrQuery, conn))
            {
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@id", pid.ToString());

                dr = cmd2.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                    x++;
                }


            }
            dr.Close();
            return x;

        }








        // final da classe
    }
}
