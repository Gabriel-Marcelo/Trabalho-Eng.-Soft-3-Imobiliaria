namespace NovaCupece
{
    partial class VerAtendimentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerAtendimentos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvAtendimentos = new System.Windows.Forms.DataGridView();
            this.gbAtendimento = new System.Windows.Forms.GroupBox();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.rbDecrescente = new System.Windows.Forms.RadioButton();
            this.rbCrescente = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtendimentos)).BeginInit();
            this.gbAtendimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dgvAtendimentos);
            this.panel1.Controls.Add(this.gbAtendimento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 639);
            this.panel1.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(371, 582);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 42);
            this.button6.TabIndex = 53;
            this.button6.Text = "Editar";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(635, 582);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 42);
            this.button5.TabIndex = 52;
            this.button5.Text = "Deletar";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(80, 582);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 42);
            this.button4.TabIndex = 51;
            this.button4.Text = "Cadastrar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(647, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 50;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvAtendimentos
            // 
            this.dgvAtendimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtendimentos.Location = new System.Drawing.Point(33, 61);
            this.dgvAtendimentos.Name = "dgvAtendimentos";
            this.dgvAtendimentos.Size = new System.Drawing.Size(721, 331);
            this.dgvAtendimentos.TabIndex = 49;
            this.dgvAtendimentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAtendimentos_CellClick);
            // 
            // gbAtendimento
            // 
            this.gbAtendimento.Controls.Add(this.btnDesfazer);
            this.gbAtendimento.Controls.Add(this.btnOrdenar);
            this.gbAtendimento.Controls.Add(this.rbDecrescente);
            this.gbAtendimento.Controls.Add(this.rbCrescente);
            this.gbAtendimento.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAtendimento.Location = new System.Drawing.Point(33, 398);
            this.gbAtendimento.Name = "gbAtendimento";
            this.gbAtendimento.Size = new System.Drawing.Size(365, 166);
            this.gbAtendimento.TabIndex = 48;
            this.gbAtendimento.TabStop = false;
            this.gbAtendimento.Text = "Ordenar Atendimentos em Ordem Alfabética";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(312, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Atendimentos";
            // 
            // VerAtendimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 633);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerAtendimentos";
            this.Text = "VerAtendimentos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VerAtendimentos_FormClosed);
            this.Load += new System.EventHandler(this.VerAtendimentos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtendimentos)).EndInit();
            this.gbAtendimento.ResumeLayout(false);
            this.gbAtendimento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.GroupBox gbAtendimento;
        public System.Windows.Forms.Button btnDesfazer;
        public System.Windows.Forms.Button btnOrdenar;
        public System.Windows.Forms.RadioButton rbDecrescente;
        public System.Windows.Forms.RadioButton rbCrescente;
        public System.Windows.Forms.DataGridView dgvAtendimentos;
    }
}