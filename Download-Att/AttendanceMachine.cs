using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Oracle.DataAccess.Client;

namespace Download_Att
{
    class AttendanceMachine
    {
        private string connString = "Password=AXIOM;User ID=AXIOM;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=aa-srv)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)))";

        public object EMPLOYEE_CODE { get; set; }
        private int COMPANY_CODE { get { return 1; } }
        public int Emp_InOut { get { return 1; } }
        public DateTime Emp_Att_Date { get; set; }
        public int Emp_Hour { get; set; }
        public int Emp_Minuts { get; set; }
        private int Emp_Posted { get { return 0; } set { } }
        public string MACHINIP { get; set; }

       
        private int _LINE_SERIAL;
        private int LINE_SERIAL
        { 
            get 
            { 
                using (OracleConnection conn = new OracleConnection(connString))
                 {
                    conn.Open();
                    string str_LINE_SERIAL = "select Max(LINE_SERIAL) from ATTENDANCE_MACHINE";
                    using (OracleCommand cmd = new OracleCommand(str_LINE_SERIAL, conn))
                            {
                                this._LINE_SERIAL = int.Parse(cmd.ExecuteScalar().ToString());
                                conn.Close();
                                return this._LINE_SERIAL + 1;
                            }
                 }
            }
       

        }
 
        public bool insertLog()
        {
            using (OracleConnection conn = new OracleConnection(connString))
            {
                //ATTENDANCE_MACHINE
                conn.Open();
                String Saving = "Insert into AXIOM.ATTENDANCE_MACHINE (LINE_SERIAL, EMPLOYEE_CODE,COMPANY_CODE,IN_OUT,ATT_DATE,HOUR,MINUTE,POSTED,MACHINIP) VALUES (:1, :2,:3,:4,:5,:6,:7,:8,:9)";
                using (OracleCommand cmd = new OracleCommand(Saving, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Double, this.LINE_SERIAL, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Varchar2, this.EMPLOYEE_CODE, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Byte, this.COMPANY_CODE, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":4", OracleDbType.Byte, this.Emp_InOut, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":5", OracleDbType.Date, this.Emp_Att_Date, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":6", OracleDbType.Int16, this.Emp_Hour, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":7", OracleDbType.Int16, this.Emp_Minuts, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":8", OracleDbType.Byte, this.Emp_Posted, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter(":9", OracleDbType.Varchar2, this.MACHINIP, ParameterDirection.Input));

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return true;
        }


        public bool ExcutePeo()
        {
            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("BUILD_ATTENDANCE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return true;
        }

    }
}
