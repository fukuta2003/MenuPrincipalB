namespace MenuPrincipalB
{
    partial class fVendedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtComissao = new System.Windows.Forms.TextBox();
            this.gpoDados = new System.Windows.Forms.GroupBox();
            this.pictNao = new System.Windows.Forms.PictureBox();
            this.pictOK = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtRg = new System.Windows.Forms.TextBox();
            this.lblRg = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gpoDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictNao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictOK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID - F2-Mostrar";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(11, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(65, 20);
            this.txtID.TabIndex = 8;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtComissao
            // 
            this.txtComissao.Location = new System.Drawing.Point(16, 199);
            this.txtComissao.Name = "txtComissao";
            this.txtComissao.Size = new System.Drawing.Size(57, 20);
            this.txtComissao.TabIndex = 13;
            this.txtComissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComissao.TextChanged += new System.EventHandler(this.txtComissao_TextChanged);
            this.txtComissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComissao_KeyPress);
            this.txtComissao.Leave += new System.EventHandler(this.txtComissao_Leave);
            // 
            // gpoDados
            // 
            this.gpoDados.BackColor = System.Drawing.Color.Transparent;
            this.gpoDados.Controls.Add(this.pictNao);
            this.gpoDados.Controls.Add(this.pictOK);
            this.gpoDados.Controls.Add(this.txtComissao);
            this.gpoDados.Controls.Add(this.label11);
            this.gpoDados.Controls.Add(this.btnExcluir);
            this.gpoDados.Controls.Add(this.btnSalvar);
            this.gpoDados.Controls.Add(this.txtRg);
            this.gpoDados.Controls.Add(this.lblRg);
            this.gpoDados.Controls.Add(this.txtCPF);
            this.gpoDados.Controls.Add(this.lblCpf);
            this.gpoDados.Controls.Add(this.txtCelular);
            this.gpoDados.Controls.Add(this.label10);
            this.gpoDados.Controls.Add(this.txtTelefone);
            this.gpoDados.Controls.Add(this.label9);
            this.gpoDados.Controls.Add(this.label8);
            this.gpoDados.Controls.Add(this.cmbEstado);
            this.gpoDados.Controls.Add(this.txtCidade);
            this.gpoDados.Controls.Add(this.label7);
            this.gpoDados.Controls.Add(this.txtBairro);
            this.gpoDados.Controls.Add(this.label6);
            this.gpoDados.Controls.Add(this.txtCep);
            this.gpoDados.Controls.Add(this.label5);
            this.gpoDados.Controls.Add(this.txtEndereco);
            this.gpoDados.Controls.Add(this.label3);
            this.gpoDados.Controls.Add(this.txtNome);
            this.gpoDados.Controls.Add(this.label2);
            this.gpoDados.Enabled = false;
            this.gpoDados.Location = new System.Drawing.Point(12, 53);
            this.gpoDados.Name = "gpoDados";
            this.gpoDados.Size = new System.Drawing.Size(805, 314);
            this.gpoDados.TabIndex = 9;
            this.gpoDados.TabStop = false;
            // 
            // pictNao
            // 
            this.pictNao.BackgroundImage = global::MenuPrincipalB.Properties.Resources.close;
            this.pictNao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictNao.Location = new System.Drawing.Point(378, 155);
            this.pictNao.Name = "pictNao";
            this.pictNao.Size = new System.Drawing.Size(15, 12);
            this.pictNao.TabIndex = 32;
            this.pictNao.TabStop = false;
            this.pictNao.Visible = false;
            // 
            // pictOK
            // 
            this.pictOK.BackgroundImage = global::MenuPrincipalB.Properties.Resources.checks;
            this.pictOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictOK.Location = new System.Drawing.Point(378, 155);
            this.pictOK.Name = "pictOK";
            this.pictOK.Size = new System.Drawing.Size(17, 12);
            this.pictOK.TabIndex = 31;
            this.pictOK.TabStop = false;
            this.pictOK.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Comissão";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcluir.BackgroundImage = global::MenuPrincipalB.Properties.Resources.delete;
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.Location = new System.Drawing.Point(89, 230);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(76, 65);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseHover += new System.EventHandler(this.btnExcluir_MouseHover);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalvar.BackgroundImage = global::MenuPrincipalB.Properties.Resources.save_as;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Black;
            this.btnSalvar.Location = new System.Drawing.Point(14, 230);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(69, 65);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseHover += new System.EventHandler(this.btnSalvar_MouseHover);
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(407, 150);
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(133, 20);
            this.txtRg.TabIndex = 12;
            // 
            // lblRg
            // 
            this.lblRg.AutoSize = true;
            this.lblRg.Location = new System.Drawing.Point(404, 134);
            this.lblRg.Name = "lblRg";
            this.lblRg.Size = new System.Drawing.Size(23, 13);
            this.lblRg.TabIndex = 28;
            this.lblRg.Text = "RG";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(240, 150);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(158, 20);
            this.txtCPF.TabIndex = 11;
            this.txtCPF.TextChanged += new System.EventHandler(this.txtCPF_TextChanged);
            this.txtCPF.Leave += new System.EventHandler(this.txtCPF_Leave);
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(239, 134);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(27, 13);
            this.lblCpf.TabIndex = 26;
            this.lblCpf.Text = "CPF";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(128, 150);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(103, 20);
            this.txtCelular.TabIndex = 10;
            this.txtCelular.TextChanged += new System.EventHandler(this.txtCelular_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Celular";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(16, 150);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(106, 20);
            this.txtTelefone.TabIndex = 9;
            this.txtTelefone.TextChanged += new System.EventHandler(this.txtTelefone_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Telefone *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(716, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(719, 93);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(69, 21);
            this.cmbEstado.TabIndex = 8;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(295, 95);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(418, 20);
            this.txtCidade.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cidade";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(16, 95);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(273, 20);
            this.txtBairro.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Bairro";
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(295, 42);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(103, 20);
            this.txtCep.TabIndex = 3;
            this.txtCep.TextChanged += new System.EventHandler(this.txtCep_TextChanged);
            this.txtCep.Leave += new System.EventHandler(this.txtCep_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cep";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(404, 42);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(384, 20);
            this.txtEndereco.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Endereço";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(14, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(275, 20);
            this.txtNome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome *";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(641, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "* Preenchimento Obrigatório";
            // 
            // fVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.gpoDados);
            this.Controls.Add(this.label15);
            this.KeyPreview = true;
            this.Name = "fVendedores";
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.fVendedores_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fVendedores_KeyPress);
            this.gpoDados.ResumeLayout(false);
            this.gpoDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictNao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictOK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtComissao;
        private System.Windows.Forms.GroupBox gpoDados;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtRg;
        private System.Windows.Forms.Label lblRg;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictOK;
        private System.Windows.Forms.PictureBox pictNao;
    }
}