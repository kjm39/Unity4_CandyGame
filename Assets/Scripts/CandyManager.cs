using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30; //const 定数 ※後から変更不可
    const int RecoverySeconds = 10;

    // 現在のキャンディのストック数
    public int candy = DefaultCandyAmount;
    // ストック回復までの残り秒数 
    int counter;

    //キャンディの消費
    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }

    //残数の数字を取得
    public int GetCandyAmount()
    {
        return candy;
    }

    //キャンディの補充
    public void AddCandy(int amount)
    {
        candy += amount;
    }

    void OnGUI()
    {
        GUI.color = Color.black; //簡易UIの文字色を黒色にしている

        // キャンディのストック数を表示
        string label = "Candy : " + candy;

        // 回復カウントしている時だけ秒数を表示
        if (counter > 0) label = label + " (" + counter + "s)";

        GUI.Label(new Rect(50, 50, 100, 30), label);
    }

    void Update()
    {
        // キャンディのストックがデフォルトより少なく、
        // 回復カウントをしていないときにカウントをスタートさせる
        if (candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy()); //30を下回ったらコルーチンの発動
        }
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;

        // 1秒ずつカウントを進める
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }
}