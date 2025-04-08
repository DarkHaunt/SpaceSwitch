using System;
using Code.Common.Extra;

namespace Code.Gameplay.Features.Effects
{
  [Serializable]
  public class EffectSetup : SerializationNameReceiver
  {
    public EffectTypeId EffectTypeId;
    public float Value;

    public EffectSetup(EffectTypeId id, float value)
    {
      EffectTypeId = id;
      Value = value;  
    } 

    protected override string ReceiveName() =>
       $"{EffectTypeId.ToString()} - {Value}";
  }
}