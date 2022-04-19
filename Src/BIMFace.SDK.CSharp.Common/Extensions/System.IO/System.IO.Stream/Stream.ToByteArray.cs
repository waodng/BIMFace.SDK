using System.IO;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  �Զ�����չ���������ڴ���д����������鲢����
        /// </summary>
        /// <param name="this">��չ����������</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream @this)
        {
            if (@this == null)
                return null;

            using (var ms = new MemoryStream())
            {
                @this.CopyTo(ms);

                return ms.ToArray();
            }
        }
    }
}