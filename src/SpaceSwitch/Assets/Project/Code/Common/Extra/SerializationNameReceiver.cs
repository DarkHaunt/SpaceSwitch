using UnityEngine;

namespace Code.Common.Extra
{
   public abstract class SerializationNameReceiver : ISerializationCallbackReceiver
   {
      [HideInInspector] public string Name;

      protected abstract string ReceiveName();

      public void OnBeforeSerialize() =>
         Name = ReceiveName();

      public void OnAfterDeserialize() {}
   }
}