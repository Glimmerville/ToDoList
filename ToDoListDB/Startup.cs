using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoListDB.Startup))]
namespace ToDoListDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
