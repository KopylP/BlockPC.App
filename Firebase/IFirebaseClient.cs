using Firebase.Database;
using Firebase.Database.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopyl.BlockPC.App.Firebase
{
    interface IFirebaseClient<T>: IDisposable
    {
        Task SubscribeOnDataChangedAsync(string childPath, Action<FirebaseEvent<T>> action);
        Task<FirebaseObject<T>> PostAsync(string childPath, T data);
        Task PutAsync(string childPath, T data);

    }
}
