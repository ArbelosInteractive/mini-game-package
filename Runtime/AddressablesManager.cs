using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Arbelos
{
    public class AddressablesManager : MonoBehaviour
    {
        public static AddressablesManager Instance { get; private set; }
        private List<AsyncOperationHandle> _asyncOperationHandles = new List<AsyncOperationHandle>();
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
               Destroy(this);
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