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
   }
}