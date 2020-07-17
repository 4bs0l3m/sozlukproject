using SozlukSitesi.Admin.Class;
using SozlukSitesi.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SozlukSitesi.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootStapper.RunConfig();    
        }
        void Session_Start()
        {
            // Kullanıcı herhangi bir sayfadan siteme ziyarete geldiğinde visitor değişkenime +1 ekliyorum.
            //Aynı anda 2 veya daha fazla kullanıcı visitor değişkenime değer ataması yapmasın diye Application.Lock() ile kilitliyorum.
            Application.Lock();
            Session["onlineUser"] = (Convert.ToInt32(Session["onlineUser"]) + 1).ToString();
            Application["visitor"] = Convert.ToInt32(Application["visitor"]) + 1;
            Application.UnLock();
        }

        void Session_End()
        {
            
            // Kullanıcının sesion timeout olduğunda visitor değişkenimi -1 yapıyorum.
            Application.Lock();
            Session["onlineUser"] = (Convert.ToInt32(Session["onlineUser"]) - 1).ToString();
            Application["visitor"] = Convert.ToInt32(Application["visitor"]) - 1;
            Application.UnLock();
            // Değer ataması yaptıktan sonra Application.Unlock() metodunu çağırıp değişkene yeni değer ataması için izin veriyorum.
        }
    }
}
