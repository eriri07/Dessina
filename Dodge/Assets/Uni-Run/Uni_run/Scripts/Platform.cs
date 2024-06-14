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

    //������Ʈ�� Ȱ��ȭ �� ������ �Ź� ����Ǵ� �ż���(�÷��̸� ���� ���� ���ʷ� �� �� �����)
    private void OnEnable()
    {
        //���� ���¸� ����
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
        //�浹�� ���¹��� �±װ� Player�̰� ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager_uni_run.instance.AddScore(1);
        }
    }
}
