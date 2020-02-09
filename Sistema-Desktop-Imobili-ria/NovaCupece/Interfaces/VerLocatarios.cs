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
    public partial class VerLocatarios : Form
    {
        public int usuario;
        public int linha;
        public String selecionar;
        public Locacao locacao;

        CadLocatario2 cadLocatario3;
        CrudFonteDeRenda crudFonte;
        CadLocatario cadLocatario2;
        CadLocatario cadLocatario;
        public home inicio;

        public VerLocatarios(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerLocatarios(string selecionar, Locacao locacao, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.selecionar = selecionar;
            this.locacao = locacao;
        }

        public VerLocatarios(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }

        private void VerLocatarios_Load(object sender, EventArgs e)
        {
            CrudLocatario crudLocatario = new CrudLocatario(inicio);
            crudLocatario.exibir(this);
            rbCrescente.Checked = true;
            if (selecionar != "selecionar") {

                btnOk.Visible = false;
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadLocatario2 = new CadLocatario(usuario, inicio);
            cadLocatario2.Visible = true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CrudLocatario crudLocatario = new CrudLocatario(inicio);
            crudLocatario.exibir(this);
        }

        private void dgvLocatario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocatario crudLocatario = new CrudLocatario(inicio);

                crudLocatario.deletar(this);
            }

            
        }

        private void btnAddOutraFonte_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                DataGridViewRow selectedRow = dgvLocatario.Rows[linha];

                int id_Locatario = Convert.ToInt16(selectedRow.Cells[0].Value);


                cadLocatario3 = new CadLocatario2("VerLocatario", id_Locatario, inicio);
                cadLocatario3.Visible = true;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocatario crudLocatario = new CrudLocatario(inicio);
                 cadLocatario = new CadLocatario("Editar", usuario, inicio);
                crudLocatario.mostrarEditarLocatario(this, cadLocatario);
            }
              
        }

        private void btnVerFonteRenda_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                crudFonte = new CrudFonteDeRenda(inicio);
                crudFonte.exibir(this);
            }
                
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                crudLocacao.setNomeLocatarioById(this);
            }
                
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            CrudLocatario crudLocatario = new CrudLocatario(inicio);
            crudLocatario.exibir(this);
        }

        private void VerLocatarios_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.locacao != null) this.locacao.Visible = false;
            if (this.cadLocatario3 != null) this.cadLocatario3.Visible = false;
            if (this.cadLocatario2 != null) this.cadLocatario2.Visible = false;
            if (this.cadLocatario != null) this.cadLocatario.Visible = false;
        }
    }
}
