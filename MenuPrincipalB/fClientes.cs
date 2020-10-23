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
   
    public partial class fClientes : Form
    {
        // objetos publicos do formulario

        Clientes cl = new Clientes();  // instanciamos a classe clientes para ser utilizada no formulario.
        Validacao Funcoes = new Validacao();
        Cep xCep = new Cep();

        bool wp_Incluir = false;  // variavel de controle que em caso verdadeiro (inclui dados) falso (alterar dados)

        public void EnviarDadosClasse()
        {
            if(string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Text = "0";
            }
            cl.Id = int.Parse(txtID.Text);
            cl.Nome = txtNome.Text;
            cl.Endereco = txtEndereco.Text;
            cl.Numero = txtNumero.Text;
            cl.Bairro = txtBairro.Text;
            cl.Cidade = txtCidade.Text;
            cl.Estado = cmbEstado.Text;
            cl.Cep = txtCep.Text;
            cl.Telefone = txtTelefone.Text;
            cl.Celular = txtCelular.Text;
            if (chkWhatsApp.Checked == true)
            {
                cl.Whatsapp = true;
            } else
            {
                cl.Whatsapp = false;
            }
            cl.Email = txtEmail.Text;
            cl.Nascimento = DateTime.Parse(txtNascimento.Text);
            cl.Pessoa = cmbPessoa.Text;
            cl.Cpf = txtCpf.Text;
            cl.Rg = txtRg.Text;

        }

        public void ReceberDadosClasse()
        {
            txtNome.Text = cl.Nome.ToString();
            txtEndereco.Text = cl.Endereco.ToString();
            txtNumero.Text = cl.Numero.ToString();
            txtBairro.Text = cl.Bairro.ToString();
            txtCidade.Text = cl.Cidade.ToString();
            cmbEstado.Text = cl.Estado.ToString();
            txtCep.Text = cl.Cep.ToString();
            txtTelefone.Text = cl.Telefone.ToString();
            txtCelular.Text = cl.Celular.ToString();

            if (cl.Whatsapp)
            {
                chkWhatsApp.Checked = true;
            } else
            {
                chkWhatsApp.Checked = false;
            }

            txtEmail.Text = cl.Email.ToString();
            txtNascimento.Text = cl.Nascimento.ToString();
            cmbPessoa.Text = cl.Pessoa.ToString();
            txtCpf.Text = cl.Cpf.ToString();
            txtRg.Text = cl.Rg.ToString();

            if(cl.Pessoa.ToString() == "Pessoa Física")
            {
                lblCpf.Text = "CPF";
                lblRg.Text = "RG";
            } else
            {
                lblCpf.Text = "CNPJ";
                lblRg.Text = "Ins. Estadual";
            }

        }

        public void LimpaDadosFormulario()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            cmbEstado.Text = "";
            txtCep.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            chkWhatsApp.Checked = false;
            txtEmail.Text = "";
            txtNascimento.Text = "";
            cmbPessoa.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
        }


        public fClientes()
        {
            InitializeComponent();
            
        }


        private void fClientes_Load(object sender, EventArgs e)
        {

            cmbEstado.Items.Clear();
            if (xCep.Carrega_Estados())
            {
                cmbEstado.Items.AddRange(xCep.Estados.ToArray());
            }

        }

        private void fClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==27)
            {
                e.Handled = true;
                // (se o nome do controle ativo em maiusculo igual TXTID
                if(this.ActiveControl.Name.ToUpper()=="TXTID")
                {
                    this.Close(); // fecha o formulario
                } else
                {
                    LimpaDadosFormulario();
                    gpoDados.Enabled = false;
                    txtID.Focus();
                }
            }

        }
        // no evento kepress do formulario, vou testar se o {enter} foi pressionado
        // caso positivo, verificar se digitou algum ID ou ficou em branco
        // id digitado wp_incluir = false, id em branco wp_incluir=true
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13) // tecla 13 é o enter (testando se foi pressionada)
            {
                e.Handled = true;
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    // incluir dados
                    wp_Incluir = true;

                } else
                {
                    // consultar ou alterar dados
                    wp_Incluir = false;
                    if (!cl.ConsultaClienteId(int.Parse(txtID.Text))) {
                        MessageBox.Show("ID não encontrado !");
                        txtID.Focus();
                    } else
                    {
                        ReceberDadosClasse();
                    }

                }

                gpoDados.Enabled = true;
                txtNome.Focus();

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!VerificaDados())
            {
                MessageBox.Show("Existem campos com preenchimento obrigatório vazios !");
                txtNome.Focus();
                return;
            } else
            {
                EnviarDadosClasse();
                // salvar os dados na classe
                // 17/07/2020 -> instanciar o evento de inserçao de dados
                if (cl.SalvarDadosCliente(wp_Incluir)) // se salvou com sucesso
                {
                    if (wp_Incluir) // se foi inclusao
                    {
                        // se foi inclusao exibe a mensagem abaixo
                        MessageBox.Show("Ok, dados incluidos com sucesso !");
                    } else
                    {
                        // se foi alteraçao exibe a mensagem abaixo
                        MessageBox.Show("OK, dados alterados com sucesso !");
                    }
                }  else
                {
                    // se retornou false é porque não salvou os dados
                    // exiba a mensagem abaixo
                    MessageBox.Show("Erro ao salvar os dados !");
                    txtNome.Focus();
                    return;
                }

            }

            LimpaDadosFormulario();
            gpoDados.Enabled = false;
            txtID.Focus();

        }

        private bool VerificaDados()
        {
            bool ret = true;  // variavel de controle para retornar se existe campos a serem preenchidos

            if (string.IsNullOrEmpty(txtNome.Text)) // verifica se o campo nome esta vazio ou nulo
            {
                ret = false;  // retorna falso quando o campo esta vazio ou nulo
            }
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                ret = false;
            }
            if (string.IsNullOrEmpty(txtTelefone.Text))
            {
                ret = false;
            }

            return ret;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(Confirma("Deseja mesmo excluir ?"))
            {
                if (cl.ExcluirClientes(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Cliente excluido com sucesso !");
                    LimpaDadosFormulario();
                    gpoDados.Enabled = false;
                    txtID.Focus();

                } else
                {
                    MessageBox.Show("Não possível excluir os dados !");
                    txtNome.Focus();
                }
            } else
            {
                MessageBox.Show("Exclusão cancelada !");
                txtNome.Focus();
            }
        }

        private bool Confirma(string Mensagem)
        {
            bool ret = true;

            DialogResult ex = MessageBox.Show(Mensagem.ToString(), "Confirma", MessageBoxButtons.YesNo);
            if (ex == DialogResult.Yes)
            {
                ret = true;
            } else
            {
                ret = false;
            }

            return ret;
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            txtCep.Text = Funcoes.Formata_Cep(txtCep.Text);
            SendKeys.SendWait("{END}");
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.Text = Funcoes.Formata_TelefoneFixo(txtTelefone.Text);
            SendKeys.SendWait("{END}");
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            txtCelular.Text = Funcoes.Formata_Celular(txtCelular.Text);
            SendKeys.SendWait("{END}");

        }

        private void cmbPessoa_Leave(object sender, EventArgs e)
        {
            if(cmbPessoa.Text=="Pessoa Física")
            {
                lblCpf.Text = "CPF";
                lblRg.Text = "RG";
            } else
            {
                lblCpf.Text = "CNPJ";
                lblRg.Text = "Ins. Estadual";
            }
        }

        private void cmbPessoa_TextChanged(object sender, EventArgs e)
        {
            txtCpf.Focus();
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if(cmbPessoa.Text=="Pessoa Física")
            {
                txtCpf.Text = Funcoes.Formata_CPF(txtCpf.Text);
            }
            if(cmbPessoa.Text=="Pessoa Jurídica")
            {
               
                txtCpf.Text = Funcoes.Formata_CNPJ(txtCpf.Text);
            }

            SendKeys.SendWait("{END}");
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            if (!Funcoes.Verifica_CNPJ(txtCpf.Text))
            {
                MessageBox.Show("CNPJ errado !");
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                fShow fsw = new fShow("CLIENTE",
                    new string[] { "Id", "Nome", "Endereco", "Cidade" , "Cpf", "Telefone" }, "Nome");

                fsw.ShowDialog();
                txtID.Text = fsw.ParametroID.ToString();
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    SendKeys.Send("{ENTER}");
                }
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (xCep.ConsultaCep(txtCep.Text))
            {
                txtEndereco.Text = xCep.Logradouro.ToString();
                txtBairro.Text = xCep.Inicial.ToString();
                txtCidade.Text = xCep.Loc_no.ToString();
                cmbEstado.Text = xCep.Ufe_sg.ToString();
            } else
            {
                MessageBox.Show("CEP Não encontrado !");
                txtEndereco.Focus();
            }
        }
    }
}
