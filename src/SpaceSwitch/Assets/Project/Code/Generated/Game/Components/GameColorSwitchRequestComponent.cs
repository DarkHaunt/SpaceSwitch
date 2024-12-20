//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherColorSwitchRequest;

    public static Entitas.IMatcher<GameEntity> ColorSwitchRequest {
        get {
            if (_matcherColorSwitchRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ColorSwitchRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherColorSwitchRequest = matcher;
            }

            return _matcherColorSwitchRequest;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.ColorSwitch.ColorSwitchRequest colorSwitchRequest { get { return (Code.Gameplay.Features.ColorSwitch.ColorSwitchRequest)GetComponent(GameComponentsLookup.ColorSwitchRequest); } }
    public Code.Gameplay.Features.ColorSwitch.StaticData.ColorType ColorSwitchRequest { get { return colorSwitchRequest.Value; } }
    public bool hasColorSwitchRequest { get { return HasComponent(GameComponentsLookup.ColorSwitchRequest); } }

    public GameEntity AddColorSwitchRequest(Code.Gameplay.Features.ColorSwitch.StaticData.ColorType newValue) {
        var index = GameComponentsLookup.ColorSwitchRequest;
        var component = (Code.Gameplay.Features.ColorSwitch.ColorSwitchRequest)CreateComponent(index, typeof(Code.Gameplay.Features.ColorSwitch.ColorSwitchRequest));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceColorSwitchRequest(Code.Gameplay.Features.ColorSwitch.StaticData.ColorType newValue) {
        var index = GameComponentsLookup.ColorSwitchRequest;
        var component = (Code.Gameplay.Features.ColorSwitch.ColorSwitchRequest)CreateComponent(index, typeof(Code.Gameplay.Features.ColorSwitch.ColorSwitchRequest));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveColorSwitchRequest() {
        RemoveComponent(GameComponentsLookup.ColorSwitchRequest);
        return this;
    }
}
