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
            // 이동방향 설정 (0, 0, 0) 이동 중지
            Movement2D.MoveTo(Vector3.zero);
            // 과녁의 자식으로 설정, 과녁과 함께 회전
            transform.SetParent(collision.transform);
            collision.GetComponent<Target>().Hit();           

            Instantiate(hitEffectPrefab, hitEffectSpawnPoint.position, hitEffectSpawnPoint.rotation);

            //PinSpawner에서 ShakeCamera 변수를 미리 받아둠.
            //Pin를 생성할 때 pin.Setup(shakeCamera);와 같이 받아와서 쓰면 좋다.
            Camera.main.GetComponent<ShakeCamera>().Shake(0.1f, 1);

            //과녁에 배치된 Pin은 OnTriggerEnter2D()를 호출하지 않도록 스크립트 삭제
            Destroy(this);
        }
        else if (collision.CompareTag("Pin"))
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
