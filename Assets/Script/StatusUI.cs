using UnityEngine;
using TMPro;  // TextMeshPro用

public class StatusUI : MonoBehaviour
{
    public PlayerStatus player;  // Playerのステータスを参照

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI staText;
    public TextMeshProUGUI strText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI intelText;
    public TextMeshProUGUI lukText;
    public TextMeshProUGUI turnText;

    void Start()
    {
        Debug.Log("Start()は実行された");

        if (player == null)
        {
            Debug.LogWarning("PlayerStatusがセットされていません！");
            return;
        }

        if (hpText == null) Debug.LogWarning("hpText が null");
        if (mpText == null) Debug.LogWarning("mpText が null");
        if (staText == null) Debug.LogWarning("staText が null");
        if (strText == null) Debug.LogWarning("strText が null");
        if (defText == null) Debug.LogWarning("defText が null");
        if (intelText == null) Debug.LogWarning("intelText が null");
        if (lukText == null) Debug.LogWarning("lukText が null");
        if (turnText == null) Debug.LogWarning("turnText が null");


        if (hpText == null || mpText == null || staText == null || strText == null || defText == null ||
            intelText == null || lukText == null || turnText == null)
        {
            Debug.LogWarning("Text系UIがセットされていません！");
            return;
        }

        UpdateALLStatusUI();
    }


    public void UpdateALLStatusUI()
    {
        Debug.Log("UpdateALLStatusUI呼ばれた！");
        Debug.Log($"HP: {player.hp}, MP: {player.mp}, STR: {player.str}, INTEL: {player.intel}");

        hpText.text = "HP: " + player.hp.ToString();
        mpText.text = "MP: " + player.mp.ToString();
        staText.text = "STA" + player.sta.ToString();
        strText.text = "STR: " + player.str.ToString();
        defText.text = "DEF: " + player.def.ToString();
        intelText.text = "INTEL: " + player.intel.ToString();
        lukText.text = "LUK: " + player.luk.ToString();
        turnText.text = "残りターン: " + player.turnsLeft.ToString();
    }



    public enum StatusType { HP, MP, STA, STR, DEF, INTEL, Luk }
    public void OnStausUp(StatusType type, int amount)
    {
        switch (type)
        {
            case StatusType.HP: player.hp += amount; break;
            case StatusType.MP: player.mp += amount; break;
            case StatusType.STA: player.sta += amount; break;
            case StatusType.STR: player.str += amount; break;
            case StatusType.DEF: player.def += amount; break;
            case StatusType.INTEL: player.intel += amount; break;
            case StatusType.Luk: player.luk += amount; break;
        }

        UpdateALLStatusUI();
    }


    //各トレーニング実行項目

    public void OnTafTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Taf);
    }
    public void OnPowerTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Power);
    }

    public void OnFigTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Fig);
    }

    public void OnMentTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Ment);
    }

    public void OnDefenseTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Defence);
    }

    public void OnMagicTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Magic);
    }

    public void finish(int turnsLeft)
    {
        // すべて最新のplayerの値で再表示
        UpdateALLStatusUI();
        if (turnText != null)
        {
            turnText.text = "残りターン: " + turnsLeft.ToString();
        }
    }

    //ユーザーに分かりやすくステータス上昇結果を表示する「フィードバックエリア」
    public TextMeshProUGUI logText; // // ← ステータスログ表示用

    public void ShowLog(string message)
    {
        if (logText != null)
        {
            logText.text = message;
        }
    }

}
