using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI elsapedText;
    
    public float time;
    public float elsapsed;
    public Slider slider;
	// Use this for initialization
	void Start () {
        slider.value = time;
        slider.maxValue = time;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        var round = (int)time;  
        
        elsapedText.text = round.ToString();
        slider.value = time;
    }

    private void OutOfTime(float time) {

        if (elsapsed > time)
        {
          
        }
    }

    public void TimePlus()
    {
        time += 0.8f;
    }


}
