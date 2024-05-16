using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
        /*Vector3.one = Vector3(1, 1, 1)
        Vector3.Left = Vector3(1, 0, 0)
        Vector3.Right = Vector3(-1, 0, 0)
        Vector3.back = Vector3(0, 0, -1)
        Vector3.forward = Vector3(0, 0, 1)
        Vector3.down = Vector3(0, -1, 0)
        Vector3.up = Vector3(0, 1, 0)*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("게임 오브젝트의 앞 방향 = " + transform.forward);
            Debug.Log("게임 오브젝트의 왼쪽 방향 = " + transform.right);
            Debug.Log("게임 오브젝트의 위쪽 방향 = " + transform.up);
        }
    }
}
