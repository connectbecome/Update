using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// public static class ViewManager
// {
//     
//     static Dictionary<string, GameObject> viewCache = new Dictionary<string, GameObject>();
//     
//     static ViewManager()
//     {
//         var baseViews = Resources.LoadAll<GameObject>("View");
//         foreach (var view in baseViews)
//         {
//             }
//         }
//     }
//
//     public static GameObject CreateView(string name, Transform parent)
//     {
//         if (!viewCache.ContainsKey(name))
//         {
//             Debug.LogError($"Error creating view named {name}");
//             return null;
//         }
//         var go = GameObject.Instantiate(viewCache[name], parent);
//         return go;
//     }
// }
//
// public static class GameApp
// {
// }
