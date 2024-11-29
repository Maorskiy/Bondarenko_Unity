

using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;


namespace Client.Runtime
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 700f;
        [SerializeField] private float screenWidthInUnits = 10f;
        [SerializeField] private PlayerDataManager playerDataManager; // Ссылка на PlayerDataManager для добавления очков

        private bool isGrounded = true;
        private GameObject lastPlatform = null; // Переменная для хранения последней платформы

        private void Awake()
        {
            Assert.IsNotNull(_rb, "[PlayerMovement] Rigidbody2D is required");
            Assert.IsNotNull(playerDataManager, "[PlayerMovement] PlayerDataManager is required");
        }

        private void Update()
        {
            MovePlayer();
            CheckJump();
            //CheckScreenWrap();
        }

        private void MovePlayer()
        {
            float moveDirection = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(moveDirection * moveSpeed, _rb.velocity.y);
        }

        private void CheckJump()
        {
            if (isGrounded)
            {
                if (_rb.velocity.y <= 0)
                {
                    _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                isGrounded = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;

                // Проверка, является ли эта платформа новой
                if (collision.gameObject != lastPlatform)
                {
                    lastPlatform = collision.gameObject; // Обновляем последнюю платформу

                    // Добавляем очки за новую платформу
                    if (playerDataManager != null)
                    {
                        playerDataManager.AddScore(10); // Добавляем 10 очков за новую платформу
                    }
                }
            }

            if (collision.collider.name == "DeadZone")
            {
                SceneManager.LoadScene(0); // Перезапуск сцены
            }
        }
    }
}
