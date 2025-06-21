using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public PlayerStatus player;
    public UIManager ui;

    private int currentSeason = 1;
    private int currentTurn = 1;

    private int[] seasonLengths = new int[] { 16, 16, 16 };
    private int maxSeason = 3;

    void Start()
    {
        player.Initialize();
        StartTurn();
    }

    void StartTurn()
    {
        Debug.Log($"[ターン開始！] Season {currentSeason}, Turn {currentTurn}");
        TryRandomEvent("Start");

        List<TriningOption> options = TrainingOption.GenerateRandomOptions(5);
        ui.showTrainingOptions(options, OntrainingSelected);
    }

    public void OntrainingSelected(TrainingOption selected)
    {
        player.ApplyTraining(selected);

        TryRandomEvent("End");

        CheckBattleTrigger();

        AdvanceTurn();
    }

    void AdvanceTurn()
    {
        currentTurn++;
        if (currentTurn > seasonLengths[currentSeason - 1])
        {
            currentSeason++;
            currentTurn = 1;
        }

        if (currentSeason > maxSeason)
        {
            ui.ShowLog($"Seeker Rank Certification!");
            return;
        }

        StartTurn();
    }

    void TryRandomEvent(string phase)
    {
        float chance = TryRandomEvent.value;
        if (chance < 0.5f)
        {
            string result = player.TryTriggerEvent(phase);
            ui.ShowLog("$イベント発生！");
        }
    }

    void CheckBattleTrigger()
    {
        if (currentSeason == 1 && currentTurn == seasonLengths[0])
        {
            DoBattle();
        }

        else if (currentSeason == 2 && currentTurn == seasonLengths[1])
        {
            DoBattle();
        }

        else if (currentSeason == 3 && (seasonLengths[2] - currentTurn) < 4)
        {
            DoBattle(true);
        }

    }

    void DoBattle(bool isFinal = false)
    {
        bool won = player.SumulateBattle();
        if (!won && isFinal)
        {
            ui.ShowLog("敗北、、、シーズン終了");
        }
        else if (!won)
        {
            ui.ShowLog("敗北、、、");
        }
        else
        {
            ui.Show("勝利！");
            player.GainReward();
        }
    }

}