using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject ItemBox;
    public float checkTime;

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(ItemBox);
            temp.transform.position = this.gameObject.transform.position;
            int RandomNumber = Random.Range(0, 4);
            temp.transform.position += new Vector3(RandomNumber, RandomNumber, 0.0f);
        }
    }
}

