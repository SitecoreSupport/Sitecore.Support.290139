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
      try
      {
        return httpContext.Request.PhysicalPath.StartsWith(httpContext.Server.MapPath("~/Sitecore/"), StringComparison.InvariantCultureIgnoreCase);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Debug("[XFrameOptionsHeaderModule] " + ex.Message + System.Environment.NewLine + ex.StackTrace);

        return true; // In case we cannot identify if the protected folder is requested the data should be protected by the XFrameOptionsHeader
      }
    }
  }
}