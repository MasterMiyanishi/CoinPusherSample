using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAreaScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {

        // 触れたものを3秒後に削除する
        Destroy(collision.gameObject, 3f);
    }
}
