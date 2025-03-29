using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ThemeDatabase : ScriptableObject
{
    public Theme[] theme; //�׸��� �����Ƿ� �迭 ����

    public int ThemeCount
    {
        get
        {
            return theme.Length; //�迭�� �ִ� �׸��� ������ ����
        }
    }

    public Theme GetTheme(int index)
    {
        return theme[index]; //���õ� �׸��� ������ ����
    }
}
