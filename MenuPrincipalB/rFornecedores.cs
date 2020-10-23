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

namespace MenuPrincipalB
{
    public partial class rFornecedores : Form
    {
        public rFornecedores()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rFornecedores_Load(object sender, EventArgs e)
        {
            AjusteTela();

            Relatorio();

        }

        private void AjusteTela()
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;
            panel2.Height = this.Height;

        }


        private void Relatorio()
        {
            Db Conexao = new Db();
            Conexao.Conecta();
            string strCommand = "";

            if (string.IsNullOrEmpty(cmbOrdem.Text))
            {
                strCommand = "SELECT * FROM FORNECEDORES ORDER BY ID";
            }
            else if (cmbOrdem.Text == "NOME")
            {
                strCommand = "SELECT * FROM FORNECEDORES ORDER BY NOME";
            }
            else if (cmbOrdem.Text == "CIDADE")
            {
                strCommand = "SELECT * FROM FORNECEDORES ORDER BY CIDADE";
            }
            else if (cmbOrdem.Text == "ESTADO")
            {
                strCommand = "SELECT * FROM FORNECEDORES ORDER BY ESTADO,CIDADE";
            }


            SqlCommand objCommand = new SqlCommand(strCommand.ToString(), Conexao.conn);
            objCommand.CommandType = CommandType.Text;

            SqlDataAdapter objAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            Rol_Fornecedores objReport = new Rol_Fornecedores();
            objCommand.Connection = Conexao.conn;
            objAdapter.SelectCommand = objCommand;
            objAdapter.Fill(objDataSet, "FORNECEDORES");
            if (!string.IsNullOrEmpty(cmbEstado.Text))
            {
                objReport.RecordSelectionFormula = "{Fornecedores.Estado}='" + cmbEstado.Text + "'";
            }
            objReport.SetDatabaseLogon(Conexao.user.ToString(), Conexao.password.ToString());
            objReport.SetDataSource(objDataSet);
            crystalReportViewer1.ReportSource = objReport;
            crystalReportViewer1.Refresh();

            Conexao.conn.Close();
            
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            Relatorio();
        }

        private void rFornecedores_Resize(object sender, EventArgs e)
        {
            AjusteTela();
        }
    }
}
