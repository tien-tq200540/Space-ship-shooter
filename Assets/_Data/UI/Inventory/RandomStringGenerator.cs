using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RandomStringGenerator : TienMonoBehaviour
{
    private const string chars = "abcdefghiklmnopqrstuywxyz0123456789";

    public static string Generate(int length)
    {
        StringBuilder sb = new();
        int lenSrc = chars.Length, indexRand = -1;
        for (int i = 0; i < length; i++)
        {
            indexRand = Random.Range(0, lenSrc);
            sb.Append(chars[indexRand]);
        }

        return sb.ToString();
    }
}
