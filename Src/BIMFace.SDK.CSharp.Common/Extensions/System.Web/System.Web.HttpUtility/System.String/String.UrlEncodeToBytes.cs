using System;
using System.Text;
using System.Web;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        /// �Զ�����չ������ʹ��ָ���ı�������ַ���ת��Ϊ URL ������ֽ�����
        /// </summary>
        /// <param name="str">Ҫ������ı�</param>
        /// <returns>һ���ѱ�����ֽ�����</returns>
        public static byte[] UrlEncodeToBytes(this string str)
        {
            return HttpUtility.UrlEncodeToBytes(str);
        }

        /// <summary>
        /// �Զ�����չ������ʹ��ָ���ı�������ַ���ת��Ϊ URL ������ֽ�����
        /// </summary>
        /// <param name="str">Ҫ������ı�</param>
        /// <param name="e">ָ�����뷽���� System.Text.Encoding ����</param>
        /// <returns>һ���ѱ�����ֽ�����</returns>
        public static byte[] UrlEncodeToBytes(this string str, Encoding e)
        {
            return HttpUtility.UrlEncodeToBytes(str, e);
        }
    }
}