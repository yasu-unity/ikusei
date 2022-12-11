using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    //定数定義
    private const int MAX_FISH =10; //フィッシュ最大数
    private const int RESPAWN_TIME = 5; //フィッシュが発生する秒数

    //オブジェクト参照
    public GameObject fishPrefab; //フィッシュプレハブ
    public GameObject canvasGame; //ゲームキャンバス
    public GameObject textScore; //テキストスコア

    //メンバ変数
    private int score=0; //現在のスコア
    private int nextScore =100; //レベルアップまでに必要なスコア

    private int currentfish =0; //現在のフィッシュ数

    private DateTime lastDateTime; //前回フィッシュを作成した時間
    void Start()
    {
        currentfish =10;
        //初期フィッシュ作成
        for (int i = 0; i<currentfish; i++){
            CreateFish ();
        }

        //初期設定
        lastDateTime= DateTime.UtcNow;

        RefreshScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentfish < MAX_FISH){
            TimeSpan timeSpan = DateTime.UtcNow -lastDateTime;

            if (timeSpan >= TimeSpan.FromSeconds (RESPAWN_TIME)){
                while (timeSpan >= TimeSpan.FromSeconds (RESPAWN_TIME)){
                    CreateNewFish ();
                    timeSpan -= TimeSpan.FromSeconds (RESPAWN_TIME);
                }
            }
        }
    }

    //新しいフィッシュの生成
    public void CreateNewFish(){
        lastDateTime = DateTime.UtcNow;
        if (currentfish >= MAX_FISH){
            return;
        }
        CreateFish();
        currentfish++;
    }
    //フィッシュ生成
    public void CreateFish (){
        GameObject fish = (GameObject)Instantiate (fishPrefab);
        fish.transform.SetParent (canvasGame.transform,false);
        fish.transform.localPosition = new Vector3(
            UnityEngine.Random.Range (-314.0F, 289.0f),
            UnityEngine.Random.Range (-203.0F, 115.0f),
            0f);
        
    }
    //オーブ入手
    public void GetFish (){
        score +=1;
        RefreshScoreText ();
        currentfish--;
    }
    //スコアテキスト更新
    void RefreshScoreText (){
        textScore.GetComponent<Text>().text =
        "ポイント:" + score + "/" + nextScore;
    }

}

