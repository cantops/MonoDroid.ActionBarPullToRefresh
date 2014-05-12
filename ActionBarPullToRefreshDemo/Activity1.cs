using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Handmark.Pulltorefresh.Library;
namespace ActionBarPullToRefreshDemo
{
    [Activity(Label = "ActionBarPullToRefreshDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity, PullToRefreshBase.IOnRefreshListener2
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.common_pull_down_list_view);

            this.PullRefreshScrollView = FindViewById<PullToRefreshScrollView>(Resource.Id.pull_refresh_scrollview);
            this.PullRefreshScrollView.SetOnRefreshListener(this);
        }
        protected PullToRefreshScrollView PullRefreshScrollView { set; get; }

      

        public void Refreshing()
        {
            this.PullRefreshScrollView.SetRefreshing();
        }
        public  void OnPullDownToRefresh(PullToRefreshBase p0)
        {
            Toast.MakeText(this,"向下进行刷新",ToastLength.Long).Show();
            Task.Delay(3000).GetAwaiter().OnCompleted(() =>
            {
                this.PullRefreshScrollView.OnRefreshComplete(); //设置一个空的延时，以体现效果
            });
        }

        public  void OnPullUpToRefresh(PullToRefreshBase p0)
        {
            Toast.MakeText(this, "向上拉动加载更多", ToastLength.Long).Show(); 
            Task.Delay(3000).GetAwaiter().OnCompleted(() =>
            {
                this.PullRefreshScrollView.OnRefreshComplete(); //设置一个空的延时，以体现效果
            }); 
        }
    }
}

