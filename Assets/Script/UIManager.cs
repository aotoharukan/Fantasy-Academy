using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonParent;
    public TextMeshProUGUI logText;

    public void ShowTrainingOptions(List<TrainingOption> options, System.Action<TrainingOption> onSelect)
    {
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
            ;
        }

        foreach (var opt in options)
        {
            GameObject btn = Instantiate(buttonPrefab, buttonParent);  // ボタン生成
            btn.GetComponentInChildren<TextMeshProUGUI>().text =
            $"{opt.name}\nSTR+{opt.strup} DEF + {opt.defup} STA - {opt.stacost}";  // 内容表示

            btn.GetComponent<Button>().onClick.AddListener(() => onSelect(opt));  // 押したら選択
        }
    }

    public void ShowLog(string message)
    {
        logText.text += "\n" + message;  // ログ履歴として追加表示
    }
}