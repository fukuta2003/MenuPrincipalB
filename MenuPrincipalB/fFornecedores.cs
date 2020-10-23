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
    public partial class fFornecedores : Form
    {

        Fornecedores fornX = new Fornecedores();
        Validacao Funcoes = new Validacao();
        Cep CEP = new Cep();

        bool wp_Incluir = true;


        public fFornecedores()
        {
            InitializeComponent();
        }

        private void fFornecedores_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();
            if (CEP.Carrega_Estados())
            {
                cmbEstado.Items.AddRange(CEP.Estados.ToArray());
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

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
                    if (!fornX.ConsultaFornecedorId(int.Parse(txtID.Text)))
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

        // evento de busca dos dados da classe

        private void BuscaDadosClasse()
        {

            txtNome.Text = fornX.Nome.ToString();
            txtCep.Text = fornX.Cep.ToString();
            txtEndereco.Text = fornX.Endereco.ToString();
            txtBairro.Text = fornX.Bairro.ToString();
            txtCidade.Text = fornX.Cidade.ToString();
            cmbEstado.Text = fornX.Estado.ToString();
            txtTelefone.Text = fornX.Telefone.ToString();
            txtCelular.Text = fornX.Celular.ToString();
            txtEmail.Text = fornX.Email.ToString();
            cmbPessoa.Text = fornX.Pessoa.ToString();
            txtCnpj.Text = fornX.Cnpj.ToString();
            txtIe.Text = fornX.Ie.ToString();
            

        }

        // enviar dados para classe

        private void SalvarDadosnaClasse()
        {

            fornX.Nome = txtNome.Text;
            fornX.Cep = txtCep.Text;
            fornX.Endereco = txtEndereco.Text;
            fornX.Bairro = txtBairro.Text;
            fornX.Cidade = txtCidade.Text;
            fornX.Estado = cmbEstado.Text;
            fornX.Telefone = txtTelefone.Text;
            fornX.Celular = txtCelular.Text;
            fornX.Email = txtEmail.Text;
            fornX.Pessoa = cmbPessoa.Text;
            fornX.Cnpj = txtCnpj.Text;
            fornX.Ie = txtIe.Text;
          

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
            txtEmail.Text = "";
            cmbPessoa.Text = "";
            txtCnpj.Text = "";
            txtIe.Text = "";
           
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Funcoes.Confirma("Posso salvar ?", "Atenção"))
            {
                SalvarDadosnaClasse();

                if (fornX.Salvar(wp_Incluir))
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

        private void cmbPessoa_TextChanged(object sender, EventArgs e)
        {
            if(cmbPessoa.Text == "JURÍDICA")
            {
                lblCpf.Text = "CNPJ";
                lblRg.Text = "I.Estadual";
            } else
            {
                lblCpf.Text = "CPF";
                lblRg.Text = "RG";
            }
        }

        private void fFornecedores_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 27)
            {
                e.Handled = true;
                if(ActiveControl.Name.ToUpper() == "TXTID")
                {
                    this.Close();
                } else
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

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            if (cmbPessoa.Text == "JURÍDICA")
            {
                txtCnpj.Text = Funcoes.Formata_CNPJ(txtCnpj.Text);
            } else
            {
                txtCnpj.Text = Funcoes.Formata_CPF(txtCnpj.Text);
            }

            SendKeys.SendWait("{END}");

        }

        private void txtCnpj_Leave(object sender, EventArgs e)
        {
            VerificaCnpj();
        }


        private void VerificaCnpj()
        {
            if (cmbPessoa.Text == "JURÍDICA")
            {
                if (!Funcoes.Verifica_CNPJ(txtCnpj.Text))
                {
                    MessageBox.Show("CNPJ INVÁLIDO !");
                    
                }

            }
            else
            {
                if (!Funcoes.Verifica_CPF(txtCnpj.Text))
                {
                    MessageBox.Show("CPF INVÁLIDO !");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(Funcoes.Confirma("Deseja realmente <deletar> os dados ?", "Atenção"))
            {
                if (fornX.Excluir(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Fornecedor deletado com sucesso !");
                } else
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
            if(e.KeyCode == Keys.F2)
            {
                fShow fsw = new fShow("FORNECEDORES", new string[] { "id","nome","cidade", "estado", "telefone"}, "nome");
                fsw.ShowDialog();
                txtID.Text = fsw.ParametroID.ToString();
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        // ----> final da classe
    }
}
