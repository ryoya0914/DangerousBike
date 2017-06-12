using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageTipSize = 5;

    int CurrentTipIndex;

    public Transform Bike;
    public GameObject[] StageTips;//ターゲットの指定
    public int StartTipIndex;//ステージ配列
    public int TipInstantiate;//生成ステージ読み込み個数
    public List<GameObject> GeneratedStageList = new List<GameObject>();//生成済みステージ保持リスト


	void Start ()
    {
        //初期化処理
        CurrentTipIndex = StartTipIndex - 1;
        UpdateStage(TipInstantiate);
	}
	
	void Update ()
    {
        int BikePositionIndex = (int)(Bike.position.x / StageTipSize);

        if (BikePositionIndex + TipInstantiate > CurrentTipIndex)
        {
            UpdateStage(BikePositionIndex + TipInstantiate);
        }
	}

    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= CurrentTipIndex) return;

        for (int i = CurrentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject StageObject = GenerateStage(i);

            GeneratedStageList.Add(StageObject);
        }

        while (GeneratedStageList.Count > TipInstantiate + 3) DestroyOldStage();

        CurrentTipIndex = toTipIndex;

    }

    GameObject GenerateStage(int TipIndex)
    {
        int NextStageTip = Random.Range(0, StageTips.Length);

        GameObject StageObject = (GameObject)Instantiate(StageTips[NextStageTip], new Vector3(TipIndex * StageTipSize, 0, 0), Quaternion.identity);
        return StageObject;
    }

    void DestroyOldStage()
    {
        GameObject OldStage = GameObject.Find("road(Clone)");
        GeneratedStageList.RemoveAt(0);
        Destroy(OldStage);
    }
}
