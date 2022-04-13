// /* ---------------------------------------------------------------------------------------
//    文件名：FileManagementApi.cs
//    文件功能描述：
// 
//    创建标识：20220410
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Constants;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.API
{
    /// <summary>
    ///  文档管理功能接口实现类
    /// </summary>
    public partial class FileManagementApi : IFileManagementApi
    {
        #region Hubs

        /// <summary>
        /// 获取Hub列表
        /// <para>通过该接口可查询您的账号已注册哪些存储中心（Hub）,您可以将文件上传到已注册的存储空间里。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="dateTimeFrom">【选填】开始时间，筛选时间范围内创建的Hub，格式为：yyyy-MM-dd HH:mm:ss</param>
        /// <param name="dateTimeTo">【选填】终止时间，筛选时间范围内创建的Hub，格式为：yyyy-MM-dd HH:mm:ss</param>
        /// <param name="info">【选填】描述信息</param>
        /// <param name="name">【选填】Hub名称</param>
        /// <param name="tenantCode">【选填】产品所属的租户 (默认值:"BIMFACE")</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual HubsResponse GetHubs(string accessToken, string dateTimeFrom = "", string dateTimeTo = "", string info = "", string name = "", string tenantCode = "BIMFACE")
        {
            /*官方文档：https://bimface.com/docs/file-management/v1/api-reference/getHubListUsingGET.html */

            //GET https://api.bimface.com/bdfs/domain/v1/hubs
            string url = BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs?1=1";
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                url += "&dateTimeFrom=" + dateTimeFrom;
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                url += "&dateTimeTo=" + dateTimeTo;
            }
            if (!string.IsNullOrWhiteSpace(info))
            {
                url += "&info=" + info;
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                url += "&name=" + name;
            }
            if (!string.IsNullOrWhiteSpace(tenantCode))
            {
                url += "&tenantCode=" + tenantCode;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                HubsResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<HubsResponse>();
                }
                else
                {
                    response = new HubsResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取Hubs]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取Hub Meta信息
        /// <para>通过该接口可查询您的账号已注册哪些存储中心（Hub）,您可以将文件上传到已注册的存储空间里。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual HubMetaResponse GetHubMeta(string accessToken, string hubId)
        {
            /*官方文档：https://bimface.com/docs/file-management/v1/api-reference/getHubMetaUsingGET.html */

            //GET https://api.bimface.com/bdfs/domain/v1/hubs/{hubId}
            string url = BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs/" + hubId;

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                HubMetaResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<HubMetaResponse>();
                }
                else
                {
                    response = new HubMetaResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取Hub Meta信息]发生异常！", ex);
            }
        }

        #endregion

        #region Project

        /// <summary>
        /// 创建项目
        /// <para>用Access Token创建项目,对文件分项目进行管理，创建项目之前需要获取应用所属的hubId。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectName">【必填】项目名称</param>
        /// <param name="projectInfo">【选填】项目描述，最多255个字符</param>
        /// <param name="projectThumbnail">【选填】项目缩略图url</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual ProjectResponse CreateProject(string accessToken, string hubId, string projectName, string projectInfo = null, string projectThumbnail = null)
        {
            /*官方文档：https://bimface.com/docs/file-management/v1/api-reference/createProjectUsingPOST.html */

            //POST https://api.bimface.com/bdfs/domain/v1/hubs/{hubId}/projects
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs/{0}/projects", hubId);

            string data = new ProjectSaveRequest
            {
                Name = projectName,
                Thumbnail = projectThumbnail,
                Info = projectInfo
            }.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ProjectResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ProjectResponse>();
                }
                else
                {
                    response = new ProjectResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[创建项目信息]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取项目列表
        /// <para>根据hubId查询所属应用下的项目，默认开启useFuzzySearch，搜索名字中包含关键字的项目。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectName">【必填】项目名称,使用URL编码(UTF-8),最多256个字符</param>
        /// <param name="useFuzzySearch">【选填】是否开启模糊搜索,若传了name, 默认为true</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual ProjectsGetResponse GetProjects(string accessToken, string hubId, string projectName = "", bool useFuzzySearch = false)
        {
            /*官方文档：https://bimface.com/docs/file-management/v1/api-reference/getProjectListUsingGET.html */

            //GET https://api.bimface.com/bdfs/domain/v1/hubs/{hubId}/projects
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs/{0}/projects", hubId) + "?1=1";
            if (!string.IsNullOrWhiteSpace(projectName))
            {
                url += "&name=" + projectName;
            }

            url += "&useFuzzySearch=" + useFuzzySearch;

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ProjectsGetResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ProjectsGetResponse>();
                }
                else
                {
                    response = new ProjectsGetResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取项目列表]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取项目信息
        /// <para>根据HubId和项目Id获取指定项目的信息，包括项目名称、项目描述等。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectId">【必填】项目Id</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual ProjectResponse GetProjectInfo(string accessToken, string hubId, string projectId)
        {
            /*官方文档：https://bimface.com/docs/file-management/v1/api-reference/getProjectMetaUsingGET.html */

            //GET https://api.bimface.com/bdfs/domain/v1/hubs/{hubId}/projects/{projectId}
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs/{0}/projects/{1}", hubId, projectId);

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ProjectResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ProjectResponse>();
                }
                else
                {
                    response = new ProjectResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取项目信息]发生异常！", ex);
            }
        }

        /// <summary>
        /// 更新项目
        /// <para>通过接口，可修改指定项目的信息，包含项目名称、项目描述、项目缩略图。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectId">【必填】项目编号</param>
        /// <param name="projectName">【选填】项目名称</param>
        /// <param name="projectInfo">【选填】项目描述，最多255个字符</param>
        /// <param name="projectThumbnail">【选填】项目缩略图url，若不填则使用默认缩略图</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual ProjectResponse UpdateProject(string accessToken, string hubId, string projectId, string projectName = null, string projectInfo = null, string projectThumbnail = null)
        {
            /* 官方文档： https: //bimface.com/docs/file-management/v1/api-reference/updateProjectUsingPATCH.html */

            //PATCH https://api.bimface.com/bdfs/domain/v1/hubs/{hubId}/projects/{projectId}
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs/{0}/projects/{1}", hubId, projectId);
            string data = new ProjectSaveRequest
            {
                Name = projectName,
                Thumbnail = projectThumbnail,
                Info = projectInfo
            }.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ProjectResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Patch(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ProjectResponse>();
                }
                else
                {
                    response = new ProjectResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[更新项目信息]发生异常！", ex);
            }
        }

        /// <summary>
        /// 根据项目ID删除项目
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectId">【必填】项目Id</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual ProjectResponse DeleteProject(string accessToken, string hubId, string projectId)
        {
            /* 官方文档： https: //bimface.com/docs/file-management/v1/api-reference/deleteProjectUsingDELETE.html */

            //DELETE https://api.bimface.com/bdfs/domain/v1/hubs/{hubId}/projects/{projectId}
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/domain/v1/hubs/{0}/projects/{1}", hubId, projectId);

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ProjectResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Delete(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ProjectResponse>();
                }
                else
                {
                    response = new ProjectResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[删除项目]发生异常！", ex);
            }
        }

        #endregion

        #region Folders

        /// <summary>
        /// 指定目录下创建文件夹
        /// <para>在指定的位置创建文件夹，可对文件进行分类管理。需要获取所属的项目Id，以及文件夹所在位置的上层文件Id或文件路径，两个参数必须二选一填入。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】</param>
        /// <param name="folderName">【必填】 文件夹名称</param>
        /// <param name="parentPath">【必填】父目录文件路径,parentId和parentPath,必须二选一填入</param>
        /// <param name="parentId">【必填】父目录文件ID,parentId和parentPath,必须二选一填入</param>
        /// <param name="autoRename">【选填】当存在同名文件夹时,是否重命名（默认false，false情况下有同名文件夹则报错）</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual FolderResponse CreateFolder(string accessToken, string projectId, string folderName, string parentPath, string parentId, bool? autoRename = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/createFolderUsingPOST.html */

            //POST https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders", projectId);
            string data = new FolderCreateRequest
            {
                Name = folderName,
                ParentPath = parentPath,
                ParentId = parentId,
                AutoRename = autoRename
            }.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url,data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderResponse>();
                }
                else
                {
                    response = new FolderResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[创建文件夹信息]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取文件夹信息
        /// <para>根据文件夹Id或文件夹路径，可获取文件夹信息，包含文件夹名称、创建时间等。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】 文件夹id(folderId和folderPath,必须二选一填入)</param>
        /// <param name="folderPath">【必填】文件夹所在路径,使用URL编码UTF-8,最多256个字符(folderId和folderPath,必须二选一填入) 	</param>
        /// <exception cref="BIMFaceException"></exception>
        public virtual FolderResponse GetFolder(string accessToken, string projectId, string folderId, string folderPath)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFolderUsingGET.html */

            //GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders?1=1", projectId);
            if (!string.IsNullOrWhiteSpace(folderId))
            {
                url = url + "&folderId=" + folderId;
            }
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                url = url + "&path=" + folderPath.UrlEncode(Encoding.UTF8);
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderResponse>();
                }
                else
                {
                    response = new FolderResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件夹信息]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取文件夹下的所有文件
        /// <para>通过接口获取指定文件夹下所有的文件信息，也可获取制定项目下所有文件列表，BIMFACE支持根据父文件Id或父文件夹路径两种方式获取</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="request">【必填】请求参数类</param>
        /// <exception cref="BIMFaceException"></exception>
        public virtual FolderContentResponse GetFolderContent(string accessToken, string projectId, FolderContentRequest request)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFolderChildrenUsingPOST.html */

            //POST https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders/contents
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders/contents", projectId);
            string data = request.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderContentResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderContentResponse>();
                }
                else
                {
                    response = new FolderContentResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件夹下的所有文件]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取文件夹路径
        /// <para>通过接口，根据文件夹的Id可获得文件夹的所在位置信息。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】文件夹ID</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual FolderPathResponse GetFolderPath(string accessToken, string projectId, string folderId)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFolderPathByIdUsingGET.html */

            //GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders/{folderId}/path
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders/{1}/path", projectId, folderId);

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderPathResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderPathResponse>();
                }
                else
                {
                    response = new FolderPathResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件夹路径]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取父文件夹信息
        /// <para>根据文件Id获取其上一层文件夹的信息，包含文件名称、创建时间等。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】文件夹ID</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual FolderResponse GetParentFolder(string accessToken, string projectId, string folderId)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getParentUsingGET.html */

            //GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders/{folderId}/parent
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders/{1}/parent", projectId, folderId);

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderResponse>();
                }
                else
                {
                    response = new FolderResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取父文件夹]发生异常！", ex);
            }
        }

        /// <summary>
        /// 更新文件夹
        /// <para>通过接口对文件夹的名称进行修改，可通过文件夹Id和文件夹路径两种参数指定需要修改的文件夹。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderName">【必填】文件夹名称</param>
        /// <param name="folderId">【必填】 	文件夹id(folderId和folderPth,必须二选一填入),id的优先级大于path</param>
        /// <param name="folderPath">【必填】文件夹路径(folderId和folderPth,必须二选一填入)</param>
        /// <param name="autoRename">【选填】存在同名文件夹时,是否自动重命名（默认false,false情况下有同名文件夹则报错）</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual FolderResponse UpdateFolder(string accessToken, string projectId, string folderName, string folderId, string folderPath, bool? autoRename = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/updateFolderUsingPATCH.html */

            // PATCH https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders", projectId);
            string data = new FolderUpdateRequest
            {
                Name = folderName,
                Path = folderPath,
                FolderId = folderId,
                AutoRename = autoRename
            }.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Patch(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderResponse>();
                }
                else
                {
                    response = new FolderResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[更新文件夹]发生异常！", ex);
            }
        }

        /// <summary>
        ///  删除文件夹。
        /// <para>删除指定文件夹，文件夹内所有文件也被删除。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】文件夹id(folderId和path,必须二选一填入)</param>
        /// <param name="folderPath">【必填】文件夹路径,使用URL编码（UTF-8），最多256个字符(folderId和path,必须二选一填入)</param>
        /// <returns></returns>
        public virtual FolderDeleteResponse DeleteFolder(string accessToken, string projectId, string folderId, string folderPath)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/deleteFolderUsingDELETE.html */

            // DELETE https://api.bimface.com/bdfs/data/v1/projects/{projectId}/folders
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/folders?1=1", projectId);
            if (!string.IsNullOrWhiteSpace(folderId))
            {
                url = url + "&folderId=" + folderId;
            }
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                url = url + "&path=" + folderPath;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FolderDeleteResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Delete(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FolderDeleteResponse>();
                }
                else
                {
                    response = new FolderDeleteResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[删除文件夹]发生异常！", ex);
            }
        }

        #endregion

        #region FolderItems 

        /// <summary>
        ///  普通文件流上传文件【使用BIMFACE公有云时不推荐使用该方式。推荐使用文件直传 UploadFileByPolicy()方法，效率更高】。
        /// <para>使用普通文件流上传，文件流需要在request body中传递。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileName">【必填】文件的名称(不包含路径)</param>
        /// <param name="fileStream">【必填】文件流</param>
        /// <param name="parentId">【必填】父文件夹Id，parentId和parentPath必须二选一填入</param>
        /// <param name="parentPath">【必填】父文件夹路径，parentId和parentPath必须二选一填入</param>
        /// <param name="autoRename">【可选】当存在同名文件时,是否自动重命名，默认为false </param>
        /// <param name="sourceId">【可选】调用方的文件源ID，不能重复</param>
        /// <returns></returns>
        public virtual FileUpload2Response UploadFileByStream(string accessToken, string projectId, string fileName, Stream fileStream, string parentId, string parentPath, bool? autoRename = null, string sourceId = "")
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/uploadFileItemUsingPOST.html */

            /* 此API详解，参考作者博客：《C#开发BIMFACE系列4 服务端API之源上传文件》 https://www.cnblogs.com/SavionZhang/p/11425804.html */

            /* 重要提示：使用普通文件流上传，不支持表单方式; 文件流需要在 request body 中传递 */

            byte[] fileBytes = fileStream.ToByteArray();

            //POST https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems", projectId);
            url = url + "?name=" + fileName.UrlEncode(Encoding.UTF8); // 使用URL编码（UTF-8）
            if (!string.IsNullOrEmpty(parentId))
            {
                url = url + "&parentId=" + parentId;
            }
            if (!string.IsNullOrEmpty(parentPath))
            {
                url = url + "&parentPath=" + parentPath;
            }

            url = url + "&length=" + fileBytes.Length;

            if (autoRename.HasValue)
            {
                url = url + "&autoRename=" + autoRename.Value;
            }
            if (!string.IsNullOrEmpty(sourceId))
            {
                url = url + "&sourceId=" + sourceId;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileUpload2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.UploadData(url, fileBytes, WebRequestMethods.Http.Post);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileUpload2Response>();
                }
                else
                {
                    response = new FileUpload2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[普通文件流上传文件]发生异常！", ex);
            }
        }

        /// <summary>
        ///  指定外部文件url方式上传文件。
        /// <para>如果需要上传的文件不在本地，且该文件可以通过指定的HTTP URL可以下载，BIMFACE支持直接传一个外部的HTTP文件URL，BIMFACE会去下载该文件，而无须用户先下载再上传。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileName">【必填】文件的名称(不包含路径)</param>
        /// <param name="parentId">【必填】父文件夹Id，parentId和parentPath必须二选一填入</param>
        /// <param name="parentPath">【必填】父文件夹路径，parentId和parentPath必须二选一填入</param>
        /// <param name="fileUrl">【必填】外部文件的url地址</param>
        /// <param name="autoRename">【可选】当存在同名文件时,是否自动重命名，默认为false </param>
        /// <param name="sourceId">【可选】调用方的文件源ID，不能重复</param>
        /// <param name="etag">【可选】文件etag</param>
        /// <param name="maxLength">【可选】</param>
        /// <returns></returns>
        public virtual FileUpload2Response UploadFileByUrl(string accessToken, string projectId, string fileName, string parentId, string parentPath, string fileUrl, bool? autoRename = null, string sourceId = "", string etag = "", long? maxLength = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/uploadByUrlUsingPOST.html */

            /* 此API详解，参考作者博客：《C#开发BIMFACE系列4 服务端API之源上传文件》 https://www.cnblogs.com/SavionZhang/p/11425804.html */

            /* 如果需要上传的文件不在本地，且该文件可以通过指定的HTTP URL可以下载，BIMFACE支持直接传一个外部的HTTP文件URL, BIMFACE会去下载该文件，而无须用户先下载，再上传。 */

            //POST https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/sourceUrl
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/sourceUrl", projectId);
            url = url + "?name=" + fileName.UrlEncode(Encoding.UTF8); // 使用URL编码（UTF-8）

            if (!string.IsNullOrWhiteSpace(parentId))
            {
                url = url + "&parentId=" + parentId;
            }
            if (!string.IsNullOrWhiteSpace(parentPath))
            {
                url = url + "&parentPath=" + parentPath;
            }

            url = url + "&url=" + fileUrl.UriEscapeDataString();

            if (autoRename.HasValue)
            {
                url = url + "&autoRename=" + autoRename.Value;
            }
            if (!string.IsNullOrWhiteSpace(etag))
            {
                url = url + "&etag=" + etag;
            }
            if (maxLength.HasValue)
            {
                url = url + "&maxLength=" + maxLength.Value;
            }
            if (!string.IsNullOrWhiteSpace(sourceId))
            {
                url = url + "&sourceId=" + sourceId;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileUpload2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileUpload2Response>();
                }
                else
                {
                    response = new FileUpload2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[指定外部文件url方式上传文件]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取文件直传的policy凭证。
        /// 【特别提醒：BIMFACE公有云支持文件直传。私有化部署时使用的对象存储是 MinIO，不支持 Policy 上传，使用普通文件流上传 或者 指定外部文件URL方式上传。】
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileName">【必填】文件的名称(不包含路径)</param>
        /// <param name="parentId">【必填】父文件夹Id，parentId和parentPath必须二选一填入</param>
        /// <param name="parentPath">【必填】父文件夹路径，parentId和parentPath必须二选一填入</param>
        /// <param name="autoRename">【可选】当存在同名文件时,是否自动重命名，默认为false </param>
        /// <param name="sourceId">【可选】调用方的文件源ID，不能重复</param>
        /// <param name="maxLength">【可选】</param>
        /// <returns></returns>
        internal virtual FileUploadPolicyResponse GetFileUploadPolicy(string accessToken, string projectId, string fileName, string parentId, string parentPath, bool? autoRename = null, string sourceId = "", long? maxLength = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFilePolicyUsingGET.html */

            /* 此API详解，参考作者博客：《C#开发BIMFACE系列5 服务端API之文件直传》 https://www.cnblogs.com/SavionZhang/p/11425945.html */

            /*  BIMFACE 使用了分布式对象存储来存储用户上传的模型/图纸文件。
                如使用普通的文件上传接口，文件流会通过BIMFACE的服务器，再流向最终的分布式存储系统，整个上传过程会受BIMFACE服务器的带宽限制，上传速度非最优。 
                如使用文件直传接口，开发者应用在申请到一个Policy凭证后，可以直接上传文件跟BIMFACE后台的分布式存储系统， 
                这样上传速度和稳定性都会有提升，是我们推荐的上传方式。 
             */

            /* 使用流程如下：
                1、开发者应用向BIMFACE申请上传Policy请求
                2、BIMFACE返回上传Policy和签名给开发者应用。
             */

            //GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/policy
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/policy", projectId);
            url = url + "?name=" + fileName; //.UrlEncode(Encoding.UTF8); // 使用URL编码（UTF-8）
            if (!string.IsNullOrWhiteSpace(parentId))
            {
                url = url + "&parentId=" + parentId;
            }
            if (!string.IsNullOrWhiteSpace(parentPath))
            {
                url = url + "&parentPath=" + parentPath;
            }
            if (autoRename.HasValue)
            {
                url = url + "&autoRename=" + autoRename.Value;
            }
            if (!string.IsNullOrWhiteSpace(sourceId))
            {
                url = url + "&sourceId=" + sourceId;
            }
            if (maxLength.HasValue)
            {
                url = url + "&maxLength=" + maxLength.Value;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileUploadPolicyResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileUploadPolicyResponse>();
                }
                else
                {
                    response = new FileUploadPolicyResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件直传的policy凭证时]发生异常！", ex);
            }
        }

        /// <summary>
        ///  【推荐使用该方式】根据policy凭证在web端上传文件。
        /// <para>通过接口获取文件直传的policy凭证后，可以直接在前端使用表单上传方式将文件上传到BIMFACE的对象存储上。</para>
        /// <para>特别提醒：BIMFACE公有云支持文件直传。私有化部署时使用的对象存储是 MinIO，不支持 Policy 上传。使用普通文件流上传 或者 指定外部文件URL方式上传。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        ///  <param name="projectId">【必填】项目ID</param>
        /// <param name="fileFullName">【必填】待上传的文件(包含全路径的完全限定名)</param>
        /// <param name="parentId">【必填】父文件夹Id，parentId和parentPath必须二选一填入</param>
        /// <param name="parentPath">【必填】父文件夹路径，parentId和parentPath必须二选一填入</param>
        /// <param name="autoRename">【可选】当存在同名文件时,是否自动重命名，默认为false </param>
        /// <param name="sourceId">【可选】调用方的文件源ID，不能重复</param>
        /// <param name="maxLength">【可选】</param>
        /// <returns></returns>
        public virtual FileUpload2Response UploadFileByPolicy(string accessToken, string projectId, string fileFullName, string parentId, string parentPath, bool? autoRename = null, string sourceId = "", long? maxLength = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/uploadByPolicyUsingPOST.html */
            /* 此API详解，参考作者博客：《C#开发BIMFACE系列5 服务端API之文件直传》 https://www.cnblogs.com/SavionZhang/p/11425945.html */

            /* BIMFACE使用了分布式对象存储来存储用户上传的模型/图纸文件。
               如使用普通的文件上传接口，文件流会通过BIMFACE的服务器，再流向最终的分布式存储系统，整个上传过程会受BIMFACE服务器的带宽限制，上传速度非最优。 
               如使用文件直传接口，开发者应用在申请到一个Policy凭证后，可以直接上传文件跟BIMFACE后台的分布式存储系统， 
               这样上传速度和稳定性都会有提升，是我们推荐的上传方式。 
            */

            /* 使用流程如下：
                1、开发者应用向BIMFACE申请上传Policy请求。
                2、BIMFACE返回上传Policy和签名给开发者应用。
                3、开发者应用使用在第二个步骤中获取的URL信息，直接上传文件数据到BIMFACE后端的分布式对象存储。
             */

            FileUpload2Response response = null;
            try
            {
                string fileName = new FileInfo(fileFullName).Name;

                FileUploadPolicyResponse policyResponse = GetFileUploadPolicy(accessToken, projectId, fileName, parentId, parentPath, autoRename, sourceId, maxLength);
                if (policyResponse.Code == HttpResult.STATUS_SUCCESS)
                {
                    /* 官方文档 https://bimface.com/docs/file-management/v1/api-reference/getFilePolicyUsingGET.html
                     * 中说明该接口的请求地址为：POST https://api.bimface.com/bdfs/data/v1/projects/policy
                     *
                     *  经测试
                     * （1）使用该地址在postman中测试可以成功。但是使用本程序测试失败，提示 unauthorized。Full authentication is required to access this resource。
                     * （2）使用“获取文件直传的policy凭证”接口中返回的 host 地址(https://bf-prod-srcfile.oss-cn-beijing.aliyuncs.com)，本程序测试成功。
                     */

                    //string url = BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/policy";
                    string url = policyResponse.Data.Host;

                    /* C# 语言 Dictionary 字典中 key 是关键字，不能添加进去。所以统一添加了响应的后缀 _BIMFACE_，解析时再去除后缀 */
                    NameValueCollection kVDatas = new NameValueCollection();
                    kVDatas.Add("name" + StringUtils.Symbol.KEY_SUFFIX, fileName);
                    kVDatas.Add("key" + StringUtils.Symbol.KEY_SUFFIX, policyResponse.Data.ObjectKey);
                    kVDatas.Add("policy" + StringUtils.Symbol.KEY_SUFFIX, policyResponse.Data.Policy);
                    kVDatas.Add("OSSAccessKeyId" + StringUtils.Symbol.KEY_SUFFIX, policyResponse.Data.AccessId);
                    kVDatas.Add("success_action_status" + StringUtils.Symbol.KEY_SUFFIX, "200");
                    kVDatas.Add("callback" + StringUtils.Symbol.KEY_SUFFIX, policyResponse.Data.CallbackBody);
                    kVDatas.Add("signature" + StringUtils.Symbol.KEY_SUFFIX, policyResponse.Data.Signature);

                    BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
                    headers.AddOAuth2Header(accessToken);

                    HttpManager httpManager = new HttpManager(headers);
                    HttpResult httpResult = httpManager.UploadFormByMultipart(url, fileFullName, kVDatas);
                    if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                    {
                        response = httpResult.Text.DeserializeJsonToObject<FileUpload2Response>();
                    }
                    else
                    {
                        response = new FileUpload2Response
                        {
                            Message = httpResult.RefText
                        };
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[通过文件直传的policy凭证，直接上传文件时]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取文件信息。
        /// <para>根据文件ID或文件路径获取文件的详细信息。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID(fileItemId和path,必须二选一填入 ）</param>
        /// <param name="filePath">【必填】 文件所在路径，使用URL编码（UTF-8），最多256个字符（fileItemId和path,必须二选一填入 ）</param>
        /// <param name="withItemSource">【选填】</param>
        /// <returns></returns>
        public virtual FileItemResponse GetFile(string accessToken, string projectId, string fileItemId, string filePath, bool? withItemSource = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/copyFileUsingPOST.html */

            //GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/meta
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/meta?1=1", projectId);
            if (!string.IsNullOrWhiteSpace(fileItemId))
            {
                url = url + "&fileItemId=" + fileItemId;
            }
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                url = url + "&path=" + filePath;
            }
            if (withItemSource.HasValue)
            {
                url = url + "&withItemSource=" + withItemSource.Value;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileItemResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileItemResponse>();
                }
                else
                {
                    response = new FileItemResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件信息]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取文件状态。
        /// <para>根据文件ID或文件路径获取文件上传状态信息</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID(fileItemId和path,必须二选一填入 ）</param>
        /// <param name="filePath">【必填】 文件所在路径，使用URL编码（UTF-8），最多256个字符（fileItemId和path,必须二选一填入 ）</param>
        /// <returns></returns>
        public virtual FileUpload2StatusResponse GetFileUploadStatus(string accessToken, string projectId, string fileItemId, string filePath)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFileItemUploadStatusUsingGET.html */

            // GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/status
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/status?1=1", projectId);
            if (!string.IsNullOrEmpty(fileItemId))
            {
                url = url + "&fileItemId=" + fileItemId;
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                url = url + "&path=" + filePath;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileUpload2StatusResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileUpload2StatusResponse>();
                }
                else
                {
                    response = new FileUpload2StatusResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件状态]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取源文件下载地址。
        /// <para>通过该接口可获取文件的下载地址，下载地址有效时间为60分钟，可通过参数修改有效期。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID(fileItemId和path,必须二选一填入 ）</param>
        /// <param name="filePath">【必填】 文件所在路径，使用URL编码（UTF-8），最多256个字符（fileItemId和path,必须二选一填入 ）</param>
        /// <param name="expireTime">【选填】有限期，默认3600s</param>
        /// <returns></returns>
        public virtual FilePath2Response GetFileDownloadUrl(string accessToken, string projectId, string fileItemId, string filePath, string expireTime = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFileItemSignedUrlUsingGET.html */

            // GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/downloadUrl
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/downloadUrl?1=1", projectId);
            if (!string.IsNullOrWhiteSpace(fileItemId))
            {
                url = url + "&fileItemId=" + fileItemId;
            }
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                url = url + "&path=" + filePath;
            }
            if (!string.IsNullOrWhiteSpace(expireTime))
            {
                url = url + "&expireTime=" + expireTime;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FilePath2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FilePath2Response>();
                }
                else
                {
                    response = new FilePath2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[源文件下载链接]发生异常！", ex);
            }
        }

        /// <summary>
        /// 获取文件路径。
        /// <para>通过接口，可根据文件Id获得文件所在的相对路径。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID</param>
        /// <returns></returns>
        public virtual FilePath2Response GetFilePath(string accessToken, string projectId, string fileItemId)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/getFileItemPathByIdUsingGET.html */

            // GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/{fileItemId}/fileItemsPath
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/{1}/fileItemsPath", projectId, fileItemId);

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FilePath2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FilePath2Response>();
                }
                else
                {
                    response = new FilePath2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[获取文件路径]发生异常！", ex);
            }
        }

        /// <summary>
        /// 复制文件。
        /// <para>可以将文件复制到指定的位置，支持跨项目复制文件，并可以通过指定文件Id,或文件路径两种方式复制。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="targetParentId"> 【必填】目标位置上传文件夹Id,(targetParentId和targetParentPath必须二选一)</param>
        /// <param name="fileItemPaths">【必填】 需要复制的文件路径集合(fileItemIds和fileItemPath必须二选一)</param>
        /// <param name="fileItemIds">【必填】需要复制的文件id集合(fileItemIds和fileItemPath必须二选一)</param>
        /// <param name="targetProjectId">【必填】目标位置的项目Id</param>
        /// <param name="targetParentPath">【必填】目标位置上层文件夹路径,(targetParentId和targetParentPath必须二选一)</param>
        /// <returns></returns>
        public virtual FileCopy2Response CopyFile(string accessToken, string projectId, string targetParentId, List<string> fileItemPaths, List<string> fileItemIds, string targetProjectId, string targetParentPath)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/copyFileUsingPOST.html */

            //POST https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/copyItem
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/copyItem", projectId);
            string data = new FileCopy2Request()
            {
                TargetParentId = targetParentId,
                FileItemPaths = fileItemPaths,
                FileItemIds = fileItemIds,
                TargetProjectId = targetProjectId,
                TargetParentPath = targetParentPath
            }.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileCopy2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileCopy2Response>();
                }
                else
                {
                    response = new FileCopy2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[复制文件]发生异常！", ex);
            }

        }

        /// <summary>
        /// 移动文件位置。
        /// <para>移动文件所在的位置，可以通过文件Id或文件路径参数指定新的文件位置，支持批量移动文件位置，无法跨项目移动。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemIds">【必填】需要复制的文件id集合(fileItemIds和fileItemPath必须二选一)</param>
        /// <param name="fileItemPaths">【必填】 需要复制的文件路径集合(fileItemIds和fileItemPath必须二选一)</param>
        /// <param name="targetParentId"> 【必填】目标位置上传文件夹Id,(targetParentId和targetParentPath必须二选一)</param>
        /// <param name="targetParentPath">【必填】目标位置上层文件夹路径,(targetParentId和targetParentPath必须二选一)</param>
        /// <returns></returns>
        public virtual FileMove2Response MoveFile(string accessToken, string projectId, List<string> fileItemIds, List<string> fileItemPaths, string targetParentId, string targetParentPath)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/moveFileUsingPATCH.html */

            // PATCH https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/moveItem
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/moveItem", projectId);
            string data = new FileMove2Request()
            {
                FileItemIds = fileItemIds,
                FileItemPaths = fileItemPaths,
                TargetParentId = targetParentId,
                TargetParentPath = targetParentPath
            }.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileMove2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Patch(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileMove2Response>();
                }
                else
                {
                    response = new FileMove2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[移动文件]发生异常！", ex);
            }

        }

        /// <summary>
        /// 文件重命名。
        /// <para>通过接口对文件的名称进行修改，可通过文件Id和文件路径两种参数指定需要修改的文件夹，默认不允许出现同名文件，可通过参数autoRename控制。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID(fileItemId和path,必须二选一填入 ）</param>
        /// <param name="filePath">【必填】 文件所在路径，使用URL编码（UTF-8），最多256个字符（fileItemId和path,必须二选一填入 ）</param>
        /// <param name="newFileName">【必填】 新文件名称</param>
        /// <param name="autoRename">【选填】文件存在同名时,是否重命名,默认false,false情况下有同名文件则报错</param>
        /// <returns></returns>
        public virtual FileItemResponse RenameFile(string accessToken, string projectId, string fileItemId, string filePath, string newFileName, bool? autoRename = null)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/fileRenameUsingPATCH.html */

            // PATCH https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems", projectId);
            url = url + "?name=" + newFileName.UrlEncode(Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(fileItemId))
            {
                url = url + "&fileItemId=" + fileItemId;
            }
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                url = url + "&path=" + filePath;
            }
            if (autoRename.HasValue)
            {
                url = url + "&autoRename=" + autoRename.Value;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileItemResponse response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Patch(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileItemResponse>();
                }
                else
                {
                    response = new FileItemResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[文件重命名]发生异常！", ex);
            }
        }

        /// <summary>
        /// 批量删除文件。
        /// <para>通过接口传入多个文件Id,即可批量删除文件。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】 	需要删除的文件Id</param>
        /// <param name="fileItemIds">【必填】文件id,若传多个，使用逗号分隔</param>
        public virtual FileDelete2Response DeleteFiles(string accessToken, string projectId, List<string> fileItemIds)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/batchDeleteFileItemsUsingDELETE.html */

            if (fileItemIds == null || fileItemIds.Count == 0)
                throw new BIMFaceException("DeleteFiles()方法中参数" + nameof(fileItemIds) + "无值。");

            // DELETE https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems", projectId);
            string data = fileItemIds.SerializeToJson();

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileDelete2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Delete(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileDelete2Response>();
                }
                else
                {
                    response = new FileDelete2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[批量删除文件]发生异常！", ex);
            }
        }

        /// <summary>
        /// 打包下载压缩文件。
        /// <para>打包下载多个文件的合集。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】 	需要删除的文件Id</param>
        /// <param name="fileItemIds">【必填】文件id,若传多个，使用逗号分隔</param>
        public virtual FileDownload2Response DownloadFilesByZip(string accessToken, string projectId, List<string> fileItemIds)
        {
            /* 官方文档：https://bimface.com/docs/file-management/v1/api-reference/downloadFilesUsingGET.html */

            if (fileItemIds == null || fileItemIds.Count == 0)
                throw new BIMFaceException("DownloadFilesByZip()方法中参数" + nameof(fileItemIds) + "无值。");

            // GET https://api.bimface.com/bdfs/data/v1/projects/{projectId}/fileItems/downloadZip
            string url = string.Format(BIMFaceConstants.API_HOST + "/bdfs/data/v1/projects/{0}/fileItems/downloadZip", projectId) + "?fileItemIds=" + fileItemIds.ToStringWith(",");

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                FileDownload2Response response;

                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<FileDownload2Response>();
                }
                else
                {
                    response = new FileDownload2Response
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[打包下载压缩文件]发生异常！", ex);
            }
        }

        #endregion
    }
}