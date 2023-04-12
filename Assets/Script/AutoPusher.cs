using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPusher : MonoBehaviour
{
    // 押し出し状態の管理用変数
    public enum PushState
    {
        Back,
        Forward,
    }

    // 押し出し状態の保存用変数
    [SerializeField] PushState g_pushState = PushState.Forward;

    // リジッドボディの定義
    Rigidbody g_rigidbody;

    // 移動速度
    [SerializeField] float g_moveSpeed = 2f;

    // 奥の位置
    Vector3 g_backPosition = new Vector3(0, 2, 3);

    // 手前の位置
    Vector3 g_forwardPosition = new Vector3(0, 2, 6);

    // 移動の始点と終点中間位置
    float g_middlePosition;

    private void Start()
    {
        // リジッドボディの取得
        g_rigidbody = GetComponent<Rigidbody>();

        // 移動の始点と終点中間位置算出（慣性を出すのに利用）
        // 初心者向けではないので注意
        g_middlePosition = (g_backPosition.z + g_forwardPosition.z) / 2;
    }
    private void FixedUpdate()
    {

        // 押し出し状態による分岐
        switch (g_pushState)
        {
            // 奥に移動中の処理
            case PushState.Back:
                // velocityで加速度を直接調節する
                // Vector3.backを指定することで奥に移動する
                // g_middlePosition - g_rigidbody.position.zを行うことで中間位置からどの程度離れているか算出する
                // Mathf.Absを使って絶対値算出（4.5が中間位置だとすると奥に行くと-になり手前になると+になるから）
                // g_moveSpeedから中間位置情報を減算することでスピードの調整を行っている
                // 中間から離れれば離れるほど遅くなる（疑似的な慣性です）
                // 本気で実装する場合は別オブジェクトに紐づけて間接的に動かすのが正解です
                g_rigidbody.velocity = Vector3.back * Mathf.Pow(g_moveSpeed - Mathf.Abs(g_middlePosition - g_rigidbody.position.z), 1.5f);

                // z座標が最大奥位置を超えたら手前に移動するようにステータスを変更する
                if (g_rigidbody.position.z <= g_backPosition.z)
                {
                    g_pushState = PushState.Forward;
                }

                break;
            // 手前に移動中の処理
            case PushState.Forward:
                // velocityで加速度を直接調節する
                // Vector3.forwardを指定することで手前に移動する
                // g_middlePosition - g_rigidbody.position.zを行うことで中間位置からどの程度離れているか算出する
                // Mathf.Absを使って絶対値算出（4.5が中間位置だとすると奥に行くと-になり手前になると+になるから）
                // g_moveSpeedから中間位置情報を減算することでスピードの調整を行っている
                // 中間から離れれば離れるほど遅くなる（疑似的な慣性です）
                // 本気で実装する場合は別オブジェクトに紐づけて間接的に動かすのが正解です
                g_rigidbody.velocity = Vector3.forward * Mathf.Pow(g_moveSpeed - Mathf.Abs(g_middlePosition - g_rigidbody.position.z), 1.5f);

                // z座標が最大手前位置を超えたら奥に移動するようにステータスを変更する
                if (g_rigidbody.position.z >= g_forwardPosition.z)
                {
                    g_pushState = PushState.Back;
                }

                break;
            default:
                break;
        }
    }
}
