using Sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuPrincipalB
{
    public partial class fProdutos : Form
    {
        bool wp_Incluir = false;
        bool wp_AlterouImagem = false;

        // intanciamento de classes

        Produtos Pro = new Produtos();
        Marcas Mar = new Marcas();
        Grupos Gru = new Grupos();
        Validacao Val = new Validacao();


        // tratamento de imagens
        private long tamanhoArquivoImagem = 0;
        private byte[] vetorImagens;

        public fProdutos()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void fProdutos_Load(object sender, EventArgs e)
        {
            cmbUnidades.Items.Clear();
            cmbUnidades.Items.Add("UN");    // VENDAS POR UNIDADE
            cmbUnidades.Items.Add("PC");    // VENDAS POR PEÇA
            cmbUnidades.Items.Add("LT");    // VENDAS POR LITRO
            cmbUnidades.Items.Add("KG");    // VENDAS POR KILO
            cmbUnidades.Items.Add("GR");    // VENDAS POR GRAMA
            cmbUnidades.Items.Add("PT");    // VENDAS POR PACOTE


        }

        private void BuscarDadosClasse()
        {

            txtDescricao.Text = Pro.Descricao.ToString();
            txtCodeBar.Text = Pro.Codebar.ToString();
            cmbUnidades.Text = Pro.Unidade.ToString();
            txtLocalEstoque.Text = Pro.Local_Estoque.ToString();
            txtPrecoVenda.Text = Pro.Preco_Venda.ToString("N").ToString();
            txtDescontoMax.Text = Pro.Desconto_Vista.ToString("N");
            txtCustoAtual.Text = Pro.Custo_Atual.ToString("N");
            txtCustoMedio.Text = Pro.Custo_Medio.ToString("N");
            txtCustoAnterior.Text = Pro.Custo_Anterior.ToString("N");
            txtEstoqueAtual.Text = Pro.Estoque_Atual.ToString("N");
            txtEstoqueMinimo.Text = Pro.Estoque_Minimo.ToString("N");
            txtEstoqueMaximo.Text = Pro.Estoque_Maximo.ToString("N");
            txtGrupo.Text = Pro.Grupo.ToString();
            if (String.IsNullOrEmpty(txtGrupo.Text))
            {
                txtGrupo.Text = "0";
            }
            if (Gru.Consulta(int.Parse(txtGrupo.Text)))
            {
                lblGrupo.Text = Gru.Descricao.ToString();
            } else
            {
                lblGrupo.Text = "Grupo não encontrado";
            }

            txtMarca.Text = Pro.Marca.ToString();
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                txtMarca.Text = "0";
            }
            if (Mar.Consulta(int.Parse(txtMarca.Text)))
            {
                lblMarca.Text = Mar.Descricao.ToString();
            }

            txtUltimoCliente.Text = Pro.Ultimo_Cliente.ToString();
            txtUltimaVenda.Text = Pro.Ultima_Venda.ToString("dd/MM/yyyy hh:mm");
            if (!string.IsNullOrEmpty(Pro.Cest))
            {
                txtCest.Text = Pro.Cest.ToString();
                if (string.IsNullOrEmpty(txtCest.Text))
                {
                    txtCest.Text = "0";
                }
                if (Pro.Consulta_Cest(txtCest.Text))
                {
                    lblCest.Text = Pro.Cest_Descricao.ToString();
                }
            }

            if (!string.IsNullOrEmpty(Pro.Ncm))
            {
                txtNcm.Text = Pro.Ncm.ToString();
                if (string.IsNullOrEmpty(txtNcm.Text))
                {
                    txtNcm.Text = "0";
                }
                if (Pro.Consulta_Ncm(txtNcm.Text))
                {
                    lblNcm.Text = Pro.Ncm_Descricao.ToString();
                }
            }

            if(Pro.Imagem != null) { 

                Image ImagemdoBanco = ByteToImage(Pro.Imagem);
                picImagem.Image = ImagemdoBanco;
            }

        }
        protected void CarregaImagem()
        {
            try
            {
                this.openFileDialog1.ShowDialog(this);
                string strFn = this.openFileDialog1.FileName;

                if (string.IsNullOrEmpty(strFn))
                    return;

                this.picImagem.Image = Image.FromFile(strFn);
                FileInfo arqImagem = new FileInfo(strFn);
                tamanhoArquivoImagem = arqImagem.Length;
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                vetorImagens = new byte[Convert.ToInt32(this.tamanhoArquivoImagem)];
                int iBytesRead = fs.Read(vetorImagens, 0, Convert.ToInt32(this.tamanhoArquivoImagem));
                fs.Close();
                wp_AlterouImagem = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnviarDadosClasse()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Text = "0";
            }
            Pro.Id = int.Parse(txtID.Text);
            Pro.Descricao = txtDescricao.Text;
            Pro.Unidade = cmbUnidades.Text;
            Pro.Local_Estoque = txtLocalEstoque.Text;
            Pro.Codebar = txtCodeBar.Text;
            Pro.Preco_Venda = decimal.Parse(txtPrecoVenda.Text);
            Pro.Desconto_Vista = decimal.Parse(txtDescontoMax.Text);
            Pro.Custo_Atual = decimal.Parse(txtCustoAtual.Text);
            Pro.Custo_Medio = decimal.Parse(txtCustoMedio.Text);
            Pro.Custo_Anterior = decimal.Parse(txtCustoAnterior.Text);
            Pro.Estoque_Atual = decimal.Parse(txtEstoqueAtual.Text);
            Pro.Estoque_Minimo = decimal.Parse(txtEstoqueMinimo.Text);
            Pro.Estoque_Maximo = decimal.Parse(txtEstoqueMaximo.Text);
            Pro.Grupo = int.Parse(txtGrupo.Text);
            Pro.Marca = int.Parse(txtMarca.Text);
            Pro.Cest = txtCest.Text;
            Pro.Ncm = txtNcm.Text;
            if (wp_AlterouImagem) { 
                Pro.Imagem = vetorImagens;
            }
            if (string.IsNullOrEmpty(txtUltimoCliente.Text))
            {
                Pro.Ultimo_Cliente = 1;  // evita erro de chave estrangeira caso o produto não ter sido vendido
            }
          
        }

        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public Image ByteToImage(byte[] imageArray)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(imageArray);
        }
        private void VerificarDadosClasse()
        {

        }

        private void picImagem_Click(object sender, EventArgs e)
        {
            CarregaImagem();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                e.Handled = true;

                if (string.IsNullOrEmpty(txtID.Text))
                {
                    wp_Incluir = true;
                    tabControl1.Enabled = true;
                    txtDescricao.Focus();

                } else
                {
                    if (Pro.Consulta(int.Parse(txtID.Text)))
                    {
                        BuscarDadosClasse();
                        wp_Incluir = false;
                        tabControl1.Enabled = true;
                        txtDescricao.Focus();

                    } else
                    {
                        MessageBox.Show("Produto (id) não encontrado !");
                        tabControl1.Enabled = false;
                        txtID.Focus();
                    }
                }

            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtGrupo.Text))
                {
                    if (Gru.Consulta(int.Parse(txtGrupo.Text)))
                    {
                        lblGrupo.Text = Gru.Descricao.ToString();
                        lblGrupo.ForeColor = Color.Black;
                        txtDescontoMax.Focus();

                    }
                    else
                    {
                        lblGrupo.Text = "Grupo não encontrado...";
                        lblGrupo.ForeColor = Color.Red;
                        txtGrupo.Focus();
                    }
                }
            }
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtMarca.Text))
                {
                    if (Mar.Consulta(int.Parse(txtMarca.Text)))
                    {
                        lblMarca.Text = Mar.Descricao.ToString();
                        lblMarca.ForeColor = Color.Black;
                        txtCustoAnterior.Focus();
                    } else
                    {
                        lblMarca.Text = "Marca não encontrada !";
                        lblMarca.ForeColor = Color.Red;
                        txtMarca.Focus();
                    }
                }
            }
        }

        private void txtCest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtCest.Text))
                {
                    if (Pro.Consulta_Cest(txtCest.Text))
                    {
                        lblCest.Text = Pro.Cest_Descricao.ToString();
                        lblCest.ForeColor = Color.Black; txtNcm.Focus();
                        if(Pro.Ncm.ToString() != "")
                        {
                            if (Val.Confirma("Existe um NCM Padrão para o CEST, deseja usa-lo ?", "Atenção"))
                            {
                                txtNcm.Text = Pro.Ncm.ToString();
                            }
                        }
                        txtNcm.Focus();
                    }
                    else
                    {
                        lblCest.Text = "CEST não encontrada !";
                        lblCest.ForeColor = Color.Red;
                        txtCest.Focus();
                    }
                }
            }

        }

        private void txtNcm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtNcm.Text))
                {
                    if (Pro.Consulta_Ncm(txtNcm.Text))
                    {
                        lblNcm.Text = Pro.Ncm_Descricao.ToString();
                        lblNcm.ForeColor = Color.Black;
                        btnSalvar.Focus();

                    }
                    else
                    {
                        lblNcm.Text = "NCM não encontrada !";
                        lblNcm.ForeColor = Color.Red;
                        btnSalvar.Focus();
                    }
                }
            }

        }

        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                fShow fns = new fShow("GRUPOS", new string[] { "Id", "Descricao" }, "descricao");
                fns.ShowDialog();
                if(!string.IsNullOrEmpty(fns.ParametroID.ToString()))
                {
                    txtGrupo.Text = fns.ParametroID.ToString();
                    SendKeys.SendWait("{ENTER}");
                }


            }
        }

        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                fShow fns = new fShow("MARCAS", new string[] { "Id", "Descricao" }, "descricao");
                fns.ShowDialog();
                if (!string.IsNullOrEmpty(fns.ParametroID.ToString()))
                {
                    txtMarca.Text = fns.ParametroID.ToString();
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void txtCest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                fShow fns = new fShow("TAB_CEST", new string[] { "CEST", "DESCRICAO", "NCM" }, "CEST");
                fns.ShowDialog();
                if (!string.IsNullOrEmpty(fns.ParametroID.ToString()))
                {
                    txtCest.Text = fns.ParametroID.ToString();
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void txtNcm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                fShow fns = new fShow("ncm", new string[] { "NCM", "NOME" }, "NOME");
                fns.ShowDialog();
                if (!string.IsNullOrEmpty(fns.ParametroID.ToString()))
                {
                    txtNcm.Text = fns.ParametroID.ToString();
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void txtPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtCustoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtEstoqueAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtDescontoMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescontoMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtCustoMedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtEstoqueMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtCustoAnterior_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void txtEstoqueMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.AnalisaMoeda(e);
        }

        private void picImagem_MouseMove(object sender, MouseEventArgs e)
        {
            picImagem.BackColor = Color.DarkSalmon;
            picImagem.BorderStyle = BorderStyle.FixedSingle;

        }

        private void picImagem_MouseLeave(object sender, EventArgs e)
        {
            picImagem.BackColor = Color.White;
            picImagem.BorderStyle = BorderStyle.None;
        }

        private void fProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                e.Handled = true;
                if (ActiveControl.Name.ToUpper() == "TXTID")
                {
                    this.Close();
                } else
                {
                    Limpa();
                    tabControl1.Enabled = false;
                    txtID.Clear();
                    txtID.Focus();
                }
            }

           
        }

        private void Limpa()
        {
            txtDescricao.Clear();
            txtCodeBar.Clear();
            txtLocalEstoque.Clear();
            cmbUnidades.Text = "";
            txtPrecoVenda.Text = "";
            txtCustoAtual.Text = "";
            txtCustoAnterior.Text = "";
            txtCustoMedio.Text = "";
            txtDescontoMax.Text = "";
            txtEstoqueAtual.Text = "";
            txtEstoqueMinimo.Text = "";
            txtEstoqueMaximo.Text = "";
            txtGrupo.Text = "";
            txtMarca.Text = "";
            txtCest.Text = "";
            txtNcm.Text = "";
            lblGrupo.Text = "";
            lblMarca.Text = "";
            lblNcm.Text = "";
            txtUltimaVenda.Text = "";
            txtUltimoCliente.Text = "";
            lblUltimoCliente.Text = "";
            Pro.Imagem = null;
            picImagem.Image = null; // limpa a imagem
            picImagem.Refresh(); // atualiza o controle
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string Questao = "";
            if (wp_Incluir)
            {
                Questao = "Posso incluir os dados ?";
            } else
            {
                Questao = "Posso alterar os dados ?";
            }

            if(Val.Confirma(Questao, "Confirme"))
            {
                
                EnviarDadosClasse();
                if (Pro.Salvar(wp_Incluir,wp_AlterouImagem))
                {
                    MessageBox.Show("Dados salvos com sucesso !");
                } else
                {
                    MessageBox.Show("Erro ao salvar os dados !");
                }
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                fShow fns = new fShow("PRODUTOS", new string[] { "ID", "DESCRICAO" , "UNIDADE", "LOCAL_ESTOQUE", "ESTOQUE_ATUAL", "PRECO_VENDA", "DESCONTO_VISTA" }, "DESCRICAO",
                                                  new string[] { "ID", "Descrição", "Unidade", "Local", "Estoque", "R$ Preço", "Desc.Max" } );
                fns.ShowDialog();
                if (!string.IsNullOrEmpty(fns.ParametroID.ToString()))
                {
                    txtID.Text = fns.ParametroID.ToString();
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        private void txtPrecoVenda_Leave(object sender, EventArgs e)
        {
            txtPrecoVenda.Text = Val.Formata_Moeda(txtPrecoVenda.Text);
        }

        private void txtCustoAtual_Leave(object sender, EventArgs e)
        {
            txtCustoAtual.Text = Val.Formata_Moeda(txtCustoAtual.Text);
        }

        private void txtEstoqueAtual_Leave(object sender, EventArgs e)
        {
            txtEstoqueAtual.Text = Val.Formata_Moeda(txtEstoqueAtual.Text);
        }

        private void txtDescontoMax_Leave(object sender, EventArgs e)
        {
            txtDescontoMax.Text = Val.Formata_Moeda(txtDescontoMax.Text);
        }

        private void txtCustoMedio_Leave(object sender, EventArgs e)
        {
            txtCustoMedio.Text = Val.Formata_Moeda(txtCustoMedio.Text);
        }

        private void txtEstoqueMinimo_Leave(object sender, EventArgs e)
        {
            txtEstoqueMinimo.Text = Val.Formata_Moeda(txtEstoqueMinimo.Text);
        }

        private void txtCustoAnterior_Leave(object sender, EventArgs e)
        {
            txtCustoAnterior.Text = Val.Formata_Moeda(txtCustoAnterior.Text);
        }

        private void txtEstoqueMaximo_Leave(object sender, EventArgs e)
        {
            txtEstoqueMaximo.Text = Val.Formata_Moeda(txtEstoqueMaximo.Text);
        }

        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(Val.Confirma("Posso excluir esse produto ?", "Atenção"))
            {
                if (Pro.Excluir(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Produto excluído com sucesso !");
                    Limpa();
                    txtID.Clear();
                    txtID.Focus();
                } else
                {
                    txtDescricao.Focus();
                }
            }
        }





        // fim da classe
    }
}
