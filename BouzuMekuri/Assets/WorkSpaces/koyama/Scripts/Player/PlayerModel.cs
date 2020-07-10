using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public List<int> Card = null;//リストの宣言
    public PlayerModel()
    {
        Card = new List<int>();
    }
    public int rule1skill;//ルール1のスキル
    public int rule2skill;//ルール2のスキル
    public bool rule3skill;//姫
    public int rule4skill;//蝉丸
    public bool PlayerSkillFlag;//プレイヤースキルの状態管理
    public int PlayerSkill;//プレイヤースキル
}
