using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Linq;

namespace Arbelos
{
    public class MiniGameManager : MonoBehaviour
    {
        public static MiniGameManager Instance;
        [SerializeField] private Transform attachTransform;  //make all mini games a child of this transform
        private IAddressablesManager _addressablesManager;
        private GameObject _currentMiniGameObject;
        private MiniGameDataHolder _currentMiniGameData;
        private AsyncOperationHandle<GameObject> _currentHandle;
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
            IEnumerable<IAddressablesManager> addressablesManagerList = FindObjectsOfType<MonoBehaviour>().OfType<IAddressablesManager>();
            _addressablesManager = addressablesManagerList.ElementAt(0);
        }

        public void LoadMiniGame(string addressableName)
        {
            _addressablesManager.LoadAddressableGameObject(addressableName, OnAddressableLoaded);
        }

        private void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
        {
            _currentHandle = handle;
            _currentMiniGameObject = Instantiate(handle.Result, attachTransform);
            _currentMiniGameData = _currentMiniGameObject.GetComponent<MiniGameDataHolder>();
            IMiniGame miniGame = _currentMiniGameObject.GetComponent<IMiniGame>();
            miniGame.Initialize(_currentMiniGameData);
        }

        public void OnMiniGameCompleted(IMiniGame.ResultStatus result)
        {
            switch (_currentMiniGameData.dataMode)
            {
                case MiniGameDataHolder.MiniGameDataMode.LearningJourney:
                {
                    if (result == IMiniGame.ResultStatus.Success)
                    {
                        //TODO: send success api call to gooru
                    }
                    else
                    {
                        //TODO: send failure api call to gooru
                    }
                    break;
                }
                case MiniGameDataHolder.MiniGameDataMode.Quest:
                {
                    break;
                }
                case MiniGameDataHolder.MiniGameDataMode.Persistent:
                {
                    break;
                }
            }
            
            DeSpawnMiniGame();
        }

        public void DeSpawnMiniGame()
        {
            Destroy(_currentMiniGameObject);
            
            _addressablesManager.UnloadAddressable(_currentHandle);
            
            _currentMiniGameObject = null;
            _currentMiniGameData = null;
            _currentHandle = default;

        }
    }
}