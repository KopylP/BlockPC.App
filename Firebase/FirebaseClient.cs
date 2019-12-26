using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using Kopyl.BlockPC.App.Utils;
using System;
using System.Threading.Tasks;

namespace Kopyl.BlockPC.App.Firebase
{
    class FirebaseClient<T> : IDisposable, IFirebaseClient<T>
    {
        //      var firebaseConfig = {
        //  apiKey: "AIzaSyAB3yMXxkGZCPZxWy1INWnAiGOeHsxI9W0",
        //  authDomain: "kopyl-blockpc.firebaseapp.com",
        //  databaseURL: "https://kopyl-blockpc.firebaseio.com",
        //  projectId: "kopyl-blockpc",
        //  storageBucket: "kopyl-blockpc.appspot.com",
        //  messagingSenderId: "40250405049",
        //  appId: "1:40250405049:web:fe70c3af1071e762a7eb68"
        //};


        #region fields
        private FirebaseClient _client;

        private bool disposed = false;

        private ILogger _logger;
        #endregion

        #region properties

        #endregion

        #region constructor
        public FirebaseClient(string url, FirebaseOptions firebaseOptions)
        {
            _logger = new Logger
            {
                LogFilePath = "D:\\firebase.config.log"
            };
            _client = new FirebaseClient(
                url, firebaseOptions
            );
        }
        #endregion

        #region methods
        public async Task SubscribeOnDataChangedAsync(string childPath, Action<FirebaseEvent<T>> action)
        {
            _client
                .Child(childPath)
                .AsObservable<T>()
                .Subscribe(d => action(d));
        }

        public async Task<FirebaseObject<T>> PostAsync(string childPath, T data)
        {
            var res = await _client
                .Child(childPath)
                .PostAsync(data);
            return res;
        }

        public async Task PutAsync(string childPath, T data)
        {
            await _client
                .Child(childPath)
                .PutAsync(data);
        }
        #endregion

        #region finilize
        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                _client?.Dispose();
                disposed = true;
            }
        }

        // Деструктор
        ~FirebaseClient()
        {
            Dispose(false);
        }
        #endregion
    }
}
