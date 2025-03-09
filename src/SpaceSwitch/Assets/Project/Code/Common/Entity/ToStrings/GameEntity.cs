using System;
using System.Linq;
using System.Text;
using Code.Common.Entity.ToStrings;
using Code.Common.Extensions;
using Entitas;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
  private EntityPrinter _printer;

  public override string ToString()
  {
    if (_printer == null)
      _printer = new EntityPrinter(this);

    _printer.InvalidateCache();

    return _printer.BuildToString();
  }

  public string EntityName(IComponent[] components)
  {
    try
    {
      if (components.Length == 1)
        return components[0].GetType().Name;

      foreach (IComponent component in components)
      {
        switch (component.GetType().Name)
        {
          case "LevelPartComponent":
            return PrintLevelPart();
          case "Projectile":
            return PrintProjectile();
          case "Player":
            return PrintPlayer();
          case "Enemy":
            return PrintEnemy();
        }
      }
    }
    catch (Exception exception)
    {
      Debug.LogError(exception.Message);
    }

    return components.First().GetType().Name;
  }

  private string PrintLevelPart()
  {
    return new StringBuilder($"LevelPart ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString(); 
  }

  private string PrintProjectile()
  {
    return new StringBuilder($"Projectile ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  }

  private string PrintPlayer()
  {
    return new StringBuilder($"Player ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  }
  
  private string PrintEnemy() =>
    new StringBuilder($"Enemy ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  
  public string BaseToString() => base.ToString();
}

