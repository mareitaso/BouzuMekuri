using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //何が出てるかのテキスト
    [SerializeField]
    private Text illust;

    //百人一首のリスト
    [SerializeField]
    private List<int> HyakuninIsshu = new List<int>();

    private int nowCard;

    void Awake()
    {
        //配列に追加
        for (int i = 0; i < 100; i++)
        {
            HyakuninIsshu.Add(i);
        }
    }

    void Start()
    {
        //配列をシャッフル
        for (int i = HyakuninIsshu.Count - 1; i >= 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var tmp = HyakuninIsshu[i];
            HyakuninIsshu[i] = HyakuninIsshu[j];
            HyakuninIsshu[j] = tmp;
            Debug.Log(HyakuninIsshu[i]);
        }
    }

    void Update()
    {
        //配列に一枚以上ある場合引ける
        if (HyakuninIsshu.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nowCard = HyakuninIsshu[0];
                TextChange();
                HyakuninIsshu.RemoveAt(0);
            }
        }
        else
        {
            illust.text = "カードがないよ";
        }
    }

    //テキストの変更
    private void TextChange()
    {
        if (nowCard < 11)
        {
            illust.text = "坊主だよ";
        }
        else if (nowCard < 32)
        {
            illust.text = "姫だよ";
        }
        else
        {
            illust.text = "殿だよ";
        }
    }
}
