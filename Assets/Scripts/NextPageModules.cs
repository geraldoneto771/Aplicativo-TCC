using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NextPageModules : MonoBehaviour{
    public RectTransform level_1_2, level_3_4;
  
    // Start is called before the first frame update
    void Start(){
        level_1_2.DOAnchorPos(Vector2.zero, 0.25f);
    }

    // Update is called once per frame
    public void NextModuloButton(){
        level_1_2.DOAnchorPos(new Vector2(-2094, 0), 0.25f);
        level_3_4.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void CloseNextButtonButton()
    {
        level_1_2.DOAnchorPos(new Vector2(0, 0), 0.25f);
        level_3_4.DOAnchorPos(new Vector2(2207, 0), 0.25f);
    }

}