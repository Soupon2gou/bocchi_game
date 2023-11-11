using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    [SerializeField] private FruitsType fruitType =FruitsType.じみへん;
    [SerializeField] private GameObject nextFruitPrefab;
    [SerializeField] ScoreManager scoreManager;
 

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
            if (otherFruits.fruitType != fruitType)
            {
                return ;    
            }
            if (otherFruits.mySerialNumber<mySerialNumber)
            {
                
                if (nextFruitPrefab != null)
                {
                    Debug.Log("create next fruits");
                    Vector3 centerPosition = (transform.position + other.transform.position) / 2;


                    // ２つの回転具合の平均をとる
                    Quaternion rotation = Quaternion.Lerp(transform.rotation, other.transform.rotation, 0.5f);



                    GameObject newFruit = Instantiate(nextFruitPrefab, centerPosition, rotation);

                    //スコアを増やす
                    scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
                    scoreManager.SetScore(nextFruitPrefab);


                    //２つの速度の平均をとる
                    Vector3 velocity = (GetComponent<Rigidbody2D>().velocity + other.gameObject.GetComponent<Rigidbody2D>().velocity) / 2;
                    newFruit.GetComponent<Rigidbody2D>().velocity = velocity;

                    //角速度の平均をとる
                    float angularVelocity = (GetComponent<Rigidbody2D>().angularVelocity + other.gameObject.GetComponent<Rigidbody2D>().angularVelocity) / 2;
                    newFruit.GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
                }

            }
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
