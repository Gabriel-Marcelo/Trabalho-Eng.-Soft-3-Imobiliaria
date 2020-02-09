using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovaCupece.Primitivas;
using NovaCupece.Classes_Adicionais;
using System.IO;

namespace NovaCupece
{
    public partial class cadLocImov2 : Form
    {
        public int usuario;
        public int id_locador;
        public string picpath;
        public home inicio;

        public cadLocImov2()
        {
            InitializeComponent();
            
        }

        public cadLocImov2(home inicio)
        {
            InitializeComponent();
           // this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public cadLocImov2(int usuario, int id_locador, home inicio)
        {
            InitializeComponent();
            //this.MaximizeBox = false;

            this.usuario = usuario;
            this.id_locador = id_locador;
            this.inicio = inicio;
        }

        private void cadLocImov2_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);
        }

        //btnAvançar
        private void button1_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.imagemDescricaoVazios(this);
            if (checar)
            {
                CadLocImov3 fimCadImov = new CadLocImov3(this, usuario, id_locador, inicio);
                CrudLocador crudLocador = new CrudLocador(inicio);

                fimCadImov.txtLocador.Text = crudLocador.getNameById(id_locador);    
                this.Visible = false;
                fimCadImov.MdiParent = inicio;
                fimCadImov.Show();
            }
            else
            {
                MessageBox.Show("Verifique se a imagem foi escolhida e se o imóvel possui descrição", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image File(*.jpg)|*.jpg|(*.png)|*.png|All Files(*.*)|*.*";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picpath = open.FileName.ToString();
                pbImovel.ImageLocation = picpath;

            }
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //fimCadImov.txtLocador.Text = crudLocador.getNameById(id_locador);
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.checarCamposVaziosImoveisTela1(this);
            txtValorAluguel.Text = txtValorAluguel.Text.Replace(',', '.');
            bool checar9 = validacaoGeral.validaSalario(txtValorAluguel);
            if (checar && checar9)
            {
                CrudImovel crudImovel = new CrudImovel(inicio);

                byte[] imagemSalvar;
                try
                {
                    imagemSalvar = ConvertImageToBinary(pbImovel.Image);
                    String caminhoImagem = picpath;

                    bool ValCad = crudImovel.cadastrar(caminhoImagem, imagemSalvar, rtxtDescricao, txtRuaAvenida,
                        txtComplemento, cboUf, txtNumero, txtBairro, txtCidade,
                        txtValorAluguel, cboStatus, usuario, id_locador);
                    if (ValCad) this.Visible = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Escolha uma Imagem", "Mensagem", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                

               
            }
            else
            {
                if (!checar)
                    MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!checar9)
                    MessageBox.Show("O valor do aluguel foi preenchido incorretamente",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = (Char)0;
            }
        }

        private void txtValorAluguel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = (Char)0;
            }
        }
    }
}
