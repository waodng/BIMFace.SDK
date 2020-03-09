// /* ---------------------------------------------------------------------------------------
//    文件名：FileConvertApi.cs
//    文件功能描述：
// 
//    创建标识：20200308
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;
using BIMFace.SDK.CSharp.Constants;
using BIMFace.SDK.CSharp.Entity.Request;
using BIMFace.SDK.CSharp.Entity.Response;
using BIMFace.SDK.CSharp.Http;

namespace BIMFace.SDK.CSharp.API
{
    /// <summary>
    ///  文件转换接口实现类
    /// </summary>
    public class FileConvertApi : IFileConvertApi
    {
        #region 发起源文件/模型转换

        /// <summary>
        ///  发起转换。将DWG文件转换成矢量图纸。
        /// <para>
        ///   请求参数示例：
        ///    {
        ///      "source":{
        ///         "fileId":1402934652281952,
        ///         "compressed":false
        ///      },
        ///      "priority":2,
        ///      "callback":"http://www.app.com/receive",
        ///      "config":null
        ///    }
        /// </para> 
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">DWG文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateDwgToVectorDrawings(string accessToken, DwgFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":1402934652281952,
                  "compressed":false
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":null
             }
             */

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。将DWG文件转换成图片。
        /// <para>
        ///   请求参数示例：
        ///   {
        ///     "source":{
        ///        "fileId":857482189666208,
        ///        "compressed":false,
        ///        "rootName":"root.dwg"
        ///     },
        ///     "priority":2,
        ///     "callback":"http://www.app.com/receive",
        ///     "config":{
        ///       "exportDrawing":false
        ///     }
        ///    }
        /// </para> 
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">DWG文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateDwgToPicture(string accessToken, DwgFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":857482189666208,
                  "compressed":false,
                  "rootName":"root.dwg"
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":{
                  "exportDrawing":false
               }
             }
             */

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。将RVT文件转换成着色模式的效果。
        /// <para>
        ///   请求参数示例：
        ///    {
        ///      "source":{
        ///         "fileId":857482189666208,
        ///         "compressed":false,
        ///         "rootName":"root.rvt"
        ///      },
        ///      "priority":2,
        ///      "callback":"http://www.app.com/receive",
        ///      "config":null
        ///    }
        /// </para> 
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">RVT文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateRvtToRenderStyle(string accessToken, RvtFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":857482189666208,
                  "compressed":false,
                  "rootName":"root.rvt"
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":null
             }
             */

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。将RVT文件转换成真实模式的效果。
        /// <para>
        ///   请求参数示例：
        ///   {
        ///     "source":{
        ///        "fileId":857482189666208,
        ///        "compressed":false,
        ///        "rootName":"root.rvt"
        ///     },
        ///     "priority":2,
        ///     "callback":"http://www.app.com/receive",
        ///     "config":{
        ///       "texture":true
        ///     }
        ///    }
        /// </para> 
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">RVT文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateRvtToRealStyle(string accessToken, RvtFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":857482189666208,
                  "compressed":false,
                  "rootName":"root.rvt"
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":{"
                  texture":true
               }
             }
             */

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。将RVT格式文件转换为具备二三维联动的功能效果。
        /// <para>
        ///   请求参数示例：
        ///   {
        ///     "source":{
        ///        "fileId":1402934652281952,
        ///        "compressed":false
        ///     },
        ///     "priority":2,
        ///     "callback":"http://www.app.com/receive",
        ///     "config":{
        ///       "texture":false
        ///       "exportDwg": true,
        ///       "exportPdf": true,
        ///       "exportDrawing": true
        ///     }
        ///    }
        /// </para> 
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">RVT文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateRvtTo23LinkStyle(string accessToken, RvtFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":1402934652281952,
                  "compressed":false
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":{
                  "texture": false,
                  "exportDwg": true,
                  "exportPdf": true,
                  "exportDrawing": true
               }
              }
             */

            if (request.Config != null)
            {
                request.Config.ExportDwg = true;
                request.Config.ExportDrawing = true;
            }

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。其它三维模型文件转换，常规转换（不带材质）
        /// <para>
        ///   请求参数示例：
        ///    {
        ///      "source":{
        ///         "fileId":857482189666208,
        ///         "compressed":false,
        ///         "rootName":"root.skp"
        ///      },
        ///      "priority":2,
        ///      "callback":"http://www.app.com/receive",
        ///      "config":null
        ///    }
        /// </para> 
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">其他三维模型文件，包括RVT格式文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateOther3DModelToWithoutMaterialStyle(string accessToken, Other3DModelFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":857482189666208,
                  "compressed":false,
                  "rootName":"root.skp"
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":null
             }
             */

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。
        ///  其他三维模型文件包括RVT格式文件，需要转换出引用的外部材质场景、贴图等
        /// （上传的文件必须为压缩包，压缩包内同级目录包含模型文件和关联的所有材质文件，转换时必须指定rootName为主文件）。
        /// <para>
        ///   请求参数示例：
        ///   {
        ///     "source":{
        ///        "fileId":1234621112557376,
        ///        "compressed":true,
        ///        "rootName":"bimface_2018_打包材质_系统材质库.rvt"
        ///     },
        ///     "priority":2,
        ///     "callback":"http://www.app.com/receive",
        ///     "config":{
        ///       "texture":true
        ///     }
        ///    }
        /// </para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">其他三维模型文件，包括RVT格式文件转化的请求数据对象。根据实际需要设置对象里面的参数，不需要的参数不用赋值</param>
        /// <returns></returns>
        public virtual FileTranslateResponse TranslateOther3DModelToWithMaterialStyle(string accessToken, Other3DModelFileTranslateRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            /*请求体示例：
             {
               "source":{
                  "fileId":1234621112557376,
                  "compressed":true,
                  "rootName":"bimface_2018_打包材质&系统材质库.rvt"
               },
               "priority":2,
               "callback":"http://www.app.com/receive",
               "config":{
                  "texture":true
               }
             }
             */

            string data = request.SerializeToJson();

            return TranslateFile(accessToken, data);
        }

        /// <summary>
        ///  发起转换。
        ///  源文件上传成功后，即可发起对该文件的转换。由于转换不能立即完成，BIMFace支持在文件转换完成以后，通过Callback机制通知应用；
        ///  另外，应用也可以通过接口查询转换状态
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="data">请求体数据</param>
        /// <returns></returns>
        private FileTranslateResponse TranslateFile(string accessToken, string data)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列12 服务端API之文件转换》 https://www.cnblogs.com/SavionZhang/p/11451815.html

            //PUT https://api.bimface.com/translate
            string url = BimfaceConstants.API_HOST + "/translate";

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileTranslateResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Put(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileTranslateResponse>();
                }
                else
                {
                    response = new FileTranslateResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[发起文件转换]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取转换状态(应用发起转换以后，可以通过该接口查询转换状态)
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public virtual FileTranslateResponse GetFileTranslateStatus(string accessToken, long fileId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列13 服务端API之获取转换状态》 https://www.cnblogs.com/SavionZhang/p/11455484.html

            //GET https://api.bimface.com/translate
            string url = string.Format(BimfaceConstants.API_HOST + "/translate?fileId={0}", fileId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileTranslateResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileTranslateResponse>();
                }
                else
                {
                    response = new FileTranslateResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取转换状态]发生异常！", ex);
            }
        }

        /// <summary>
        /// 批量获取转换状态详情
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="request">请求体参数对象。AppKey属性必须赋值</param>
        /// <returns></returns>
        public virtual FileTranslateDetailsResponse GetFileTranslateDetails(string accessToken, TranslateQueryRequest request)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列14 服务端API之批量获取转换状态详情》 https://www.cnblogs.com/SavionZhang/p/11455795.html

            // POST https://api.bimface.com/translateDetails
            string url = string.Format(BimfaceConstants.API_HOST + "/translateDetails");

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            string data = request.SerializeToJson();

            try
            {
                FileTranslateDetailsResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileTranslateDetailsResponse>();
                }
                else
                {
                    response = new FileTranslateDetailsResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[批量获取转换状态详情]发生异常！", ex);
            }
        }

        #endregion

        #region 获取模型数据

        /// <summary>
        ///  查询满足条件的构件ID列表
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】文件ID</param>
        /// <param name="request">【非必填】请求参数对象</param>
        /// <returns></returns>
        public virtual SingleModelElementsSwaggerDisplay GetSingleModelElements(string accessToken, string fileId, FileElementsGetRequest request = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列16 服务端API之获取模型数据1：查询满足条件的构件ID列表》 https://www.cnblogs.com/SavionZhang/p/11457965.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/elementIds
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/elementIds", fileId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            string data = string.Empty;
            if (request != null)
            {
                data = request.SerializeToJson();
            }

            try
            {
                SingleModelElementsSwaggerDisplay response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelElementsSwaggerDisplay>();
                }
                else
                {
                    response = new SingleModelElementsSwaggerDisplay
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[查询满足条件的构件ID列表]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型的单个构件材质列表
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="elementId">【必填】代表该单模型的构件ID</param>
        /// <returns></returns>
        public virtual SingleModelSingleElementMaterials GetSingleModelSingleElementMaterials(string accessToken, long fileId, string elementId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列17 服务端API之获取模型数据2：获取构件材质列表》https://www.cnblogs.com/SavionZhang/p/11459867.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/elements/{elementId}/materials
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/elements/{1}/materials", fileId, elementId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelSingleElementMaterials response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelSingleElementMaterials>();
                }
                else
                {
                    response = new SingleModelSingleElementMaterials
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取构件材质列表]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型的单个构件属性
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="elementId">【必填】代表该单模型的构件ID</param>
        /// <param name="includeOverrides">【非必填】是否查询修改的属性</param>
        /// <returns></returns>
        public virtual SingleModelSingleElementProperty GetSingleModelSingleElementProperty(string accessToken, long fileId, string elementId, bool? includeOverrides = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列18 服务端API之获取模型数据3：获取构件属性》 https://www.cnblogs.com/SavionZhang/p/11465063.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/elements/{elementId}
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/elements/{1}", fileId, elementId);
            if (includeOverrides != null)
            {
                url = url + "?includeOverrides=" + includeOverrides;
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelSingleElementProperty response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelSingleElementProperty>();
                }
                else
                {
                    response = new SingleModelSingleElementProperty
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取构件属性]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型的多个构件的共同属性
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表多个模型的文件ID</param>
        /// <param name="elementIds">【必填】代表该单模型的构件ID列表</param>
        /// <param name="includeOverrides">【非必填】是否查询修改的属性</param>
        /// <returns></returns>
        public virtual SingleModelMultipleElementsCommonProperties GetSingleModelMultipleElementsCommonProperties(string accessToken, long fileId, string[] elementIds, bool? includeOverrides = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列19 服务端API之获取模型数据4：获取多个构件的共同属性》https://www.cnblogs.com/SavionZhang/p/11474013.html

            if (elementIds == null && elementIds.Length == 0)
            {
                throw new ArgumentException("参数 elementIds 不能为 null， 且必须包含元素！");
            }

            // GET https://api.bimface.com/data/v2/files/{fileId}/commonElementProperties?elementIds={string}
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/commonElementProperties?elementIds={1}", fileId, elementIds.ToStringWith(","));
            if (includeOverrides != null)
            {
                url = url + "&includeOverrides=" + includeOverrides;
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelMultipleElementsCommonProperties response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelMultipleElementsCommonProperties>();
                }
                else
                {
                    response = new SingleModelMultipleElementsCommonProperties
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取多个构件的共同属性]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型的多个构件的共同属性
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="elementIds">【必填】代表该单模型的构件ID列表</param>
        /// <param name="includeOverrides">【非必填】是否查询修改的属性</param>
        /// <returns></returns>
        public virtual SingleModelMultipleElementsCommonProperties GetSingleModelMultipleElementsCommonProperties(string accessToken, long fileId, List<string> elementIds, bool? includeOverrides = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列19 服务端API之获取模型数据4：获取多个构件的共同属性》https://www.cnblogs.com/SavionZhang/p/11474013.html

            return GetSingleModelMultipleElementsCommonProperties(accessToken, fileId, elementIds.ToArray(), includeOverrides);
        }

        /// <summary>
        ///  批量获取单个模型的多个构件属性
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="request">【必填】请求过滤参数</param>
        /// <param name="includeOverrides">【非必填】是否查询修改的属性</param>
        /// <returns></returns>
        public virtual SingleModelMultipleElementsProperties GetSingleModelMultipleElementsProperties(string accessToken, long fileId, ElementPropertyFilterRequest request, bool? includeOverrides = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列20 服务端API之获取模型数据5：批量获取构件属性》 https://www.cnblogs.com/SavionZhang/p/11475284.html

            if (request == null)
            {
                throw new ArgumentException("参数 request 不能为null ！");
            }

            // POST https://api.bimface.com/data/v2/files/{fileId}/elements
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/elements", fileId);
            if (includeOverrides != null)
            {
                url = url + "?includeOverrides=" + includeOverrides;
            }

            string data = request.SerializeToJson();

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelMultipleElementsProperties response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelMultipleElementsProperties>();
                }
                else
                {
                    response = new SingleModelMultipleElementsProperties
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[批量获取构件属性]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型的楼层信息
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="includeArea">【非必填】是否将楼层中的面积分区ID、名称一起返回</param>
        /// <param name="includeRoom">【非必填】是否将楼层中的房间ID、名称一起返回</param>
        /// <returns></returns>
        public virtual SingleModelFloors GetSingleModelFloors(string accessToken, long fileId, bool? includeArea = null, bool? includeRoom = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列21 服务端API之获取模型数据6：获取单模型的楼层信息》 https://www.cnblogs.com/SavionZhang/p/11490514.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/floors
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/floors", fileId);
            if (includeArea != null && includeRoom == null)
            {
                url = url + "?includeArea=" + includeArea;
            }
            else if (includeArea == null && includeRoom != null)
            {
                url = url + "?includeRoom=" + includeRoom;
            }
            else if (includeArea != null && includeRoom != null)
            {
                url = url + "?includeArea=" + includeArea + "&includeRoom=" + CommonExtension.ToString(includeRoom);
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelFloors response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelFloors>();
                }
                else
                {
                    response = new SingleModelFloors
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取单模型的楼层信息]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取多个模型的楼层信息
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileIds">【必填】代表多个模型的文件ID</param>
        /// <param name="includeArea">【非必填】是否将楼层中的面积分区ID、名称一起返回</param>
        /// <param name="includeRoom">【非必填】是否将楼层中的房间ID、名称一起返回</param>
        /// <returns></returns>
        public virtual MultipleModelsFloors GetMultipleModelFloors(string accessToken, string[] fileIds, bool? includeArea = null, bool? includeRoom = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列21 服务端API之获取模型数据7：获取多个模型的楼层信息》 https://www.cnblogs.com/SavionZhang/p/11491569.html

            if (fileIds != null && (fileIds == null && fileIds.Length == 0))
            {
                throw new ArgumentException("参数 fileIds 不能为 null，且必须包含元素！");
            }

            // GET https://api.bimface.com/data/v2/files/{fileIds}/fileIdfloorsMappings
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/fileIdfloorsMappings", fileIds.ToStringWith(","));
            if (includeArea != null && includeRoom == null)
            {
                url = url + "?includeArea=" + includeArea;
            }
            else if (includeArea == null && includeRoom != null)
            {
                url = url + "?includeRoom=" + includeRoom;
            }
            else if (includeArea != null && includeRoom != null)
            {
                url = url + "?includeArea=" + includeArea + "&includeRoom=" + includeRoom;
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                MultipleModelsFloors response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<MultipleModelsFloors>();
                }
                else
                {
                    response = new MultipleModelsFloors
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取多个模型的楼层信息]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取模型链接信息
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <returns></returns>
        public virtual SingleModelLink GetSingleModelLink(string accessToken, long fileId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列23 服务端API之获取模型数据8：获取模型链接信息》 https://www.cnblogs.com/SavionZhang/p/11492515.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/links
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/links", fileId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelLink response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelLink>();
                }
                else
                {
                    response = new SingleModelLink
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取模型链接信息]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型中单个房间信息
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="roomId">【必填】房间ID</param>
        /// <returns></returns>
        public virtual SingleModelSingleRoom GetSingleModelSingleRoom(string accessToken, long fileId, string roomId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列24 服务端API之获取模型数据9：获取单个房间信息》 https://www.cnblogs.com/SavionZhang/p/11492932.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/rooms/{roomId}
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/rooms/{1}", fileId, roomId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelSingleRoom response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelSingleRoom>();
                }
                else
                {
                    response = new SingleModelSingleRoom
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取单个房间信息]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型中单个楼层对应面积分区列表
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="floorId">【必填】代表该单模型的楼层ID</param>
        /// <returns></returns>
        public virtual SingleModelSingleFloorAreas GetSingleModelSingleFloorAreas(string accessToken, long fileId, string floorId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列25 服务端API之获取模型数据10：获取楼层对应面积分区列表》 https://www.cnblogs.com/SavionZhang/p/11493502.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/areas
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/areas?floorId={1}", fileId, floorId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelSingleFloorAreas response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelSingleFloorAreas>();
                }
                else
                {
                    response = new SingleModelSingleFloorAreas
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取楼层对应面积分区列表]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型中单个面积分区信息
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="areaId">【必填】面积分区ID</param>
        /// <returns></returns>
        public virtual SingleModelSingleArea GetSingleModelSingleArea(string accessToken, long fileId, string areaId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列26 服务端API之获取模型数据11：获取单个面积分区信息》https://www.cnblogs.com/SavionZhang/p/11493593.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/areas/{areaId}
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/areas/{1}", fileId, areaId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelSingleArea response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelSingleArea>();
                }
                else
                {
                    response = new SingleModelSingleArea
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取单个面积分区信息]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型中构件的默认分类树
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="v">【非必填】用来区别treeType为default时返回树的格式</param>
        /// <param name="request">【非必填】其他过滤参数类对象</param>
        /// <returns></returns>
        public virtual SingleModelTree GetSingleModelTreeByDefault(string accessToken, long fileId, string v = "2.0", FileTreeRequestBody request = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列27 服务端API之获取模型数据12：获取构件分类树》 https://www.cnblogs.com/SavionZhang/p/11493844.html

            //return GetSingleModelTree(accessToken, fileId, TreeType.Default, v, request);
            /* 单模型构件分类树,
              （1）treeType 接受两个值：default 和 customized，默认为 default。
              （2）v 参数用来区别 treeType 为 default 时返回树的格式, customized 总是返回格式2.0的构件树。 
              （3）当 treeType 为"customized"时，FileTreeRequestBody 类的 desiredHierarchy 属性 表示了筛选树的层次,可选值有building,systemType,specialty,floor,category,family,familyType，
                  如:desiredHierarchy=specialty,systemtype。
                    customizedNodeKeys: 用来指定筛选树每个维度用id或者是name作为唯一标识, 如"floor":"id"
            */

            // POST https://api.bimface.com/data/v2/files/{fileId}/tree
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/tree?treeType=default", fileId);

            if (!string.IsNullOrWhiteSpace(v))
            {
                url = url + "&v=" + v;
            }

            string data = string.Empty;
            if (request != null)
            {
                data = request.SerializeToJson();
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelTree response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelTree>();
                }
                else
                {
                    response = new SingleModelTree
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取单个模型中构件的默认分类树]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型中构件的自定义分类树
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="v">【非必填】用来区别treeType为default时返回树的格式</param>
        /// <param name="request">【非必填】其他过滤参数类对象</param>
        /// <returns></returns>
        public virtual SingleModelTreeByCustomized GetSingleModelTreeByCustomized(string accessToken, long fileId, string v = "2.0", FileTreeRequestBody request = null)
        {
            //return GetSingleModelTree(accessToken, fileId, TreeType.Default, v, request);
            /* 单模型构件分类树,
              （1）treeType 接受两个值：default 和 customized，默认为 default。
              （2）v 参数用来区别 treeType 为 default 时返回树的格式, customized 总是返回格式2.0的构件树。 
              （3）当 treeType 为"customized"时，FileTreeRequestBody 类的 desiredHierarchy 属性 表示了筛选树的层次,可选值有building,systemType,specialty,floor,category,family,familyType，
                  如:desiredHierarchy=specialty,systemtype。
                    customizedNodeKeys: 用来指定筛选树每个维度用id或者是name作为唯一标识, 如"floor":"id"
            */

            // POST https://api.bimface.com/data/v2/files/{fileId}/tree
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/tree?treeType=customized", fileId);

            if (!string.IsNullOrWhiteSpace(v))
            {
                url = url + "&v=" + v;
            }

            string data = string.Empty;
            if (request != null)
            {
                data = request.SerializeToJson();
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelTreeByCustomized response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelTreeByCustomized>();
                }
                else
                {
                    response = new SingleModelTreeByCustomized
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取单个模型中构件的自定义分类树]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取构件分类树
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="treeType">分类树的类型</param>
        /// <param name="v">格式</param>
        /// <param name="request">其他请求参数</param>
        /// <returns></returns>
        public virtual SingleModelTree GetSingleModelTree(string accessToken, long fileId, TreeType treeType = TreeType.Default, string v = "2.0", FileTreeRequestBody request = null)
        {
            /* 单模型构件分类树,
              （1）treeType 接受两个值：default 和 customized，默认为 default。
              （2）v 参数用来区别 treeType 为 default 时返回树的格式, customized 总是返回格式2.0的构件树。 
              （3）当 treeType 为"customized"时，FileTreeRequestBody 类的 desiredHierarchy 属性 表示了筛选树的层次,可选值有building,systemType,specialty,floor,category,family,familyType，
                  如:desiredHierarchy=specialty,systemtype。
                    customizedNodeKeys: 用来指定筛选树每个维度用id或者是name作为唯一标识, 如"floor":"id"
            */

            string tempTreeType = treeType == TreeType.Default ? "default" : "customized";

            // POST https://api.bimface.com/data/v2/files/{fileId}/tree
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/tree?treeType={1}", fileId, tempTreeType);

            if (!string.IsNullOrWhiteSpace(v))
            {
                url = url + "&v=" + v;
            }

            string data = string.Empty;
            if (request != null)
            {
                data = request.SerializeToJson();
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelTree response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelTree>();
                }
                else
                {
                    response = new SingleModelTree
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取构件分类树]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取三维视点或二维视图列表
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <returns></returns>
        public virtual SingleModelViews GetSingleModelViews(string accessToken, long fileId)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列28 服务端API之获取模型数据13：获取三维视点或二维视图列表》 https://www.cnblogs.com/SavionZhang/p/11493866.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/views
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/views", fileId);

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelViews response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelViews>();
                }
                else
                {
                    response = new SingleModelViews
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取楼层对应面积分区列表]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取单个模型的图纸列表。
        ///  如果请求参数elementId为null，返回所有图纸，否则返回包含该构件的所有图纸
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】代表该单模型的文件ID</param>
        /// <param name="elementId">【非必填】构件ID</param>
        /// <returns></returns>
        public virtual SingleModelDrawingSheets GetSingleModelDrawingSheets(string accessToken, long fileId, string elementId = null)
        {
            // 此API详解，参考作者博客：《C#开发BIMFACE系列29 服务端API之获取模型数据14：获取图纸列表》 https://www.cnblogs.com/SavionZhang/p/11493875.html

            // GET https://api.bimface.com/data/v2/files/{fileId}/drawingsheets
            string url = string.Format(BimfaceConstants.API_HOST + "/data/v2/files/{0}/drawingsheets", fileId);
            if (!string.IsNullOrWhiteSpace(elementId))
            {
                url = url + "?elementId=" + elementId;
            }

            BimFaceHttpHeaders headers = new BimFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                SingleModelDrawingSheets response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<SingleModelDrawingSheets>();
                }
                else
                {
                    response = new SingleModelDrawingSheets
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("[获取单个模型的图纸列表]发生异常！", ex);
            }
        }

        #endregion
    }
}