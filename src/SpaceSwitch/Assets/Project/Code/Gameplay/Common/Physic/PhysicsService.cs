using System.Collections.Generic;
using Code.Gameplay.Common.Collisions;
using UnityEngine;
using Physics = UnityEngine.Physics;

namespace Project.Code.Gameplay.Common.Physic
{
  public class PhysicsService : IPhysicsService
  {
    private static readonly RaycastHit[] Hits = new RaycastHit[128];
    private static readonly Collider[] OverlapHits = new Collider[128];
    
    private readonly ICollisionRegistry _collisionRegistry;

    public PhysicsService(ICollisionRegistry collisionRegistry)
    {
      _collisionRegistry = collisionRegistry;
    }

    public IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask)
    {
      int hitCount = Physics.RaycastNonAlloc(worldPosition, direction, Hits, float.MaxValue, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public int OverlapSphere(Vector3 worldPos, float radius, Collider[] hits, int layerMask) =>
      Physics.OverlapSphereNonAlloc(worldPos, radius, hits, layerMask);

    public GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask)
    {
      int hitCount = Physics.RaycastNonAlloc(worldPosition, direction, Hits, float.MaxValue, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public GameEntity LineCast(Vector3 start, Vector3 end, int layerMask)
    {
      Vector3 direction = end - start;
      int hitCount = Physics.RaycastNonAlloc(start, direction, Hits, direction.magnitude, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }
    
    public IEnumerable<GameEntity> SphereCast(Vector3 position, float radius, int layerMask) 
    {
      int hitCount = Physics.OverlapSphereNonAlloc(position, radius, OverlapHits, layerMask);

      DrawDebug(position, radius, 1f, Color.red);
      
      for (int i = 0; i < hitCount; i++)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public int SphereCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer) 
    {
      int hitCount = Physics.OverlapSphereNonAlloc(position, radius, OverlapHits, layerMask);

      DrawDebug(position, radius, 1f, Color.green);
      
      for (int i = 0; i < hitCount; i++)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
        if (entity == null)
          continue;

        if (i < hitBuffer.Length)
          hitBuffer[i] = entity;
      }

      return hitCount;
    }

    public TEntity OverlapPoint<TEntity>(Vector3 worldPosition, int layerMask) where TEntity : class
    {
      int hitCount = Physics.OverlapSphereNonAlloc(worldPosition, 0.1f, OverlapHits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        Collider hit = OverlapHits[i];
        if (hit == null)
          continue;

        TEntity entity = _collisionRegistry.Get<TEntity>(hit.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    private static void DrawDebug(Vector3 worldPos, float radius, float seconds, Color color)
    {
      Debug.DrawLine(worldPos + radius * Vector3.up, worldPos - radius * Vector3.up, color, seconds);
      Debug.DrawLine(worldPos + radius * Vector3.right, worldPos - radius * Vector3.right, color, seconds);
      Debug.DrawLine(worldPos + radius * Vector3.forward, worldPos - radius * Vector3.forward, color, seconds);
    }
  }
}