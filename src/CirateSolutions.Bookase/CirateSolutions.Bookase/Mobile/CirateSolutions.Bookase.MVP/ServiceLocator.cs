using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.MVP
{
    public static class ServiceLocator
    {
        public static IServiceLocator Instance { get; private set; }
        public static void SetImplementation(IServiceLocator serviceLocator) => Instance = serviceLocator;
        public static void ClearImplementation() => Instance = null;
    }
}