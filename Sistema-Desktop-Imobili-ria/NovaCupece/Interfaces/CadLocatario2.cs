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
    public partial class CadLocatario2 : Form
    {
        public bool menuStrip = false;
        public int id_Locatario;
        public string verLocatario = "";
        public string editar = "";
        public home inicio;

        public CadLocatario2(home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
        }

        public CadLocatario2(String verLocatario, int id_Locatario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.verLocatario = verLocatario;
            this.id_Locatario = id_Locatario;
        }

        public CadLocatario2(bool menuStrip, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.menuStrip = menuStrip;
            this.inicio = inicio;
        }

        public CadLocatario2(int id_Locatario, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.id_Locatario = id_Locatario;
            this.inicio = inicio;
        }

        public CadLocatario2(string editar, home inicio)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.inicio = inicio;
            this.editar = editar;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            bool checar = validacaoGeral.checarCamposVazios(this);
            bool checar2 = validacaoGeral.validaSalario(txtSalarioBruto);
            if (checar && checar2)
            {
                CrudLocatario crudLocatario = new CrudLocatario(id_Locatario);

                if (verLocatario == "VerLocatario")
                {
                    bool valCad = crudLocatario.cadastrarFonteDeRenda(id_Locatario, this);
                    if (valCad) validacaoGeral.limpar(this);
                }
                else if (editar == "editar")
                {
                    CrudFonteDeRenda crudFonte = new CrudFonteDeRenda(inicio);
                    crudFonte.editar(this);
                }
                else
                {
                    bool valCad = crudLocatario.cadastrarFonteDeRenda(this);
                    if (valCad) validacaoGeral.limpar(this);
                }
            }
            else
            {
                if(!checar)
                    MessageBox.Show("Campo(s) vazio(s)", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!checar2)
                    MessageBox.Show("O campo 'Salário Bruto' não foi preenchido corretamente", "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocatarios_Click(object sender, EventArgs e)
        {
            VerLocatarios verLocatarios = new VerLocatarios(inicio);
            verLocatarios.Visible = true;
            this.Visible = false;
        }

        private void CadLocatario2_Load(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.tamanho(this);

            if (menuStrip)
            {
                btnLocatarios.Visible = true;
            }
            else
            {
                btnLocatarios.Visible = false;
            }
        }

        private void btnAddOutraFonte_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ValidacaoGeral validacaoGeral = new ValidacaoGeral();
            validacaoGeral.limpar(this);
        }

        private void txtSalarioBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = (Char)0;
            }
        }
    }
}
