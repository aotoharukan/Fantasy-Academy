using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TrainingOption : MonoBehaviour
{
    public enum OptionKind
    {
        Training, // トレーニング選択肢
        Event, // イベント選択肢
    }

    public class TrainingOption
    {
        public OptionKind kind; // 種別：Training または Event
        public TrainingType trainingType; // kindがTrainingのときだけ使用
        public string displayName; // UI表示用の名前

        // ステ上昇値（トレーニングのみ使用）
        public int hpup, mpup, staup, stacost, strup, defup, intelup, lukup;

        // イベント処理に使う（今後関数ポインタかenumで分岐）// イベント時に判別するための識別ID（        
        public string eventID; // 例："EVENT_SKILL", "EVENT_GOLD"
    }

    public enum TrainingType
    {
        Taf,
        Power,
        Fig,
        Defence,
        Magic,
        Ment,
    }

    public static List<TrainingOption> GenerateRandomOptions(int count)
    {
        // 最終的に表示する選択肢のリスト
        List<TrainingOption> options = new List<TrainingOption>();

        // イベント枠の数をランダムに1〜2個とする（残りはトレーニング）
        int eventCount = Random.Range(0, 2);

        // トレーニングの数 = 全体数 - イベント数
        int trainingCount = count - eventCount;

        // TrainingType の全種類を取得してランダム抽選用に使う
        TrainingType[] allTypes = (TrainingType[])System.Enum.GetValues(typeof(TrainingType));
        List<TrainingOption> list = new List<TrainingOption>();

        // 重複しないようにランダムで trainingCount 分選ぶ
        while (selected.Count < count)
        {
            TrainingType pick = allTypes[Random.Range(0, allTypes.Length)];
            if (!selected.Contains(pick)) selected.Add(pick);
        }

        // 選ばれたトレーニングタイプから TrainingOption を作成
        foreach (TrainingType type in selected)
        {
            TrainingOption opt = new TrainingOption();
            T.kind = OptipnKind.Training; // これはトレーニング選択肢
            t.trainingType = type; // トレーニング種別

            // トレーニング種別に応じて displayName と上昇値を設定
            switch (type)
            {
                case TrainingType.Taf:
                    opt.name = "体力強化"; // 表示名
                    opt.levelup = 1;
                    opt.hpup = Random.Range(25, 51); // HPが25〜50上昇
                    opt.defup = Random.Range(10, 21); // DEFが10〜20上昇
                    break;

                case TrainingType.Power:
                    opt.name = "パワートレーニング";
                    opt.levelup = 1;
                    opt.strup = Random.Range(20, 31); // STRが20〜30上昇
                    break;

                case TrainingType.Fig:
                    opt.name = "フィジカル訓練";
                    opt.levelup = 1;
                    opt.strup = Random.Range(15, 26); // STRが15〜25上昇
                    opt.staup = Random.Range(1, 6);   // STAが1〜5上昇
                    break;

                case TrainingType.Defence:
                    opt.name = "防御訓練";
                    opt.levelup = 1;
                    opt.defup = Random.Range(20, 31); // DEFが20〜30上昇
                    break;

                case TrainingType.Magic:
                    opt.name = "魔術研究";
                    opt.levelup = 1;
                    opt.intelup = Random.Range(15, 26); // INTが15〜25上昇
                    opt.mpup = Random.Range(1, 6);      // MPが1〜5上昇
                    break;

                case TrainingType.Ment:
                    opt.name = "精神統一";
                    opt.levelup = 1;
                    opt.mpup = Random.Range(10, 16); // MPが10〜15上昇
                    break;
            }

            options.Add(opt);
        }

        // イベント候補の名前とIDを定義（仮に3種）
        string[] eventNames = { "神社に行く", "先生と話す", "特別講義" };
        string[] eventIDs = { "EVENT_GOLD", "EVENT_SKILL", "EVENT_REST" };

        // eventCount 分だけイベント選択肢を生成
        for (int i = 0; i < eventCount; i++)
        {
            TrainingOption e = new TrainingOption();
            e.kind = OptionKind.Event; // イベントタイプ
            int id = Random.Range(0, eventIDs.Length); // 0〜2のいずれか

            e.displayName = eventNames[id]; // 表示名
            e.eventID = eventIDs[id];       // イベント識別子

            options.Add(e); // リストに追加
        }

        return options; // 最終リストを返す
    }
}
