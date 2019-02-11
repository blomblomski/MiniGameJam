using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour {

    public Player player;
    public Transform playerTrans;
    public GameObject platform;
    public GameObject fish;
    public Vector3 startPos = new Vector3();
    public Vector3 endPos = new Vector3();


    public int levelLength;
    private int startLength;
    [SerializeField]
    private int level = 0;
    [SerializeField]
    private int _skipBlocks = 0;
    public float minHeight;
    public float maxHeight;
    public int distance;
    private List<GameObject> gameObj = new List<GameObject>();
    private List<GameObject> fishObj = new List<GameObject>();
    public  List<int> ran = new List<int>();
 

	// Use this for initialization
	void Start () {
        player.GetComponent<Player>();
        StartLevel();
        endPos.x = levelLength * distance;
    }



    private void Update()
    {

        if (playerTrans.position.x > endPos.x - 30)
        {
            ran.Clear();
            startLength = levelLength;
            levelLength += levelLength;            
            endPos.x = levelLength * distance;
            _skipBlocks++;
            level++;
            minHeight += 0.1f;
            maxHeight += 0.1f;

            StartLevel();
            if(level > 2)
                CleanList();
        }
        
    }

    private void StartLevel() {
       

        for (int i = 0; i < _skipBlocks; i++)
        {
            Debug.Log("Skip");
            ran.Add(Random.Range(startLength, levelLength));
        }
  

        for (int i = startLength; i < levelLength; i++)
        {
            var currentPos = new Vector3(i * distance,0f,0f);           
            currentPos.y = Random.Range(startPos.y + minHeight, startPos.y + maxHeight);               
            var instance = Instantiate(platform, currentPos, Quaternion.identity);
                gameObj.Add(instance);

            PlaceFish(currentPos);                
        }

        foreach (var i in ran)
        {          
            Destroy(gameObj[i].gameObject);
            gameObj.RemoveAt(i);
        }
      
    }

    private void PlaceFish(Vector3 pos) {
        float ran = pos.y + Random.Range(4, 7);
        var newPos = new Vector3(pos.x, pos.y + ran, pos.z);
        var instnace = Instantiate(fish, newPos, Quaternion.identity);
        fishObj.Add(instnace);
    }


    private void CleanList() {
            for (int i = 0; i < levelLength / 3; i++)
            {
                Destroy(gameObj[1].gameObject);
                gameObj.RemoveAt(0);
            }
    }

    

}
