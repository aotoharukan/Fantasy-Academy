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
    
    public enum TrainingType { Power, Magic, Defence }
    public void DoTraining(TrainingType type)
    {
        if (turnsLeft <= 0)
        {
            Debug.Log("ターン切れ！");
            return;
        }

        int hpup = 0;   // ✅ 必ず初期化！
        int mpup = 0;
        int strup = 0;
        int defup = 0;
        int intelup = 0;
        int lukup = 0;

        switch (type)
        {
            case TrainingType.Magic:
                intelup = Random.Range(10, 21);
                mpup = Random.Range(10, 16);
                intel += intelup;
                mp += mpup;

                Debug.Log("魔力トレーニング実行！: INTEL+ " + intelup + "MP+ " + mpup + "、残りターン: " + turnsLeft);
                break;

            case TrainingType.Power:
                hpup = Random.Range(25, 51);
                strup = Random.Range(10, 21);
                hp += hpup;
                str += strup;

                Debug.Log("パワートレーニング実行！: HP+ " + hpup + "STR+ " + strup + "、残りターン: " + turnsLeft);
                break;

            case TrainingType.Defence:
                hpup = Random.Range(25, 51);
                defup = Random.Range(10, 21);
                hp += hpup;
                def += defup;

                Debug.Log("ディフェンストレーニング実行！: HP+ " + hpup + "STR+ " + defup + "、残りターン: " + turnsLeft);
                break;
        }

        turnsLeft--;
        if (statusUI != null)
        {
            statusUI.UpdateALLStatusUI();   // ← UIをまとめて更新！
        }

         Debug.Log($"トレーニング完了：INTEL+{intelup} MP+{mpup} STR+{strup} HP+{hpup} DEF+{defup} LUK+{lukup} 残ターン:{turnsLeft}");

    }   
    
}



