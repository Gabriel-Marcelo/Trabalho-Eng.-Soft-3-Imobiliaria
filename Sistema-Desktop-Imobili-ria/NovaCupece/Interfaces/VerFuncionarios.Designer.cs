namespace NovaCupece
{
    partial class VerFuncionarios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerFuncionarios));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.gbFuncionarios = new System.Windows.Forms.GroupBox();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.rbDecrescente = new System.Windows.Forms.RadioButton();
            this.rbCrescente = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.gbFuncionarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnCadastrar);
            this.panel1.Controls.Add(this.gbFuncionarios);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(-5, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 639);
            this.panel1.TabIndex = 1;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCadastrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCadastrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.BackgroundImage")));
            this.btnCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCadastrar.Location = new System.Drawing.Point(603, 580);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(134, 42);
            this.btnCadastrar.TabIndex = 47;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.button4_Click);
            // 
            // gbFuncionarios
            // 
            this.gbFuncionarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFuncionarios.Controls.Add(this.btnDesfazer);
            this.gbFuncionarios.Controls.Add(this.btnOrdenar);
            this.gbFuncionarios.Controls.Add(this.rbDecrescente);
            this.gbFuncionarios.Controls.Add(this.rbCrescente);
            this.gbFuncionarios.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFuncionarios.Location = new System.Drawing.Point(40, 408);
            this.gbFuncionarios.Name = "gbFuncionarios";
            this.gbFuncionarios.Size = new System.Drawing.Size(365, 166);
            this.gbFuncionarios.TabIndex = 46;
            this.gbFuncionarios.TabStop = false;
            this.gbFuncionarios.Text = "Ordenar Funcionários em Ordem Alfabética";
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.BackColor = System.Drawing.Color.Black;
            this.btnDesfazer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDesfazer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesfazer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesfazer.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesfazer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDesfazer.Location = new System.Drawing.Point(232, 124);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(110, 30);
            this.btnDesfazer.TabIndex = 37;
            this.btnDesfazer.Text = "Desfazer";
            this.btnDesfazer.UseVisualStyleBackColor = false;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.BackColor = System.Drawing.Color.Black;
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
            // rbDecrescente
            // 
            this.rbDecrescente.AutoSize = true;
            this.rbDecrescente.Location = new System.Drawing.Point(17, 80);
            this.rbDecrescente.Name = "rbDecrescente";
            this.rbDecrescente.Size = new System.Drawing.Size(116, 26);
            this.rbDecrescente.TabIndex = 1;
            this.rbDecrescente.TabStop = true;
            this.rbDecrescente.Text = "Descrescente";
            this.rbDecrescente.UseVisualStyleBackColor = true;
            // 
            // rbCrescente
            // 
            this.rbCrescente.AutoSize = true;
            this.rbCrescente.Location = new System.Drawing.Point(17, 44);
            this.rbCrescente.Name = "rbCrescente";
            this.rbCrescente.Size = new System.Drawing.Size(93, 26);
            this.rbCrescente.TabIndex = 0;
            this.rbCrescente.TabStop = true;
            this.rbCrescente.Text = "Crescente";
            this.rbCrescente.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(134, 582);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 42);
            this.button1.TabIndex = 33;
            this.button1.Text = "Deletar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(310, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Funcionários";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(721, 331);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAtualizar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.Red;
            this.btnAtualizar.Location = new System.Drawing.Point(654, 397);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(107, 42);
            this.btnAtualizar.TabIndex = 48;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(390, 580);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 42);
            this.button4.TabIndex = 49;
            this.button4.Text = "Editar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // VerFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 633);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerFuncionarios";
            this.Text = "VerFuncionarios";
            this.Deactivate += new System.EventHandler(this.VerFuncionarios_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerFuncionarios_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VerFuncionarios_FormClosed);
            this.Load += new System.EventHandler(this.VerFuncionarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbFuncionarios.ResumeLayout(false);
            this.gbFuncionarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.GroupBox gbFuncionarios;
        public System.Windows.Forms.Button btnDesfazer;
        public System.Windows.Forms.Button btnOrdenar;
        public System.Windows.Forms.RadioButton rbDecrescente;
        public System.Windows.Forms.RadioButton rbCrescente;
        public System.Windows.Forms.DataGridView dataGridView1;
        //private DataSet1 dataSet1;
    }
}