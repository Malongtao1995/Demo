using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflexss
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 查看类型的结构
            //string n = "ss";

            //Type type = n.GetType();
            //foreach (MemberInfo item in type.GetMembers())
            //{
            //    Console.WriteLine("{0}\t{1}", item.MemberType, item.Name);
            //}
            #endregion
            #region 查看类中的构造函数
            //Class1 class1 = new Class1();
            //Type type = class1.GetType();
            //ConstructorInfo[] ss = type.GetConstructors();
            //foreach (ConstructorInfo item in ss)
            //{
            //    ParameterInfo[] ps = item.GetParameters();
            //    foreach (ParameterInfo item1 in ps)
            //    {
            //        Console.WriteLine(item1.Name);
            //    }

            //}
            #endregion
            #region 利用构造函数动态生成对象
            //Type t = typeof(Class1);
            //Type[] pt = new Type[2];
            //pt[0]=typeof(string);
            //pt[1]=typeof(int);
            //ConstructorInfo ci = t.GetConstructor(pt);//获取到构造函数
            //object[] obj = new object[] { "ss",1};
            //object o = ci.Invoke(obj);
            //((Class1)o).SS();
            #endregion
            #region Activator生成对象
            //Type t = typeof(Class1);
            //object o = Activator.CreateInstance(t, "sg", 1);
            //((Class1)o).SS();
            #endregion
            #region 查看类的属性
            //Class1 n = new Class1();

            //Type type = n.GetType();

            //PropertyInfo[] pis = type.GetProperties();
            //foreach (PropertyInfo item in pis)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion
            #region 查看类中的public方法
            //Class1 class1 = new Class1();
            //Type t = class1.GetType();
            //MethodInfo[] mis = t.GetMethods();
            //foreach (var item in mis)
            //{
            //    Console.WriteLine(item.ReturnType+" "+item.Name);
            //}
            #endregion
            #region 查看类中的public字段
            //Class1 class1 = new Class1();
            //Type type = class1.GetType();
            //FieldInfo[] fieldinfo = type.GetFields();
            //foreach (var item in fieldinfo)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion
            #region 用反射生成对象，并调用属性，方法和字段进行操作
            Reflexs.Class1 class1 = new  Reflexs.Class1();
            Type type = class1.GetType();
            object obj = Activator.CreateInstance(type);
            string file = ((Reflexs.Class1)obj).filed;//通过反射新生成的对象 点出字段的值
            FieldInfo fi = type.GetField("filed");//通过fi.GetValue(obj).ToString();获取字段的值
            fi.SetValue(obj, "dd");//设置字段的值
            PropertyInfo pi1 = type.GetProperty("Name");//获取属性的值
            pi1.SetValue(obj, "dc", null);//设置属性的值
            MethodInfo methodinfo = type.GetMethod("SS");//获取方法的值
            methodinfo.Invoke(obj, null);//调用方法
            #endregion
            #region assembly类获取程序集
            //Assembly ass = Assembly.Load("ClassLibrary1");
            //Type t = ass.GetType("ClassLibrary1.Class1");//获取类
            //ClassLibrary1.Class1 sd = new ClassLibrary1.Class1();
            //MethodInfo method = t.GetMethod("SSSd");
            //method.Invoke(sd, null);
            #endregion  

        }
    }
}
