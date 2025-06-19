using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int hp = 100;
    public int str = 20;
    public int def = 10;
    public int intel = 20;
    public int luk = 5;
    public int mp = 0;
    public int turnsLeft = 12;

    public StatusUI statusUI;

    void Start()
    {
        if (statusUI == null)
        {
            statusUI = FindFirstObjectByType<StatusUI>();  // Unity 2023以降推奨
            Debug.Log("StatusUI 自動取得しました！");
        }
    }

    
    public enum TrainingType { Power, Magic, Defence }
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
            case TrainingType.Magic:
                intelup = Random.Range(10, 26);
                mpup = Random.Range(5, 11);
                Debug.Log($"元のINTEL: {intel}, 元のMP: {mp}");
                intel += intelup;
                mp += mpup;
                Debug.Log($"加算後のINTEL: {intel}, MP: {mp}");
                break;

            case TrainingType.Power:
                strup = Random.Range(10, 21);
                staup = Random.Range(5, 11);
                hp += hpup;
                str += strup;
                break;

            case TrainingType.Defence:
                hpup = Random.Range(25, 51);
                defup = Random.Range(10, 21);
                hp += hpup;
                def += defup;
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

        }   
    
}



