using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    public partial class CadUsuario : Form
    {
        public int idFunc;
        public bool menuStrip = false;
        public int usuario;
        public home inicio;
        public string verFuncionario = "";

        public CadUsuario()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            txtSenha.PasswordChar = '*';
            txtSenha2.PasswordChar = '*';
        }

        public CadUsuario(int idFunc, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.idFunc = idFunc;
            this.inicio = inicio;
        }

        public CadUsuario(int idFunc, bool menuStrip, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.idFunc = idFunc;
            this.menuStrip = menuStrip;
        }

        public CadUsuario(int idFunc, bool menuStrip, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.idFunc = idFunc;
            this.menuStrip = menuStrip;
            this.usuario = usuario;
        }

        public CadUsuario(int idFunc, string verFuncionario, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.idFunc = idFunc;
            this.verFuncionario = verFuncionario;
            this.usuario = usuario;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar1 = validacaoGeral.validaSenha(this);
            bool checar2 = validacaoGeral.checarUsuarioNoBanco(this);
            bool checar3 = validacaoGeral.checarVazio(this);

            if(checar1 && checar2 && checar3)
            {
                CrudUsuario user = new CrudUsuario();
                user.cadastrar(txtUser, txtSenha2, idFunc);

                if (menuStrip)
                {
                    VerFuncionarios func = new VerFuncionarios(usuario, inicio);
                    func.MdiParent = inicio;
                    func.Show();
                }

                this.Dispose();
            }
            else if(!checar3)
            {
                MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else if (!checar1)
            {
                MessageBox.Show("As senhas estão diferentes", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else if (!checar2)
            {
                MessageBox.Show("Esse usuário já existe", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtUser.Focus();
            }
            
        }

        private void CadUsuario_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);
        }

        private void CadUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
