using Newtonsoft.Json.Linq;
using System;
using System.Activities;
using System.Threading.Tasks;
using System.Net.Http;
using System.ComponentModel;

namespace SyncActivity
{
    public class SampleSyncActivity : CodeActivity
    {        
        [Category("Output")]
        public OutArgument<JObject> User { get; set; }
             
        protected override void Execute(CodeActivityContext context)
        {
            var user = GetUser(new Uri("https://reqres.in/api/users/2"));
            User.Set(context, user);
        }

        public static JObject GetUser(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var userJson = client.GetStringAsync(uri).Result;
                return JObject.Parse(userJson);
            }   
        }        
    }
}
