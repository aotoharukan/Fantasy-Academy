using UnityEngine;        // Unityの基本API（Cで言う標準ヘッダ）
using TMPro;              // TextMeshProのテキスト操作用（外部UIライブラリ）

public class StatusUI : MonoBehaviour // Cでいう「struct + 関数群」をまとめたもの
{
    public PlayerStatus player;             // プレイヤーのステータス参照（構造体っぽい役割）
    
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

}
