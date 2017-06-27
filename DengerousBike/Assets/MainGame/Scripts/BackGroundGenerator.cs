using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    //const int StageTipSize = 2;
    private float speed = 5f;

    int CurrentTipIndex;

    public Transform Bike;
    public GameObject Stage;//ターゲットの指定
    public float StageSpeed = 0;
    public int StartTipIndex;//ステージ配列
    public int TipInstantiate;//生成ステージ読み込み個数
    public List<GameObject> GeneratedStageList = new List<GameObject>();//生成済みステージ保持リスト


    void Start()
    {
        //初期化処理
        CurrentTipIndex = StartTipIndex - 1;
        UpdateStage(TipInstantiate);

    }

    void Update()
    {
        StartCoroutine(StartScene());
    }

    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= CurrentTipIndex) return;

        for (int i = CurrentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject StageObject = GenerateStage(i);

            GeneratedStageList.Add(StageObject);
        }

        while (GeneratedStageList.Count > TipInstantiate + 6) DestroyOldStage();

        CurrentTipIndex = toTipIndex;

    }

    GameObject GenerateStage(int TipIndex)
    {
        //int NextStageTip = Random.Range(0, StageTips.Length);
        GameObject StageObject = PoolManager.SpawnObject(Stage, new Vector3(TipIndex * speed, 5.6f, 0), Quaternion.identity);
        StageObject.name = "BackGround";
        var pos = StageObject.transform.position;
        pos.x -= 3;
        StageObject.transform.position = pos;
        return StageObject;
    }

    void DestroyOldStage()
    {
        GameObject OldStage = GameObject.Find("BackGround");
        GeneratedStageList.RemoveAt(0);
        //Destroy(OldStage);
        PoolManager.ReleaseObject(OldStage);
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2);
        int BikePositionIndex = (int)(Bike.position.x / speed);

        if (BikePositionIndex + TipInstantiate > CurrentTipIndex)
        {
            UpdateStage(BikePositionIndex + TipInstantiate);
        }

        foreach (var Stage in GeneratedStageList)
        {
            var pos = Stage.transform.position;
            pos.x += StageSpeed * Time.deltaTime;
            Stage.transform.position = pos;
        }
    }
}
