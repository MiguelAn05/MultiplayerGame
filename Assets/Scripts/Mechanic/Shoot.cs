using UnityEngine;

public class Shoot : MonoBehaviour
{
   [SerializeField] private GameObject bulletPrefab;
   
   
   private void Update()
   {
      OnShoot();
   }

   private void OnShoot()
   {
      if (bulletPrefab != null)
      {
          if (Input.GetMouseButtonDown(0))
          {
              Instantiate(bulletPrefab, transform.position, Quaternion.identity);
          }
          
      }
     
   } 
   
   
   
   
}
