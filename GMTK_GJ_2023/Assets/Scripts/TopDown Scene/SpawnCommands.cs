using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Text answerText;

    List<string> commands = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        List<string> possibleCommands = new List<string> {"right", "left", "jumpRight", "jumpLeft"};

        List<string> answer = answerText.text.Split(" ").ToList();

        foreach (string command in answer)
        {
            commands.Add(command);
        }
        int randomCommands = 10 - commands.Count();

        for (int i = 0; i < randomCommands; i++) 
        {
            commands.Add(possibleCommands[Random.Range(0, possibleCommands.Count)]);
        }

        commands = ShuffleList(commands);

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnEnemy(spawnInterval));
    }

    private IEnumerator spawnEnemy(float interval) 
    { 
        for (int i = 0; i < commands.Count; i++)
        {
            yield return new WaitForSeconds(spawnInterval);
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

        }
        

    }

    private List<string> ShuffleList(List<string> commands)
    {
        List<string> shuffledList = new List<string>();
        int listCount = commands.Count;
        for (int i = 0; i < listCount; i++)
        {
            int randomElement = Random.Range(0, commands.Count);
            shuffledList.Add(commands[randomElement]);
            commands.Remove(commands[randomElement]);
        }
        return shuffledList;
    }
}
    
