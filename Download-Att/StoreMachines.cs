using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Client

namespace Download_Att
{
    class StoreMachines
    {
        //private string _connString = "Provider=OraOLEDB.Oracle.1;Password=AXIOM;Persist Security Info=True;User ID=AXIOM;Data Source=orcl";
        private string _connString = "Password=AXIOM;User ID=AXIOM;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=aa-srv)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)))";

        private string Machines_IP { get; set; }
       private int Machines_Port { get; set; }
       private string Machines_Type { get; set; }
       private string Machines_Location { get; set; }
       private bool Machines_Status { get; set; }
       private string Machines_Version { get; set; }

      
       private List<string> _listArray = new List<string>();
       public  List<string> GetMachineIPs()
        {
           
            using (OracleConnection conn = new OracleConnection(_connString))
            {
                conn.Open();
               
                string MACHINE = "select * from MUHAMMAD_MACHINE_ALL where STATUS =1";
                using (OracleCommand cmd = new OracleCommand(MACHINE, conn))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    {
                      while (dr.Read())
                        {
                           string IP = dr["ip_Machin"].ToString();
                           _listArray.Add(IP);
                        }
                        dr.Close();
                        conn.Close();
                        return _listArray;

                    }
                }
            }
        }

        //Oracle.DataAccess.Client.OracleConnection
        private int _machineCount;
        public int GetMachineCount
        {
            get
            {
                using (OracleConnection conn = new OracleConnection(_connString))
                {
                    conn.Open();
                    string str_MachineCount = "select count(ip_Machin) from MUHAMMAD_MACHINE_ALL where STATUS =1";
                    using (OracleCommand cmd = new OracleCommand(str_MachineCount, conn))
                    {
                        this._machineCount = int.Parse(cmd.ExecuteScalar().ToString());
                        conn.Close();
                        return this._machineCount;
                    }
                }
            }

        }

        //enum machinType {New, Old};
        private string _machinType;
        public string GetMachinType(string ip)
        {
            using (OracleConnection conn = new OracleConnection(_connString))
            {
                conn.Open();
                string str_machinType = "select Type from MUHAMMAD_MACHINE_ALL where IP_MACHIN ='" + ip + "' ";
                using (OracleCommand cmd = new OracleCommand(str_machinType, conn))
                {
                    _machinType = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            return _machinType;

        }
           
       
 
        
    }
}
