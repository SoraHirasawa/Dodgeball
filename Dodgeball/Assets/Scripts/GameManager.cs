using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dodgeballPrefab;
    [SerializeField] GameObject collectiblePrefab;
    GameObject dodgeball;
    GameObject collectible;
    public static GameManager Instance = null;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveDodgeballs()
    {
        GameObject[] dodgeballs = GameObject.FindGameObjectsWithTag("Ball");
        dodgeball = Instantiate(dodgeballPrefab);
        dodgeball.transform.position = new Vector2(Random.Range(-153, 153), 40);
        if (dodgeballs.Length > 5)
        {
            Destroy(dodgeballs[Random.Range(0, dodgeballs.Length - 1)].gameObject);
        }
    }

    public void moveCollectibles()
    {
        collectible = Instantiate(collectiblePrefab);
        collectible.transform.position = new Vector2(Random.Range(-153, 153), Random.Range(-40, 40));
    }
}
