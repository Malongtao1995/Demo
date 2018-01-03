using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式__银行取钱
{
    class Program
    {
        //---本例场景为当用户从银行账号里取出钱后，马上通知电子邮件和发手机短信---
        //本例中的订阅者，也就是观察者是电子邮件与手机
        //发布者，也就是被监视对象是银行账号


        //Obverser电子邮件，手机关心的对象e ,分别是邮件地址、手机号码、取款金额
        public class UserEventArgs : EventArgs
        {
            public readonly string emailAddress;
            public readonly string mobilePhone;
            public readonly string amount;
            public UserEventArgs(string emailAddress, string mobilePhone, string amount)
            {
                this.emailAddress = emailAddress;
                this.mobilePhone = mobilePhone;
                this.amount = amount;
            }
        }

        //发布者，也就是被监视的对象-银行账号
        class BankAccount
        {
            //声明一个处理银行交易的委托
            public delegate void ProcessTranEventHandler(object sender, UserEventArgs e);
            //声明一个事件
            public event ProcessTranEventHandler ProcessTran;

            protected virtual void OnProcessTran(UserEventArgs e)
            {
                if (ProcessTran != null)
                {
                    ProcessTran(this, e);
                }
            }

            public void Prcess(UserEventArgs e)
            {
                OnProcessTran(e);
            }
        }

        //观察者Email
        class Email
        {
            public static void SendEmail(object sender, UserEventArgs e)
            {
                Console.WriteLine("向用户邮箱" + e.emailAddress + "发送邮件:您在" + System.DateTime.Now.ToString() + "取款金额为" + e.amount);
            }
        }

        //观察者手机
        class Mobile
        {
            public static void SendNotification(object sender, UserEventArgs e)
            {
                Console.WriteLine("向用户手机" + e.mobilePhone + "发送短信:您在" + System.DateTime.Now.ToString() + "取款金额为" + e.amount);
            }
        }

        //订阅系统，实现银行系统订阅几个Observer，实现与客户端的松耦合
        class SubscribSystem
        {
            public SubscribSystem()
            {

            }

            public SubscribSystem(BankAccount bankAccount, UserEventArgs e)
            {
                //现在我们在银行账户订阅2个，分别是电子邮件和手机短信
                bankAccount.ProcessTran += new BankAccount.ProcessTranEventHandler(Email.SendEmail);
                bankAccount.ProcessTran += new BankAccount.ProcessTranEventHandler(Mobile.SendNotification);
                bankAccount.Prcess(e);
            }
        }

        class Client
        {
            public static void Main(string[] args)
            {
                Console.Write("请输入您要取款的金额：");
                string amount = Console.ReadLine();
                Console.WriteLine("交易成功，请取磁卡。");
                //初始化e
                UserEventArgs user = new UserEventArgs("jinjiangbo2008@163.com", "18868789776", amount);
                //初始化订阅系统
                SubscribSystem subject = new SubscribSystem(new BankAccount(), user);
                Console.ReadKey();
            }
        }
    }
}
