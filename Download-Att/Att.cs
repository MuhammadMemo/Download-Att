using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using System.Data;
using Axzkemkeeper;
using zkemkeeper;
using ZKFPEngXControl;


namespace Download_Att
{
    class Att
    {
      public  bool GetDate()
        {
            getMachineIP();
            return true;
        }
      private MainForm frm = new MainForm();
      private void connetMachin(string ip)
      {
            zkemkeeper.CZKEM ZK = new zkemkeeper.CZKEM();
            if (ZK.Connect_Net(ip, 4370))
          {

              downloadLog();
              
          }
      }
        private DateTime dateMarge;
        private int vMachineNumber, dwtmachenNi, iSacand, virMod, outMod, dwYear, iMonth, iDay, iHour, iMinute, dwEnrollNumber, dwemachenNi;
        string dwEnrollNumbers;
       
        //FROM MUHAMMAD_MACHINE_ALL  m full join MUHAMMAD_MACHINE_LOG g
      private  void downloadLog()
        {
            int CountLog=0;
            zkemkeeper.CZKEM ZK = new  zkemkeeper.CZKEM();


            ZK.ReadGeneralLogData(vMachineNumber);

              if (machinType(ip) == "Old")
              {
                  while (ZK.GetAllGLogData(vMachineNumber, ref  dwtmachenNi,ref dwEnrollNumber, ref  dwemachenNi, ref  virMod, ref  outMod, ref  dwYear, ref  iMonth, ref  iDay, ref  iHour, ref  iMinute))
                  {
                      dateMarge = Convert.ToDateTime(iDay + "/" + iMonth + "/" + dwYear);
                     
                      CountLog = CountLog + 1;
                      
                      this.insertLogOld();
                      this.insertLogBackupOld();
                  }
              }
              else{
                  while (ZK.SSR_GetGeneralLogData(vMachineNumber, out  dwEnrollNumbers, out  virMod, out  outMod, out  dwYear, out  iMonth, out  iDay, out  iHour, out  iMinute, out  iSacand, ref  dwtmachenNi))
                  {
                      dateMarge = Convert.ToDateTime(iDay + "/" + iMonth + "/" + dwYear);
                     
                      CountLog = CountLog + 1;
                      this.insertLog();
                      this.insertLogBackup();
                  }
                  }
              
             ZK.ClearGLog(vMachineNumber);

             ZK.SetDeviceTime(vMachineNumber);
          

        }
        //Ok
      private string connString = "Password=AXIOM;User ID=AXIOM;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=hr-srv)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)))";
      private string ip;
      private void getMachineIP()
        {

            using (OracleConnection conn = new OracleConnection(connString))
            {
                
                conn.Open();
                zkemkeeper.CZKEM ZK = new zkemkeeper.CZKEM();
                string MACHINE = "select * from MUHAMMAD_MACHINE_ALL where STATUS =1";
                using (OracleCommand cmd = new OracleCommand(MACHINE, conn))
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    {
                        while (dr.Read())
                        {
                            ip = dr["ip_Machin"].ToString();
                            this.connetMachin(ip);
                            
                        }
                        dr.Close();
                        conn.Close();
                        //frm.IPLabel.Text = "";
                        frm.statusStrip1.Text = "";
                        ZK.Disconnect();
                        
                    }
                }
            } 
        }
      //ok
      private bool insertLog()
      {
          using (OracleConnection conn = new OracleConnection(connString))
          {
              conn.Open();
              String Saving = "Insert into AXIOM.ATTENDANCE_MACHINE (LINE_SERIAL, EMPLOYEE_CODE,COMPANY_CODE,IN_OUT,ATT_DATE,HOUR,MINUTE,POSTED) VALUES (:1, :2,:3,:4,:5,:6,:7,:8)";
              using (OracleCommand cmd = new OracleCommand(Saving, conn))
              {
                  cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Double, this.get_LINE_SERIAL(), ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Double, this.dwEnrollNumbers, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Byte, 1, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":4", OracleDbType.Byte, 1, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":5", OracleDbType.Date, this.dateMarge, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":6", OracleDbType.Int16, this.iHour, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":7", OracleDbType.Int16, this.iMinute, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":8", OracleDbType.Byte, 0, ParameterDirection.Input));

                  cmd.ExecuteNonQuery();
                  conn.Close();
              }
          }
          return true;
      }

      private bool insertLogOld()
      {
          using (OracleConnection conn = new OracleConnection(connString))
          {
              conn.Open();
              String Saving = "Insert into AXIOM.ATTENDANCE_MACHINE (LINE_SERIAL, EMPLOYEE_CODE,COMPANY_CODE,IN_OUT,ATT_DATE,HOUR,MINUTE,POSTED) VALUES (:1, :2,:3,:4,:5,:6,:7,:8)";
              using (OracleCommand cmd = new OracleCommand(Saving, conn))
              {
                  cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Double, this.get_LINE_SERIAL(), ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Varchar2, this.dwEnrollNumber, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Byte, 1, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":4", OracleDbType.Byte, 1, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":5", OracleDbType.Date, this.dateMarge, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":6", OracleDbType.Int16, this.iHour, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":7", OracleDbType.Int16, this.iMinute, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":8", OracleDbType.Byte, 0, ParameterDirection.Input));

                  cmd.ExecuteNonQuery();
                  conn.Close();
              }
          }
          return true;
      }


      private bool insertLogBackupOld()
      {
          using (OracleConnection conn = new OracleConnection(connString))
          {
              conn.Open();
              String Saving = "Insert into AXIOM.MUHAMMAD_MACHINE_BACKUP (IP_MACHIN,EMPLOYEE_CODE,ATT_DATE,HOUR,MINUTE) VALUES (:1, :2,:3,:4,:5)";
              using (OracleCommand cmd = new OracleCommand(Saving, conn))
              {
                  cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Varchar2, this.ip, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Double, this.dwEnrollNumber, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Date, this.dateMarge, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":4", OracleDbType.Int16, this.iHour, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":5", OracleDbType.Int16, this.iMinute, ParameterDirection.Input));
                  //cmd.Parameters.Add(new OracleParameter(":8", OracleDbType.Byte, 0, ParameterDirection.Input));

                  cmd.ExecuteNonQuery();
                  conn.Close();
              }
          }
          return true;
      }

      private bool insertLogBackup()
      {
          using (OracleConnection conn = new OracleConnection(connString))
          {
              conn.Open();
              String Saving = "Insert into AXIOM.MUHAMMAD_MACHINE_BACKUP (IP_MACHIN,EMPLOYEE_CODE,ATT_DATE,HOUR,MINUTE) VALUES (:1, :2,:3,:4,:5)";
              using (OracleCommand cmd = new OracleCommand(Saving, conn))
              {
                  cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Varchar2, this.ip, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Double, this.dwEnrollNumbers, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Date, this.dateMarge, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":4", OracleDbType.Int16, this.iHour, ParameterDirection.Input));
                  cmd.Parameters.Add(new OracleParameter(":5", OracleDbType.Int16, this.iMinute, ParameterDirection.Input));
                  //cmd.Parameters.Add(new OracleParameter(":8", OracleDbType.Byte, 0, ParameterDirection.Input));

                  cmd.ExecuteNonQuery();
                  conn.Close();
              }
          }
          return true;
      }
//ok
      private int LINE_SERIAL;
      int get_LINE_SERIAL()
      {
          using (OracleConnection conn = new OracleConnection(connString))
          {
              conn.Open();
              string str_LINE_SERIAL = "select Max(LINE_SERIAL) from ATTENDANCE_MACHINE";
              using (OracleCommand cmd = new OracleCommand(str_LINE_SERIAL, conn))
              {
                  LINE_SERIAL = int.Parse(cmd.ExecuteScalar().ToString());
              }
              conn.Close();
          }
          return LINE_SERIAL + 1;
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

       //enum machinType {New, Old};
        private string _machinType;
        private string machinType(string ip)
           {
               using (OracleConnection conn = new OracleConnection(connString))
             {
              conn.Open();
              string str_machinType = "select Type from MUHAMMAD_MACHINE_ALL where IP_MACHIN ='"+ip+"' ";
              using (OracleCommand cmd = new OracleCommand(str_machinType, conn))
              {
                  _machinType =cmd.ExecuteScalar().ToString();
              }
              conn.Close();
          }
               return _machinType;
           
           }
           
       

        

    }
}
