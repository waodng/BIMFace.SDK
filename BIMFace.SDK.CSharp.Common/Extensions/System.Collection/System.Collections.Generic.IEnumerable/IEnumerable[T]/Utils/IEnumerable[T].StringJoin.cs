using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���ķָ����Ž������е�Ԫ�ش�����һ���ַ���
        /// </summary>
        /// <typeparam name="T">�������Ͳ���</typeparam>
        /// <param name="this">��չ����</param>
        /// <param name="separator">�ָ�����</param>
        /// <returns></returns>
        internal static string JoinWith<T>(this IEnumerable<T> @this, string separator)
        {
            if (@this == null || @this.Any() == false)
                return "";

            return string.Join(separator, @this);
        }

        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���ķָ����Ž������е�Ԫ�ش�����һ���ַ���
        /// </summary>
        /// <typeparam name="T">�������Ͳ���</typeparam>
        /// <param name="this">��չ����</param>
        /// <param name="separator">�ָ�����</param>
        /// <returns></returns>
        internal static string JoinWith<T>(this IEnumerable<T> @this, char separator)
        {
            if (@this == null || @this.Any() == false)
                return "";

            return string.Join(separator.ToString(), @this);
        }

        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���ķָ����Ž������е�Ԫ�ش�����һ���ַ���
        /// </summary>
        /// <typeparam name="T">�������Ͳ���</typeparam>
        /// <param name="this">��չ����</param>
        /// <param name="separator">�ָ�����</param>
        /// <returns></returns>
        public static string ToStringWith<T>(this IEnumerable<T> @this, string separator)
        {
            if (@this == null || @this.Any() == false)
                return "";

            return string.Join(separator, @this);
        }

        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���ķָ����Ž������е�Ԫ�ش�����һ���ַ�����ÿ��������ʾΪ������һ�С�
        ///  �÷���һ�����ڽ��Զ�����Ķ��󼯺�ƴ�ӳɶ�����ʾ���ַ�����
        /// </summary>
        /// <typeparam name="T">�������Ͳ���</typeparam>
        /// <param name="this">��չ����</param>
        /// <param name="ignoreNullObj">�Ƿ���Լ�����Ϊ NULL �Ķ���</param>
        /// <returns></returns>
        public static string ToStringLine<T>(this IEnumerable<T> @this, bool ignoreNullObj = true)
        {
            if (@this == null || @this.Any() == false)
                return "";

            StringBuilder sb = new StringBuilder();
            foreach (var obj in @this)
            {
                if (obj != null)
                {
                    sb.AppendLine(obj.ToString());
                }
                else
                {
                    if (ignoreNullObj == false)
                    {
                        sb.AppendLine("NULL");
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���ķָ����Ž������е�Ԫ�ش�����һ���ַ�����ÿ��������ʾΪ������һ�С�
        ///  �÷���һ�����ڽ��Զ�����Ķ��󼯺�ƴ�ӳɶ�����ʾ���ַ�����
        /// </summary>
        /// <typeparam name="T">�������Ͳ���</typeparam>
        /// <param name="this">��չ����</param>
        /// <param name="separator">�ָ����š�</param>
        /// <param name="ignoreNullObj">�Ƿ���Լ�����Ϊ NULL �Ķ���</param>
        /// <returns></returns>
        public static string ToStringLineWith<T>(this IEnumerable<T> @this, string separator, bool ignoreNullObj = true)
        {
            if (@this == null || @this.Any() == false)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var obj in @this)
            {
                if (obj != null)
                {
                    sb.AppendLine(obj.ToString() + separator);
                }
                else
                {
                    if (ignoreNullObj == false)
                    {
                        sb.AppendLine("NULL");
                    }
                }
            }

            return sb.ToString();
        }



        /// <summary>
        ///  �Զ�����չ������ʹ��ָ���ķָ����Ž������е�Ԫ�ش�����һ���ַ���
        /// </summary>
        /// <typeparam name="T">�������Ͳ���</typeparam>
        /// <param name="this">��չ����</param>
        /// <param name="separator">�ָ�����</param>
        /// <returns></returns>
        public static string ToStringWith<T>(this IEnumerable<T> @this, char separator)
        {
            if (@this == null || @this.Any() == false)
            {
                return "";
            }
            return string.Join(separator.ToString(), @this);
        }
    }
}