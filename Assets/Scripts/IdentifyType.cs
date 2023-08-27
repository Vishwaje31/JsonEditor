using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static class IdentifyType
{
    public static Type GetComponentType(string _str)
    {
        switch (_str)
        {
            case "BoxCollider":
                return typeof(BoxCollider);

            case "SpriteRenderer":
                return typeof(SpriteRenderer);

        }

        return null;
    }

}
