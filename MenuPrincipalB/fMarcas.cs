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
    public partial class fMarcas : Form
    {

        Marcas gpo = new Marcas();
        Validacao Funcoes = new Validacao();
        int CurrentIndex = 0;

        public bool wp_Incluir = false;

        public fMarcas()
        {
            InitializeComponent();
        }

        private void fMarcas_Load(object sender, EventArgs e)
        {

        }


        private void BuscaDadosClasse()
        {
            txtDescricao.Text = gpo.Descricao.ToString();

        }

        private void EnviaDadosClasse()
        {

            if (string.IsNullOrEmpty(txtID.Text))
            {
                gpo.Id = 0;
            }
            else
            {
                gpo.Id = int.Parse(txtID.Text);
            }

            gpo.Descricao = txtDescricao.Text;

        }

        private void LimparDados()
        {
            txtID.Text = "";
            txtDescricao.Text = "";
            btnExcluir.Enabled = false;

        }

        private void fGrupos_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcoes.AnalisaInteiro(e);

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
                    if (gpo.Consulta(int.Parse(txtID.Text)))
                    {
                        BuscaDadosClasse();
                        gpoDados.Enabled = true;
                        btnExcluir.Enabled = true;
                        txtDescricao.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ID deste <grupo> não encontrado !");
                        txtID.Focus();

                    }
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (Funcoes.Confirma("Posso Salvar ?", "Atenção"))
            {
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Campo Obrigatório não preenchido !");
                    txtDescricao.Focus();
                }
                else
                {
                    EnviaDadosClasse();
                    if (gpo.Salvar(wp_Incluir))
                    {
                        MessageBox.Show("Dados gravados com sucesso !");
                        LimparDados();
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
                fShow fsw = new fShow("MARCAS",
                   new string[] { "Id", "DESCRICAO" }, "DESCRICAO");

                fsw.ShowDialog();

                txtID.Text = fsw.ParametroID.ToString();

                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    SendKeys.SendWait("{ENTER}");
                }

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Funcoes.Confirma("Posso excluir esse grupo ?", "Alerta"))
            {
                if (gpo.Excluir(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("ID/Grupo excluido com sucesso !");
                    LimparDados();
                    gpoDados.Enabled = false;
                    txtID.Focus();
                }
            }
            else
            {
                txtDescricao.Focus();
            }
        }

        private void txtID_TextChanged_1(object sender, EventArgs e)
        {

        }

        





        // fim da classe
    }
}
