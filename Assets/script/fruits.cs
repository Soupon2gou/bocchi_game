using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public enum FruitsType
    {

    }

    public int mySerialNumber;
    private static int totalSerialNumber=0;

    private void Start()
    {
        totalSerialNumber++;
        mySerialNumber = totalSerialNumber;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out fruits otherFruits ))
        {
            if (otherFruits.mySerialNumber<mySerialNumber)
            {
                Debug.Log("create next fruits");

            }
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
