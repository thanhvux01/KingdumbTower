using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    [SerializeField] string yourString;

    Char[] chars;

    private void Start()
    {
        Debug.Log("Từ của bạn là" + yourString);
        if (CheckPalindrome(yourString) == true)
        {
            Debug.Log("Chuỗi của bạn đọc ngược lại được");
        }
        else
        {
            Debug.Log("Chuỗi của bạn không đọc ngược lại được");
        }
    }

    void Lapday()
    {

        for (int i = 0; i < chars.Length - 1; i++)
        {
            if (chars[i] == '?' || chars[chars.Length - 1 - i] == '?')
            {
                if (chars[i] == '?')
                {
                    chars[i] = chars[chars.Length - 1 - i];
                }
                else
                {
                    chars[chars.Length - 1 - i] = chars[i];
                }
            }
        }

    }
    bool CheckPalindrome(string str)
    {
        // Chuyển string về chuổi kí tự char

        chars = str.ToCharArray();
        Lapday();
        Debug.Log("Từ sau khi được lấp chỗ trống"+ new string(chars));
        for (int i = 0; i < chars.Length; i++)
        {


            if (chars[i] != chars[chars.Length - 1 - i])
            {

                Debug.Log("Vị trị đối xứng không khớp");
                Debug.Log(chars[i]);
                Debug.Log(chars[chars.Length - 1 - i]);
                return false;
            }
        }
        return true;
    }
}
