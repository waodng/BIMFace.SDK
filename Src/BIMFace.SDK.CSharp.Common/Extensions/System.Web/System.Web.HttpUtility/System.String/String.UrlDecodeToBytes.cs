using System.Text;
using System.Web;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���Ľ������ URL ������ַ���ת��Ϊ�ѽ�����ֽ�����
        /// </summary>
        /// <param name="str">Ҫ������ַ���</param>
        /// <returns>һ���ѽ�����ֽ�����</returns>
        public static byte[] UrlDecodeToBytes(this string str)
        {
            return HttpUtility.UrlDecodeToBytes(str);
        }

        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���Ľ������ URL ������ַ���ת��Ϊ�ѽ�����ֽ�����
        /// </summary>
        /// <param name="str">Ҫ������ַ���</param>
        /// <param name="e">ָ�����뷽���� System.Text.Encoding ����</param>
        /// <returns>һ���ѽ�����ֽ�����</returns>
        public static byte[] UrlDecodeToBytes(this string str, Encoding e)
        {
            return HttpUtility.UrlDecodeToBytes(str, e);
        }
    }
}