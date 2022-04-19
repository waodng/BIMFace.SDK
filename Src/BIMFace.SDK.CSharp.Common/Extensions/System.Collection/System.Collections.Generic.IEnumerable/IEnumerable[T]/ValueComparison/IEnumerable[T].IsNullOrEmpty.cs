using System.Collections.Generic;
using System.Linq;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  �Զ�����չ�������жϼ����Ƿ�Ϊ null ���߲������κ�Ԫ��
        /// </summary>
        /// <param name="this">��չ����</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        /// <summary>
        ///  �Զ�����չ�������жϼ����Ƿ�Ϊ null �Ұ���Ԫ��
        /// </summary>
        /// <param name="this">��չ����</param>
        /// <returns></returns>
        public static bool IsNotNullAndEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }
    }
}