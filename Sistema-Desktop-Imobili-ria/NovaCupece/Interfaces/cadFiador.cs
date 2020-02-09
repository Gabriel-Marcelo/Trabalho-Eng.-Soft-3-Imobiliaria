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
    public partial class cadFiador : Form
    {
        public int usuario;
        public string editar;
        public int id_Fiador;
        public home inicio;

        public string email = "";
        public string cpf = "";
        public string rg = "";

        public cadFiador()
        {
            InitializeComponent();
        }

        public cadFiador(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;
        }

        public cadFiador(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.usuario = usuario;
            this.inicio = inicio;
        }

        public cadFiador(int usuario, string editar, int id_Fiador, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.usuario = usuario;
            this.editar = editar;
            this.id_Fiador = id_Fiador;
            this.inicio = inicio;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
            bool checar12 = validacaoGeral.validaSalario(txtValorFianca);
            txtValorFianca.Text = txtValorFianca.Text.Replace(',', '.');
            bool checar13 = validacaoGeral.checaEmail(this);

            if(editar == "editar")
            {
                bool checar9 = validacaoGeral.contaCpf(this);
                bool checar10 = validacaoGeral.contaRg(this);
                bool checar11 = validacaoGeral.contaEmail(this);
                if(checar1 && checar5 && checar6 && checar7 && checar8 && checar9 && checar10 && checar11 &&
                    checar12)
                {
                    CrudFiador fiador = new CrudFiador(inicio);
                    fiador.editar(this);
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
                        {
                            MessageBox.Show("Você deve registrar pelo menos 1 telefone completo", "Mensagem", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
                        }
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
                        if (!checar12)
                            MessageBox.Show("Caracteres inválidos no campo 'Salário'", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        
                    }
                }
            }
            else if (checar1 && checar2 && checar3 && checar4 && checar5 && checar6 && checar7 && checar8 
                && checar12 && checar13)
            {

                CrudFiador crudFiador = new CrudFiador(inicio);
                crudFiador.cadastrar(this);
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
                        MessageBox.Show("Caracteres inválidos no campo 'Valor Fiança'",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!checar13)
                        MessageBox.Show("Esse e-mail já está cadastrado, escolha outro", "Mensagem",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            
            


        }

        private void dtData_ValueChanged(object sender, EventArgs e)
        {
            mtxtDataNasc.Text = dtData.Value.ToString().Substring(0, 10);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }

        private void cadFiador_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);

            email = txtEmail.Text;
            cpf = mtxtCpf.Text;
            rg = mtxtRg.Text;
        }

        private void txtValorFianca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = (Char)0;
            }
        }
    }
}
