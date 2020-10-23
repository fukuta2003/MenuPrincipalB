using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sistema.Models;
using System.Collections;
using CrystalDecisions.Shared;

namespace MenuPrincipalB 
{
    public partial class fShow : Form 
    {

        ListViewItem item;
        public string Tabela { get; set; }
        public string[] Campos { get; set; }
        public string[] Titulos { get; set; }
        public string Ordem { get; set; }

        public bool Controle;  // true -> monta cabeçario, false -> nao monta cabecario

        public SqlConnection conn;
        public SqlDataReader dr;
        public ArrayList Larguras = new ArrayList();

        Db Conex = new Db();


        public String ParametroID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public fShow() 
        {
            InitializeComponent();
        }

        // criando um construtor de sobre-carga para passar argumentos da tabela
        // e campos da tabela

        public fShow(string tabela, string[] campos, string ordem, string[] titulos = null)
        {
            Tabela = tabela;
            Campos = campos;
            Ordem = ordem;
            Titulos = titulos;
            
            InitializeComponent();
        }

        private void fShow_Load(object sender, EventArgs e)
        {
            Controle = true;
            listView1.View = System.Windows.Forms.View.Details;

            Conexao();

            AbreTabela(Tabela,Campos);

            MontaGrid();

            listView1.Focus();

            
        }

        private void MontaGrid()
        {
            string TipoDados = "";

            int[] ColunasValores; int[] ColunasDatas;
            ColunasValores = new int[50];
            ColunasDatas = new int[50];

            int x = 0;
            int xTamanho = 0;
            // Monta Cabeçario da Listview
            if (Controle) { 
                for (x = 0; x < Campos.Length; x++)
                {
                    if (Titulos == null)
                    {
                        listView1.Columns.Add(Campos[x].ToString(), 100, HorizontalAlignment.Left);
                    } else
                    {
                        listView1.Columns.Add(Titulos[x].ToString(), 100, HorizontalAlignment.Left);
                    }

                    cmbPesquisa.Items.Add(Campos[x].ToString().ToUpper()); // adicionar os campos na combobox de pesquisa
                }
                if (x > 0 && x < 2)
                {
                    cmbPesquisa.SelectedIndex = x - 1;
                } else
                {
                    cmbPesquisa.SelectedIndex = 1;
                }
                
            }

            int cols = listView1.Columns.Count;

            x = Campos.Length;
            int y = 0;
            TipoDados = "";
            string Mascara;
            xTamanho = 0;
            Mascara = "";
            while (dr.Read())
            {
                TipoDados = dr.GetDataTypeName(0).ToString();

                //MessageBox.Show(TipoDados.ToString());

                if (TipoDados.ToString().ToUpper() == "INT")
                {
                    xTamanho = dr[Campos[0]].ToString().Length;
                    item = new ListViewItem(dr[Campos[0]].ToString().PadLeft(6 - xTamanho, '0'));

                } else
                {
                    item = new ListViewItem(dr[Campos[0]].ToString());

                }
                string xConteudo = "";

                for (y = 1; y < x; y++)
                {
                    Mascara = "";
                    TipoDados = dr.GetDataTypeName(y).ToString();
                    // MessageBox.Show(TipoDados.ToString());
                    
                    if (TipoDados.ToString() == "Date" || TipoDados == "DateTime")
                    {
                        Mascara = "dd/MM/yyyy";
                        ColunasDatas[y] = y;
                    }

                    xTamanho = dr[Campos[0]].ToString().Length;
                    xConteudo = dr[Campos[y]].ToString();

                    if(y==1)
                    {
                        item.SubItems.Add(dr[Campos[y]].ToString().PadRight(50-xTamanho,' '));

                    }
                    else
                    {
                        if (TipoDados.ToString().ToUpper() == "DECIMAL")
                        {
                            item.SubItems.Add(dr[Campos[y]].ToString().PadLeft(02, 'x'));
                            ColunasValores[y] = y;           


                        } else if(TipoDados.ToString().ToUpper() == "DATE")
                        {
                            item.SubItems.Add(DateTime.Parse(dr[Campos[y]].ToString()).ToString("dd/MM/yyyy"));

                        } else
                        {
                            // outros campos sendo preenchidos

                            item.SubItems.Add(dr[Campos[y]].ToString());

                        }


                    }

                }


                listView1.Items.Add(item);

            }

            int tamColunas = 0;

            if (tamColunas < 150)
            {
                tamColunas = 150;
            }
            
            if(Controle)
            {

                for (y = 1; y < cols; y++)
                {
                    listView1.AutoResizeColumn(y, ColumnHeaderAutoResizeStyle.HeaderSize);
                    listView1.AutoResizeColumn(y, ColumnHeaderAutoResizeStyle.ColumnContent);
                    if (listView1.Columns[y].Width > 600)
                    {
                        tamColunas = tamColunas + 600;
                    } else
                    {
                        if(y == ColunasValores[y]) // colunas de valores
                        {
                            listView1.Columns[y].TextAlign = HorizontalAlignment.Right;
                            listView1.Columns[y].Width = 100;
                            tamColunas = tamColunas + listView1.Columns[y].Width;

                        } else
                        {
                            // outras colunas
                            // colunas com tamanho menor que 100, ficam com tamanho de 100

                            if (listView1.Columns[y].Width < 100)
                            {
                                listView1.Columns[y].Width = 100;
                            }

                            tamColunas = tamColunas + listView1.Columns[y].Width;
                        }

                    }
                }

                for (y = 1; y < cols; y++)
                {
                    Larguras.Add(listView1.Columns[y].Width);
                }
                Controle = false;
                listView1.Width = tamColunas - 45;

            }
            else
            {
                tamColunas = 150;
                for (y=1; y < cols ; y++)
                {
                   listView1.Columns[y].Width = int.Parse(Larguras[y-1].ToString());
                   tamColunas += listView1.Columns[y].Width; 
                }

            }

       
            // int z1 = listView1.Columns[cols - 1].Width;
            listView1.Refresh();
            listView1.Focus();
            SendKeys.Send("{HOME}");

            //this.Width = 800;

            // centraliza a tela depois de ter a chamado

            this.Width = tamColunas;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.Refresh();
           
            //this.StartPosition = FormStartPosition.CenterScreen;
            dr.Close();
            conn.Close();
        }

