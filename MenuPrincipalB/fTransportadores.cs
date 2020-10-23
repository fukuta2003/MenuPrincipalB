using Sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Models;

namespace MenuPrincipalB
{
    public partial class fTransportadores : Form
    {

        Transportadores Tra = new Transportadores();

        Validacao Fun = new Validacao();

        Cep cep = new Cep();

        public bool wp_Incluir;


        public fTransportadores()
        {
            InitializeComponent();
        }

        private void txtTaxa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);

        }

        private void txtTaxa_Leave(object sender, EventArgs e)
        {
            txtTaxa.Text = Fun.Formata_Moeda(txtTaxa.Text);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Fun.Confirma("Deseja realmente excluir ?", "Atenção"))
            {
                if (Tra.Excluir(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("FORNECEDOR EXCLUIDO COM SUCESSO !");
                }
                else
                {
                    MessageBox.Show("Nãoi foi possível excluir ?");
                }

                LimpaDados();
                gpoDados.Enabled = false;
                txtID.Focus();

            }
        }

      
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;

                if (string.IsNullOrEmpty(txtID.Text))
                {
                    wp_Incluir = true;

                }
                else
                {

                    wp_Incluir = false;
                    if (Tra.Consulta(int.Parse(txtID.Text)))
                    {

                        BuscarDadosClasse();

                    }


                }

                gpoDados.Enabled = true;
                txtNome.Focus();

            }



        }

        public void BuscarDadosClasse()
        {
            txtNome.Text = Tra.Descricao.ToString();
            txtEndereco.Text = Tra.Endereco.ToString();
            txtBairro.Text = Tra.Bairro.ToString();
            txtCidade.Text = Tra.Cidade.ToString();
            cmbEstado.Text = Tra.Estado.ToString();
            txtCep.Text = Tra.Cep.ToString();
            txtTelefone.Text = Tra.Telefone.ToString();
            txtEmail.Text = Tra.Email.ToString();
            txtCnpj.Text = Tra.Cpfcnpj.ToString();
            txtIE.Text = Tra.Rginscricao.ToString();
            txtTaxa.Text = Tra.Taxa.ToString("n");
            if (Tra.Ecorreio == "S")
            {
                cmbCorreio.Text = "SIM";
            } else
            {
                cmbCorreio.Text = "NÃO";
            }

            if (Tra.Ativa == "S")
            {
                cmbAtivo.Text = "SIM";
            } else
            {
                cmbAtivo.Text = "NÃO";
            }


        }

        public void EnviaDadosClasse()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                Tra.Id = 0;

            }
            else
            {
                Tra.Id = int.Parse(txtID.Text);
            }
            Tra.Descricao = txtNome.Text;
            Tra.Endereco = txtEndereco.Text;
            Tra.Bairro = txtBairro.Text;
            Tra.Cidade = txtCidade.Text;
            Tra.Estado = cmbEstado.Text;
            Tra.Cep = txtCep.Text;
            Tra.Telefone = txtTelefone.Text;
            Tra.Email = txtEmail.Text;
            Tra.Cpfcnpj = txtCnpj.Text;
            Tra.Rginscricao = txtIE.Text;
            Tra.Taxa = double.Parse(txtTaxa.Text);
            if(cmbAtivo.Text=="SIM")
            {
                Tra.Ativa = "S";
            } else
            {
                Tra.Ativa = "N";
            }
            if (cmbCorreio.Text == "SIM")
            {
                Tra.Ecorreio = "S";
            } else
            {
                Tra.Ecorreio = "N";
            }

        }

        public void LimpaDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cmbEstado.Text = "";
            txtCep.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtCnpj.Text = "";
            txtIE.Text = "";
            txtTaxa.Text = "";
            cmbCorreio.Text = "";
            cmbAtivo.Text = "";
        }

        private bool VerificaDados()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                ret = false;
            }
            if (string.IsNullOrEmpty(txtCidade.Text))
            {
                ret = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                ret = false;
            }

            return ret;

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            txtCep.Text = Fun.Formata_Cep(txtCep.Text);
            SendKeys.SendWait("{END}");
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.Text = Fun.Formata_TelefoneFixo(txtTelefone.Text);
            SendKeys.SendWait("{END}");
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            txtCnpj.Text = Fun.Formata_CPF(txtCnpj.Text);
            SendKeys.SendWait("{END}");
        }

        private void gpoDados_Enter(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (Fun.Confirma("Atenção", "Posso salvar os dados ?"))
            {
                EnviaDadosClasse();
                if (Tra.Salvar(wp_Incluir))
                {
                    MessageBox.Show("Dados salvos com sucesso !");
                    LimpaDados();
                    gpoDados.Enabled = false;
                    txtID.Focus();

                }
                else
                {
                    MessageBox.Show("Houve erro no momento salvar !");
                    txtNome.Focus();
                }

            }

        }

        private void fTransportadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                e.Handled = true;
                if (ActiveControl.Name.ToUpper() == "TXTID")
                {
                    this.Close();
                }
                else
                {
                    LimpaDados();
                    gpoDados.Enabled = false;
                    txtID.Focus();
                }
            }
        }

     
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                fShow fsw = new fShow("TRANSPORTADORES",
                    new string[] { "Id", "Descricao", "Taxa" }, "Descricao");

                fsw.ShowDialog();


                if (!string.IsNullOrEmpty(fsw.ParametroID.ToString()))
                {
                    txtID.Text = int.Parse(fsw.ParametroID.ToString()).ToString();
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {

            if (cep.ConsultaCep(txtCep.Text))
            {
                txtEndereco.Text = cep.Logradouro.ToString();
                txtBairro.Text = cep.Inicial.ToString();
                txtCidade.Text = cep.Loc_no.ToString();
                cmbEstado.Text = cep.Ufe_sg.ToString();
            }


        }

        private void fTransportadores_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();
            if (cep.Carrega_Estados())
            {
                cmbEstado.Items.AddRange(cep.Estados.ToArray());
            }

        }

        private void cmbCorreio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }

        private void txtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }
    }
}
