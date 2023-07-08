using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCommands : MonoBehaviour
{
    [SerializeField]
    private GameObject commandRight;
    [SerializeField]
    private GameObject commandLeft;
    [SerializeField]
    private GameObject commandJumpRight;
    [SerializeField]
    private GameObject commandJumpLeft;
    [SerializeField] 
    private Transform spawnPoint;

    [SerializeField]
    private float spawnInterval = 3f;

    List<string> commands = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        commands.Add("right");
        commands.Add("right");
        commands.Add("jumpRight");
        commands.Add("left");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnEnemy(spawnInterval));
    }

    private IEnumerator spawnEnemy(float interval) 
    { 
        int commandLimit = 5;
        int commandCount = 0;

        for (int i = 0; i < commands.Count; i++)
        {
            if (commandCount < commandLimit)
            {
                switch (commands[i])
                {
                    case "right":
                        GameObject Right = Instantiate(commandRight, spawnPoint);
                        break;
                    case "left":
                        GameObject Left = Instantiate(commandLeft, spawnPoint);
                        break;
                    case "jumpRight":
                        GameObject JumnpRight = Instantiate(commandJumpRight, spawnPoint);
                        break;
                    case "jumpLeft":
                        GameObject JumpLeft = Instantiate(commandJumpLeft, spawnPoint);
                        break;

                }
                commands[i] = "idle";
                commandCount++;
                yield return new WaitForSeconds(spawnInterval);
            }

            
        }
        

    }
}
    
