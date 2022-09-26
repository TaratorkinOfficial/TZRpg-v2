using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterFactory 
{
    protected List<GameObject> characters;
    protected GameObject curCharacter;
    protected GameObject curCharacterClone;
    protected int length;
    protected int randIntChar;
    protected FinderTextures finderTextures;

    public void LoadCharacters()
    {
        characters = Resources.LoadAll<GameObject>("Prefabs/").ToList();
        length = characters.Count;
        randIntChar = Random.Range(0, length);
        curCharacter = characters[randIntChar];
    }
    public async void ShowCharacter()
    {
        await Task.Delay(10);
        if (length == 0)
        {
            Debug.Log("Prefabs not found!");
        }
        else
        {
            Object.Destroy(curCharacterClone);
            curCharacterClone = Object.Instantiate(curCharacter, Vector3.zero, Quaternion.identity);
            Debug.Log("Spawn");
        }
    }
}
