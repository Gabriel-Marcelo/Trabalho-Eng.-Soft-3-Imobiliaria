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

namespace NovaCupece
{
    public partial class home : Form
    {
        public int usuario;
        

        public home()
        {
            InitializeComponent();
            
            
        }

        public home(int usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            
        }

        private void home_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
           
        }

        private void visualizarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VerImoveis verImoveis = new VerImoveis(usuario, this);
            verImoveis.MdiParent = this;
            verImoveis.Show();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadFunc cadFunc = new CadFunc(true, usuario, this);
            cadFunc.btnEditar.Visible = false;
            cadFunc.MdiParent = this;
            cadFunc.Show();
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CadLocImov1 locador = new CadLocImov1(usuario, this);
            locador.MdiParent = this;
            locador.Show();
        }

        private void cadastrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CadLocatario locatario = new CadLocatario(usuario, true, this);
            locatario.MdiParent = this;
            locatario.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VerLocadores verLocadores = new VerLocadores("imovel", usuario, this);
            verLocadores.MdiParent = this;
            verLocadores.Show();
        }

        private void cadastrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            cadFiador fiador = new cadFiador(usuario, this);
            fiador.MdiParent = this;
            fiador.Show();
        }

        private void verTodosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            verFiadores fiador = new verFiadores(usuario, this);
            fiador.MdiParent = this;
            fiador.Show();
        }

        private void visualizarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerFuncionarios funcionarios = new VerFuncionarios(usuario, this);
            funcionarios.MdiParent = this;
            funcionarios.Show();
            
        }

        private void cadastrarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            LoginSistema sistema = new LoginSistema();

            String usuario = sistema.getUser(this.usuario);
            int id_user = sistema.getId(this.usuario);

            Atendimento atendimento = new Atendimento(id_user, true, this);
            atendimento.txtUsuario.Text = usuario.ToString();
            atendimento.txtUsuario.Enabled = false;
            atendimento.btnEditar.Visible = false;
            atendimento.MdiParent = this;
            atendimento.Show();
        }

        private void visualizarTodosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VerAtendimentos verAtendimentos = new VerAtendimentos(usuario, this);
            verAtendimentos.MdiParent = this;
            verAtendimentos.Show();
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerLocadores verLocadores = new VerLocadores(usuario, this);
            verLocadores.MdiParent = this;
            verLocadores.Show();
        }

        private void verTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerLocacoes verlocacoes = new VerLocacoes(usuario, this);
            verlocacoes.MdiParent = this;
            verlocacoes.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerFuncionarios funcionarios = new VerFuncionarios(usuario, this);
            funcionarios.MdiParent = this;
            funcionarios.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerFuncionarios funcionarios = new VerFuncionarios(usuario, this);
            funcionarios.MdiParent = this;
            funcionarios.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VerImoveis verImoveis = new VerImoveis(usuario, this);
            verImoveis.MdiParent = this;
            verImoveis.Show();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VerImoveis verImoveis = new VerImoveis(usuario, this);
            verImoveis.MdiParent = this;
            verImoveis.Show();
        }

        private void excluirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VerLocadores verLocadores = new VerLocadores(usuario, this);
            verLocadores.MdiParent = this;
            verLocadores.Show();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VerLocadores verLocadores = new VerLocadores(usuario, this);
            verLocadores.MdiParent = this;
            verLocadores.Show();
        }

        private void verTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VerLocatarios verLocatarios = new VerLocatarios(usuario, this);
            verLocatarios.MdiParent = this;
            verLocatarios.Show();
        }

        private void editarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            verFiadores fiador = new verFiadores(usuario, this);
            fiador.MdiParent = this;
            fiador.Show();
        }

        private void excluirToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            verFiadores fiador = new verFiadores(usuario, this);
            fiador.MdiParent = this;
            fiador.Show();
        }

        private void editarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VerLocatarios verLocatarios = new VerLocatarios(usuario, this);
            verLocatarios.MdiParent = this;
            verLocatarios.Show();
        }

        private void excluirToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VerLocatarios verLocatarios = new VerLocatarios(usuario, this);
            verLocatarios.MdiParent = this;
            verLocatarios.Show();
        }

        private void editarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            VerLocacoes verlocacoes = new VerLocacoes(usuario, this);
            verlocacoes.MdiParent = this;
            verlocacoes.Show();
        }

        private void excluirToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            VerLocacoes verlocacoes = new VerLocacoes(usuario, this);
            verlocacoes.MdiParent = this;
            verlocacoes.Show();
        }

        private void adiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerLocatarios verLocatarios = new VerLocatarios(usuario, this);
            verLocatarios.MdiParent = this;
            verLocatarios.Show();
        }

        private void cadastrarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            VerImoveis verImoveis = new VerImoveis(usuario, this);
            verImoveis.MdiParent = this;
            verImoveis.Show();

            
        }

        /*private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.e = e;
            this.sender = sender;
            DialogResult dr = MessageBox.Show("Tem certeza que deseja fazer log off?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                e.Cancel = false;
                frmLogin login = new frmLogin();
                login.Visible = true;
            }
            else if(dr == DialogResult.No)
            {
                //e.Cancel = true;
            }
        }*/

        private void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            
           
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem certeza que deseja fazer log off?", "Mensagem",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
                frmLogin login = new frmLogin();
                login.Visible = true;
            }
            else if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
