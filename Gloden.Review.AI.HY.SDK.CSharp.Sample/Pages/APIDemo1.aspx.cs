using System;

using BIMFace.SDK.CSharp.Common.Extensions;

using Gloden.Review.AI.BIM.SDK.CSharp.API;

namespace Gloden.Review.AI.BIM.SDK.CSharp.Sample.Pages
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