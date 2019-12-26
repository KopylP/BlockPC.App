using Firebase.Database.Streaming;
using Kopyl.BlockPC.App.Firebase;
using Kopyl.BlockPC.App.Models;
using Kopyl.BlockPC.App.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopyl.BlockPC.App
{
    class FirebaseLockHandler
    {
        IFirebaseClient<LockModel> _firebaseClient;
        string _modelName;

        public FirebaseLockHandler(string modelName)
        {
            _modelName = modelName;
        }

        private void LockModel_DataChanged(FirebaseEvent<LockModel> obj)
        {
            LockModel lockModel = obj.Object;
            try
            {
                if (lockModel.Lock == true)
                {
                    PCLocker.Lock();
                    lockModel.Lock = false;
                    _firebaseClient.PutAsync("computers/first-pc/lock-model", lockModel);
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        internal void Init()
        {
            _firebaseClient = BlockPCFirebaseClient<LockModel>.NewInstance();
            _firebaseClient.PutAsync($"computers/{_modelName}/lock-model", new LockModel { Lock = false });
            _firebaseClient.SubscribeOnDataChangedAsync($"computers/{_modelName}", LockModel_DataChanged);
        }

        internal void Stop()
        {
            _firebaseClient.Dispose();
        }
    }
}
