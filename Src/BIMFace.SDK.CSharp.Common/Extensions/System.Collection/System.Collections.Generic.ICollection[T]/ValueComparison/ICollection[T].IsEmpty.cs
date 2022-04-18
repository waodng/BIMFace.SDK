using System.Collections.Generic;

namespace BIMFace.SDK.CSharp.Common.Extension
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  �Զ�����չ�������жϼ����Ƿ�Ϊ null ��Ԫ�صĸ�������0 
        /// </summary>
        /// <param name="this">��չ����</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this ICollection<T> @this)
        {
            return @this.Count == 0;
        }

        /// <summary>
        ///  �Զ�����չ�������жϼ����Ƿ�Ϊ null ��Ԫ�صĸ�������0��
        ///  �÷�����ͬ�� ICollection.IsNotNullAndEmpty()���� 
        /// </summary>
        /// <param name="this">��չ����</param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this ICollection<T> @this)
        {
            return @this.Count != 0;
        }
    }
}