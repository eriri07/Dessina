using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ ������Ʈ
    public float spawnInterval = 1.0f; // ���� ���� (��)
    public Vector3 spawnAreaSize = new Vector3(5f, 0f, 5f); // ���� ���� ũ��

    private float timer = 0.0f;

    void Update()
    {
        // Ÿ�̸� ������Ʈ
        timer += Time.deltaTime;

        // ������ ���ݸ��� ������Ʈ ����
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0.0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    void SpawnObject()
    {
        // ������ ��ġ ���
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                                                                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                                                                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));

        // ������Ʈ ����
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
