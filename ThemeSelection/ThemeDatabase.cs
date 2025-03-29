using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ThemeDatabase : ScriptableObject
{
    public Theme[] theme; //테마가 많으므로 배열 생성

    public int ThemeCount
    {
        get
        {
            return theme.Length; //배열에 있는 테마의 개수를 리턴
        }
    }

    public Theme GetTheme(int index)
    {
        return theme[index]; //선택된 테마의 정보를 리턴
    }
}
