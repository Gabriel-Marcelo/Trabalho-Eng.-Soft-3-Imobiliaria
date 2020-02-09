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
    public partial class frmLogin : Form
    {
        public home inicio;

        public frmLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            

        }

        public frmLogin(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //btnLogar
        private void button1_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar1 = validacaoGeral.checarVazio(this);
            bool checar2 = validacaoGeral.userCadastrado(this);

            if (checar1 && !checar2)
            {
                LoginSistema sistema = new LoginSistema();

                int checar = sistema.logar(txtUsuario, txtSenha);


                int idUser = sistema.getId(txtUsuario);

                if (checar == 1)
                {
                    home logar = new home(idUser);
                    logar.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha inválidos ou usuário não existe!",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else if (!checar1)
            {
                MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadFunc cadfunc = new CadFunc("Login");
            cadfunc.btnEditar.Visible = false;
            cadfunc.Visible = true;
            
        }
    }
}
