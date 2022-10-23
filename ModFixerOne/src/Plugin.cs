﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Diagnostics;

namespace ModFixerOne
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "starfi5h.plugin.ModFixerOne";
        public const string NAME = "ModFixerOne";
        public const string VERSION = "0.1.0";

        public static Plugin Instance { get; private set; }
        public Harmony Harmony { get; private set; }
        public string Version { get; set; }

        public static ManualLogSource Log;


        public void Awake()
        {
            Instance = this;
            Log = Logger;
            Harmony = new Harmony(GUID);
            Fixer_Patch.OnAwake();
        }

        [Conditional("DEBUG")]
        public void OnDestroy()
        {
            Harmony.UnpatchSelf();
            Harmony = null;
        }

        public bool CheckVersion(string hostVersion, string clientVersion)
        {
            return hostVersion.Equals(clientVersion);
        }
    }
}
