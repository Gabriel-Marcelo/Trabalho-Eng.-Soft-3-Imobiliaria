using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovaCupece.Classes_Adicionais;
using NovaCupece.Interfaces;

namespace NovaCupece.Primitivas
{
    class CrudFonteDeRenda
    {
        public StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommand comando;

        static int id_Fontes_Do_Editar;
        static int id_Locatario_Do_Editar;

        public home inicio;

        public CrudFonteDeRenda(home inicio)
        {
            this.inicio = inicio;
        }

        public void exibir(VerFontesDeRenda verFontesDeRenda)
        {

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("Select * from FonteDeRenda", stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            verFontesDeRenda.dgvFonteDeRenda.DataSource = ds.Tables[0];

        }

        public void exibir(VerLocatarios verLocatarios)
        {
            DataGridViewRow selectedRow = verLocatarios.dgvLocatario.Rows[verLocatarios.linha];

            int id_locatario = Convert.ToInt16(selectedRow.Cells[0].Value);

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select * from FonteDeRenda where id_Locatario = '"+ id_locatario +"'",
                stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            stringConexao.conn.Close();

            VerFontesDeRenda verFontes = new VerFontesDeRenda(true, inicio);

            verFontes.dgvFonteDeRenda.DataSource = ds.Tables[0];

            verFontes.Visible = true;

        }

        public void atualizar(VerFontesDeRenda verFonte)
        {
            DataGridViewRow selectedRow = verFonte.dgvFonteDeRenda.Rows[verFonte.linha];
            int id_Locatario = Convert.ToInt16(selectedRow.Cells[6].Value);

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select * from FonteDeRenda where id_Locatario = '"+ id_Locatario +"'",
                stringConexao.conn);

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            verFonte.dgvFonteDeRenda.DataSource = ds.Tables[0];

        }


        public void deletar(VerFontesDeRenda verFontes)
        {
            DataGridViewRow selectedRow = verFontes.dgvFonteDeRenda.Rows[verFontes.linha];
            int id_Fonte = Convert.ToInt16(selectedRow.Cells[0].Value);

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "delete from FonteDeRenda where id = '" + id_Fonte + "'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Fonte de renda deletada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }catch(SqlException ex)
            {
                MessageBox.Show("Falha ao deletar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

        }

        public void mostrarEditar(VerFontesDeRenda verFontes)
        {
            DataGridViewRow selectedRow = verFontes.dgvFonteDeRenda.Rows[verFontes.linha];

            CadLocatario2 cadLocatario2 = new CadLocatario2("editar", inicio);

            int id_fontes = Convert.ToInt16(selectedRow.Cells[0].Value);

            MessageBox.Show(id_fontes.ToString());

            id_Fontes_Do_Editar = id_fontes;

            int id_Locatario = Convert.ToInt16(selectedRow.Cells[6].Value);

            id_Locatario_Do_Editar = id_Locatario;

            cadLocatario2.txtEmpresa.Text = selectedRow.Cells[1].Value.ToString();
            cadLocatario2.txtCargo.Text = selectedRow.Cells[2].Value.ToString();
            cadLocatario2.txtSalarioBruto.Text = selectedRow.Cells[3].Value.ToString();

            String horario_Trabalho = selectedRow.Cells[4].Value.ToString();

            cadLocatario2.txtHora1.Text = horario_Trabalho.Substring(0, 2);
            cadLocatario2.txtHora2.Text = horario_Trabalho.Substring(5);

            String tel_Comercial = selectedRow.Cells[5].Value.ToString();

            cadLocatario2.mtxtTelComercial1.Text = tel_Comercial.Substring(0, 4);
            cadLocatario2.mtxtTelComercial2.Text = tel_Comercial.Substring(4);

            cadLocatario2.Visible = true;

        }

        public void editar(CadLocatario2 cadFonte)
        {

            comando = new SqlCommand();

            try
            {

                stringConexao.conn.Open();
                
            }catch(SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema", "Mensagem", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            String horario_Trabalho = "";
            horario_Trabalho += cadFonte.txtHora1.Text;
            horario_Trabalho += cadFonte.txtHora2.Text;


            String telComercial = "";
            telComercial += cadFonte.mtxtTelComercial1.Text;
            telComercial += cadFonte.mtxtTelComercial2.Text;

            MessageBox.Show(id_Fontes_Do_Editar.ToString());

            comando.CommandText = "update FonteDeRenda set empresaFonte = '" + cadFonte.txtEmpresa.Text + "', " +
                "cargo = '" + cadFonte.txtCargo.Text + "', salario = '" + cadFonte.txtSalarioBruto.Text + "', " +
                "horarioTrabalho = '" + horario_Trabalho + "', telComercial = '" + telComercial + "', " +
                "id_locatario = '" + id_Locatario_Do_Editar + "' where id = '"+ id_Fontes_Do_Editar +"'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Atualização dafasdf", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            stringConexao.conn.Close();

        }

        
    }
}
