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

    public void DoMagicTraining()
    {
        if (turnsLeft <= 0)
        {
            Debug.Log("もうターンがありません！");
            return;
        }

        int intelup = Random.Range(10, 21);
        int mpup = Random.Range(10, 16);

        intel += intelup;
        mp += mpup;
        turnsLeft--;

        Debug.Log("魔力トレーニング実行！: INTEL+ " + intelup + "MP+ " + mpup + "、残りターン" + turnsLeft);

        // UI更新
        if (statusUI != null)
        {
            statusUI.UpdateStatus(intel, mp, turnsLeft);
        }
    }   

}



