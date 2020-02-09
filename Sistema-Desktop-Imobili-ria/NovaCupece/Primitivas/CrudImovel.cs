using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovaCupece.Interfaces;
using System.Drawing;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece.Primitivas
{
    class CrudImovel
    {
        public VerImoveis verImoveis;

        public home inicio;

        public CrudImovel(home inicio)
        {
            this.inicio = inicio;
        }

        public CrudImovel(VerImoveis verImoveis, home inicio)
        {
            this.verImoveis = verImoveis;
            this.inicio = inicio;
        }

        



        DataSet ds;
        SqlDataAdapter dataAdapter;
        StringConexao stringConexao = new StringConexao();
        public SqlCommand comando;

        public bool cadastrar(String fileName, Byte[] data, RichTextBox txtDescricao, TextBox txtRuaAvenida,
            TextBox txtComplemento, ComboBox cboUf, TextBox txtNumero, TextBox txtBairro, TextBox txtCidade,
            TextBox txtValorAluguel, ComboBox cboStatus, int id_usuario, int id_locador)
        {
            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não conectou", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "insert into Imovel(fileNameImg, Data, descricao, rua_Avenida, complemento, uf, numero," +
                "bairro, cidade, valor_Aluguel, status_Imovel, id_User, id_Locador) values ('"+ fileName + "'," +
                " '" + data + "', '" + txtDescricao.Text + "', '" + txtRuaAvenida.Text + "', '" + txtComplemento.Text + "'," +
                " '" + cboUf.SelectedItem + "'," +
                "'" + txtNumero.Text + "', '" + txtBairro.Text + "', '" + txtCidade.Text + "'," +
                " '" + txtValorAluguel.Text + "','" + cboStatus.SelectedItem + "'," +
                "'" + id_usuario + "', '" + id_locador + "')";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Imóvel Cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                stringConexao.conn.Close();
                return true;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível cadastrar o imóvel. Cheque se os campos foram " +
                    "preenchidos corretamente", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                stringConexao.conn.Close();
                return false;
            }

            
        }

        public void exibir(DataGridView dataGrid)
        {
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não conectou", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status" +
                "_Imovel from Imovel", stringConexao.conn);

            dataAdapter.Fill(ds);

            dataGrid.DataSource = ds.Tables[0];

        }

       
        public String getImovelByPathName(DataGridView dataGrid, int linha)
        {
            DataGridViewRow selectedRow = dataGrid.Rows[linha];

            int id_imovel = Convert.ToInt16(selectedRow.Cells[0].Value);

            String picpath;

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não conectou", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select fileNameImg from Imovel where id = '" + id_imovel + "' ", stringConexao.conn);

            dataAdapter.Fill(ds);

            picpath = ds.Tables[0].Rows[0][0].ToString();
            return picpath;

        }




        public void mostrarDetalhe(VerImoveis verImoveis, DetalheImovel detalheImovel)
        {

            CrudLocador crudLocador = new CrudLocador(inicio);

            DataGridViewRow selectedRow = verImoveis.dgvImovel.Rows[verImoveis.linha];

            int id_Imovel = Convert.ToInt16(selectedRow.Cells[0].Value);

            

            detalheImovel.btnSalvar.Visible = false;

            detalheImovel.pbImovel.ImageLocation = getImovelByPathName(verImoveis.dgvImovel, verImoveis.linha);
            detalheImovel.rtxtDescricao.Text = selectedRow.Cells[2].Value.ToString();
            detalheImovel.txtRuaAvenida.Text = selectedRow.Cells[3].Value.ToString();
            detalheImovel.txtComplemento.Text = selectedRow.Cells[4].Value.ToString();

            
            detalheImovel.cboUf.SelectedItem = selectedRow.Cells[5].Value.ToString();
            detalheImovel.txtNumero.Text = selectedRow.Cells[6].Value.ToString();
            detalheImovel.txtBairro.Text = selectedRow.Cells[7].Value.ToString();
            detalheImovel.txtCidade.Text = selectedRow.Cells[8].Value.ToString();
            detalheImovel.txtValorAluguel.Text = selectedRow.Cells[9].Value.ToString();
            detalheImovel.cboStatus.SelectedItem = selectedRow.Cells[10].Value.ToString();

            detalheImovel.txtLocador.Text = crudLocador.getNameById(Convert.ToInt16(selectedRow.Cells[1].Value));

            detalheImovel.Visible = true;

        }

        public void deletar(int linha, DataGridView dataGrid)
        {

            DataGridViewRow selectedRow = dataGrid.Rows[linha];

            int id_imovel = Convert.ToInt16(selectedRow.Cells[0].Value);

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não conectou", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "delete from Imovel where id = '" + id_imovel + "'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("O imóvel foi deletado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("O comando não executou", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

        }

        public void mostrarEditar(VerImoveis verImoveis, DetalheImovel detalheImovel)
        {
            

            CrudLocador crudLocador = new CrudLocador(inicio);

            DataGridViewRow selectedRow = verImoveis.dgvImovel.Rows[verImoveis.linha];

            int id_Imovel = Convert.ToInt16(selectedRow.Cells[0].Value);


            detalheImovel.btnOk.Visible = false;


            detalheImovel.pbImovel.Enabled = true;
            detalheImovel.rtxtDescricao.Enabled = true;
            detalheImovel.txtRuaAvenida.Enabled = true;
            detalheImovel.txtComplemento.Enabled = true;


            detalheImovel.cboUf.Enabled = true;
            detalheImovel.txtNumero.Enabled = true;
            detalheImovel.txtBairro.Enabled = true;
            detalheImovel.txtCidade.Enabled = true;
            detalheImovel.txtValorAluguel.Enabled = true;
            detalheImovel.cboStatus.Enabled = true;







            detalheImovel.pbImovel.ImageLocation = getImovelByPathName(verImoveis.dgvImovel, verImoveis.linha);
            detalheImovel.rtxtDescricao.Text = selectedRow.Cells[2].Value.ToString();
            detalheImovel.txtRuaAvenida.Text = selectedRow.Cells[3].Value.ToString();
            detalheImovel.txtComplemento.Text = selectedRow.Cells[4].Value.ToString();


            detalheImovel.cboUf.SelectedItem = selectedRow.Cells[5].Value.ToString();
            detalheImovel.txtNumero.Text = selectedRow.Cells[6].Value.ToString();
            detalheImovel.txtBairro.Text = selectedRow.Cells[7].Value.ToString();
            detalheImovel.txtCidade.Text = selectedRow.Cells[8].Value.ToString();
            detalheImovel.txtValorAluguel.Text = selectedRow.Cells[9].Value.ToString();
            detalheImovel.cboStatus.SelectedItem = selectedRow.Cells[10].Value.ToString();

            detalheImovel.txtLocador.Text = crudLocador.getNameById(Convert.ToInt16(selectedRow.Cells[1].Value));

            detalheImovel.Visible = true;
        }

        public void salvarEditar(DetalheImovel detalheImovel)
        {
            

            CrudLocador crudLocador = new CrudLocador(inicio);

            int id_Imovel = detalheImovel.id_imovel;

            int id_User = detalheImovel.usuario;

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não conectou", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "update Imovel set fileNameImg = '" + detalheImovel.picpath + "', descricao = '" + detalheImovel.rtxtDescricao.Text + "'," +
                "rua_avenida = '" + detalheImovel.txtRuaAvenida.Text + "', complemento = '" + detalheImovel.txtComplemento.Text + "'," +
                " uf = '" + detalheImovel.cboUf.SelectedItem + "', numero = '" + Convert.ToInt32(detalheImovel.txtNumero.Text) + "'," +
                " bairro = '" + detalheImovel.txtBairro.Text + "', cidade = '" + detalheImovel.txtCidade.Text + "', " +
                "valor_Aluguel = '" + Convert.ToDecimal(detalheImovel.txtValorAluguel.Text) + "', status_Imovel = '" + detalheImovel.cboStatus.SelectedItem + "'," +
                "id_User =  '"+ id_User +"' where id = '"+ id_Imovel +"'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Imóvel Editado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            stringConexao.conn.Close();

        }

    }
}
