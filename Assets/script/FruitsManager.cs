using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FruitsType
{
    じみへん,
    後藤ふたり,
    後藤ひとり,
    きくり,
    PAさん,
    伊地知星歌,
    伊地知虹夏,
    山田リョウ,
    喜多郁代,
    はまじあき先生,
    ぼっちちゃん,
    MAX,
}

public class FruitsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;

    [SerializeField] private Image nextFruitImage;

    public int nextFruitIndex;

    private int ChoiceNextFruit()
    {
        int index = Random.Range(0, fruitPrefabs.Length);
        nextFruitImage.sprite = fruitPrefabs[index].GetComponent<SpriteRenderer>().sprite;
        return index;
    }

    private void Start()
    {
        nextFruitIndex = ChoiceNextFruit();
    }


    public static GameObject GetNextFruit(FruitsType fruitsType)
    {
        return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = GameObject.Find("Canvas/Spown").transform.position;
            position.z=0;

            //生成するフルーツの種類をランダムで決める
            int fruitType = Random.Range(0, fruitPrefabs.Length);

            GameObject createdFruit = Instantiate(fruitPrefabs[nextFruitIndex],position, Quaternion.identity);

            //生成したあとちょっと傾ける
            createdFruit.transform.Rotate(new Vector3(0,0,Random.Range(-30,30)));

            //生成した後ちょっと回転させる
            createdFruit.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-30,30);

            nextFruitIndex = ChoiceNextFruit();
        }
    }
}
