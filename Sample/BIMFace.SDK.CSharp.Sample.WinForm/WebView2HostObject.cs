
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    /// <summary>
    ///  使用WebView组件时，向网页注入的对象类，供js调用C#方法使用
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class WebView2HostObject
    {
        /* 1、微软官方文档教程 https://docs.microsoft.com/zh-cn/microsoft-edge/webview2/
         * 2、示例下载 https://github.com/MicrosoftEdge/WebView2Samples
         */

        /// <summary>
        /// 测试计算2个整数的加法
        /// </summary>
        /// <param name="fileId">模型/图纸ID</param>
        /// <param name="num1">参数1</param>
        /// <param name="num2">参数2</param>
        /// <returns></returns>
        public string TestCalcAdd(string fileId, int num1, int num2)
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

            MessageBox.Show("C#方法 TestCalcAdd() 被调用。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return string.Format("网页端响应：传入的参数分别是 fileId：{0} num1：{1}，num2：{2}，\r\n 加法运算 num1 + num2 = {3}", fileId, num1, num2, num1 + num2);
        }
    }
}
