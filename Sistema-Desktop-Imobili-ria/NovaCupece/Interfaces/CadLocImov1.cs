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
using System.Data;
using System.Data.SqlClient;
using NovaCupece.Classes_Adicionais;
using NovaCupece.Primitivas;

namespace NovaCupece
{
    public partial class CadLocImov1 : Form
    {
        public int usuario;
        public int id_locador;
        public string editar;
        public home inicio;

        public string email = "";
        public string cpf = "";
        public string rg = "";

        public CadLocImov1()
        {
            InitializeComponent();
        }

        public CadLocImov1(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public CadLocImov1(string editar, int id_Locador, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.editar = editar;
            this.id_locador = id_locador;
        }

        public CadLocImov1(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }

        //btnAvançar
        private void button1_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar1 = validacaoGeral.checarCamposVazios(this);
            bool checar2 = validacaoGeral.validaCpf(this);
            bool checar3 = validacaoGeral.validaRg(this);
            bool checar4 = validacaoGeral.validaEmail(this);
            bool checar5 = validacaoGeral.contarCamposCpf(mtxtCpf);
            bool checar6 = validacaoGeral.contarCamposRg(mtxtRg);
            bool checar7 = validacaoGeral.validaTelefone(mtxtTelRes1, mtxtTelRes2,
                mtxtTelCel1, mtxtTelCel2);
            bool checar8 = validacaoGeral.validaData(mtxtDataNasc);
            bool checar9 = validacaoGeral.checaEmail(this);

            if (checar1 && checar2 && checar3 && checar4 && checar5 && checar6 && checar7 && checar8 
                && checar9)
            {
                CrudLocador crudLocador = new CrudLocador(inicio);

                bool ValCad = crudLocador.cadastrar(txtNome, mtxtCpf, mtxtRg, mtxtDataNasc, mtxtTelRes1, mtxtTelRes2, mtxtTelCel1, mtxtTelCel2,
                txtEmail, txtEnd);
                if (ValCad)
                {
                    int id_Locador = crudLocador.getId(mtxtCpf);

                    cadLocImov2 imovel = new cadLocImov2(usuario, id_Locador, inicio);
                    imovel.txtLocador.Text = crudLocador.getNameById(id_Locador);
                    imovel.cboStatus.SelectedItem = imovel.cboStatus.Items[1];
                    imovel.cboUf.SelectedItem = imovel.cboUf.Items[24];
                    this.Visible = false;

                    imovel.MdiParent = inicio;
                    imovel.Show();
                }
                
            }
            else
            {
                if (!checar2)
                    MessageBox.Show("Esse CPF já está cadastrado", "Mensagem", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                if (!checar3)
                    MessageBox.Show("Esse RG já está cadastrado", "Mensagem", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                if (!checar4)
                    MessageBox.Show("Esse E-mail está incorreto", "Mensagem", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                if (!checar5)
                    MessageBox.Show("Preencha corretamente seu CPF", "Mensagem", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                if (!checar6)
                    MessageBox.Show("Preencha corretamente seu RG", "Mensagem", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                if (!checar7)
                {
                    MessageBox.Show("Você deve registrar pelo menos 1 telefone completo", "Mensagem", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                if (!checar8)
                    MessageBox.Show("Data de nascimento inválida. Você deve ser maior de 18 anos",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (!checar9)
                    MessageBox.Show("Esse e-mail já está cadastrado, escolha outro",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }

        private void CadLocImov1_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);

            email = txtEmail.Text;
            cpf = mtxtCpf.Text;
            rg = mtxtRg.Text;
        }

        private void dtpLocador_ValueChanged(object sender, EventArgs e)
        {
            mtxtDataNasc.Text = dtpLocador.Value.ToString().Substring(0, 10);
        }
    }
}
