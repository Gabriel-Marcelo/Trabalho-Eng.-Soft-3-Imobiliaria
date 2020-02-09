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

namespace NovaCupece.Interfaces
{
    public partial class VerFontesDeRenda : Form
    {
        public int linha;
        public bool locatario = false;

        public home inicio;

        public VerFontesDeRenda(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public VerFontesDeRenda(bool locatario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.locatario = locatario;
        }

        private void VerFontesDeRenda_Load(object sender, EventArgs e)
        {
            if (locatario)
            {

            }
            else
            {
                CrudFonteDeRenda crudFonte = new CrudFonteDeRenda(inicio);
                crudFonte.exibir(this);
            }
            
        }

        private void dgvFonteDeRenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linha = e.RowIndex;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);
            if (checar)
            {
                CrudFonteDeRenda crudFonte = new CrudFonteDeRenda(inicio);
                crudFonte.deletar(this);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CrudFonteDeRenda crudFonte = new CrudFonteDeRenda(inicio);
            crudFonte.atualizar(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.validaDatagrid(this);
            if (checar)
            {
                CrudFonteDeRenda crudFonte = new CrudFonteDeRenda(inicio);
                crudFonte.mostrarEditar(this);
            }  
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}
