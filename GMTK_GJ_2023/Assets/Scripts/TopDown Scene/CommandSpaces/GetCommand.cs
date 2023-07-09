using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetCommand : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer button;
    [SerializeField]
    private Transform commandSpaces;

    [SerializeField]
    public List<string> commands = new List<string>();

    [SerializeField]
    private Text answerText;

    // Update is called once per frame
    void Update()
    {
        if (button.color == Color.green)
        {
            bool isRight = true;
            List<string> answer = answerText.text.Split(" ").ToList();
            foreach (Transform child in commandSpaces)
            {
                commands.Add(child.gameObject.tag);
            }
            
            for (int i = 0; i < answer.Count; i++) 
            {
                if (commands[i].ToLower() != answer[i].ToLower())
                {
                    Debug.Log("Command " + i.ToString() + "is " + commands[i]);
                    Debug.Log("Answer " + i.ToString() + "is " + answer[i]);
                    isRight = false;
                    button.color = Color.yellow;
                }
            }
            if (isRight)
            {
                button.color = Color.cyan;
            }
        }
    }

    public List<string> returnCommands(List<string> commandList)
    {
        foreach (string command in commands)
        {
            commandList.Add(command);
        }
        return commandList;
    }
}
