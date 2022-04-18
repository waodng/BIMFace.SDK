using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    /// <summary>
    /// 用于向 ChromiumWebBrowser 对象加载的网页中注册的C#对象类，用于js与C#交互
    /// </summary>
    public class ChromiumWebBrowserBindObject3//: FrmCefSharpDemo2 /* 不建议继承自Form */
    {
        /// <summary>
        /// 测试网页js调用C#窗体中的方法次数
        /// </summary>
        /// <param name="fileId">模型/图纸ID</param>
        /// <param name="num1">参数1</param>
        /// <param name="num2">参数2</param>
        /// <returns></returns>
        public string TestParentCalcTimes(string fileId, int num1, int num2)
        {
            /* 特别说明，方法的返回值数据类型、参数的数据类型只能是简单类型。
            * 
            * 1、返回类型如果想使用复杂类型，如下操作：
            * （1）定义一个实体类
            * （2）给实体类对象的属性赋值
            * （3）将对象序列化为字符串
            * （4）返回字符串
            * （5）js 方法体中再将接收的字符串反序列化为对象即可操作
            * 
            * 2、参数使用复杂类型
            * （1）将参数的类型设置为字符串，js传入的值是json格式的字符串类型
            * （2）定义一个实体类与Json对应
            * （3）将字符串的值反序列化为实体类
            * （4）使用实体类对象
            */

            FrmDemoList.FrmCefSharpDemo3.CalcTimes();

            return string.Format("传入的参数分别是 fileId：{0} num1：{1}，num2：{2}，\r\n 加法运算 num1 + num2 = {3}", fileId, num1, num2, num1 + num2);
        }

        /// <summary>
        /// 测试网页js调用C#窗体中的方法次数
        /// </summary>
        /// <param name="fileId">模型/图纸ID</param>
        /// <param name="num1">参数1</param>
        /// <param name="num2">参数2</param>
        /// <returns></returns>
        public string TestCalcTimes(string fileId, int num1, int num2)
        {
            /* 特别说明，方法的返回值数据类型、参数的数据类型只能是简单类型。
            * 
            * 1、返回类型如果想使用复杂类型，如下操作：
            * （1）定义一个实体类
            * （2）给实体类对象的属性赋值
            * （3）将对象序列化为字符串
            * （4）返回字符串
            * （5）js 方法体中再将接收的字符串反序列化为对象即可操作
            * 
            * 2、参数使用复杂类型
            * （1）将参数的类型设置为字符串，js传入的值是json格式的字符串类型
            * （2）定义一个实体类与Json对应
            * （3）将字符串的值反序列化为实体类
            * （4）使用实体类对象
            */

            FrmDemoList.FrmCefSharpDemo3.CalcTimes();

            return string.Format("传入的参数分别是 fileId：{0} num1：{1}，num2：{2}，\r\n 加法运算 num1 + num2 = {3}", fileId, num1, num2, num1 + num2);
        }
    }
}