        private void Conexao() 
        {

            if (!Conex.Conecta())
            {
                MessageBox.Show("Banco de Dados não conectado !");
                this.Close();
            } else
            {
                conn = Conex.conn;
            }

            /*

            string host = "192.168.1.250";

          //  string host = "sqlserverflex.ddns.net"; // para acesso externo


            string DB = "OFICINA2";   // nome do banco de dados

            string user = "dev078";    // usuario do banco de dados
            string password = "etec078";  // senha do banco de dados

            string constring = "server=" + host + ";"
                             + "database=" + DB + ";"
                             + "user=" + user + ";"
                             + "password=" + password;

            conn = new SqlConnection(constring);
            */





        }

        private void AbreTabela(string pTabela, string[] pCampos, string pCondicao="")
        {

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            // montando a string de SELECT de dados
            string strQuery = "SELECT ";
            foreach(string p in pCampos)
            {
                strQuery += p.ToString() + ",";
            }
            int TamanhoQuery = strQuery.Length;
            strQuery = strQuery.Substring(0, TamanhoQuery - 1); // retira a ultima (,)
            strQuery = strQuery + " FROM " + pTabela;

            // aplicar condiçao

            if (pCondicao.ToString() != "")
            {

                strQuery = strQuery + " WHERE " + pCondicao.ToString();

            }


            if (!String.IsNullOrEmpty(Ordem)) // verifica se a string ORDEM é vazia ou nula
            {
                // Ñão sendo vazia incrementa na string do SELECT o comando ORDER BY para classificar a QUERY

                strQuery = strQuery + " ORDER BY " + Ordem; 
            }

            SqlCommand cmd = new SqlCommand(strQuery,conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            dr = cmd.ExecuteReader();
           


            //MessageBox.Show(strQuery);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Finaliza();
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                e.Handled = true;
                Finaliza();

            }
        }

        private void Finaliza()
        {
            string xid = listView1.SelectedItems[0].Text;
            txtID.Text = xid.ToString();
            this.Close();

        }

        private void fShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if(ActiveControl.Name.ToUpper()=="CMBPESQUISA")
                {
                    int xid = 0;
                    txtID.Text = "";
                    this.Close();

                } else
                {
                    cmbPesquisa.Focus();
                }

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // montar pesquisa
            Controle = false;
            string xCondicao = "";
            string Condicao = "";
      
            Condicao = cmbPesquisa.Text + " LIKE '%" + txtPesquisa.Text + "%'";
            dr.Close();
            listView1.Items.Clear();
            AbreTabela(Tabela, Campos, Condicao.ToString());
            MontaGrid();

        }

        private void cmbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                e.Handled = true;
                Controle = false;
                string Condicao = "";

                Condicao = cmbPesquisa.Text + " LIKE '%" + txtPesquisa.Text + "%'";
                dr.Close();
                listView1.Items.Clear();
                AbreTabela(Tabela, Campos, Condicao.ToString());
                MontaGrid();
                txtPesquisa.Focus();
                SendKeys.SendWait("{END}");
            }
        }
    }
    
}
