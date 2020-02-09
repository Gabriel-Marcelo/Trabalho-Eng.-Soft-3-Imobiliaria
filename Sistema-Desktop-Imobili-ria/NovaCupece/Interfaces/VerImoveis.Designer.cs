namespace NovaCupece
{
    partial class VerImoveis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerImoveis));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLocar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDetalhe = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gbMostrar = new System.Windows.Forms.GroupBox();
            this.btnDesfazer2 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rbDisponiveis = new System.Windows.Forms.RadioButton();
            this.rbAlugados = new System.Windows.Forms.RadioButton();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.gbImoveis = new System.Windows.Forms.GroupBox();
            this.btnDesfazer1 = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.rbEstado = new System.Windows.Forms.RadioButton();
            this.rbCidade = new System.Windows.Forms.RadioButton();
            this.dgvImovel = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbMostrar.SuspendLayout();
            this.gbImoveis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImovel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnLocar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDetalhe);
            this.panel1.Controls.Add(this.btnDeletar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.gbMostrar);
            this.panel1.Controls.Add(this.btnCadastrar);
            this.panel1.Controls.Add(this.gbImoveis);
            this.panel1.Controls.Add(this.dgvImovel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(-2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 760);
            this.panel1.TabIndex = 2;
            // 
            // btnLocar
            // 
            this.btnLocar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLocar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLocar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLocar.Location = new System.Drawing.Point(336, 409);
            this.btnLocar.Name = "btnLocar";
            this.btnLocar.Size = new System.Drawing.Size(154, 42);
            this.btnLocar.TabIndex = 56;
            this.btnLocar.Text = "Locar Imóvel";
            this.btnLocar.UseVisualStyleBackColor = false;
            this.btnLocar.Click += new System.EventHandler(this.btnLocar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(653, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 55;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDetalhe
            // 
            this.btnDetalhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDetalhe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalhe.BackgroundImage")));
            this.btnDetalhe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetalhe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalhe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalhe.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalhe.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDetalhe.Location = new System.Drawing.Point(39, 409);
            this.btnDetalhe.Name = "btnDetalhe";
            this.btnDetalhe.Size = new System.Drawing.Size(136, 42);
            this.btnDetalhe.TabIndex = 54;
            this.btnDetalhe.Text = "Ver detalhe";
            this.btnDetalhe.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDetalhe.UseVisualStyleBackColor = false;
            this.btnDetalhe.Click += new System.EventHandler(this.btnDetalhe_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDeletar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletar.BackgroundImage")));
            this.btnDeletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeletar.Location = new System.Drawing.Point(72, 681);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(121, 42);
            this.btnDeletar.TabIndex = 53;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditar.Location = new System.Drawing.Point(308, 681);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(107, 42);
            this.btnEditar.TabIndex = 52;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // gbMostrar
            // 
            this.gbMostrar.Controls.Add(this.btnDesfazer2);
            this.gbMostrar.Controls.Add(this.btnOk);
            this.gbMostrar.Controls.Add(this.rbDisponiveis);
            this.gbMostrar.Controls.Add(this.rbAlugados);
            this.gbMostrar.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMostrar.Location = new System.Drawing.Point(437, 490);
            this.gbMostrar.Name = "gbMostrar";
            this.gbMostrar.Size = new System.Drawing.Size(365, 166);
            this.gbMostrar.TabIndex = 51;
            this.gbMostrar.TabStop = false;
            this.gbMostrar.Text = "Mostrar";
            // 
            // btnDesfazer2
            // 
            this.btnDesfazer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDesfazer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDesfazer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesfazer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesfazer2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesfazer2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDesfazer2.Location = new System.Drawing.Point(232, 124);
            this.btnDesfazer2.Name = "btnDesfazer2";
            this.btnDesfazer2.Size = new System.Drawing.Size(110, 30);
            this.btnDesfazer2.TabIndex = 37;
            this.btnDesfazer2.Text = "Desfazer";
            this.btnDesfazer2.UseVisualStyleBackColor = false;
            this.btnDesfazer2.Click += new System.EventHandler(this.btnDesfazer2_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(17, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 30);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rbDisponiveis
            // 
            this.rbDisponiveis.AutoSize = true;
            this.rbDisponiveis.Location = new System.Drawing.Point(17, 80);
            this.rbDisponiveis.Name = "rbDisponiveis";
            this.rbDisponiveis.Size = new System.Drawing.Size(108, 26);
            this.rbDisponiveis.TabIndex = 1;
            this.rbDisponiveis.TabStop = true;
            this.rbDisponiveis.Text = "Disponíveis";
            this.rbDisponiveis.UseVisualStyleBackColor = true;
            // 
            // rbAlugados
            // 
            this.rbAlugados.AutoSize = true;
            this.rbAlugados.Location = new System.Drawing.Point(17, 44);
            this.rbAlugados.Name = "rbAlugados";
            this.rbAlugados.Size = new System.Drawing.Size(92, 26);
            this.rbAlugados.TabIndex = 0;
            this.rbAlugados.TabStop = true;
            this.rbAlugados.Text = "Alugados";
            this.rbAlugados.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCadastrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.BackgroundImage")));
            this.btnCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCadastrar.Location = new System.Drawing.Point(545, 682);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(135, 42);
            this.btnCadastrar.TabIndex = 50;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // gbImoveis
            // 
            this.gbImoveis.Controls.Add(this.btnDesfazer1);
            this.gbImoveis.Controls.Add(this.btnOrdenar);
            this.gbImoveis.Controls.Add(this.rbEstado);
            this.gbImoveis.Controls.Add(this.rbCidade);
            this.gbImoveis.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbImoveis.Location = new System.Drawing.Point(15, 490);
            this.gbImoveis.Name = "gbImoveis";
            this.gbImoveis.Size = new System.Drawing.Size(365, 166);
            this.gbImoveis.TabIndex = 47;
            this.gbImoveis.TabStop = false;
            this.gbImoveis.Text = "Ordenar por:";
            // 
            // btnDesfazer1
            // 
            this.btnDesfazer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDesfazer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDesfazer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesfazer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesfazer1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesfazer1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDesfazer1.Location = new System.Drawing.Point(232, 124);
            this.btnDesfazer1.Name = "btnDesfazer1";
            this.btnDesfazer1.Size = new System.Drawing.Size(110, 30);
            this.btnDesfazer1.TabIndex = 37;
            this.btnDesfazer1.Text = "Desfazer";
            this.btnDesfazer1.UseVisualStyleBackColor = false;
            this.btnDesfazer1.Click += new System.EventHandler(this.btnDesfazer1_Click);
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOrdenar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOrdenar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrdenar.Location = new System.Drawing.Point(17, 124);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(110, 30);
            this.btnOrdenar.TabIndex = 36;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = false;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // rbEstado
            // 
            this.rbEstado.AutoSize = true;
            this.rbEstado.Location = new System.Drawing.Point(17, 80);
            this.rbEstado.Name = "rbEstado";
            this.rbEstado.Size = new System.Drawing.Size(76, 26);
            this.rbEstado.TabIndex = 1;
            this.rbEstado.TabStop = true;
            this.rbEstado.Text = "Estado";
            this.rbEstado.UseVisualStyleBackColor = true;
            // 
            // rbCidade
            // 
            this.rbCidade.AutoSize = true;
            this.rbCidade.Location = new System.Drawing.Point(17, 44);
            this.rbCidade.Name = "rbCidade";
            this.rbCidade.Size = new System.Drawing.Size(74, 26);
            this.rbCidade.TabIndex = 0;
            this.rbCidade.TabStop = true;
            this.rbCidade.Text = "Cidade";
            this.rbCidade.UseVisualStyleBackColor = true;
            // 
            // dgvImovel
            // 
            this.dgvImovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImovel.Location = new System.Drawing.Point(39, 72);
            this.dgvImovel.Name = "dgvImovel";
            this.dgvImovel.Size = new System.Drawing.Size(721, 331);
            this.dgvImovel.TabIndex = 24;
            this.dgvImovel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImovel_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(320, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 36);
            this.label8.TabIndex = 23;
            this.label8.Text = "Imóveis";
            // 
            // VerImoveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 754);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerImoveis";
            this.Text = "VerImoveis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerImoveis_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VerImoveis_FormClosed);
            this.Load += new System.EventHandler(this.VerImoveis_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbMostrar.ResumeLayout(false);
            this.gbMostrar.PerformLayout();
            this.gbImoveis.ResumeLayout(false);
            this.gbImoveis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImovel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnDetalhe;
        public System.Windows.Forms.DataGridView dgvImovel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLocar;
        public System.Windows.Forms.GroupBox gbImoveis;
        public System.Windows.Forms.Button btnDesfazer1;
        public System.Windows.Forms.Button btnOrdenar;
        public System.Windows.Forms.RadioButton rbEstado;
        public System.Windows.Forms.RadioButton rbCidade;
        public System.Windows.Forms.GroupBox gbMostrar;
        public System.Windows.Forms.Button btnDesfazer2;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.RadioButton rbDisponiveis;
        public System.Windows.Forms.RadioButton rbAlugados;
    }
}