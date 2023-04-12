using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nn.hid;

public class InsertCoinScript : MonoBehaviour {
    // 生成されるコインオブジェクト
    [SerializeField] GameObject g_coinObject;

    private NpadId npadId = NpadId.Invalid;
    private NpadStyle npadStyle = NpadStyle.Invalid;
    private NpadState npadState = new NpadState();

    private void Start() {
        Npad.Initialize();
        Npad.SetSupportedIdType(new NpadId[] { NpadId.Handheld, NpadId.No1 });
        Npad.SetSupportedStyleSet(NpadStyle.FullKey | NpadStyle.Handheld | NpadStyle.JoyDual);
    }



    private void Update() {
    

        // Jumpボタンが押されたとき
        if (Input.GetButtonDown("Jump") || npadState.GetButton(NpadButton.A))
        {
            // オブジェクトを生成する
            // 出現位置は現オブジェクトのポジション
            // 回転は無し
            Instantiate(g_coinObject, this.transform.position, Quaternion.identity);
        }
    }
}
