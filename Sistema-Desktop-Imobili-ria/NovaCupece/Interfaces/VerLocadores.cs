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
using NovaCupece.Primitivas;

namespace NovaCupece
{
    public partial class VerLocadores : Form
    {
        public String imovel;
        public int linha;
        public int usuario;
        public home inicio;
        CadLocImov1 locador;
        CadLocImov1 cadLocador;
        cadLocImov2 cadImov;

        public VerLocadores(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerLocadores(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }

        public VerLocadores(String imovel, int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.imovel = imovel;
            this.usuario = usuario;
        }

        private void VerLocadores_Load(object sender, EventArgs e)
        {
            rbCrescente.Checked = true;
            if (imovel == "imovel")
            {
                lblTitulo.Text = "Selecione um Locador para o Imóvel";
                lblTitulo.BackColor = Color.White;
                lblTitulo.ForeColor = Color.Red;

                this.btnCadastrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnDeletar.Visible = false;

                CrudLocador crudLocador = new CrudLocador(inicio);
                crudLocador.exibir(dgvLocadores);
            }
            else
            {
                this.btnSelecionar.Visible = false;
                CrudLocador crudLocador = new CrudLocador(inicio);
                crudLocador.exibir(dgvLocadores);
            }

            
        }

        private void dgvLocadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocador crudLocador = new CrudLocador(inicio);
                int id_locador = crudLocador.getId(dgvLocadores, linha);

                cadImov = new cadLocImov2(usuario, id_locador, inicio);
                cadImov.txtLocador.Text = crudLocador.getNameById(id_locador);
                cadImov.cboStatus.SelectedItem = cadImov.cboStatus.Items[1];
                cadImov.cboUf.SelectedItem = cadImov.cboUf.Items[24];
                cadImov.MdiParent = inicio;
                cadImov.Show();
                this.Visible = false;
            }  

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            CrudLocador crudLocador = new CrudLocador(inicio);
            crudLocador.exibir(dgvLocadores);
        }

        private void btnExluir_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocador crudLocador = new CrudLocador(inicio);
                crudLocador.checarExclusao(this);
            }

            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocador crudLocador = new CrudLocador(inicio);
                DataGridViewRow selectedRow = dgvLocadores.Rows[linha];
                int id_Locador = Convert.ToInt16(selectedRow.Cells[0].Value);
                locador = new CadLocImov1("editar", id_Locador, inicio);
                crudLocador.mostrarEditar(this,locador);
            }
               
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadLocador = new CadLocImov1(usuario, inicio);
            cadLocador.Visible = true;
            
        }

        private void VerLocadores_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.locador != null) this.locador.Visible = false;
            if(this.cadLocador != null) this.cadLocador.Visible = false;
            if(this.cadImov != null) this.cadImov.Visible = false;
        }
    }
}
