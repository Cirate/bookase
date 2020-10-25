using Android.OS;
using AndroidX.AppCompat.App;
using CirateSolutions.Bookase.Droid.Activities.Interfaces;

namespace CirateSolutions.Bookase.Droid.Activities.Abstractions
{
    public abstract class BootstrapActivity
        : AppCompatActivity,
          IBootstrapActivity
    {
        public abstract int LayoutId { get; }
        public abstract int ContentFrameId { get; }
        public static IBootstrapActivity CurrentActivity { get; private set; }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(LayoutId);
            CurrentActivity = this;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (CurrentActivity == this)
                CurrentActivity = null;
        }
    }
}