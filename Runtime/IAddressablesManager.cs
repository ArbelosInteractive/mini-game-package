using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Arbelos
{
    public interface IAddressablesManager
    {
        public void LoadAddressableGameObject(string assetAddress, Action<AsyncOperationHandle<GameObject>> callback);
        public void UnloadAddressable(AsyncOperationHandle handle);
    }
}