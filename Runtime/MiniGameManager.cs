using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Arbelos
{
    public class MiniGameManager : MonoBehaviour
    {
        public static MiniGameManager Instance;
        private Transform attachTransform;  //make all mini games a child of this transform
        public GameObject currentMiniGameObject;
        
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

        public void LoadMiniGame(string addressableName)
        {
            AddressablesManager.Instance.LoadAddressableGameObject(addressableName, OnAddressableLoaded);
        }

        private void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
        {
            //spawn the mini game
            currentMiniGameObject = Instantiate(handle.Result, attachTransform);
            
            //get the mini game data holder
            MiniGameDataHolder dataHolder = currentMiniGameObject.GetComponent<MiniGameDataHolder>();
            
            //get the mini game and initialize it
            IMiniGame miniGame = currentMiniGameObject.GetComponent<IMiniGame>();
            miniGame.Initialize(dataHolder);
        }
    }
}