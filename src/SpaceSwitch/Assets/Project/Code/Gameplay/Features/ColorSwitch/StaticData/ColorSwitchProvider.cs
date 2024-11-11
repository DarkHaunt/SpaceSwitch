namespace Code.Gameplay.Features.ColorSwitch.StaticData
{
   public static class ColorSwitchProvider
   {
      public static ColorType NextColorAfter(ColorType colorType) =>
         colorType == ColorType.Blue
            ? ColorType.Red
            : ColorType.Blue;
   }
}