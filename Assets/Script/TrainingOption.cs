using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TrainingOption : MonoBehaviour
{
    public string trainingname;
    public TrainingType type;
    public int hpup, mpup, staup, stacost, strup, defup, intelup, lukup;

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
        List<TrainingOption> options = new List<TrainingOption>();

        List<TrainingOption> list = new List<TrainingOption>();
        TrainingType[] allTypes = (TrainingType[])System.Enum.GetValues(typeof(TrainingType));

        List<TrainingType> selected = new List<TrainingType>();

        while (selected.Count < count)
        {
            TrainingType pick = allTypes[Random.Range(0, allTypes.Length)];

            if (!selected.Contains(pick)) selected.Add(pick);
        }

        foreach (TrainingType type in selected)
        {
            TrainingOption opt = new TrainingOption();
            opt.type = type;

            switch (type)
            {
                case TrainingType.Taf:
                    opt.name = "体力強化"; // 表示名
                    opt.hpup = Random.Range(25, 51); // HPが25〜50上昇
                    opt.defup = Random.Range(10, 21); // DEFが10〜20上昇
                    break;

                case TrainingType.Power:
                    opt.name = "パワートレーニング";
                    opt.strup = Random.Range(20, 31); // STRが20〜30上昇
                    break;

                case TrainingType.Fig:
                    opt.name = "フィジカル訓練";
                    opt.strup = Random.Range(15, 26); // STRが15〜25上昇
                    opt.staup = Random.Range(1, 6);   // STAが1〜5上昇
                    break;

                case TrainingType.Defence:
                    opt.name = "防御訓練";
                    opt.defup = Random.Range(20, 31); // DEFが20〜30上昇
                    break;

                case TrainingType.Magic:
                    opt.name = "魔術研究";
                    opt.intelup = Random.Range(15, 26); // INTが15〜25上昇
                    opt.mpup = Random.Range(1, 6);      // MPが1〜5上昇
                    break;

                case TrainingType.Ment:
                    opt.name = "精神統一";
                    opt.mpup = Random.Range(10, 16); // MPが10〜15上昇
                    break;
            }

            options.Add(opt);
        }

        return options;
    }
}
