using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Show Process List
            Console.WriteLine("============Process List==========");
            ManagementObjectCollection objects = new ManagementObjectSearcher("SELECT * FROM Win32_Process").Get();
            foreach (ManagementObject item in objects)
            {
                Console.WriteLine((item["Name"].ToString()));
            }
            //Creat Ban List
            Console.WriteLine("=========Bank List=========");
            string lst = "Communicator.exe,POWERPNT.exe,notepad.exe";
            string[] bannedProc = lst.Split(',');
            foreach (string s in bannedProc)
            {
                Console.WriteLine(s);
            }
            //Search and Destroy
            Console.WriteLine("==============Search and Destory=============");
            int count = 0;
            foreach (string item in bannedProc)
            {
                if (DetectProcess(item))
                {
                    count++;
                    Console.WriteLine("Process[{0}] was killed {1}.", item, KillProcess(item) ? "Successfully" : "Unsucessfully");

                }
            }
            Console.WriteLine("Done,{0}banned process found", count);

        }
        protected static bool DetectProcess(string processNam)
        {

            ManagementObjectCollection objects = new ManagementObjectSearcher("SELECT * FROM Win32_Process").Get();
            foreach (ManagementObject item in objects)
            {
                string str = item["Name"].ToString();
                if (str.Trim().ToUpper() == processNam.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        protected static bool KillProcess(string processName)
        {


            ManagementObjectCollection objects = new ManagementObjectSearcher("SELECT * FROM Win32_Process").Get();
            foreach (ManagementObject item in objects)
            {
                string str = item["Name"].ToString();
                if (str.Trim().ToUpper() == processName.Trim().ToUpper())
                {
                    string[] args = new string[] { "0" };
                    item.InvokeMethod("Terminate", args);
                    return true;
                }
            }
            return false;
        }
    }
}
