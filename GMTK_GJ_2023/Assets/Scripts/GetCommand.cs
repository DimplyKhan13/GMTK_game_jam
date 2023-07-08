using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCommand : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer button;
    [SerializeField]
    private Transform commandSpaces;

    [SerializeField]
    public List<string> commands = new List<string>();

    // Update is called once per frame
    void Update()
    {
        if (button.color == Color.green)
        {
            foreach (Transform child in commandSpaces)
            {
                commands.Add(child.gameObject.tag);
            }
            button.color = Color.blue;
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
