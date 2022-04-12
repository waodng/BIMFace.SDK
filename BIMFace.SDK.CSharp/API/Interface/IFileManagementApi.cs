// /* ---------------------------------------------------------------------------------------
//    文件名：IFileManagementApi.cs
//    文件功能描述：
// 
//    创建标识：20220412
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.IO;

using BIMFace.SDK.CSharp.Entity.Request;
using BIMFace.SDK.CSharp.Entity.Response;

namespace BIMFace.SDK.CSharp.API
{
    /// <summary>
    ///  文档管理功能接口
    /// </summary>
    public partial interface IFileManagementApi
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
        HubsResponse GetHubs(string accessToken, string dateTimeFrom = "", string dateTimeTo = "", string info = "",
                             string name = "", string tenantCode = "BIMFACE");

        /// <summary>
        /// 获取Hub Meta信息
        /// <para>通过该接口可查询您的账号已注册哪些存储中心（Hub）,您可以将文件上传到已注册的存储空间里。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        HubMetaResponse GetHubMeta(string accessToken, string hubId);
        
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
        ProjectResponse CreateProject(string accessToken, string hubId, string projectName, string projectInfo = "", string projectThumbnail = "");

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
        ProjectsGetResponse GetProjects(string accessToken, string hubId, string projectName = "", bool useFuzzySearch = false);

        /// <summary>
        /// 获取项目信息
        /// <para>根据HubId和项目Id获取指定项目的信息，包括项目名称、项目描述等。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectId">【必填】项目Id</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        ProjectResponse GetProjectInfo(string accessToken, string hubId, string projectId);

        /// <summary>
        /// 根据项目ID删除项目
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="hubId">【必填】hub编号</param>
        /// <param name="projectId">【必填】项目Id</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        ProjectResponse DeleteProject(string accessToken, string hubId, string projectId);

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
        ProjectResponse UpdateProject(string accessToken, string hubId, string projectId, string projectName = "",
                                      string projectInfo = "", string projectThumbnail = "");
       
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
        FolderResponse CreateFolder(string accessToken, string projectId, string folderName, string parentPath,
                                    string parentId, bool autoRename = false);


        /// <summary>
        /// 获取文件夹信息
        /// <para>根据文件夹Id或文件夹路径，可获取文件夹信息，包含文件夹名称、创建时间等。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】 文件夹id(folderId和folderPath,必须二选一填入)</param>
        /// <param name="folderPath">【必填】文件夹所在路径,使用URL编码UTF-8,最多256个字符(folderId和folderPath,必须二选一填入) 	</param>
        /// <exception cref="BIMFaceException"></exception>
        FolderResponse GetFolder(string accessToken, string projectId, string folderId, string folderPath);

        /// <summary>
        /// 获取文件夹下的所有文件
        /// <para>通过接口获取指定文件夹下所有的文件信息，也可获取制定项目下所有文件列表，BIMFACE支持根据父文件Id或父文件夹路径两种方式获取</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="request">【必填】请求参数类</param>
        /// <exception cref="BIMFaceException"></exception>
        FolderContentResponse GetFolderContent(string accessToken, string projectId, FolderContentRequest request);

        /// <summary>
        /// 获取文件夹路径
        /// <para>通过接口，根据文件夹的Id可获得文件夹的所在位置信息。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】文件夹ID</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        FolderPathResponse GetFolderPath(string accessToken, string projectId, string folderId);

        /// <summary>
        /// 获取父文件夹信息
        /// <para>根据文件Id获取其上一层文件夹的信息，包含文件名称、创建时间等。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】文件夹ID</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        FolderResponse GetParentFolder(string accessToken, string projectId, string folderId);

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
        FolderResponse UpdateFolder(string accessToken, string projectId, string folderName, string folderId,
                                    string folderPath, bool autoRename = false);


        /// <summary>
        ///  删除文件夹。
        /// <para>删除指定文件夹，文件夹内所有文件也被删除。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="folderId">【必填】文件夹id(folderId和path,必须二选一填入)</param>
        /// <param name="folderPath">【必填】文件夹路径,使用URL编码（UTF-8），最多256个字符(folderId和path,必须二选一填入)</param>
        /// <returns></returns>
        FolderDeleteResponse DeleteFolder(string accessToken, string projectId, string folderId, string folderPath);
        
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
        FileUpload2Response UploadFileByStream(string accessToken, string projectId, string fileName, Stream fileStream,
                                               string parentId, string parentPath, bool autoRename = false, string sourceId = "");

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
        FileUpload2Response UploadFileByUrl(string accessToken, string projectId, string fileName, string parentId,
                                            string parentPath, string fileUrl, bool autoRename = false,
                                            string sourceId = "", string etag = "", long? maxLength = null);

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
        FileUpload2Response UploadFileByPolicy(string accessToken, string projectId, string fileFullName,
                                               string parentId, string parentPath, bool autoRename = false,
                                               string sourceId = "", long? maxLength = null);

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
        FileItemResponse GetFile(string accessToken, string projectId, string fileItemId, string filePath, bool withItemSource = false);

        /// <summary>
        /// 获取文件状态。
        /// <para>根据文件ID或文件路径获取文件上传状态信息</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID(fileItemId和path,必须二选一填入 ）</param>
        /// <param name="filePath">【必填】 文件所在路径，使用URL编码（UTF-8），最多256个字符（fileItemId和path,必须二选一填入 ）</param>
        /// <returns></returns>
        FileUpload2StatusResponse GetFileUploadStatus(string accessToken, string projectId, string fileItemId, string filePath);

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
        FilePath2Response GetFileDownloadUrl(string accessToken, string projectId, string fileItemId, string filePath,string expireTime = null);

        /// <summary>
        /// 获取文件路径。
        /// <para>通过接口，可根据文件Id获得文件所在的相对路径。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID</param>
        /// <returns></returns>
        FilePath2Response GetFilePath(string accessToken, string projectId, string fileItemId);

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
        FileCopy2Response CopyFile(string accessToken, string projectId, string targetParentId,
                                   List<string> fileItemPaths, List<string> fileItemIds, string targetProjectId, string targetParentPath);

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
        FileMove2Response MoveFile(string accessToken, string projectId, List<string> fileItemIds,
                                   List<string> fileItemPaths, string targetParentId, string targetParentPath);

        /// <summary>
        /// 文件重命名。
        /// <para>通过接口对文件的名称进行修改，可通过文件Id和文件路径两种参数指定需要修改的文件夹，默认不允许出现同名文件，可通过参数autoRename控制。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】项目ID</param>
        /// <param name="fileItemId">【必填】文件ID(fileItemId和path,必须二选一填入 ）</param>
        /// <param name="filePath">【必填】 文件所在路径，使用URL编码（UTF-8），最多256个字符（fileItemId和path,必须二选一填入 ）</param>
        /// <param name="newFileName">【必填】 新文件名称</param>
        /// <param name="withItemSource">【选填】</param>
        /// <returns></returns>
        FileItemResponse RenameFile(string accessToken, string projectId, string fileItemId, string filePath, string newFileName, bool withItemSource = false);

        /// <summary>
        /// 批量删除文件。
        /// <para>通过接口传入多个文件Id,即可批量删除文件。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="projectId">【必填】 	需要删除的文件Id</param>
        /// <param name="fileItemIds">【必填】文件id,若传多个，使用逗号分隔</param>
        FileDelete2Response DeleteFiles(string accessToken, string projectId, List<string> fileItemIds);

        FileDownload2Response DownloadFilesByZip(string accessToken, string projectId, List<string> fileItemIds);

        #endregion
    }
}