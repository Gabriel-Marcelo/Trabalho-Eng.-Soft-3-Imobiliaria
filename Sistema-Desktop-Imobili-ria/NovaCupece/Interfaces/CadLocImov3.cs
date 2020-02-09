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
using System.IO;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    public partial class CadLocImov3 : Form
    {
        public cadLocImov2 imovel1;
        public int usuario;
        public int id_locador;
        public home inicio;

        public CadLocImov3(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.cboStatus.SelectedIndex = 1;
            this.inicio = inicio;
        }
        public CadLocImov3(cadLocImov2 imovel1, int usuario, int id_locador, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.imovel1 = imovel1;
            this.usuario = usuario;
            this.id_locador = id_locador;
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
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.checarCamposVaziosImoveisTela2(this);
            if (checar)
            {
                CrudImovel crudImovel = new CrudImovel(inicio);

                byte[] imagemSalvar = ConvertImageToBinary(imovel1.pbImovel.Image);
                String caminhoImagem = imovel1.picpath;

                crudImovel.cadastrar(caminhoImagem, imagemSalvar, imovel1.rtxtDescricao, txtRuaAvenida,
                    txtComplemento, cboUf, txtNumero, txtBairro, txtCidade,
                    txtValorAluguel, cboStatus, usuario, id_locador);

                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            //validacaoGeral.limpar(this);
        }

        private void CadLocImov3_Load(object sender, EventArgs e)
        {

            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);
            cboStatus.SelectedItem = cboStatus.Items[1];
        }

        private void txtValorAluguel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = (Char)0;
               
            }
        }

        private void cboUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
