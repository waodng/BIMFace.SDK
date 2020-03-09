using System.Collections.Generic;
using System.Collections.Specialized;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        ///// <summary>
        /////  �Զ�����չ���������ֵ�ת��Ϊ NameValueCollection ���϶���
        ///// </summary>
        ///// <param name="this">��չ����</param>
        ///// <returns></returns>
        //public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> @this)
        //{
        //    if(@this == null)
        //    {
        //        return null;
        //    }

        //    var nameValueCollection = new NameValueCollection();
        //    foreach(var item in @this)
        //    {
        //        nameValueCollection.Add(item.Key, item.Value);
        //    }

        //    return nameValueCollection;
        //}


        /// <summary>
        ///  �Զ�����չ���������ֵ�ת��Ϊ NameValueCollection ���϶���
        /// </summary>
        /// <param name="dict">��չ����</param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            if (dict == null)
            {
                return null;
            }

            var nameValueCollection = new NameValueCollection();

            foreach (var item in dict)
            {
                string value = null;
                if (item.Value != null)
                {
                    value = item.Value.ToString();
                }

                nameValueCollection.Add(item.Key.ToString(), value);
            }

            return nameValueCollection;
        }
    }
}