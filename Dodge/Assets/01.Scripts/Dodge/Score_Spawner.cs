using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // 스폰할 오브젝트
    public float spawnInterval = 1.0f; // 스폰 간격 (초)
    public Vector3 spawnAreaSize = new Vector3(5f, 0f, 5f); // 스폰 영역 크기

    private float timer = 0.0f;

    void Update()
    {
        // 타이머 업데이트
        timer += Time.deltaTime;

        // 지정된 간격마다 오브젝트 스폰
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0.0f; // 타이머 초기화
        }
    }

    void SpawnObject()
    {
        // 랜덤한 위치 계산
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                                                                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                                                                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));

        // 오브젝트 스폰
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
