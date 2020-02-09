using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovaCupece.Classes_Adicionais;

namespace NovaCupece.Primitivas
{
    class CrudLocacao
    {
        public StringConexao stringConexao = new StringConexao();
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommand comando;

        public home inicio;

        public CrudLocacao(home inicio)
        {
            this.inicio = inicio;
        }
        public CrudLocacao()
        {
            
        }


        public void popFiador(Locacao locacao)
        {
            verFiadores fiadores = new verFiadores("selecionar", locacao, inicio);

            fiadores.btnAtualizar.Visible = false;
            fiadores.btnCadastrar.Visible = false;
            fiadores.btnDeletar.Visible = false;
            fiadores.btnEditar.Visible = false;

            fiadores.Visible = true;
        }



        public void popLocatario(Locacao locacao)
        {
            VerLocatarios locatarios = new VerLocatarios("selecionar", locacao, inicio);

            locatarios.btnAddOutraFonte.Visible = false;
            locatarios.btnCadastrar.Visible = false;
            locatarios.btnDeletar.Visible = false;
            locatarios.btnEditar.Visible = false;
            locatarios.btnVerFonteRenda.Visible = false;
            locatarios.btnAtualizar.Visible = false;

            locatarios.Visible = true;

        }


        public void setNomeFiadorById(verFiadores fiadores)
        {
            DataGridViewRow selectedRow = fiadores.dgvFiadores.Rows[fiadores.linha];

            string nome = selectedRow.Cells[1].Value.ToString();

            fiadores.locacao.txtFiador.Text = nome;

            fiadores.locacao.id_Fiador = Convert.ToInt16(selectedRow.Cells[0].Value);
            fiadores.Visible = false;
        }


        public void setNomeLocatarioById(VerLocatarios locatarios)
        {
            DataGridViewRow selectedRow = locatarios.dgvLocatario.Rows[locatarios.linha];

            string nome = selectedRow.Cells[1].Value.ToString();

            locatarios.locacao.txtLocatario.Text = nome;

            locatarios.locacao.id_Locatario = Convert.ToInt16(selectedRow.Cells[0].Value);

            locatarios.Visible = false;
        }


        public void setValuesLocacao(VerImoveis verImoveis, Locacao locacao)
        {
           

            ds = new DataSet();
            DataSet ds1 = new DataSet();

            DataGridViewRow selectedRow = verImoveis.dgvImovel.Rows[verImoveis.linha];

            int id_Locador = Convert.ToInt16(selectedRow.Cells[1].Value);
            
            locacao.txtValorLocacao.Text = selectedRow.Cells[9].Value.ToString();

            int id_Imovel = Convert.ToInt16(selectedRow.Cells[0].Value);

            locacao.id_Imovel = id_Imovel;

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível se conectar ao sistema! Contate o administrador",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select nome from Locador where id = '" + id_Locador + "'", stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o nome do locador da base de dados", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select fileNameImg from Imovel where id = '"+ id_Imovel +"'", stringConexao.conn);
                dataAdapter.Fill(ds1);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar a imagem do imóvel da base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            locacao.txtLocador.Text = ds.Tables[0].Rows[0][0].ToString();

            locacao.id_Locador = id_Locador;

            locacao.path = ds1.Tables[0].Rows[0][0].ToString();

            locacao.pbLocacao.ImageLocation = locacao.path;

            locacao.Visible = true;
        }

