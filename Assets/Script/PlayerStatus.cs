using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
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

    public void UpREward()
    {
        money += 10000;
        sta += 10;
    }
    
/*
        public StatusUI statusUI;

        void Start()
        {
            if (statusUI == null)
            {
                statusUI = FindFirstObjectByType<StatusUI>();  // Unity 2023以降推奨
                Debug.Log("StatusUI 自動取得しました！");
            }
        }


        public enum TrainingType { Taf, Power, Fig, Defence, Magic, Ment}
        public void DoTraining(TrainingType type)
        {
            Debug.Log($"このPlayerStatusのインスタンスID: {this.GetInstanceID()}");
            Debug.Log($"StatusUIが参照してるplayerのID: {statusUI.player.GetInstanceID()}");

            if (turnsLeft <= 0)
            {
                Debug.Log("ターン切れ！");
                return;
            }

            int hpup = 0;  //必ず初期化！
            int mpup = 0;
            int staup = 0;
            int strup = 0;
            int defup = 0;
            int intelup = 0;
            int lukup = 0;

            switch (type)
            {
                case TrainingType.Taf:
                    hpup = Random.Range(25, 51);
                    defup = Random.Range(10, 21);
                    hp += hpup;
                    def += defup;
                    break;

                case TrainingType.Power:
                    strup = Random.Range(20, 31);
                    str += strup;
                    break;

                case TrainingType.Fig:
                    strup = Random.Range(15, 26);
                    staup = Random.Range(1, 6);
                    hp += hpup;
                    str += strup;
                    break;

                case TrainingType.Defence:
                    defup = Random.Range(20, 31);
                    def += defup;
                    break;

                case TrainingType.Magic:
                    intelup = Random.Range(15, 26);
                    mpup = Random.Range(1, 6);
                    Debug.Log($"元のINTEL: {intel}, 元のMP: {mp}");
                    intel += intelup;
                    mp += mpup;
                    Debug.Log($"加算後のINTEL: {intel}, MP: {mp}");
                    break;

                case TrainingType.Ment:
                    mpup = Random.Range(10, 16);
                    mp += mpup;
                    break;
            }

            turnsLeft--;
                if (statusUI != null)
                {
                    statusUI.UpdateALLStatusUI();   // ← UIをまとめて更新！
                }

                Debug.Log($"トレーニング完了：HP+{hpup} MP+{mpup} STA+{staup} STR+{strup} DEF+{defup} INTEL+{intelup} LUK+{lukup} 残ターン:{turnsLeft}");

                if (statusUI != null)
                {
                    statusUI.UpdateALLStatusUI();

                    string result = $"HP+{hpup} MP+{mpup} STA+{staup} STR+{strup} DEF+{defup} INTEL+{intelup} LUK+{lukup}";
                    statusUI.ShowLog(result);

                }

            }*/

}



