using System;
using Code.Common.Extra;

namespace Code.Gameplay.Features.Effects
{
  [Serializable]
  public class EffectSetup : SerializationNameReceiver
  {
    public EffectTypeId EffectTypeId;
    public float Value;
    
    protected override string ReceiveName() =>
       $"{EffectTypeId.ToString()} - {Value}";
  }
}