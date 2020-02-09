using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace NovaCupece.Classes_Adicionais
{
    class StringConexao
    {


        /// //////////////**********************Da Escola******************//////////////
        //public SqlConnection conn = new SqlConnection("Server=SRVSQL;Database=LBDT-G01;User Id=aluno;Password=aluno;");


        /// //////////////**********************Gabriel******************//////////////
        //public SqlConnection conn = new SqlConnection("Server=localhost;Database=TesteImob;User Id=sa;Password=123456;");

        /// //////////////**********************Thiago******************//////////////
        public SqlConnection conn = new SqlConnection("Server=DESKTOP-BPPDA5V;Database=TesteImob;Trusted_Connection=True");

    }
}
