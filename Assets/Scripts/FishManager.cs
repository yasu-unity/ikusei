using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    //オブジェクト参照
    private GameObject gameManager; //ゲームマネージャー

    void Start()
    {
        gameManager = GameObject.Find ("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //フィッシュ取得
    public void TouchFish(){
        if (Input.GetMouseButton (0)== false){
            return;
        }
        gameManager.GetComponent<GameManager> ().GetFish ();
        Destroy (this.gameObject);
    }
}
