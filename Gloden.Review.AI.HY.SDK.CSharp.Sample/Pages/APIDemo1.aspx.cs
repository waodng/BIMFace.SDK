using System;
using Gloden.Review.AI.HY.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;

namespace Gloden.Review.AI.HY.SDK.CSharp.Sample.Pages
{
    public partial class APIDemo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IAuthorizeApi api = new AuthorizeApi();
            var response = api.Login();
            //if (response.success)
            //{
            txtResult.Text = response.SerializeToJson(true);
            //}

        }
    }
}