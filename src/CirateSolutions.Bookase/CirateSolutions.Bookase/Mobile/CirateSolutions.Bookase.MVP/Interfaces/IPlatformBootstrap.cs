using System.Threading.Tasks;
using SimpleInjector;

namespace CirateSolutions.Bookase.MVP.Interfaces
{
    public interface IPlatformBootstrap
    {
        Task Init(Container container);
        Task RegisterPlatformDependencies(Container container);
    }
}