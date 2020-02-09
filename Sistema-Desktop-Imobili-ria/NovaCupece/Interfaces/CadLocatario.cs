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

namespace NovaCupece
{
    public partial class CadLocatario : Form
    {
        public string editar;

        public int usuario;
        public bool menuStrip = false;
        public home inicio;

        public string email = "";
        public string cpf = "";
        public string rg = "";

        public CadLocatario(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public CadLocatario()
        {
            InitializeComponent();
        }

        public CadLocatario(String editar, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.editar = editar;
            this.usuario = usuario;
            this.inicio = inicio;
        }

        public CadLocatario(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }
        public CadLocatario(int usuario, bool menuStrip, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.usuario = usuario;
            this.menuStrip = true;
            this.inicio = inicio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar1 = validacaoGeral.checarCamposVazios(this);
            bool checar2 = validacaoGeral.validaCpf(this);
            bool checar3 = validacaoGeral.validaRg(this);
            bool checar4 = validacaoGeral.validaEmail(this);
            bool checar5 = validacaoGeral.contarCamposCpf(mtxtCpf);
            bool checar6 = validacaoGeral.contarCamposRg(mtxtRg);
            bool checar7 = validacaoGeral.validaTelefone(mtxtTelRes1, mtxtTelRel2,
                mtxtTelCel1, mtxtTelCel2);
            bool checar8 = validacaoGeral.validaData(mtxtDataNasc);
            bool checar12 = validacaoGeral.checaEmail(this);
            
            if (editar == "Editar")
            {
                bool checar9 = validacaoGeral.contaCpf(this);
                bool checar10 = validacaoGeral.contaRg(this);
                bool checar11 = validacaoGeral.contaEmail(this);

                if(checar1 && checar5 && checar6 && checar7 && checar8 && checar9 && checar10 && checar11)
                {
                    CrudLocatario crudLoc = new CrudLocatario(inicio);
                    crudLoc.editar(this);
                }
                else
                {
                    if (!checar1)
                        MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                    else
                    {
                        if (!checar5)
                            MessageBox.Show("Preencha corretamente seu CPF", "Mensagem", MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
                        if (!checar6)
                            MessageBox.Show("Preencha corretamente seu RG", "Mensagem", MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
                        if (!checar7)
                            MessageBox.Show("Você deve registrar pelo menos 1 telefone completo", "Mensagem", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
                        
                        if (!checar8)
                            MessageBox.Show("Data de nascimento inválida. Você deve ser maior de 18 anos",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if(!checar9)
                            MessageBox.Show("Esse CPF já está cadastrado", "Mensagem", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
                        if(!checar10)
                            MessageBox.Show("Esse RG já está cadastrado", "Mensagem", MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
                        if (!checar11)
                            MessageBox.Show("Esse e-mail já está cadastrado", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                    }
                }
            }
            else if (checar1 && checar2 && checar3 && checar4 && checar5 && checar6 && checar7 && checar8 
                && checar12)
            {

                CrudLocatario crudLocatario = new CrudLocatario(inicio);
                bool valCad = crudLocatario.cadastrar(this);
                if (valCad)
                {
                    CadLocatario2 locatario2;

                    if (menuStrip)
                    {
                        locatario2 = new CadLocatario2(true, inicio);
                    }
                    else
                    {
                        locatario2 = new CadLocatario2(inicio);
                    }

                    this.Dispose();
                    locatario2.MdiParent = inicio;
                    locatario2.Show();
                }
                

            }
            else
            {
                if (!checar1)
                    MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
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
                    if (!checar12)
                        MessageBox.Show("Esse e-mail já está cadastrado, escolha outro", "Mensagem",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void CadLocatario_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);

            email = txtEmail.Text;
            cpf = mtxtCpf.Text;
            rg = mtxtRg.Text;

            if (editar == "Editar")
            {
                btnAvançar.Text = "Salvar";
                btnAvançar.BackgroundImage = null;
                btnAvançar.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void dtpLocatario_ValueChanged(object sender, EventArgs e)
        {
            mtxtDataNasc.Text = dtpLocatario.Value.ToString().Substring(0, 10);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }
    }
}
