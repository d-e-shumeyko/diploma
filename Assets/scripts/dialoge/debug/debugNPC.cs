using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugNPC : MonoBehaviour
{
    [SerializeField] private Color defaultCol = Color.white;

    [SerializeField] private Color charColor = Color.red;
    [SerializeField] private Color bulbColor = Color.green;
    [SerializeField] private Color squiColor = Color.blue;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        string pokemonName = ((Ink.Runtime.StringValue)dialogueManager.getInstance().getVariableState("pokemon_name")).value;

        switch (pokemonName)
        {
            case "":
                spriteRenderer.color = defaultCol;
                break;
            case "Charmander":
                spriteRenderer.color = charColor;
                break;
            case "Bulbasaur":
                spriteRenderer.color = bulbColor;   
                break;
            case "Squirtle":
                spriteRenderer.color = squiColor;   
                break;
            default:
                Debug.LogWarning("name not handled: " + pokemonName);
                break;
        }
    }
}
