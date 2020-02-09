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
    public partial class VerLocacoes : Form
    {
        public int linha;
        public int usuario;
        Locacao locacao; 
        verFiadores fiadores;
        Locacao locacaoDetalhe;
        verFiadores fiadores2;
        public home inicio;

        public VerLocacoes(home inicio)
        {
            InitializeComponent();
            //this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerLocacoes(int usuario, home inicio)
        {
            InitializeComponent();
            // this.MaximizeBox = false;

            this.inicio = inicio;
            this.usuario = usuario;
        }

        private void VerLocacoes_Load(object sender, EventArgs e)
        {
            CrudLocacao crudLocacao = new CrudLocacao(inicio);
            crudLocacao.exibir(this);
        }

        private void dgvLocacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CrudLocacao crudLocacao = new CrudLocacao(inicio);
            crudLocacao.exibir(this);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                crudLocacao.deletarFiadorLocacao(this);
                crudLocacao.deletar(this);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                locacao = new Locacao(true, inicio);
                crudLocacao.mostrarEditar(this, locacao);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                locacaoDetalhe = new Locacao("Ok", inicio);
                crudLocacao.verDetalhe(this, locacaoDetalhe);
            }

        }

        private void btnAddFiador_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {
                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                DataGridViewRow selectedRow = dgvLocacoes.Rows[linha];
                int id_Locacao = Convert.ToInt16(selectedRow.Cells[0].Value);
                fiadores2 = new verFiadores("OutroFiador", id_Locacao, usuario, inicio);
                crudLocacao.chamarFiadores(this, fiadores2);
            }

                
        }

        private void btnFiadorDeUmaLocacao_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);

            if (checar)
            {

                CrudLocacao crudLocacao = new CrudLocacao(inicio);
                fiadores = new verFiadores(this, "verLocacoes", usuario, inicio);
                crudLocacao.verFiadoresDeUmaLocacao(this, fiadores);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutrasFuncionalidades funcionalidades = new OutrasFuncionalidades();
            funcionalidades.ordenar(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrudLocacao crudLocacao = new CrudLocacao(inicio);
            crudLocacao.exibir(this);
        }

        private void VerLocacoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.locacao != null) this.locacao.Visible = false;
            if(this.fiadores != null) this.fiadores.Visible = false;
            if(this.locacaoDetalhe != null) this.locacaoDetalhe.Visible = false;
            if(this.fiadores2 != null) this.fiadores2.Visible = false;
        }
    }
}
