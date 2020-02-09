namespace NovaCupece
{
    partial class Locacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Locacao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpLocacao = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.mtxDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSelecionarFiador = new System.Windows.Forms.Button();
            this.txtFiador = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mtxDataLocacao = new System.Windows.Forms.MaskedTextBox();
            this.btnSelecionarLocatario = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorLocacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocatario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbLocacao = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.dtpLocacao);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.mtxDataFinal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnSelecionarFiador);
            this.panel1.Controls.Add(this.txtFiador);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.mtxDataLocacao);
            this.panel1.Controls.Add(this.btnSelecionarLocatario);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtValorLocacao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtLocador);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtLocatario);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbLocacao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(-2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 755);
            this.panel1.TabIndex = 3;
            // 
            // dtpLocacao
            // 
            this.dtpLocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLocacao.Location = new System.Drawing.Point(487, 569);
            this.dtpLocacao.Name = "dtpLocacao";
            this.dtpLocacao.Size = new System.Drawing.Size(299, 29);
            this.dtpLocacao.TabIndex = 76;
            this.dtpLocacao.ValueChanged += new System.EventHandler(this.dtpLocacao_ValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(92, 691);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 45);
            this.btnOk.TabIndex = 75;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // mtxDataFinal
            // 
            this.mtxDataFinal.Enabled = false;
            this.mtxDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxDataFinal.Location = new System.Drawing.Point(291, 569);
            this.mtxDataFinal.Mask = "00/00/0000";
            this.mtxDataFinal.Name = "mtxDataFinal";
            this.mtxDataFinal.Size = new System.Drawing.Size(190, 31);
            this.mtxDataFinal.TabIndex = 74;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(96, 575);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 25);
            this.label9.TabIndex = 73;
            this.label9.Text = "Data Final:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.BackgroundImage")));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalvar.Location = new System.Drawing.Point(633, 694);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(126, 42);
            this.btnSalvar.TabIndex = 72;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnSelecionarFiador
            // 
            this.btnSelecionarFiador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelecionarFiador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelecionarFiador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarFiador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarFiador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarFiador.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelecionarFiador.Location = new System.Drawing.Point(633, 633);
            this.btnSelecionarFiador.Name = "btnSelecionarFiador";
            this.btnSelecionarFiador.Size = new System.Drawing.Size(139, 31);
            this.btnSelecionarFiador.TabIndex = 71;
            this.btnSelecionarFiador.Text = "Selecionar";
            this.btnSelecionarFiador.UseVisualStyleBackColor = false;
            this.btnSelecionarFiador.Click += new System.EventHandler(this.btnSelecionarFiador_Click);
            // 
            // txtFiador
            // 
            this.txtFiador.Enabled = false;
            this.txtFiador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiador.Location = new System.Drawing.Point(291, 633);
            this.txtFiador.Name = "txtFiador";
            this.txtFiador.Size = new System.Drawing.Size(336, 31);
            this.txtFiador.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(96, 639);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 25);
            this.label7.TabIndex = 69;
            this.label7.Text = "Fiador:";
            // 
            // mtxDataLocacao
            // 
            this.mtxDataLocacao.Enabled = false;
            this.mtxDataLocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxDataLocacao.Location = new System.Drawing.Point(291, 507);
            this.mtxDataLocacao.Mask = "00/00/0000";
            this.mtxDataLocacao.Name = "mtxDataLocacao";
            this.mtxDataLocacao.Size = new System.Drawing.Size(190, 31);
            this.mtxDataLocacao.TabIndex = 68;
            // 
            // btnSelecionarLocatario
            // 
            this.btnSelecionarLocatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelecionarLocatario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelecionarLocatario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarLocatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarLocatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarLocatario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelecionarLocatario.Location = new System.Drawing.Point(633, 379);
            this.btnSelecionarLocatario.Name = "btnSelecionarLocatario";
            this.btnSelecionarLocatario.Size = new System.Drawing.Size(139, 31);
            this.btnSelecionarLocatario.TabIndex = 67;
            this.btnSelecionarLocatario.Text = "Selecionar";
            this.btnSelecionarLocatario.UseVisualStyleBackColor = false;
            this.btnSelecionarLocatario.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(96, 513);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 25);
            this.label6.TabIndex = 62;
            this.label6.Text = "Data da Locação:";
            // 
            // txtValorLocacao
            // 
            this.txtValorLocacao.Enabled = false;
            this.txtValorLocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorLocacao.Location = new System.Drawing.Point(291, 443);
            this.txtValorLocacao.MaxLength = 100;
            this.txtValorLocacao.Name = "txtValorLocacao";
            this.txtValorLocacao.Size = new System.Drawing.Size(190, 31);
            this.txtValorLocacao.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(96, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 25);
            this.label5.TabIndex = 60;
            this.label5.Text = "Valor da Locação:";
            // 
            // txtLocador
            // 
            this.txtLocador.Enabled = false;
            this.txtLocador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocador.Location = new System.Drawing.Point(291, 311);
            this.txtLocador.Name = "txtLocador";
            this.txtLocador.Size = new System.Drawing.Size(190, 31);
            this.txtLocador.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(96, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 58;
            this.label3.Text = "Locador:";
            // 
            // txtLocatario
            // 
            this.txtLocatario.Enabled = false;
            this.txtLocatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocatario.Location = new System.Drawing.Point(291, 379);
            this.txtLocatario.Name = "txtLocatario";
            this.txtLocatario.Size = new System.Drawing.Size(336, 31);
            this.txtLocatario.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(96, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 56;
            this.label4.Text = "Locatário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(367, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 25);
            this.label2.TabIndex = 55;
            this.label2.Text = "Endereço do Imóvel";
            // 
            // pbLocacao
            // 
            this.pbLocacao.Location = new System.Drawing.Point(321, 70);
            this.pbLocacao.Name = "pbLocacao";
            this.pbLocacao.Size = new System.Drawing.Size(226, 165);
            this.pbLocacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLocacao.TabIndex = 54;
            this.pbLocacao.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(221, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 53;
            this.label1.Text = "Imóvel:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(353, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 33);
            this.label8.TabIndex = 52;
            this.label8.Text = "Locação";
            // 
            // Locacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Locacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locacao";
            this.Load += new System.EventHandler(this.Locacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox pbLocacao;
        public System.Windows.Forms.TextBox txtValorLocacao;
        public System.Windows.Forms.TextBox txtLocador;
        public System.Windows.Forms.TextBox txtLocatario;
        public System.Windows.Forms.Button btnSelecionarLocatario;
        public System.Windows.Forms.TextBox txtFiador;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnSelecionarFiador;
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.MaskedTextBox mtxDataLocacao;
        public System.Windows.Forms.MaskedTextBox mtxDataFinal;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DateTimePicker dtpLocacao;
    }
}