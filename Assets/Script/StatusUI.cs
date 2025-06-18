using UnityEngine;
using TMPro;  // TextMeshPro用

public class StatusUI : MonoBehaviour
{
    public PlayerStatus player;  // Playerのステータスを参照

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI strText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI intelText;
    public TextMeshProUGUI lukText;
    public TextMeshProUGUI mpText;
    public TextMeshProUGUI turnText;

    void Start()
    {
        // 初期表示
        UpdateALLStatusUI();
    }

    public void UpdateALLStatusUI()
    {
        hpText.text = "HP: " + player.hp.ToString();
        mpText.text = "MP: " + player.mp.ToString();
        strText.text = "STR: " + player.str.ToString();
        defText.text = "DEF: " + player.def.ToString();
        intelText.text = "INTEL: " + player.intel.ToString();
        lukText.text = "LUK: " + player.luk.ToString();
        turnText.text = "残りターン: " + player.turnsLeft.ToString();
    }


    public enum StatusType { HP, MP, STR, DEF, INTEL, Luk }
    public void OnStausUp(StatusType type, int amount)
    {
        switch (type)
        {
            case StatusType.HP: player.hp += amount; break;
            case StatusType.MP: player.mp += amount; break;
            case StatusType.STR: player.str += amount; break;
            case StatusType.DEF: player.def += amount; break;
            case StatusType.INTEL: player.intel += amount; break;
            case StatusType.Luk: player.luk += amount; break;
        }

        UpdateALLStatusUI();
    }


    //各トレーニング実行項目
    public void OnMagicTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Magic);
    }

    public void OnPowerTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Power);
    }

    public void OnDefenseTrainingClicked()
    {
        player.DoTraining(PlayerStatus.TrainingType.Defence);
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
}
