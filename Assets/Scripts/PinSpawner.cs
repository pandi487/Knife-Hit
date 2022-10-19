using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pinPrefab;

    [SerializeField]
    private Text ScoreText; //Score ���� Textǥ��

    [SerializeField]
    private static int ScoreValue = 0; // ����

    private void Start()
    {
        ScoreValue = 0;
        ScoreText.text = "Score : " + ScoreValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Instantiate(pinPrefab, transform.position, Quaternion.identity);
                AddScore(1);
            }
        }
    }

    public void AddScore(int num)
    {
        ScoreValue += num;
        ScoreText.text = "Score :" + ScoreValue.ToString();
    }
}
