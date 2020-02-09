using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece.Primitivas
{
    class CrudAtendimento
    {
        StringConexao stringConexao = new StringConexao();
        SqlCommand comando;
        SqlDataAdapter dataAdapter;
        DataSet ds;

        public int id_User;
        public DataGridView dataGrid;
        public int linha;

        public home inicio;

        public CrudAtendimento(home inicio)
        {
            this.inicio = inicio;
        }

        public CrudAtendimento(int id_User, DataGridView dataGrid, int linha, home inicio)
        {
            this.id_User = id_User;
            this.dataGrid = dataGrid;
            this.linha = linha;
            this.inicio = inicio;
        }

        public void cadastrar(TextBox txtCliente, TextBox txtData, TextBox txtHora, RichTextBox txtDescricao, int id_User)
        {
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando = new SqlCommand();
            comando.Connection = stringConexao.conn;
            comando.CommandText = "insert into Atendimento(cliente, data, hora, descricao, id_User) Values " +
                "('"+ txtCliente.Text + "', '" + txtData.Text + "', '" + txtHora.Text + "', '" + txtDescricao.Text + "'," +
                " '" + id_User + "')";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Atendimento Cadastrado!", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível salvar os dados. Tente Novamente", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

        }

        public DateTime getData()
        {
            DateTime localDate = DateTime.Now;
            
            return localDate;
        }

        public void exibir(DataGridView dGrid)
        {
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select * from Atendimento", stringConexao.conn);
            ds = new DataSet();

            dataAdapter.Fill(ds);

            dGrid.DataSource = ds.Tables[0];

            stringConexao.conn.Close();

        }
        public void mostrarEditar(DataGridView dGrid, int id_User, int linha, Atendimento atendimento)
        {
             

            LoginSistema sistema = new LoginSistema();
            DataGridViewRow selectedRow = dGrid.Rows[linha];
            atendimento.txtUsuario.Text = sistema.getUser(Convert.ToInt16(selectedRow.Cells[5].Value));
            atendimento.txtCliente.Text = selectedRow.Cells[1].Value.ToString();
            atendimento.txtData.Text = selectedRow.Cells[2].Value.ToString();
            atendimento.txtHorario.Text = selectedRow.Cells[3].Value.ToString();
            atendimento.rtxtDescricao.Text = selectedRow.Cells[4].Value.ToString();
            atendimento.btnSalvar.Visible = false;

            atendimento.Visible = true;
        }

        public void editar(TextBox txtCliente, RichTextBox txtDescricao, int id_user, DataGridView dataGrid, int linha)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];
            int id_atendimento = Convert.ToInt16(selectedRow.Cells[0].Value);

            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando = new SqlCommand();
            comando.Connection = stringConexao.conn;
            comando.CommandText = "Update Atendimento set cliente = '"+ txtCliente.Text +"', " +
                "descricao = '"+ txtDescricao.Text +"' where id = '"+ id_atendimento +"'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Atendimento editado!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível editar o atendimento", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();

        }

        public void deletar(DataGridView dataGrid, int linha)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];
            comando = new SqlCommand();
            int checar = 0;

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não conectou");
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "delete from Atendimento where id = '" + selectedRow.Cells[0].Value + "' and id_User = '"+ inicio.usuario +"'";

            try
            {
                checar = comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível deletar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (checar != 0)
            {
                MessageBox.Show("O Registro foi Deletado! Clique em Atualizar", "Deletar",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            stringConexao.conn.Close();

        }

    }
}
