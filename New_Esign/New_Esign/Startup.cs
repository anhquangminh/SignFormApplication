using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(New_Esign.Startup))]
namespace New_Esign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string language = Ultils.GetCookie("lang");
            if (!string.IsNullOrEmpty(language)) LanguageHelper.languageId = language;
            ConfigureAuth(app);
        }
    }
}
