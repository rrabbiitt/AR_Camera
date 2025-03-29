using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManaging : MonoBehaviour
{
    public ThemeDatabase themeDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= themeDB.ThemeCount)
        {
            selectedOption = 0;
        }
    }
}
