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
    public partial class fLogin : Form
    {
        // instanciamento da classe clogin para o nome do objeto login

        CLogin login = new CLogin();
        string NomeUsuario = "";
        string Operador = "";
        // 03-07-2020 criar o parametro para passar os dados para o formulario menu
        // dados do usuario logado
        public string ParametroUsuario
        {
            get { return txtUsuario.Text; }  // retorno do txtusuario.text (usuario logado)
        }

        public string ParametroNomeUsuario
        {
            get { return NomeUsuario.ToString();  }
        }

        public string ParametroOperador
        {
            get { return Operador.ToString(); }
        }


        public fLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();  // encerra o sistema
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // passando os dados de usuario e senha para classe cLogin
            login.Login = txtUsuario.Text;
            login.Password = txtSenha.Text;

            if (login.Consulta_Login())
            {
                NomeUsuario = login.NomeUsuario.ToString();
                Operador = login.Operador.ToString();
                this.Close();
            } else
            {
                MessageBox.Show("Usuário ou senha inválidos !");
                txtUsuario.Focus();
            }

        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            if (!login.Conecta())  // se não conectar ao banco de dados encerra o sistema
            {
                MessageBox.Show("Servidor não conectado !");
                Application.Exit();

            } else
            {
                // caso o teste de conexão seja ok
                // MessageBox.Show("CONEXÃO OK !");  
               
            }

            login.FechaBancoDeDados();  // apos o teste fecha a conexao com o banco de dados

        }
    }
}
