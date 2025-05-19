using UnityEngine;

namespace Project.Code.Gameplay.Common.Physic
{
   public static class PhysicTools
   {
      private static readonly Collider[] TempBuffer = new Collider[128];
      
      public static int OverlapCollider3DNonAlloc(Collider collider, Collider[] results, int layerMask = Physics.DefaultRaycastLayers)
      {
         int count = 0;

         switch (collider)
         {
            case BoxCollider box:
            {
               Vector3 center = box.transform.TransformPoint(box.center);
               Vector3 halfExtents = Vector3.Scale(box.size * 0.5f, box.transform.lossyScale);
               Quaternion rotation = box.transform.rotation;

               count = Physics.OverlapBoxNonAlloc(center, halfExtents, TempBuffer, rotation, layerMask);
               break;
            }
            case SphereCollider sphere:
            {
               Vector3 center = sphere.transform.TransformPoint(sphere.center);
               float radius = sphere.radius * MaxScaleFactor(sphere.transform.lossyScale);

               count = Physics.OverlapSphereNonAlloc(center, radius, TempBuffer, layerMask);
               break;
            }
            case CapsuleCollider capsule:
            {
               GetCapsuleWorldPoints(capsule, out Vector3 point0, out Vector3 point1, out float radius);
               count = Physics.OverlapCapsuleNonAlloc(point0, point1, radius, TempBuffer, layerMask);
               break;
            }
            default:
               Debug.LogWarning($"OverlapCollider3DNonAlloc: collider type {collider.GetType().Name} not supported.");
               return 0;
         }

         for (int i = 0; i < count; i++)
         {
            Collider col = TempBuffer[i];
            
            if (col != collider)
               results[i] = col;
         }

         return count;
      }

      private static float MaxScaleFactor(Vector3 v) => Mathf.Max(v.x, v.y, v.z);

      private static void GetCapsuleWorldPoints(CapsuleCollider capsule, out Vector3 point0, out Vector3 point1, out float radius)
      {
         Transform t = capsule.transform;
         Vector3 center = t.TransformPoint(capsule.center);
         float height = capsule.height * 0.5f;
         Vector3 scale = t.lossyScale;
         radius = capsule.radius * MaxScaleFactor(scale);

         Vector3 direction;
         switch (capsule.direction)
         {
            case 0:
               direction = t.right;
               height *= scale.x;
               break;
            case 1:
               direction = t.up;
               height *= scale.y;
               break;
            case 2:
               direction = t.forward;
               height *= scale.z;
               break;
            default: direction = t.up; break;
         }

         point0 = center + direction * (height - radius);
         point1 = center - direction * (height - radius);
      }
   }
}