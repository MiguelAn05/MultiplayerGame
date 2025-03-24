using Photon.Pun;
using UnityEngine;

namespace Mechanic
{
    public class Shoot : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed = 10f;

        private PhotonView _photonView;
        private bool _facingRight = true; 

        private void Start()
        {
            _photonView = GetComponentInParent<PhotonView>();
        }

        private void Update()
        {
            if (!_photonView.IsMine) return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnShoot();
            }
        }

        private void OnShoot()
        {
            GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, firePoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            if (bulletScript != null)
            {
                float direction = Mathf.Sign(transform.localScale.x);
                bulletScript.SetDirection(new Vector3(direction, 0, 0));
            }
        }

        public void SetFacingDirection(bool facingRight)
        {
            _facingRight = facingRight;
        }
    }
}
