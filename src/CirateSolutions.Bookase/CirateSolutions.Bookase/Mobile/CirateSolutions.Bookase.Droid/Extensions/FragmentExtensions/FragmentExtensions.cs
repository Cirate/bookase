
using AndroidX.Fragment.App;

namespace CirateSolutions.Bookase.Droid.Extensions.FragmentExtensions
{
    public static class FragmentExtensions
    {
        public static string FragmentJavaName(this Fragment fragment) => Java.Lang.Class.FromType(fragment.GetType()).Name;
    }
}