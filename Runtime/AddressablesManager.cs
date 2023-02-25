using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Arbelos
{
    public abstract class AddressablesManager : MonoBehaviour
    {
        public static AddressablesManager Instance { get; private set; }
        protected List<AsyncOperationHandle> _asyncOperationHandles = new List<AsyncOperationHandle>();
        
        public void LoadAddressableGameObject(string assetAddress, Action<AsyncOperationHandle<GameObject>> callback)
        {
            AsyncOperationHandle<GameObject> opHandle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
            opHandle.Completed += callback;
            _asyncOperationHandles.Add(opHandle);
        }

        public void UnloadAddressable(AsyncOperationHandle handle)
        {
            _asyncOperationHandles.Remove(handle);
        }
        
        protected void CleanUp()
        {
            foreach (var handle in _asyncOperationHandles)
            {
                Addressables.Release(handle);
            }
        }
    }
}