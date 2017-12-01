using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace RecordApp
{
    public class DBConnection
    {
        string ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;initial catalog=recordsDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        SqlConnection con;

        public void OpenConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        public void CloseConnection()
        {
            con.Close();
        }
        public void ExecQueries(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        public  SqlDataReader DataReader (string query)
        {
            SqlCommand cmd=new SqlCommand(query ,con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }

        public DataTable ShowDataInGridView(string query)
        {
            SqlDataAdapter dr = new SqlDataAdapter(query, ConnectionString);
            DataTable ds = new DataTable();
            dr.Fill(ds);
           
            return ds;
        }
        public void AddPlayer(string userName, string imagePath)
        {
           
            SqlCommand cmd = new SqlCommand(
                "spNewUser", con);
                    
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Name", userName));
            cmd.Parameters.Add(new SqlParameter("@imagePath", imagePath));

            SqlDataReader data = cmd.ExecuteReader();   
        }

      


        public void AddGame(int p1ID,int p1Stars,int p1Coins, int p2ID, int p2Stars, int p2Coins, int p3ID, int p3Stars, int p3Coins, int p4ID, int p4Stars, int p4Coins)
        {

            SqlCommand cmd = new SqlCommand(
                "spNewGame", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //player 1 
            cmd.Parameters.Add(new SqlParameter("@player1ID", p1ID));
            cmd.Parameters.Add(new SqlParameter("@player1stars", p1Stars));
            cmd.Parameters.Add(new SqlParameter("@player1coins", p1Coins));
            //player 2
            cmd.Parameters.Add(new SqlParameter("@player2ID", p2ID));
            cmd.Parameters.Add(new SqlParameter("@player2stars", p2Stars));
            cmd.Parameters.Add(new SqlParameter("@player2coins", p2Coins));
            //player 3
            cmd.Parameters.Add(new SqlParameter("@player3ID", p3ID));
            cmd.Parameters.Add(new SqlParameter("@player3stars", p3Stars));
            cmd.Parameters.Add(new SqlParameter("@player3coins", p3Coins));
            //player 4
            cmd.Parameters.Add(new SqlParameter("@player4ID", p4ID));
            cmd.Parameters.Add(new SqlParameter("@player4stars", p4Stars));
            cmd.Parameters.Add(new SqlParameter("@player4coins", p4Coins));

            //execute 
            SqlDataReader data = cmd.ExecuteReader();


        }

        public int GetWins(int playerId)
        {
            SqlCommand cmd = new SqlCommand(
                "getWinCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", playerId));

            SqlParameter parmOUT = new SqlParameter("@wins", SqlDbType.Int);
            parmOUT.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parmOUT);
            cmd.ExecuteNonQuery();
            int returnVALUE = (int)cmd.Parameters["@wins"].Value;
            return returnVALUE;
        }
       


    }
}
