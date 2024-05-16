using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public int point = 0;
    public Rigidbody player_rigidbody;          //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;                    //이동속력
    int test;
    public GameManager gameManager;
   
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 player_rigidbody에 할당
        player_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3 (xSpeed, 0, zSpeed);
        //리지드바디의 속도에 newVelocity 할당
        player_rigidbody.velocity = newVelocity;
    }
    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        GameManager gamemanager = FindObjectOfType<GameManager>();
        gamemanager.EndGame();
    }
    void OnTriggerEnter(Collider other)          //Trigger 통한 충돌
    {
        if (other.gameObject.tag == "Item")      //설정한 Tag로 Items와 충돌 했을 때
        {
            point += 1;                        //Point 10점을 올려준다.
            other.gameObject.SetActive(false);          //해당 오브젝트를 파괴 시켜준다.
            int num = Random.Range(0, 4);
            gameManager.temp[num].SetActive(true);
        }
    }
}
