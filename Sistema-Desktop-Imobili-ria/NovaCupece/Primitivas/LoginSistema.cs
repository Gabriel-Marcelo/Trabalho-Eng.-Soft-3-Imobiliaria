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
    class LoginSistema
    {

        StringConexao stringConexao = new StringConexao();



        
        public SqlCommand comando;
        DataSet ds;
        SqlDataAdapter dataAdapter;

        public int logar(TextBox usuario, TextBox senha)
        {
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema");
            }

            int existir;

            dataAdapter = new SqlDataAdapter("select id from Logar where usuario = '"+ usuario.Text +"' and " +
                "senha = '"+ senha.Text +"'", stringConexao.conn);
            ds = new DataSet();

           
            existir = dataAdapter.Fill(ds);
           

            stringConexao.conn.Close();

            if (existir == 1) return 1;
            else return 0;

        }

        public int getId(int id)
        {
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema");
            }

            dataAdapter = new SqlDataAdapter("select id from Logar where id = '"+ id +"'", stringConexao.conn);
            ds = new DataSet();

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            return Convert.ToInt16(ds.Tables[0].Rows[0].Field<int?>("id"));
        }

        public int getId(TextBox txtUsuario)
        {
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema");
            }

            dataAdapter = new SqlDataAdapter("select id from Logar where usuario = '" + txtUsuario.Text + "'", stringConexao.conn);
            ds = new DataSet();

           int retorno = dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            if(retorno != 0)
            {
                return Convert.ToInt16(ds.Tables[0].Rows[0].Field<int?>("id"));
            }
            return 0;
        }

        public String getUser(int id)
        {
            try
            {
                stringConexao.conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha na conexão!Contate o administrador do sistema");
            }

            dataAdapter = new SqlDataAdapter("select usuario from Logar where id = '" + id + "'", stringConexao.conn);
            ds = new DataSet();

            dataAdapter.Fill(ds);

            stringConexao.conn.Close();

            //return ds.Tables[0].Rows[0].Field<String?>("usuario").ToString();
            return ds.Tables[0].Rows[0]["usuario"].ToString();
        }


        public int getFuncByIdUser(int id_Usuario)
        {
            int retorno;

            ds = new DataSet();

            try
            {
                stringConexao.conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível conectar a base de dados", "Mensagem", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            try
            {
                dataAdapter = new SqlDataAdapter("select id_Func from Logar where id = '"+ id_Usuario +"'", 
                    stringConexao.conn);
                dataAdapter.Fill(ds);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Não foi possível buscar o id do funcionário na entidade Logar",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            stringConexao.conn.Close();
            try
            {
                retorno = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
            }
            catch(Exception ex)
            {
                retorno = -1;
            }

            return retorno;
        }

    }
}
