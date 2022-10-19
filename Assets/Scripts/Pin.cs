using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private Transform hitEffectSpawnPoint;
    [SerializeField]
    private GameObject hitEffectPrefab;

    private Movement2D Movement2D;

    private UIManager UIManager;

    private void Update()
    {
        Movement2D = GetComponent<Movement2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            // �̵����� ���� (0, 0, 0) �̵� ����
            Movement2D.MoveTo(Vector3.zero);
            // ������ �ڽ����� ����, ����� �Բ� ȸ��
            transform.SetParent(collision.transform);
            collision.GetComponent<Target>().Hit();           

            Instantiate(hitEffectPrefab, hitEffectSpawnPoint.position, hitEffectSpawnPoint.rotation);

            //PinSpawner���� ShakeCamera ������ �̸� �޾Ƶ�.
            //Pin�� ������ �� pin.Setup(shakeCamera);�� ���� �޾ƿͼ� ���� ����.
            Camera.main.GetComponent<ShakeCamera>().Shake(0.1f, 1);

            //���ῡ ��ġ�� Pin�� OnTriggerEnter2D()�� ȣ������ �ʵ��� ��ũ��Ʈ ����
            Destroy(this);
        }
        else if (collision.CompareTag("Pin"))
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
