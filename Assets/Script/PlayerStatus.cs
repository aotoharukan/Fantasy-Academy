using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int level, hp, mp, sta, str, def, intel, luk, money, turnsLeft;

    public void Initialize()
    {
        level = 1; // 初期レベル
        hp = 100;  // ヒットポイント
        mp = 0;    // マナポイント
        sta = 50;  // スタミナ
        str = 10;  // 力
        def = 10;  // 防御
        intel = 10; // 知力
        luk = 5;   // 運
        money = 100; // 所持金
    }

    public void ApplyTraining(TrainingOption t)
    {
        level++; // レベルアップ
        mp += t.mpup; // マナアップ
        sta -= t.stacost; // スタミナ消費
        sta += t.staup; // スタミナアップ
        hp += t.hpup; //体力アップ
        str += t.strup; // 力アップ
        def += t.defup; // 防御アップ
        intel += t.intelup; // 知力アップ
        luk += t.lukup; // 運アップ        
    }

    // TrainingType を PlayerStatus の外部に定義（別ファイルでもOK）
    public enum TrainingType
    {
        Taf,
        Power,
        Fig,
        Defence,
        Magic,
        Ment
    }

    // PlayerStatus.cs にこの関数を必ず追加
    public void DoTraining(TrainingType type)
    {
        // 仮処理でもいいので最低限は入れておく
        Debug.Log($"トレーニング開始: {type}");
    }

    public string TryTriggerEvent(string phase)
    {
        int reward = Random.Range(1000, 5001);
        money += reward;

        return $"フェーズ:{phase} → {reward}G獲得!";
    }

    public bool SimulateBattle()
    {
        int score = str + def + intel + luk;
        return score > Random.Range(100, 200);
    }

    public void UpReward()
    {
        money += 10000;
        sta += 10;
        Debug.Log("報酬を獲得！");
    }
}

