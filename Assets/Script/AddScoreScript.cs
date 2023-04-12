using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreScript : MonoBehaviour {

    // スコア
    private int g_score = 0;

    // 外部からスコアを取得できるようにプロパティを作成
    // (メソッドからアクセスできる用にする)
    public int G_score {
        get {
            return g_score;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // コインが接触した場合スコアを加算する
        if (collision.transform.tag == "ScoreAdd") {
            g_score++;

            // コインをデストロイする
            Destroy(collision.transform.gameObject);
        }
    }
}