        public bool disponivel(Locacao locacao)
        {
            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select status_Imovel from Imovel where id = '"+ locacao.id_Imovel +"'", stringConexao.conn);

            try
            {
                dataAdapter.Fill(ds);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar os dados na base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            string status = ds.Tables[0].Rows[0][0].ToString();

            if (status == "Disponível")
            {
                return true;
            }
            else return false;

        }

        public void salvar(Locacao locacao)
        {
            comando = new SqlCommand();

            bool disponibilidade = disponivel(locacao);
            if (disponibilidade)
            {
                try
                {
                    stringConexao.conn.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                comando.Connection = stringConexao.conn;

                comando.CommandText = "INSERT INTO Locacao(fileNameImg, id_Locador, id_Locatario, id_Fiador, valorLocacao, dataLoc, dataFinal, id_Imovel) VALUES " +
                    "('" + locacao.path + "', '" + locacao.id_Locador + "', '" + locacao.id_Locatario + "', '" + locacao.id_Fiador + "'," +
                    "'" + locacao.txtValorLocacao.Text + "', '" + locacao.mtxDataLocacao.Text + "', '" + locacao.mtxDataFinal.Text + "', '" + locacao.id_Imovel + "' )";

                int checar = 0;

                try
                {
                   comando.ExecuteNonQuery();
                    MessageBox.Show("A Locação foi registrada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro no registro da nova locação", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                stringConexao.conn.Close();

                int id_Locacao = getUltimaLocacao();

                checar = addFiadorLocacao(id_Locacao, locacao.id_Fiador);

                if(checar != 0)
                {
                    alteraStatusImovel(locacao);
                }

            }
            else
            {
                MessageBox.Show("Imóvel indisponível. Selecione outro", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            
        }

        public bool validaCadLocacao(Locacao locacao)
        {
            ds = new DataSet();
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            try
            {

                dataAdapter = new SqlDataAdapter("select * from locacao", stringConexao.conn);
                dataAdapter.Fill(ds);

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível checar se esta locação é possível");
            }

            stringConexao.conn.Close();
            bool checar = true;
            foreach(DataTable table in ds.Tables)
            {
                foreach(DataRow row in table.Rows)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        int aux = Convert.ToInt16(row[column]);
                        if(aux == locacao.id_Imovel)
                        {
                            checar = false;
                        }
                    }
                }
            }

            if (checar) return true;
            else return false;

        }

        public int getUltimaLocacao()
        {
            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não possível estabelecer a conexão com a base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select id from Locacao where id = (select max(id) from Locacao)", 
                stringConexao.conn);

            try
            {

                dataAdapter.Fill(ds);

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o Último id da locacao");
            }

            stringConexao.conn.Close();

            return Convert.ToInt16(ds.Tables[0].Rows[0][0]);
            
        }


        public int addFiadorLocacao(int id_Locacao, int id_Fiador)
        {
            int checar = 0;

            comando = new SqlCommand();

            try
            {

                stringConexao.conn.Open();

            }catch(SqlException ex)
            {
                MessageBox.Show("Não possível estabelecer a conexão com a base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "INSERT INTO Fiador_Locacao(id_Locacao, id_Fiador) VALUES " +
                "('" + id_Locacao + "', '" + id_Fiador + "')";

            try
            {

                checar = comando.ExecuteNonQuery();

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível gravar os dados Fiador_Locacao", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            return checar;
        }

        public void alteraStatusImovel(Locacao locacao)
        {
            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "UPDATE Imovel set status_Imovel = 'Indisponível' where id = '" + locacao.id_Imovel + "'";

            try
            {
                comando.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Falha ao modificar status do imóvel", "Mensagem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

            stringConexao.conn.Close();
        }

        public void setCurrentDate(Locacao locacao)
        {
            DateTime today = DateTime.Today;
            string dateTime = today.ToString();

            locacao.mtxDataLocacao.Text = dateTime.Substring(0, 10);
        }

        public void exibir(VerLocacoes verLocacoes)
        {

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select * from Locacao", stringConexao.conn);

            try
            {

                dataAdapter.Fill(ds);

            }catch(SqlException ex)
            {
                MessageBox.Show("Falha ao buscar as locações da base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            verLocacoes.dgvLocacoes.DataSource = ds.Tables[0];

        }

        public void deletar(VerLocacoes verLocacoes)
        {
            DataGridViewRow selectedRow = verLocacoes.dgvLocacoes.Rows[verLocacoes.linha];

            comando = new SqlCommand();

            int id_Locacao = Convert.ToInt16(selectedRow.Cells[0].Value);

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "Delete from Locacao where id = '" + id_Locacao + "'";

            

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro deletado com sucesso", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }catch(SqlException ex)
            {
                MessageBox.Show("Falha ao deletar locação", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

            stringConexao.conn.Close();

        }

        public void deletarFiadorLocacao(VerLocacoes verLocacoes)
        {
            DataGridViewRow selectedRow = verLocacoes.dgvLocacoes.Rows[verLocacoes.linha];
            int id_Locacao = Convert.ToInt16(selectedRow.Cells[0].Value);

            comando = new SqlCommand();

            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "Delete from Fiador_Locacao where id_Locacao = '" + id_Locacao + "'";

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro deletado com sucesso", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha ao deletar locação", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

            stringConexao.conn.Close();

        }

        public string getLocadorById(int id)
        {
            ds = new DataSet();
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select nome from Locador where id = '"+ id +"'", stringConexao.conn);

            try
            {
                dataAdapter.Fill(ds);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar na base de dados o nome do locador", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            return ds.Tables[0].Rows[0][0].ToString();

        }

        public string getLocatarioById(int id)
        {
            ds = new DataSet();
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select nome from Locatario where id = '" + id + "'", stringConexao.conn);

            try
            {
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar na base de dados o nome do locatario", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string getFiadorById(int id)
        {
            ds = new DataSet();
            try
            {
                stringConexao.conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Conexão falhou! Contate o administrador do sistema.", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select nome from Fiador where id = '" + id + "'", stringConexao.conn);

            try
            {
                dataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar na base de dados o nome do Fiador", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public void mostrarEditar(VerLocacoes verLocacoes, Locacao locacao)
        {
            DataGridViewRow selectedRow = verLocacoes.dgvLocacoes.Rows[verLocacoes.linha];

            

            locacao.pbLocacao.ImageLocation = selectedRow.Cells[1].Value.ToString();
            locacao.txtLocador.Text = getLocadorById(Convert.ToInt16(selectedRow.Cells[2].Value));
            locacao.txtLocatario.Text = getLocatarioById(Convert.ToInt16(selectedRow.Cells[3].Value));
            locacao.txtValorLocacao.Text = selectedRow.Cells[5].Value.ToString();
            locacao.txtFiador.Text = getFiadorById(Convert.ToInt16(selectedRow.Cells[4].Value));
            locacao.mtxDataLocacao.Text = selectedRow.Cells[6].Value.ToString();
            locacao.mtxDataFinal.Text = selectedRow.Cells[7].Value.ToString();

            locacao.btnSelecionarFiador.Visible = false;
            locacao.btnSelecionarLocatario.Visible = false;

            locacao.mtxDataFinal.Enabled = false;

            locacao.txtValorLocacao.Enabled = true;

            locacao.Visible = true;

        }

        public void editar(Locacao locacao)
        {
            comando = new SqlCommand();

            try
            {

                stringConexao.conn.Open();

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com a base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "Update Imovel set valor_Aluguel = '" + locacao.txtValorLocacao.Text + "' where id = " +
                "'" + locacao.id_Imovel + "'";

            try
            {

                comando.ExecuteNonQuery();
                MessageBox.Show("Valor do imóvel editado com sucesso", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível alterar o valor do imóvel", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

        }

        public void chamarFiadores(VerLocacoes verLocacoes, verFiadores fiadores)
        {
            DataGridViewRow selectedRow = verLocacoes.dgvLocacoes.Rows[verLocacoes.linha];

            int id_Locacao = Convert.ToInt16(selectedRow.Cells[0].Value);

            fiadores.btnOk.Text = "Selecionar";
            fiadores.lblFiadores.Text = "Selecione um fiador";

            fiadores.Visible = true;
        }

        public void addOutroFiadorLocacao(verFiadores fiadores)
        {
            comando = new SqlCommand();

            DataGridViewRow selectedRow = fiadores.dgvFiadores.Rows[fiadores.linha];

            int id_Fiador = Convert.ToInt16(selectedRow.Cells[0].Value);
            int id_Locacao = fiadores.id_Locacao;

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com a base de dados", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comando.Connection = stringConexao.conn;

            comando.CommandText = "INSERT INTO Fiador_Locacao(id_Locacao, id_Fiador) VALUES ('"+ id_Locacao +"', " +
                "'"+ id_Fiador +"')";

            try
            {

                comando.ExecuteNonQuery();
                MessageBox.Show("Fiador_Locacao foi adicionado com sucesso", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

            }catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível registrar o Fiador_Locacao", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

        }

        public void verDetalhe(VerLocacoes verLocacoes, Locacao locacao)
        {
            DataGridViewRow selectedRow = verLocacoes.dgvLocacoes.Rows[verLocacoes.linha];

            locacao.pbLocacao.ImageLocation = selectedRow.Cells[1].Value.ToString();
            locacao.txtLocador.Text = getLocadorById(Convert.ToInt16(selectedRow.Cells[2].Value));
            locacao.txtLocatario.Text = getLocatarioById(Convert.ToInt16(selectedRow.Cells[3].Value));
            locacao.txtValorLocacao.Text = selectedRow.Cells[5].Value.ToString();
            locacao.txtFiador.Text = getFiadorById(Convert.ToInt16(selectedRow.Cells[4].Value));
            locacao.mtxDataLocacao.Text = selectedRow.Cells[6].Value.ToString();
            locacao.mtxDataFinal.Text = selectedRow.Cells[7].Value.ToString();

            locacao.btnSelecionarFiador.Visible = false;
            locacao.btnSelecionarLocatario.Visible = false;
            locacao.btnSalvar.Visible = false;

            locacao.mtxDataFinal.Enabled = false;

            locacao.txtValorLocacao.Enabled = false;

            locacao.Visible = true;
        }

        public void verFiadoresDeUmaLocacao(VerLocacoes verLocacoes, verFiadores fiadores)
        {
            

            fiadores.gbFiadores.Visible = false;
            fiadores.btnAtualizar.Visible = false;
            fiadores.btnCadastrar.Visible = false;
            fiadores.btnDeletar.Visible = false;
            fiadores.btnEditar.Visible = false;

            DataSet ds1 = getFiadoresDeUmaLocacao(verLocacoes);

            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            foreach (DataTable table in ds1.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        int item = Convert.ToInt16(row[column]);
                        // read column and item

                        dataAdapter = new SqlDataAdapter("SELECT * from Fiador where id = '" + item +"'",
                            stringConexao.conn);

                        try
                        {

                            dataAdapter.Fill(ds);

                        }catch(SqlException ex)
                        {
                            MessageBox.Show("Não foi possível buscar os dados do Fiador", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
            }

            stringConexao.conn.Close();

            fiadores.dgvFiadores.DataSource = ds.Tables[0];

            fiadores.Visible = true;
        }

        public DataSet getFiadoresDeUmaLocacao(VerLocacoes verLocacoes)
        {
            DataGridViewRow selectedRow = verLocacoes.dgvLocacoes.Rows[verLocacoes.linha];

            int id_Locacao = Convert.ToInt16(selectedRow.Cells[0].Value);

            ds = new DataSet();

            try
            {

                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar com a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dataAdapter = new SqlDataAdapter("select id_Fiador from Fiador_Locacao where id_Locacao = '" + id_Locacao + "'",
                stringConexao.conn);

            try
            {

                dataAdapter.Fill(ds);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar os fiadores do Fiador_Locacao", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            stringConexao.conn.Close();

            return ds;
        }

    }
}
