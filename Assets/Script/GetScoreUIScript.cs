using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreUIScript : MonoBehaviour {
    // インスペクターでスコアを管理しているオブジェクトを設定
    public GameObject g_scoreObject;

    // startメソッドでスコア管理用のスクリプトを取得する
    private AddScoreScript g_scoreScript;

    // UIとして表示するスコアのテキストオブジェクト
    private Text g_scoreDisplayText;

    private void Start() {
        // スコアを管理しているスクリプトを取得する
        g_scoreScript = g_scoreObject.GetComponent<AddScoreScript>();

        // テキストオブジェクトを取得する
        g_scoreDisplayText = this.GetComponent<Text>();
    }
    private void Update() {
        // スコアを取得してテキストに表示する
        g_scoreDisplayText.text = g_scoreScript.G_score.ToString();
    }
}
