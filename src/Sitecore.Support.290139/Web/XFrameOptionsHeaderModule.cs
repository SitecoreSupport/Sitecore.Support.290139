namespace Sitecore.Support.Web
{
  using System;
  using System.Web;

  public class XFrameOptionsHeaderModule : Sitecore.Web.XFrameOptionsHeaderModule
  {
    /// <summary>
    /// Check whether current requested URL is starts with path to sitecore folder.
    /// </summary>
    /// <param name="httpContext">Instance of <see cref="HttpContextBase"/>.</param>
    /// <returns><c>true</c> ifapplication request url is under protected with header directory; otherwise - <c>false</c>.</returns>
    protected override bool IsSitecoreFolderRequest(HttpContextBase httpContext)
    {
      return httpContext.Request.PhysicalPath.StartsWith(httpContext.Server.MapPath("~/Sitecore/"), StringComparison.InvariantCultureIgnoreCase);
    }
  }
}