using System;

namespace Arbelos
{
   public interface IMiniGame
   {
        public enum ResultStatus
        {
            Success,
            Failure
        }

        public void Initialize(MiniGameDataHolder dataHolder);
        public void MiniGameComplete(ResultStatus result);
        public void SaveData<T>(string key, T obj);
        public void LoadData<T>(string key, Action<T> resultCallback);
    }
}