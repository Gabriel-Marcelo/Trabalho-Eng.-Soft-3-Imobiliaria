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
using System.IO;
using NovaCupece.Classes_Adicionais;
using NovaCupece.Interfaces;

namespace NovaCupece
{
    public partial class VerImoveis : Form
    {
        public int linha;
        public int usuario;
        DetalheImovel detalheImovel;
        DetalheImovel detalheImovelEditar;
        VerLocadores verLocadores;
        Locacao locacao;
        public home inicio;

        public VerImoveis(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerImoveis(int usuario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }


        private void VerImoveis_Load(object sender, EventArgs e)
        {
            CrudImovel crudImovel = new CrudImovel(inicio);
            crudImovel.exibir(dgvImovel);
            rbCidade.Checked = true;
            rbAlugados.Checked = true;
        }

        private void dgvImovel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void btnDetalhe_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudImovel crudImovel = new CrudImovel(inicio);

                detalheImovel = new DetalheImovel(inicio);
                detalheImovel.btnMudar.Visible = false;
                crudImovel.mostrarDetalhe(this, detalheImovel);
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           // ValidacaoGeral validacaoGeral = new ValidacaoGeral();
           // bool checar = validacaoGeral.validaDatagrid(this);

           // if (checar)
          //  {
                verLocadores = new VerLocadores("imovel", usuario, inicio);
                verLocadores.Visible = true;
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrudImovel crudImovel = new CrudImovel(inicio);
            crudImovel.exibir(dgvImovel);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudImovel crudImovel = new CrudImovel(inicio);
                crudImovel.deletar(linha, dgvImovel);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudImovel crudImovel = new CrudImovel(this, inicio);
                DataGridViewRow selectedRow = dgvImovel.Rows[linha];
                int id_Imovel = Convert.ToInt16(Convert.ToInt16(selectedRow.Cells[0].Value));
                detalheImovelEditar = new DetalheImovel(id_Imovel, usuario, inicio);
                crudImovel.mostrarEditar(this, detalheImovelEditar);
            }

        }

        private void btnLocar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                locacao = new Locacao(inicio);
                crudLocacao.setValuesLocacao(this, locacao);
            }

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.mostrar(this);
        }

        private void btnDesfazer1_Click(object sender, EventArgs e)
        {
            CrudImovel crudImovel = new CrudImovel(inicio);
            crudImovel.exibir(dgvImovel);

            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.desfazerOrdenarImovel();
        }

        private void btnDesfazer2_Click(object sender, EventArgs e)
        {
            CrudImovel crudImovel = new CrudImovel(inicio);
            crudImovel.exibir(dgvImovel);

            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.desfazerMostrarImovel();
        }

        private void VerImoveis_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.detalheImovel != null) this.detalheImovel.Visible = false;
            if (this.detalheImovelEditar != null) this.detalheImovelEditar.Visible = false;
            if (this.verLocadores != null) this.verLocadores.Visible = false;
            if (this.locacao != null) this.locacao.Visible = false;
        }

        private void VerImoveis_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
