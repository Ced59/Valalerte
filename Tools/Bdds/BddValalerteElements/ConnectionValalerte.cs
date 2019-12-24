using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ValarAlerte.Tools.Bdds.BddValalerte
{
    public class ConnectionValalerte
    {
        private static SqlConnection _instance = null;
        private static readonly object _lock = new object();
        public static SqlConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {

                        _instance = new SqlConnection(PassConnection.ConnectionBddValalerte());

                        try
                        {
                            _instance.Open();
                            _instance.Close();
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            try
                            {
                                _instance = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "\"E:\\Projets VALAREP\\ValarAlerte\\Bdd\\Valalerte.mdf\";Integrated Security=True;Connect Timeout=30");
                            }
                            catch
                            {
                                _instance = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "\"D:\\Projets VALAREP\\ValarAlerte\\Bdd\\Valalerte.mdf\";Integrated Security=True;Connect Timeout=30");
                            }
                           

                        }


                    }
                    return _instance;
                }
            }
        }
        private ConnectionValalerte()
        {

        }
    }
}



