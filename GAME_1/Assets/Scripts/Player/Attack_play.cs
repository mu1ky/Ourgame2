using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_play : MonoBehaviour
{
    public class PlayerShooting : MonoBehaviour
    {
        public Camera playerCamera; // ������ �� ������ ������
        public float shootingRange = 100f; // ������������ ��������� ��������
        public float damage = 20f; // ���� �� ������� ��������
        public float fireRate = 1f; // ������� ��������
        private float nextFireTime = 0f;

        void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // �������� ������� �������
            {
                nextFireTime = Time.time + 1f / fireRate; // ��������� ������� ��������� ��������
                Shoot();
            }
        }

        private void Shoot()
        {
            RaycastHit hit;
            // ������� ��� �� ������� ������ � ����������� �� �������
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
            {
                Debug.Log("������� �� �������: " + hit.transform.name);
                // �������� �� ��������� � �����
                Robot enemy = hit.transform.GetComponent<Robot>(); // �����������, ��� � ����� ���� ����� Enemy
                if (enemy != null)
                {
                    enemy.TakeDamage_enemy(damage); // ��������� �������� �����
                    Debug.Log("����� ����� � �����! ����: " + damage);
                }
            }
        }
    }
}