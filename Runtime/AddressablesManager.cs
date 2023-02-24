using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Arbelos
{
    public abstract class AddressablesManager
    {
        public static AddressablesManager Instance { get; private set; }
        private List<AsyncOperationHandle> asyncOperationHandles = new List<AsyncOperationHandle>();
        
        public void LoadAddressableGameObject(string assetAddress, Action<AsyncOperationHandle<GameObject>> callback)
        {
            var opHandle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
            opHandle.Completed += callback;
            asyncOperationHandles.Add(opHandle);
        }
        
        private void CleanUp()
        {
            foreach (var handle in asyncOperationHandles)
            {
                Addressables.Release(handle);
            }
        }
    }
}