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
    public partial class fVendedores : Form
    {

        Vendedores VendX = new Vendedores();
        Validacao Funcoes = new Validacao();
        Cep CEP = new Cep();

        bool wp_Incluir = true;

        public fVendedores()
        {
            InitializeComponent();
        }

        private void fVendedores_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();
            if (CEP.Carrega_Estados())
            {
                cmbEstado.Items.AddRange(CEP.Estados.ToArray());
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
                    gpoDados.Enabled = true;
                    txtNome.Focus();
                }
                else
                {
                    wp_Incluir = false;
                    if (!VendX.ConsultaId(int.Parse(txtID.Text)))
                    {
                        MessageBox.Show("O ID Informado não foi encontrado !");
                        txtID.Focus();

                    }
                    else
                    {

                        BuscaDadosClasse();
                        gpoDados.Enabled = true;
                        txtNome.Focus();
                    }
                }

            }

        }


        private void BuscaDadosClasse()
        {

            txtNome.Text = VendX.Nome.ToString();
            txtCep.Text = VendX.Cep.ToString();
            txtEndereco.Text = VendX.Endereco.ToString();
            txtBairro.Text = VendX.Bairro.ToString();
            txtCidade.Text = VendX.Cidade.ToString();
            cmbEstado.Text = VendX.Estado.ToString();
            txtTelefone.Text = VendX.Telefone.ToString();
            txtCelular.Text = VendX.Celular.ToString();
            
            txtCPF.Text = VendX.Cpf.ToString();
            Verifica_Cpf(); // funcao que verifica se o cpf cadastrado esta correto ou nao !
            
            txtRg.Text = VendX.Rg.ToString();
            txtComissao.Text = VendX.Comissao.ToString();

        }

        private void SalvarDadosnaClasse()
        {
            if (string.IsNullOrEmpty(txtID.Text)){
                VendX.Id = 0;
            } else
            {
                VendX.Id = int.Parse(txtID.Text);
            }
            VendX.Nome = txtNome.Text;
            VendX.Cep = txtCep.Text;
            VendX.Endereco = txtEndereco.Text;
            VendX.Bairro = txtBairro.Text;
            VendX.Cidade = txtCidade.Text;
            VendX.Estado = cmbEstado.Text;
            VendX.Telefone = txtTelefone.Text;
            VendX.Celular = txtCelular.Text;
            VendX.Cpf = txtCPF.Text;
            VendX.Rg = txtRg.Text;
            VendX.Comissao = double.Parse(txtComissao.Text);

        }

        private void LimparDados()
        {
            txtNome.Text = "";
            txtEndereco.Clear();
            txtBairro.Text = "";
            txtCidade.Text = "";
            cmbEstado.Text = "";
            txtCep.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtCPF.Text = "";
            txtRg.Text = "";
            txtComissao.Text = "";
            pictNao.Visible = false;
            pictOK.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Funcoes.Confirma("Posso salvar ?", "Atenção"))
            {
                SalvarDadosnaClasse();

                if (VendX.Salvar(wp_Incluir))
                {
                    MessageBox.Show("Dados salvos com sucesso !");

                }
                else
                {

                    MessageBox.Show("Erro ao salvar os dados !");

                }

                LimparDados();
                gpoDados.Enabled = false;
                txtID.Focus();
            }
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            txtCep.Text = Funcoes.Formata_Cep(txtCep.Text);
            SendKeys.SendWait("{END}");
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            txtCelular.Text = Funcoes.Formata_Celular(txtCelular.Text);
            SendKeys.SendWait("{END}");

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.Text = Funcoes.Formata_TelefoneFixo(txtTelefone.Text);
            SendKeys.SendWait("{END}");

        }

        private void fVendedores_KeyPress(object sender, KeyPressEventArgs e)
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
                    LimparDados();
                    gpoDados.Enabled = false;
                    txtID.Focus();
                }
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (CEP.ConsultaCep(txtCep.Text))
            {
                txtEndereco.Text = CEP.Logradouro.ToString();
                txtBairro.Text = CEP.Inicial.ToString();
                txtCidade.Text = CEP.Loc_no.ToString();
                cmbEstado.Text = CEP.Ufe_sg.ToString();
                txtEndereco.Focus();
                SendKeys.SendWait("{END}");
            }
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            txtCPF.Text = Funcoes.Formata_CPF(txtCPF.Text);
            SendKeys.SendWait("{END}");

        }

        private void txtComissao_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            Verifica_Cpf();
        }

        private void Verifica_Cpf()
        {
            if (!Funcoes.Verifica_CPF(txtCPF.Text))
            {
                //MessageBox.Show("CPF INVÁLIDO !");
                pictNao.Visible = true;
                pictOK.Visible = false;
            }
            else
            {
                pictOK.Visible = true;
                pictNao.Visible = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Funcoes.Confirma("Deseja realmente <deletar> os dados ?", "Atenção"))
            {
                if (VendX.Excluir(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Fornecedor deletado com sucesso !");
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir / deletar !");
                }

            }

            LimparDados();
            gpoDados.Enabled = false;
            txtID.Focus();

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                fShow fsw = new fShow("VENDEDORES", new string[] { "id", "nome", "cidade", "estado", "telefone" }, "nome");
                fsw.ShowDialog();
                txtID.Text = fsw.ParametroID.ToString();
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void txtComissao_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar == '.')
            {
                e.Handled = true;
            }

        }

        private void txtComissao_Leave(object sender, EventArgs e)
        {
            if (txtComissao.Text == "")
            {
                txtComissao.Text = "0.00";
            }

            txtComissao.Text = Convert.ToDouble(txtComissao.Text).ToString("n");
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_MouseHover(object sender, EventArgs e)
        {
            btnExcluir.BackColor = Color.Red;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            btnExcluir.BackColor = Color.LightYellow;
        }

        private void btnSalvar_MouseHover(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.LightBlue;

        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.LightYellow;

        }




        // fim da classe
    }

}
