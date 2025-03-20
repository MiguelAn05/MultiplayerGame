using UnityEngine;

namespace Mechanic
{
   public class BulletDestroyer : MonoBehaviour
   {
      public void OnTriggerEnter2D(Collider2D other)
      {
         if (other.CompareTag("Bullet"))
         {
            Destroy(other.gameObject);
         }
      }
   }
}
