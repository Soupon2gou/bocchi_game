using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    public float speed = 5f; // �ړ����x
    public float xBound =4f; // x�������̐���

    private float FirstPosition =0f;

    private void Start()
    {
        FirstPosition = transform.position.x; 
    }

    void Update()
    {
        // ���L�[�̓��͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");

        // ���E�Ɉړ����邽�߂̃x�N�g�����쐬
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // �ړ��x�N�g���ɑ��x����Z���Ď��ۂɈړ�������
        transform.Translate(movement * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -xBound, xBound);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

}
