using UnityEngine;        // Unityの基本API（Cで言う標準ヘッダ）
using TMPro;              // TextMeshProのテキスト操作用（外部UIライブラリ）

public class StatusUI : MonoBehaviour // Cでいう「struct + 関数群」をまとめたもの
{
    public PlayerStatus player;          // プレイヤーのステータス参照（構造体っぽい役割
    
    public Text hpText;
    public Text strText;
    public Text defText;
    public Text intelText;
    public Text lukText;
    public Text mpText;
    public Text turnText;

    // HP表示用テキスト
    public TextMeshProUGUI hpText;

    public void OnHpUpButtonClicked()
    {
        player.hp += 10;  // HPは10ずつアップ
        UpdateHpText();
    }

    void UpdateHpText()
    {
        hpText.text = "HP: " + player.hp.ToString();
    }


    //str表示用テキスト
    public TextMeshProUGUI strText;         // STR表示用のUIテキスト（ポインタに近い）

    void Start()                            // Unityの初期化関数（Cなら main の準備パート）
    {
        UpdateHpText();
        UpdateStrText();                   // 初期表示更新（printf っぽい)
        UpdateDefText();
        UpdateIntelText();
        UpdateLukText();
    }

    public void OnStrUpButtonClicked()      // ボタンクリック時に呼ばれる関数
    {
        player.str += 1;                    // STRを+1（変数更新）
        UpdateStrText();                    // 表示更新（再描画）
    }

    void UpdateStrText()
    {
        strText.text = "STR: " + player.str.ToString(); // 数値→文字列変換（Cなら sprintf）
    }


    // DEF（防御力）表示
    public TextMeshProUGUI defText;

    public void OnDefUpButtonClicked()
    {
        player.def += 1;
        UpdateDefText();
    }

    void UpdateDefText()
    {
        defText.text = "DEF: " + player.def.ToString();
    }


    // INTEL（知力）表示
    public TextMeshProUGUI intelText;

    public void OnIntelUpButtonClicked()
    {
        player.intel += 1;
        UpdateIntelText();
    }

    void UpdateIntelText()
    {
        intelText.text = "INTEL: " + player.intel.ToString();
    }



    // MP表示
    public TextMeshProUGUI mpText;

    public void OnMpUpButtonClicked()
    {
        player.mp += 1;
        UpdateMpText();
    }

    void UpdateMpText()
    {
        mpText.text = "MP: " + player.mp.ToString();
    }


    // LUK（運）表示
    public TextMeshProUGUI lukText;

    public void OnLukUpButtonClicked()
    {
        player.luk += 1;
        UpdateLukText();
    }

    void UpdateLukText()
    {
        lukText.text = "LUK: " + player.luk.ToString();
    }



    public TextMeshProUGUI turnText;

    public void UpdateStatus(int hp, int str, int def, int intel, int luk, int turnsLeft)
    {
        if (hpText != null) hpText.text = "HP: " + player.hp.ToString();
        if (strText != null) strText.text = "STR: " + player.str.ToString();
        if (defText != null) defText.text = "DEF: " + player.def.ToString();
        if (intelText != null) intelText.text = "INTEL: " + player.intel.ToString();
        if (lukText != null) lukText.text = "LUK: " + player.luk.ToString();
        if (mpText != null) mpText.text = "MP: " + player.mp.ToString();
        if (turnText != null) turnText.text = "残りターン: " + turnsLeft.ToString();
    }
}

