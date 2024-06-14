using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameObject[] obstacles = new GameObject[3];
    bool stepped = false;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            obstacles[i] = transform.GetChild(i).gameObject;
        }
    }

    //컴포넌트가 활성화 될 때마다 매번 실행되는 매서드(플레이를 누를 때도 최초로 한 번 실행됨)
    private void OnEnable()
    {
        //밟힘 상태를 리셋
        stepped = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌한 상태방의 태그가 Player이고 이전에 플레이어 캐릭터가 밟지 않았다면
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager_uni_run.instance.AddScore(1);
        }
    }
}
