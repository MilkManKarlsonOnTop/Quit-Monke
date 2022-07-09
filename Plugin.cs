using BepInEx;
using System;
using UnityEngine;
using Utilla;
using BananaHook;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Collections;


namespace QuitMonke
{
    /// <summary>
    /// This is your mod's main class.
    ///	</summary>


    [ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInDependency("net.rusjj.gtlib.bananahook", "1.3.1")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void OnEnable() {
			HarmonyPatches.ApplyHarmonyPatches();
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnDisable() {


			HarmonyPatches.RemoveHarmonyPatches();
			Utilla.Events.GameInitialized -= OnGameInitialized;
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
		}

		void Update(object sender, PlayerTaggedPlayerArgs player)
		{
			if (player.victim.IsLocal)
			{
				Quit();
			}
		}

		void Quit()
        {
			Application.Quit();
		}

		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			

			inRoom = true;
		}

		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{

			inRoom = false;
		}
	}
}
	