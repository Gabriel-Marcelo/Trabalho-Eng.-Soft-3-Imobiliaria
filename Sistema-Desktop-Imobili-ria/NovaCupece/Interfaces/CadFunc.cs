using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    public partial class CadFunc : Form
    {
        public String verificar = "editar";
        public int linha;
        public DataGridView dataGrid;
        public String btnVerificar = "salvar";
        public bool menuStrip = false;
        public String cadFuncLogin = "";
        public int usuario;
        public home inicio;
        public string verFuncionario = "";

        public string rg = "";
        public string cpf = "";
        public string email = "";

        public CadFunc()
        {
            InitializeComponent();
        }

        public CadFunc(home inicio, string verFuncionario)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.verFuncionario = verFuncionario;
        }

        public CadFunc(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;
        }

        public CadFunc(String verificar, int linha, DataGridView dataGrid, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.verificar = verificar;
            this.linha = linha;
            this.dataGrid = dataGrid;
        }

        public CadFunc(bool menuStrip, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.menuStrip = menuStrip;
            
        }
        public CadFunc(bool menuStrip, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;

            this.menuStrip = menuStrip;
            this.usuario = usuario;
        }

        public CadFunc(String cadFuncLogin, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.cadFuncLogin = cadFuncLogin;
        }

        public CadFunc(String cadFuncLogin)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            
            this.cadFuncLogin = cadFuncLogin;
        }



        private void CadFunc_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);

            cpf = txtCpf.Text;
            rg = txtRg.Text;
            email = txtEmail.Text;
        }

        //btnSalvar
        private void button1_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar1 = validacaoGeral.checarCamposVazios(this);
            bool checar2 = validacaoGeral.validaCpf(this);
            bool checar3 = validacaoGeral.validaRg(this);
            bool checar4 = validacaoGeral.validaEmail(this);
            bool checar5 = validacaoGeral.contarCamposCpf(txtCpf);
            bool checar6 = validacaoGeral.contarCamposRg(txtRg);
            bool checar7 = validacaoGeral.validaTelefone(txtTelRes1, txtTelRes2,
                txtTelCel1, txtTelCel2);
            bool checar8 = validacaoGeral.validaData(txtDataNasc);
            txtSal.Text = txtSal.Text.Replace(',', '.');
            bool checar9 = validacaoGeral.validaSalario(txtSal);
            bool checar10 = validacaoGeral.checaEmail(this);

            if (checar1 && checar2 && checar3 && checar4 && checar5 && checar6 && checar7 && checar8 && 
                checar9 && checar10)
            {
                CrudFunc crudfunc = new CrudFunc(menuStrip, inicio);

                bool valCad = crudfunc.cadastrar(txtNome, txtCpf, txtRg, txtDataNasc, txtTelRes1, txtTelRes2, txtTelCel1, txtTelCel2,
                txtEmail, txtCargo, txtSal, txtEnd);
                if (valCad)
                {
                    crudfunc.ultimoIdCadastro = crudfunc.guardaIdCadastro(this.txtNome.Text, this.txtEmail.Text);

                    if (menuStrip)
                    {
                        this.Dispose();
                        CadUsuario user = new CadUsuario(crudfunc.ultimoIdCadastro, menuStrip, usuario, inicio);
                        user.MdiParent = inicio;
                        user.Show();
                    }
                    else if (cadFuncLogin == "Login")
                    {
                        this.Dispose();
                        CadUsuario user = new CadUsuario(crudfunc.ultimoIdCadastro, inicio);
                        user.Visible = true;

                    }
                    else if (verFuncionario == "verFuncionarios")
                    {
                        this.Dispose();
                        CadUsuario user = new CadUsuario(crudfunc.ultimoIdCadastro, "verFuncionarios", usuario,
                            inicio);
                        user.MdiParent = inicio;
                        user.Show();
                    }
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
                    if (!checar9)
                        MessageBox.Show("Caracteres inválidos no campo 'Salário'", "Mensagem",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!checar10)
                        MessageBox.Show("Esse e-mail já está cadastrado, escolha outro", "Mensagem",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        //btnEditar
        private void button1_Click_1(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar1 = validacaoGeral.checarCamposVazios(this);
            bool checar2 = validacaoGeral.contaCpf(this);
            bool checar3 = validacaoGeral.contaRg(this);
            bool checar4 = validacaoGeral.contaEmail(this);
            bool checar5 = validacaoGeral.contarCamposCpf(txtCpf);
            bool checar6 = validacaoGeral.contarCamposRg(txtRg);
            bool checar7 = validacaoGeral.validaTelefone(txtTelRes1, txtTelRes2,
                txtTelCel1, txtTelCel2);
            bool checar8 = validacaoGeral.validaData(txtDataNasc);
            txtSal.Text = txtSal.Text.Replace(',', '.');
            bool checar9 = validacaoGeral.validaSalario(txtSal);
          

            if (checar1 && checar2 && checar3 && checar4 && checar5 && checar6 && checar7 && checar8 && 
                checar9)
            {
                CrudFunc crudfunc = new CrudFunc(this, inicio);

                crudfunc.editar(linha, dataGrid, txtNome, txtCpf, txtRg, txtDataNasc, txtTelRes1, txtTelRes2, txtTelCel1, txtTelCel2,
                txtEmail, txtCargo, txtSal, txtEnd);

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
                        MessageBox.Show("Esse E-mail já está cadastrado", "Mensagem", MessageBoxButtons.OK,
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
                        MessageBox.Show("Caracteres inválidos no campo 'Salário'", "Mensagem",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

            }
        }


        

        private void dtpFuncionario_ValueChanged(object sender, EventArgs e)
        {
            txtDataNasc.Text = dtpFuncionario.Value.ToString().Substring(0, 10);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }

        private void txtSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = (Char)0;
            }
        }
    }
}
