using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform player; // ������ �� ������ ������
        public float shootingRange = 10f; // ������������ ��������� ��� ��������
        public float shootingDelay = 2f; // ����� �������� ����� ����������
        public float fieldOfViewAngle = 45f; // ���� ����������� ����
        public GameObject bulletPrefab; // ������ ����
        public Transform firePoint; // �����, ������ ����� �������� ����

        private void Start()
        {
            StartCoroutine(ShootAtPlayer());
        }

        private IEnumerator ShootAtPlayer()
        {
            while (true)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.position);

                // ��������� ��������� �� �� � ������� �������� � ���� �� ������ ��������� �� ������
                if (distanceToPlayer <= shootingRange && CanSeePlayer())
                {
                    Shoot();
                    yield return new WaitForSeconds(shootingDelay); // ���� ����� ��������� ���������
                }
                else
                {
                    yield return null; // �������� ���������� �����
                }
            }
        }

        private void Shoot()
        {
            // ������� ����
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(firePoint.up * 20f, ForceMode2D.Impulse); // ������ �������� ����
            Debug.Log("Shoot at player!");
        }

        private bool CanSeePlayer()
        {
            // ��������� ���� ����� ������ � �������
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.up, directionToPlayer);

            if (angle < fieldOfViewAngle / 2f)
            {
                // ��������� �� ������� ����������� ����� ������ � �������
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, shootingRange);
                if (hit.collider != null && hit.collider.transform == player)
                {
                    return true; // ����� �� ����
                }
            }

            return false; // ����� ��� ���� ������ ��� ���� �����������
        }

        private void Update()
        {
            // ������ �������� ����� � ������ (�� �������)
            FacePlayer();
        }

        private void FacePlayer()
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            // �������� �� ��������� � ������
            if (other.CompareTag("Player"))
            {
                // ������ ��������� ����� ������
                // ��������, ������� ����� ����������� � ������
                Debug.Log("Player hit!");
                Destroy(gameObject); // ���������� ����
            }
            else
            {
                Destroy(gameObject, 2f); // ���������� ���� ����� 2 �������, ���� �� ������ � ������
            }
        }
    }
}
