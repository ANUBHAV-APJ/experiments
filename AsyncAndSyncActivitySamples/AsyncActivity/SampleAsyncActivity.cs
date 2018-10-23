using Newtonsoft.Json.Linq;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncActivity
{
    public class SampleAsyncActivity : AsyncCodeActivity<JObject>
    {        
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {

            Func<Uri, JObject> userDelegate = new Func<Uri, JObject>(GetUserAsync);
            context.UserState = userDelegate;
            return userDelegate.BeginInvoke(new Uri("https://reqres.in/api/users/2"), callback, state);
        }

        protected override JObject EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            Func<Uri, JObject> userDelegate = (Func<Uri, JObject>)context.UserState;
            return userDelegate.EndInvoke(result);
        }

        public JObject GetUserAsync(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var userJson = client.GetStringAsync(uri);
                return JObject.Parse(userJson.Result);
            }
        }
    }
}
