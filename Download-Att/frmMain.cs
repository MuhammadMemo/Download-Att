using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Axzkemkeeper;
using zkemkeeper;
using ZKFPEngXControl;




namespace Download_Att
{
     
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            
            //toolStripStatusLabel1.Text = "start";
            if (backgroundWorker1.IsBusy==false)
            {
                backgroundWorker1.RunWorkerAsync();
                timer1.Enabled = true;
                //timer1.Start();
            }

            //toolStripStatusLabel1.Text = "End";
           
         }
        

        private void Form1_Load(object sender, EventArgs e)
        {

           
            this.Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add("Start Programe..................."  + "   " + DateTime.Now);
            });


            //toolStripStatusLabel1.Text = "start";
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync();
                timer1.Enabled = true;
                //timer1.Start();
            }

        }

        private void Exite_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //ZK.ClearGLog();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
        private int vMachineNumber ,dwtmachenNi, dwBakup, dwEable, dwYea;
   string   dwEnrollNumbers;
   byte dwPriv;

   private int a1, a2, a3, a4, a5,a6,a7;
        private void butStorData_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void butAbout_Click(object sender, EventArgs e)
        {
           
        }

        private void tmrRun_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

           

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {

           //string ip = "192.168.0.195" ;
           // int n=0,y=0,m=0,d=0,h=0,mn=0,s=0;

            //if (ZK.Connect_Net(ip, 4370))
            //{
            //    //ZK.GetDeviceTime(n, ref y, ref m, ref d, ref h, ref mn, ref s);

            //    ZK.SetDeviceTime(n);

            //    //MessageBox.Show(mn.ToString(), s.ToString());
            //}
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
         //   //frm.ZK.SetDeviceTime(vMachineNumber);
         //   AttendanceMachine att = new AttendanceMachine();
         //   //att.ExcutePeo();//BUILD_ATTENDANCE StoredProcedure after get data
         //   //MessageBox.Show("Done");
         //   int vMachineNumber = 0,i=0,v=0;
         //   ZK.Connect_Net("192.168.0.141", 4370);
         //   ZK.ReadGeneralLogData(vMachineNumber);

         //textBox1.Text=   ZK.GetDeviceInfo(vMachineNumber, i, ref v).ToString();

                          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    progressBar1.Value = i;
            //    System.Threading.Thread.Sleep(10);
            //    label2.Text =  i.ToString();
            //    label2.Refresh();
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {

            
          

            //foreach (string ip in mIPs.GetMachineIPs())
            //{
            //    int CountLog = 0;

               
            //    if (mIPs.GetMachinType(ip) == "Old")
            //    {
            //        while (ZK.GetAllGLogData(vMachineNumber, ref  dwtmachenNi, ref dwEnrollNumber, ref  dwemachenNi, ref  virMod, ref  outMod, ref  dwYear, ref  iMonth, ref  iDay, ref  iHour, ref  iMinute))
            //        {
            //            dateMarge = Convert.ToDateTime(iDay + "/" + iMonth + "/" + dwYear);
            //            CountLog = CountLog + 1;

            //            att.Emp_Att_Date = dateMarge;
            //            att.EMPLOYEE_CODE = dwEnrollNumber;
            //            att.Emp_Hour = iHour;
            //            att.Emp_Minuts = iMinute;
            //            att.insertLog();
            //            //this.insertLogOld();
            //            //this.insertLogBackupOld();
            //        }
            //    }
            //    else
            //    {
            //        while (ZK.SSR_GetGeneralLogData(vMachineNumber, out  dwEnrollNumbers, out  virMod, out  outMod, out  dwYear, out  iMonth, out  iDay, out  iHour, out  iMinute, out  iSacand, ref  dwtmachenNi))
            //        {
            //            dateMarge = Convert.ToDateTime(iDay + "/" + iMonth + "/" + dwYear);

            //            CountLog = CountLog + 1;

            //            att.Emp_Att_Date = dateMarge;
            //            att.EMPLOYEE_CODE = dwEnrollNumber;
            //            att.Emp_Hour = iHour;
            //            att.Emp_Minuts = iMinute;
            //            att.insertLog();

            //            //cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Double, this.LINE_SERIAL, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Double, this.EMPLOYEE_CODE, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Byte, this.COMPANY_CODE, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":4", OracleDbType.Byte, this.Emp_InOut, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":5", OracleDbType.Date, this.Emp_Att_Date, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":6", OracleDbType.Int16, this.Emp_Hour, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":7", OracleDbType.Int16, this.Emp_Minuts, ParameterDirection.Input));
            //            //cmd.Parameters.Add(new OracleParameter(":8", OracleDbType.Byte, this.Emp_Posted, ParameterDirection.Input));
                       
            //        }
            //    }

            //   //ZK.ClearGLog(vMachineNumber);
            //   //ZK.SetDeviceTime(vMachineNumber);
            //}
            
        }
        static int countDownloadGenaral = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           //ZK.
            
            StoreMachines mIPs = new StoreMachines();
            AttendanceMachine att = new AttendanceMachine();

            DateTime dateMarge;
            int vMachineNumber = 0, dwtmachenNi = 0, iSacand = 0, virMod = 0, outMod = 0, dwYear = 0, iMonth = 0, iDay = 0, iHour = 0, iMinute = 0, dwEnrollNumber = 0, dwemachenNi = 0;
            int CountLog = 0, IPCount = 0, countLogGenaral = 0;

       

            
          string dwEnrollNumbers;

          int   IPCountMachint = mIPs.GetMachineCount;

            this.Invoke((MethodInvoker)delegate
            {
                countDownloadGenaral += 1;
                listBox1.Items.Add("Start Downloading........." + countDownloadGenaral + "/      " + IPCountMachint + " Machine " + "/   " + DateTime.Now);
            });

           
            foreach (string IPs in mIPs.GetMachineIPs())
            {
                zkemkeeper.CZKEM ZK = new zkemkeeper.CZKEM();
                //string IPs = "192.168.0.152";//test
                ZK.Connect_Net(IPs, 4370);
                ZK.ReadGeneralLogData(vMachineNumber);



                IPCount += 1;
                    this.Invoke((MethodInvoker)delegate
                    {
    
                        listBox1.Items.Add(IPCount + ".    " + "Connecting to........ " + " " + IPs + "/     " + DateTime.Now);
                    });
              //System.Threading.Thread.Sleep(1000);
              
                //Get Machin Type in database {New-Old}
                if (mIPs.GetMachinType(IPs) == "Old")
                {
                    while (ZK.GetAllGLogData(vMachineNumber, ref  dwtmachenNi, ref dwEnrollNumber, ref  dwemachenNi, ref  virMod, ref  outMod, ref  dwYear, ref  iMonth, ref  iDay, ref  iHour, ref  iMinute))
                    {
                        //flagGetMachin = true;

                        dateMarge = Convert.ToDateTime(iDay + "/" + iMonth + "/" + dwYear);
                        CountLog += 1;
                        countLogGenaral += 1;
                         
                        att.Emp_Att_Date = dateMarge;
                        att.EMPLOYEE_CODE = dwEnrollNumber;
                        att.Emp_Hour = iHour;
                        att.Emp_Minuts = iMinute;
                        att.MACHINIP = IPs;
                        att.insertLog();
                    }
                }
                else
                {
                    while (ZK.SSR_GetGeneralLogData(vMachineNumber, out  dwEnrollNumbers, out  virMod, out  outMod, out  dwYear, out  iMonth, out  iDay, out  iHour, out  iMinute, out  iSacand, ref  dwtmachenNi))
                    {
                        //flagGetMachin = true;
                        dateMarge = Convert.ToDateTime(iDay + "/" + iMonth + "/" + dwYear);
                        CountLog += 1;
                        countLogGenaral += 1;

                        att.Emp_Att_Date = dateMarge;
                        att.EMPLOYEE_CODE = dwEnrollNumbers;
                        att.Emp_Hour = iHour;
                        att.Emp_Minuts = iMinute;
                        att.MACHINIP = IPs;
                        att.insertLog();
                    }
                }
                ZK.ClearGLog(vMachineNumber);
                ZK.SetDeviceTime(vMachineNumber); 

                this.Invoke((MethodInvoker)delegate
                {
                    string s = IPCount + ".   " + "Connected to........ " + " " + IPs + " /" + DateTime.Now  +"/  " + CountLog + "  Record  " ;
                    listBox1.Items[listBox1.Items.Count-1] = s;
                });

                CountLog = 0;
                //System.Threading.Thread.Sleep();

            }//for
            //System.Threading.Thread.Sleep(10000);

            if (countLogGenaral>0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("Bulding.........................." + countLogGenaral + "  Record /  " + DateTime.Now);
                });

                att.ExcutePeo();//BUILD_ATTENDANCE StoredProcedure after get data

                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("End.............................................." + "/    " + DateTime.Now);
                    listBox1.Items.Add("*********************************************************************************************");
                });

            }
            else
            { 
            this.Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add("No Data any machin!..................." + "/    " + DateTime.Now);
                listBox1.Items.Add("End.............................................." + "/    " + DateTime.Now);
                listBox1.Items.Add("*************************************************************************************************");
            });

            }
           

        
            IPCount = 0;
            //flagGetMachin = false;
            countLogGenaral = 0;
            IPCountMachint = 0;
            //System.Threading.Thread.Sleep(120000);

                    
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            //progressBar1.Update()

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AttendanceMachine att = new AttendanceMachine();

            att.ExcutePeo();//BUILD_ATTENDANCE StoredProcedure after get data
            MessageBox.Show("Done");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "start";

            //label1.Text=timer1.
            if (backgroundWorker1.IsBusy == false)
            {

                backgroundWorker1.RunWorkerAsync();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "start";
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync();
                timer1.Enabled = true;
                //timer1.Start();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show())
            //{ 
            
            //}
            e.Cancel = true;
            MessageBox.Show("No");

        }

       
    }
}
