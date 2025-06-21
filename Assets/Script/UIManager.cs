using UnityEngine;
using UnityEngine.UI;
using TMpro;
using System.Collections.Generic;

public class UIManager : MonoBehavior
{
    public GameObject buttonPrefab;
    public Transform buttonParent;
    public TextMeshProUGUI logText;

    public void showTrainingOptions(List<TrainingOption> options, System.Action<TrainingOption> onSelect)
    {
        foreach (Transfrm child in buttonParent)
        {
            Destroy(child.gameobject);
            ;
        }

        foreach (var opt in options)
        {
            Gameobject btn = Instanstiate(buttonPrefab, buttonParent);
            btn.GetComponentInChildren<TextMeshProUGUI>().text =
            $"{opt.name}\nSTR+{opt.strup} DEF"
        }
    }
}