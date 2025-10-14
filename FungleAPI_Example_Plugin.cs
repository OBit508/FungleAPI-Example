using BepInEx;
using BepInEx.Unity.IL2CPP;
using FungleAPI;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using xCloud;
using FungleAPI.Utilities.Assets;
using FungleAPI.PluginLoading;

namespace FungleAPI_Example
{
    [BepInProcess("Among Us.exe")]
    [BepInPlugin("com.rafael.fungleapiexample", "FungleAPI-Example", "1.0.0")]
    [BepInDependency(FungleAPIPlugin.ModId)]
    public class FungleAPI_Example_Plugin : BasePlugin, IFungleBasePlugin
    {
        public Harmony Harmony = new Harmony("com.rafael.fungleapiexample");
        public override void Load()
        {
            Harmony.PatchAll();
        }
        public void LoadAssets()
        {
            ExampleButton.__sprite = ResourceHelper.LoadSprite(FunglePlugin<FungleAPI_Example_Plugin>.Plugin, "FungleAPI_Example.Resources.ButtonImage", 150);
        }
        public string ModName { get; } = "FungleAPI-Example";
        public string ModVersion { get; } = "1.0.0";
    }
}
