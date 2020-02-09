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
using NovaCupece.Classes_Adicionais;

namespace NovaCupece
{
    public partial class verFiadores : Form
    {
        public int usuario;
        public int linha;
        public string selecionar;
        public Locacao locacao;
        public int id_Locacao;
        public string addOutro;
        public VerLocacoes verLocacoes;
        public string stringVerLocacoes;

        public cadFiador fiador;
        public cadFiador fiadorEditar;
        public home inicio;

        public verFiadores(VerLocacoes verLocacoes, string stringVerLocacoes, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.verLocacoes = verLocacoes;
            this.stringVerLocacoes = stringVerLocacoes;
            this.usuario = usuario;
            this.inicio = inicio;
        }


        public verFiadores(string selecionar, Locacao locacao, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.selecionar = selecionar;
            this.locacao = locacao;
            this.inicio = inicio;
        }

        public verFiadores(string addOutro, int id_Locacao, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.addOutro = addOutro;
            this.id_Locacao = id_Locacao;
            this.usuario = usuario;
            this.inicio = inicio;
        }

        public verFiadores(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.inicio = inicio;
        }

        public verFiadores(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void verFiadores_Load(object sender, EventArgs e)
        {
            if(stringVerLocacoes != "verLocacoes")
            {
                CrudFiador crudFiador = new CrudFiador(inicio);
                crudFiador.exibir(this);
                rbCrescente.Checked = true;
            }

            

            if (addOutro == "OutroFiador")
            {
                btnOk.Visible = true;
            }
            else if(stringVerLocacoes == "verLocacoes")
            {
                btnOk.Visible = true;
            }
            else if(selecionar != "selecionar")
            {
                
                btnOk.Visible = false;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           
            fiador = new cadFiador(usuario, inicio);
            fiador.Visible = true;
           
                
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CrudFiador crudFiador = new CrudFiador(inicio);
            crudFiador.exibir(this);
        }

        private void dgvFiadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudFiador crudFiador = new CrudFiador(inicio);
                crudFiador.deletar(this);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudFiador crudFiador = new CrudFiador(inicio);
                DataGridViewRow selectedRow = dgvFiadores.Rows[linha];
                int id_Fiador = Convert.ToInt16(selectedRow.Cells[0].Value);
                fiadorEditar = new cadFiador(usuario, "editar", id_Fiador, inicio);
                crudFiador.mostrarEditar(this, fiadorEditar);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CrudLocacao crudLocacao = new CrudLocacao(inicio);

            if (addOutro == "OutroFiador")
            {
               
                crudLocacao.addOutroFiadorLocacao(this);
            }
            else if(stringVerLocacoes == "verLocacoes")
            {
                this.Visible = false;
            }
            else
            {
                crudLocacao.setNomeFiadorById(this);
            }

         
            
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            CrudFiador crudFiador = new CrudFiador(inicio);
            crudFiador.exibir(this);
        }

        private void verFiadores_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.fiador != null) this.fiador.Visible = false;
            if (this.fiadorEditar != null) this.fiadorEditar.Visible = false;

        }

        private void verFiadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
