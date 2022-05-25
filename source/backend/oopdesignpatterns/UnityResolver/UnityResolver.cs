using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace OOPDesignPatternsAPP.UnityResolver
{
    public class UnityResolver
    {
        public static void Register()
        {
            /* Implement Unity Through Config File */
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();
             /* Implement Unity Through Code */
            // var container = new UnityContainer();
            // container.RegisterType<IYourType, YourType>();
        }
    }
}
