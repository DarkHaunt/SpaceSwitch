//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawningEnemies;

    public static Entitas.IMatcher<GameEntity> SpawningEnemies {
        get {
            if (_matcherSpawningEnemies == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawningEnemies);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawningEnemies = matcher;
            }

            return _matcherSpawningEnemies;
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

    static readonly Code.Gameplay.Features.EnemyLifetime.SpawningEnemies spawningEnemiesComponent = new Code.Gameplay.Features.EnemyLifetime.SpawningEnemies();

    public bool isSpawningEnemies {
        get { return HasComponent(GameComponentsLookup.SpawningEnemies); }
        set {
            if (value != isSpawningEnemies) {
                var index = GameComponentsLookup.SpawningEnemies;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : spawningEnemiesComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
