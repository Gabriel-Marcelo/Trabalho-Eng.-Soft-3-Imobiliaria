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
using NovaCupece.Primitivas;


namespace NovaCupece
{
    public partial class VerFuncionarios : Form
    {
        public int linha;
        public int usuario;

        public home inicio;
        public CadFunc cadfunc;
        public CadFunc cadfunc2; 

        public VerFuncionarios(home inicio)
        {
            InitializeComponent();
            //this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerFuncionarios(int usuario, home inicio)
        {
            InitializeComponent();
            // this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }


        private void VerFuncionarios_Load(object sender, EventArgs e)
        {
            
            
            CrudFunc crudfunc = new CrudFunc(inicio);
            crudfunc.exibir(dataGridView1);
            rbCrescente.Checked = true;
        }

        //btnDeletar
        private void button1_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);
            CrudFunc crudFunc = new CrudFunc(inicio);

            LoginSistema loginSistema = new LoginSistema();
           // int id_funcLogado = loginSistema.getFuncByIdUser(usuario);
            int id_funcGrid = crudFunc.getIdFuncDoGrid(this);

            if (checar && (usuario != id_funcGrid))
            {

                CrudFunc crudfunc = new CrudFunc(inicio);
                crudfunc.deletarUsuario(linha, dataGridView1);
                crudfunc.Deletar(linha, dataGridView1);
            }
            else if(usuario == id_funcGrid)
            {
                MessageBox.Show("Não é possível deletar um funcionário logado", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        }

        //btn cadastrar
        private void button4_Click(object sender, EventArgs e)
        {
           
                cadfunc = new CadFunc(inicio,"verFuncionarios");

                cadfunc.Text = "Cadastrar Funcionário";
                cadfunc.lblTitulo.Text = "Cadastrar Funcionário";
                cadfunc.btnEditar.Visible = false;

                cadfunc.Visible = true;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
            CrudFunc crudfunc = new CrudFunc(inicio);
            crudfunc.exibir(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        //btnEditar
        private void button4_Click_1(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudFunc crudfunc = new CrudFunc(inicio);
                cadfunc2  = new CadFunc("editar", linha, dataGridView1, inicio);
                crudfunc.MostrarEditar(linha, dataGridView1, cadfunc2);
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            CrudFunc crudFunc = new CrudFunc(inicio);
            crudFunc.exibir(dataGridView1);
        }

        private void VerFuncionarios_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void VerFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void VerFuncionarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                if(this.cadfunc != null) this.cadfunc.Visible = false;
                if(this.cadfunc2 != null) this.cadfunc2.Visible = false;
            
            
        }
    }
}
