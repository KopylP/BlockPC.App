using System;
using System.Configuration;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Streaming;

namespace Kopyl.BlockPC.App.Firebase
{
    class BlockPCFirebaseClient<T> : FirebaseClient<T>
    {

        #region constructor
        private BlockPCFirebaseClient(string url, FirebaseOptions firebaseOptions) : base(url, firebaseOptions)
        {
        }
        #endregion

        #region static methods
        public static BlockPCFirebaseClient<T> NewInstance()
        {
            var url = ConfigurationManager.AppSettings["firebase-url"];
            var sekretKey = ConfigurationManager.AppSettings["firebase-secret-key"];
            return new BlockPCFirebaseClient<T>(url, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(sekretKey)
            });
        }
        #endregion
    }
}
