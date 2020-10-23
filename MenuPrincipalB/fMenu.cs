using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MenuPrincipalB
{
    public partial class fMenu : Form
    {

        fLogin lg = new fLogin();

        public fMenu()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaClientes();
        }

        private void ChamaClientes()
        {
            fClientes cli = new fClientes();
            cli.Text = "CADASTRO DE CLIENTES";
            cli.StartPosition = FormStartPosition.CenterScreen;
            cli.WindowState = FormWindowState.Normal;
            cli.MdiParent = this;
            cli.Show();
        }
        private void ChamaFornecedores()
        {
            fFornecedores forn = new fFornecedores();
            forn.Text = "CADASTRO DE FORNECEDORES";
            forn.StartPosition = FormStartPosition.CenterScreen;
            forn.WindowState = FormWindowState.Normal;
            forn.MdiParent = this;
            forn.Show();
        }

        private void ChamaVendedores()
        {
            fVendedores forn = new fVendedores();
            forn.Text = "CADASTRO DE VENDEDORES";
            forn.StartPosition = FormStartPosition.CenterScreen;
            forn.WindowState = FormWindowState.Normal;
            forn.MdiParent = this;
            forn.Show();

        }

        private void ChamaGrupos()
        {
            fGrupos grp = new fGrupos();
            grp.Text = "CADASTRO DE GRUPOS DE PRODUTOS";
            grp.StartPosition = FormStartPosition.CenterScreen;
            grp.WindowState = FormWindowState.Normal;
            grp.MdiParent = this;
            grp.Show();

        }
        private void ChamaMarcas()
        {
            fMarcas grp = new fMarcas();
            grp.Text = "CADASTRO DE MARCAS DE PRODUTOS";
            grp.StartPosition = FormStartPosition.CenterScreen;
            grp.WindowState = FormWindowState.Normal;
            grp.MdiParent = this;
            grp.Show();

        }

        private void ChamaOrcamentos()
        {
            fOrcamento grp = new fOrcamento();
            grp.Text = "Orçamentos ao cliente";
            grp.StartPosition = FormStartPosition.CenterScreen;
            grp.WindowState = FormWindowState.Normal;
            grp.MdiParent = this;
            grp.Show();

        }

        private void ChamaTransportadores()
        {
            fTransportadores tra = new fTransportadores();
            tra.Text = "Cadastro de Transportadores";
            tra.StartPosition = FormStartPosition.CenterScreen;
            tra.WindowState = FormWindowState.Normal;
            tra.MdiParent = this;
            tra.Show();

        }

        private void ChamaFormasPagamento()
        {
            fFormasPagamento fpg = new fFormasPagamento();
            fpg.Text = "Formas de Pagamento";
            fpg.StartPosition = FormStartPosition.CenterScreen;
            fpg.WindowState = FormWindowState.Normal;
            fpg.MdiParent = this;
            fpg.Show();
        }


        private void ChamaProdutos()
        {
            fProdutos fPro = new fProdutos();
            fPro.Text = "Cadastro de Produtos";
            fPro.StartPosition = FormStartPosition.CenterScreen;
            fPro.WindowState = FormWindowState.Normal;
            fPro.MdiParent = this;
            fPro.Show();
        }

        private void ChamaRelatorioClientes()
        {
            rClientes rolcli = new rClientes();
            rolcli.Text = "Relatório de Clientes Simplificado";
            rolcli.StartPosition = FormStartPosition.CenterScreen;
            rolcli.WindowState = FormWindowState.Maximized;
            rolcli.MdiParent = this;
            rolcli.Show();
        }
        private void ChamaRelatorioFornecedores()
        {
            rFornecedores rolfor = new rFornecedores();
            rolfor.Text = "Relatório de Clientes Simplificado";
            rolfor.StartPosition = FormStartPosition.CenterScreen;
            rolfor.WindowState = FormWindowState.Maximized;
            rolfor.MdiParent = this;
            rolfor.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            lg.StartPosition = FormStartPosition.CenterScreen;
            lg.WindowState = FormWindowState.Normal;
            lg.ShowDialog();

            // pegar os dados do parametro do formulario flogin

            lblUsuario.Text = lg.ParametroUsuario.ToString();
            lblNomeUsuario.Text = lg.ParametroNomeUsuario.ToString();
            lblOperador.Text = lg.ParametroOperador.ToString();
            lblData.Text = DateTime.Now.Date.ToString("dd-MM-yyy");
            
        }

       

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ChamaClientes();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ChamaFornecedores();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ChamaVendedores();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaGrupos();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaMarcas();
        }

        private void orçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaOrcamentos();
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaFormasPagamento();
        }

        private void transportadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaTransportadores();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamaProdutos();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChamaRelatorioClientes();
        }

        private void fornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChamaRelatorioFornecedores();
        }
    }
}
