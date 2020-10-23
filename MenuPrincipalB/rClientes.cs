using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Sistema.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace MenuPrincipalB
{
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }

        private void rClientes_Load(object sender, EventArgs e)
        {
            try
            {
                Db Conexao = new Db();
                Conexao.Conecta();

                // conexao sql server

              //  string strConexao = ConfigurationManager.ConnectionStrings["Cliente"].ConnectionString;
                
                string strCommand = "SELECT * FROM CLIENTE ORDER BY NOME";
                SqlCommand objCommand = new SqlCommand(strCommand.ToString(), Conexao.conn);
                objCommand.CommandType = CommandType.Text;

                SqlDataAdapter objAdapter = new SqlDataAdapter();
                DataSet objDataSet = new DataSet();
                Rol_Clientes objReport = new Rol_Clientes();
                objCommand.Connection = Conexao.conn;
                objAdapter.SelectCommand = objCommand;
                objAdapter.Fill(objDataSet, "Cliente");
                objReport.SetDataSource(objDataSet);
              //  objReport.SetParameterValue("NumeroId", 6);


                //ReportDocument cryRpt = new ReportDocument();
                // string path_ = System.AppDomain.CurrentDomain.BaseDirectory;
               // string path_ = "F:\\ETEC078-SISTEMAS\\MenuPrincipalB\\MenuPrincipalB\\";
                ////@"C:\Users\Mac\Documents\Visual Studio 2010\Projects\Crystal_MultiplasTabelas\Crystal_MultiplasTabelas\RelatoriosMultiplasTabelas.rpt";
                //string caminho = path_ + "RelatoriosMultiplasTabelas.rpt";
                //string caminho = path_ + "Rol_Clientes.rpt";
                // MessageBox.Show(path_.ToString());

               // cryRpt.Load(caminho);
              //  cryRpt.RecordSelectionFormula = "{cliente.id} <= 10";
                //crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.ReportSource = objReport;
                crystalReportViewer1.Refresh();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException.ToString());
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
