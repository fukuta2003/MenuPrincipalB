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
    public partial class fFormasPagamento : Form
    {

        FormasPagamento Fpg = new FormasPagamento();
        Validacao Fun = new Validacao();

        bool wp_Incluir = false;


        public fFormasPagamento()
        {
            InitializeComponent();
        }

        private void fFormasPagamento_Load(object sender, EventArgs e)
        {

        }

        private void BuscaDadosClasse()
        {
            txtDescricao.Text = Fpg.Descricao.ToString();
            txtParc01.Text = Fpg.Parc01.ToString();
            txtParc02.Text = Fpg.Parc02.ToString();
            txtParc03.Text = Fpg.Parc03.ToString();
            txtParc04.Text = Fpg.Parc04.ToString();
            txtParc05.Text = Fpg.Parc05.ToString();
            txtParc06.Text = Fpg.Parc06.ToString();
            txtPorc01.Text = Fpg.Porc01.ToString();
            txtPorc02.Text = Fpg.Porc02.ToString();
            txtPorc03.Text = Fpg.Porc03.ToString();
            txtPorc04.Text = Fpg.Porc04.ToString();
            txtPorc05.Text = Fpg.Porc05.ToString();
            txtPorc06.Text = Fpg.Porc06.ToString();


        }

        private void EnviaDadosClasse()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                Fpg.ID = 0;
            } else
            {
                Fpg.ID = int.Parse(txtID.Text);
            }

            // tratando os valores para nao ficar nulos, caso não informe nos campos do formulario

            if (string.IsNullOrEmpty(txtParc01.Text))
            {
                txtParc01.Text = "0";
            }
            if (string.IsNullOrEmpty(txtParc02.Text))
            {
                txtParc02.Text = "0";
            }
            if (string.IsNullOrEmpty(txtParc03.Text))
            {
                txtParc03.Text = "0";
            }
            if (string.IsNullOrEmpty(txtParc04.Text))
            {
                txtParc04.Text = "0";
            }
            if (string.IsNullOrEmpty(txtParc05.Text))
            {
                txtParc05.Text = "0";
            }
            if (string.IsNullOrEmpty(txtParc06.Text))
            {
                txtParc06.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPorc01.Text))
            {
                txtPorc01.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPorc02.Text))
            {
                txtPorc02.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPorc03.Text))
            {
                txtPorc03.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPorc04.Text))
            {
                txtPorc04.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPorc05.Text))
            {
                txtPorc05.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPorc06.Text))
            {
                txtPorc06.Text = "0";
            }


            Fpg.Descricao = txtDescricao.Text;
            Fpg.Parc01 = int.Parse(txtParc01.Text);
            Fpg.Parc02 = int.Parse(txtParc02.Text);
            Fpg.Parc03 = int.Parse(txtParc03.Text);
            Fpg.Parc04 = int.Parse(txtParc04.Text);
            Fpg.Parc05 = int.Parse(txtParc05.Text);
            Fpg.Parc06 = int.Parse(txtParc06.Text);

            Fpg.Porc01 = double.Parse(txtPorc01.Text);
            Fpg.Porc02 = double.Parse(txtPorc02.Text);
            Fpg.Porc03 = double.Parse(txtPorc03.Text);
            Fpg.Porc04 = double.Parse(txtPorc04.Text);
            Fpg.Porc05 = double.Parse(txtPorc05.Text);
            Fpg.Porc06 = double.Parse(txtPorc06.Text);

        }

        private void LimparDadosClasse()
        {
            txtID.Text = "";
            txtDescricao.Text = "";
            txtParc01.Text = "";
            txtParc02.Text = "";
            txtParc03.Text = "";
            txtParc04.Text = "";
            txtParc05.Text = "";
            txtParc06.Text = "";
            txtPorc01.Text = "";
            txtPorc02.Text = "";
            txtPorc03.Text = "";
            txtPorc04.Text = "";
            txtPorc05.Text = "";
            txtPorc06.Text = "";

        }

        private void fFormasPagamento_KeyPress(object sender, KeyPressEventArgs e)
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
                    LimparDadosClasse();
                    gpoDados.Enabled = false;
                    txtID.Focus();
                }
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (txtID.Text == "")
                {
                    wp_Incluir = true;
                    btnExcluir.Enabled = false;
                    gpoDados.Enabled = true;
                    txtDescricao.Focus();
                }
                else
                {
                    if (Fpg.Consulta(int.Parse(txtID.Text)))
                    {
                        BuscaDadosClasse();
                        gpoDados.Enabled = true;
                        btnExcluir.Enabled = true;
                        txtDescricao.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ID desta FORMA DE PAGAMENTO não encontrado !");
                        txtID.Focus();

                    }
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (Fun.Confirma("Posso Salvar ?", "Atenção"))
            {
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Campo Obrigatório não preenchido !");
                    txtDescricao.Focus();
                }
                else
                {
                    EnviaDadosClasse();
                    if (Fpg.Salvar(wp_Incluir))
                    {
                        MessageBox.Show("Dados gravados com sucesso !");
                        LimparDadosClasse();
                        gpoDados.Enabled = false;
                        txtID.Focus();
                    }
                }
            }
            else
            {
                txtDescricao.Focus();
            }

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                fShow fsw = new fShow("FORMASPAGAMENTO",
                   new string[] { "Id", "DESCRICAO" }, "DESCRICAO");

                fsw.ShowDialog();

               
                if (!string.IsNullOrEmpty(fsw.ParametroID.ToString()))
                {
                    txtID.Text = int.Parse(fsw.ParametroID.ToString()).ToString();
                    SendKeys.SendWait("{ENTER}");
                }

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Fun.Confirma("Posso excluir esse grupo ?", "Alerta"))
            {
                if (Fpg.Excluir(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("ID/Grupo excluido com sucesso !");
                    LimparDadosClasse();
                    gpoDados.Enabled = false;
                    txtID.Focus();
                }
            }
            else
            {
                txtDescricao.Focus();
            }
        }

        private void txtParc01_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }
        private void txtParc02_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }
        private void txtParc03_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }
        private void txtParc04_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }
        private void txtParc05_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }
        private void txtParc06_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaInteiro(e);
        }

        private void txtPorc01_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);
        }

        private void txtPorc02_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);
        }
        private void txtPorc03_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);
        }
        private void txtPorc04_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);
        }
        private void txtPorc05_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);
        }
        private void txtPorc06_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fun.AnalisaMoeda(e);
        }










        // fim da classe
    }
}
