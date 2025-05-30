//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlayerSoundPlayer;

    public static Entitas.IMatcher<GameEntity> PlayerSoundPlayer {
        get {
            if (_matcherPlayerSoundPlayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerSoundPlayer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerSoundPlayer = matcher;
            }

            return _matcherPlayerSoundPlayer;
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

    public Code.Gameplay.Features.Player.PlayerSoundPlayerComponent playerSoundPlayer { get { return (Code.Gameplay.Features.Player.PlayerSoundPlayerComponent)GetComponent(GameComponentsLookup.PlayerSoundPlayer); } }
    public Code.Gameplay.Features.Player.Behaviors.PlayerSoundPlayer PlayerSoundPlayer { get { return playerSoundPlayer.Value; } }
    public bool hasPlayerSoundPlayer { get { return HasComponent(GameComponentsLookup.PlayerSoundPlayer); } }

    public GameEntity AddPlayerSoundPlayer(Code.Gameplay.Features.Player.Behaviors.PlayerSoundPlayer newValue) {
        var index = GameComponentsLookup.PlayerSoundPlayer;
        var component = (Code.Gameplay.Features.Player.PlayerSoundPlayerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Player.PlayerSoundPlayerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePlayerSoundPlayer(Code.Gameplay.Features.Player.Behaviors.PlayerSoundPlayer newValue) {
        var index = GameComponentsLookup.PlayerSoundPlayer;
        var component = (Code.Gameplay.Features.Player.PlayerSoundPlayerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Player.PlayerSoundPlayerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePlayerSoundPlayer() {
        RemoveComponent(GameComponentsLookup.PlayerSoundPlayer);
        return this;
    }
}
