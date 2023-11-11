using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    public float xBound =4f; // x軸方向の制限

    private float FirstPosition =0f;

    private void Start()
    {
        FirstPosition = transform.position.x; 
    }

    void Update()
    {
        // 矢印キーの入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");

        // 左右に移動するためのベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // 移動ベクトルに速度を乗算して実際に移動させる
        transform.Translate(movement * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -xBound, xBound);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

}
