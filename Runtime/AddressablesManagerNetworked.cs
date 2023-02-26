using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Stemuli
{
    public class AddressablesManagerNetworked : NetworkBehaviour
    {
        private List<AsyncOperationHandle> _asyncOperationHandles = new List<AsyncOperationHandle>();

        public static AddressablesManagerNetworked Instance { get; private set; }

        public override void Spawned()
        {
            if (Instance)
            {
                Runner.Despawn(Object);
            }
            else
            {
                Instance = this;
                var rootObj = GameObject.Find("------- Managers ----------");
                transform.parent = rootObj.transform;
            }

        }
        
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
        
        private void CleanUp()
        {
            foreach (var handle in _asyncOperationHandles)
            {
                Addressables.Release(handle);
            }
        }

        private void OnDestroy()
        {
            CleanUp();
        }
    }
}
