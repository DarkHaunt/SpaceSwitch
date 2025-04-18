//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReachedSplineEnd;

    public static Entitas.IMatcher<GameEntity> ReachedSplineEnd {
        get {
            if (_matcherReachedSplineEnd == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReachedSplineEnd);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReachedSplineEnd = matcher;
            }

            return _matcherReachedSplineEnd;
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

    static readonly Code.Gameplay.Features.Splines.ReachedSplineEnd reachedSplineEndComponent = new Code.Gameplay.Features.Splines.ReachedSplineEnd();

    public bool isReachedSplineEnd {
        get { return HasComponent(GameComponentsLookup.ReachedSplineEnd); }
        set {
            if (value != isReachedSplineEnd) {
                var index = GameComponentsLookup.ReachedSplineEnd;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : reachedSplineEndComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
