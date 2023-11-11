using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FruitsType
{
    ���݂ւ�,
    �㓡�ӂ���,
    �㓡�ЂƂ�,
    ������,
    PA����,
    �ɒn�m����,
    �ɒn�m����,
    �R�c�����E,
    �쑽���,
    �͂܂������搶,
    �ڂ��������,
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

            //��������t���[�c�̎�ނ������_���Ō��߂�
            int fruitType = Random.Range(0, fruitPrefabs.Length);

            GameObject createdFruit = Instantiate(fruitPrefabs[nextFruitIndex],position, Quaternion.identity);

            //�����������Ƃ�����ƌX����
            createdFruit.transform.Rotate(new Vector3(0,0,Random.Range(-30,30)));

            //���������タ����Ɖ�]������
            createdFruit.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-30,30);

            nextFruitIndex = ChoiceNextFruit();
        }
    }
}
