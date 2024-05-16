using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public int point = 0;
    public Rigidbody player_rigidbody;          //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;                    //�̵��ӷ�
    int test;
    public GameManager gameManager;
   
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� player_rigidbody�� �Ҵ�
        player_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0, zSpeed);
        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        player_rigidbody.velocity = newVelocity;
    }
    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        GameManager gamemanager = FindObjectOfType<GameManager>();
        gamemanager.EndGame();
    }
    void OnTriggerEnter(Collider other)          //Trigger ���� �浹
    {
        if (other.gameObject.tag == "Item")      //������ Tag�� Items�� �浹 ���� ��
        {
            point += 1;                        //Point 10���� �÷��ش�.
            other.gameObject.SetActive(false);          //�ش� ������Ʈ�� �ı� �����ش�.
            int num = Random.Range(0, 4);
            gameManager.temp[num].SetActive(true);
        }
    }
}
