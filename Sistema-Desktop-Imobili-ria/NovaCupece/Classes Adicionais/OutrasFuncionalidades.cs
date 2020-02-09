using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace NovaCupece.Classes_Adicionais
{
    class OutrasFuncionalidades
    {
        public StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommand comando;

        public static bool ordImoveis = false;
        public static bool mostrarImoveis = false;

        public void ordenar(VerAtendimentos atendimentos)
        {
            ds = new DataSet();
            
            try
            {

                stringConexao.conn.Open();

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

      

            if (atendimentos.rbCrescente.Checked)
                dataAdapter = new SqlDataAdapter("select * from Atendimento order by cliente",
                    stringConexao.conn);

            else if (atendimentos.rbDecrescente.Checked)
            {
                dataAdapter = new SqlDataAdapter("select * from Atendimento order by cliente desc",
                    stringConexao.conn);
            }

            try
            {

                dataAdapter.Fill(ds);
                atendimentos.dgvAtendimentos.DataSource = ds.Tables[0];

            }
            catch(SqlException ex){

                MessageBox.Show("Não foi possível ordenar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            stringConexao.conn.Close();

            

        }

        public void ordenar(VerFuncionarios funcionarios)
        {
            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            if (funcionarios.rbCrescente.Checked)
                dataAdapter = new SqlDataAdapter("select * from Funcionario where status_func = 'Ativo' " +
                    "order by nome",
                    stringConexao.conn);

            else if (funcionarios.rbDecrescente.Checked)
            {
               dataAdapter = new SqlDataAdapter("select * from Funcionario where status_func = 'Ativo' " +
                   "order by nome desc",
                   stringConexao.conn);
            }

            try
            {

                dataAdapter.Fill(ds);
                funcionarios.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Não foi possível ordenar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            stringConexao.conn.Close();

           

        }

        public void ordenar(verFiadores fiadores)
        {
            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            if (fiadores.rbCrescente.Checked)
            {
                dataAdapter = new SqlDataAdapter("select * from Fiador order by nome",
                    stringConexao.conn);
            }
            else if (fiadores.rbDecrescente.Checked)
            {
                dataAdapter = new SqlDataAdapter("select * from Fiador order by nome desc",
                    stringConexao.conn);
            }

            try
            {

                dataAdapter.Fill(ds);
                fiadores.dgvFiadores.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Não foi possível ordenar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            stringConexao.conn.Close();

            
        }

        public void ordenar(VerLocadores locadores)
        {
            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            if (locadores.rbCrescente.Checked)
                dataAdapter = new SqlDataAdapter("select * from Locador order by nome",
                    stringConexao.conn);
            else if (locadores.rbDecrescente.Checked)
            {
                dataAdapter = new SqlDataAdapter("select * from Locador order by nome desc",
                    stringConexao.conn);
            }

            try
            {

                dataAdapter.Fill(ds);
                locadores.dgvLocadores.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Não foi possível ordenar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            stringConexao.conn.Close();

            
        }

        public void ordenar(VerLocatarios locatarios)
        {
            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            if (locatarios.rbCrescente.Checked)
                dataAdapter = new SqlDataAdapter("select * from Locatario order by nome",
                    stringConexao.conn);
            else if (locatarios.rbDecrescente.Checked)
            {
                dataAdapter = new SqlDataAdapter("select * from Locatario order by nome desc",
                    stringConexao.conn);
            }

            try
            {

                dataAdapter.Fill(ds);
                locatarios.dgvLocatario.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Não foi possível ordenar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            stringConexao.conn.Close();

            

        }

        public void ordenar(VerLocacoes locacoes)
        {
            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            dataAdapter = new SqlDataAdapter("select * from Locacao order by valorLocacao",
                stringConexao.conn) ;
            

            try
            {

                dataAdapter.Fill(ds);
                locacoes.dgvLocacoes.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Não foi possível ordenar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            stringConexao.conn.Close();

            
        }

        public void ordenar(VerImoveis imoveis)
        {
            ordImoveis = true;

            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(mostrarImoveis == false)
            {
                if (imoveis.rbCidade.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel order by cidade",
                        stringConexao.conn);
                }
                else if (imoveis.rbEstado.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel order by uf",
                        stringConexao.conn);
                }
            }
            else
            {
                if(imoveis.rbCidade.Checked && imoveis.rbDisponiveis.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "id = (select id from Imovel where status_Imovel = 'Disponível') " +
                        "order by cidade", stringConexao.conn);
                }
                else if(imoveis.rbCidade.Checked && imoveis.rbAlugados.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where id = " +
                        "(select id from Imovel where status_Imovel = 'Indisponível') " +
                        "order by cidade",
                        stringConexao.conn);
                }
                else if(imoveis.rbEstado.Checked && imoveis.rbDisponiveis.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "id = (select id from Imovel where status_Imovel = 'Disponível') " +
                        "order by uf",
                        stringConexao.conn);
                }
                else if(imoveis.rbEstado.Checked && imoveis.rbAlugados.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "id = (select id from Imovel where status_Imovel = 'Indisponível') " +
                        "order by uf", 
                        stringConexao.conn);
                }
            }


            try
            {
                dataAdapter.Fill(ds);
                imoveis.dgvImovel.DataSource = ds.Tables[0];
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Falha em ordenar imóveis", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            

            mostrarImoveis = false;

        }

        public void mostrar(VerImoveis imoveis)
        {
            mostrarImoveis = true;

            ds = new DataSet();


            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(ordImoveis == false)
            {
                if (imoveis.rbDisponiveis.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, " +
                        "complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "status_Imovel = 'Disponível'",
                        stringConexao.conn);
                }
                else if (imoveis.rbAlugados.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, " +
                        "complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "status_Imovel = 'Alugado'",
                        stringConexao.conn);
                }
            }
            else
            {
                if (imoveis.rbCidade.Checked && imoveis.rbDisponiveis.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "id = (select id from Imovel where status_Imovel = 'Disponível') " +
                        "order by cidade", stringConexao.conn);
                }
                else if (imoveis.rbCidade.Checked && imoveis.rbAlugados.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where id = " +
                        "(select id from Imovel where status_Imovel = 'Indisponível') " +
                        "order by cidade",
                        stringConexao.conn);
                }
                else if (imoveis.rbEstado.Checked && imoveis.rbDisponiveis.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "id = (select id from Imovel where status_Imovel = 'Disponível') " +
                        "order by uf",
                        stringConexao.conn);
                }
                else if (imoveis.rbEstado.Checked && imoveis.rbAlugados.Checked)
                {
                    dataAdapter = new SqlDataAdapter("select id, id_Locador, descricao, rua_avenida, complemento, uf, numero, bairro, cidade, valor_Aluguel, status_Imovel from Imovel where " +
                        "id = (select id from Imovel where status_Imovel = 'Indisponível') " +
                        "order by uf",
                        stringConexao.conn);
                }
            }

            try
            {
                dataAdapter.Fill(ds);
                imoveis.dgvImovel.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha em ordenar imóveis", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            

            ordImoveis = false;

        }

        public void desfazerOrdenarImovel()
        {
            ordImoveis = false;
        }

        public void desfazerMostrarImovel()
        {
            mostrarImoveis = false;
        }

    }

    
}
