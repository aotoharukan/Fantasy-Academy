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
        this.TryRandomEvent("Start");

        List<TrainingOption> options = TrainingOption.GenerateRandomOptions(5);
        ui.ShowTrainingOptions(options, OnTrainingSelected);
    }

    public void OnTrainingSelected(TrainingOption selected)
    {
        // トレーニングだった場合
        if (selected.kind == OptionKind.Training)
        {
            player.ApplyTraining(selected); // ステータスに反映
        }
        // イベントだった場合
        else if (selected.kind == OptionKind.Event)
        {
            ProcessEvent(selected.eventID); // イベントIDに応じた処理を呼ぶ
        }

        TryRandomEvent("End"); // ターン終了時のイベント処理（従来）
        CheckBattleTrigger();  // バトル発生チェック
        AdvanceTurn();         // ターンを進める
    }

    // イベントごとの処理をまとめた関数（後で追加・強化可能）
    void ProcessEvent(string id)
    {
        switch (id)
        {
            case "EVENT_GOLD":
                player.money += 100;
                ui.ShowLog("💰臨時収入！100Gゲット！");
                break;

            case "EVENT_SKILL":
                ui.ShowLog("🧠スキル獲得イベント！（仮）");
                break;

            case "EVENT_REST":
                player.sta += 20;
                ui.ShowLog("😴しっかり休憩してスタミナ回復！");
                break;
        }
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

    public void TryRandomEvent(string phase)
    {
        float chance = Random.value;
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
        bool won = player.SimulateBattle();
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
            ui.ShowLog("勝利！");
            player.UpReward();
        }
    }

}