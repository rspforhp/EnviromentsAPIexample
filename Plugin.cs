using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using APIPlugin;
using DiskCardGame;
using BepInEx;
using BepInEx.Logging;
using EasyFeedback.APIs;
using GBC;
using HarmonyLib;
using Pixelplacement;
using UnityEngine;
using Logger = UnityEngine.Logger;
using CardLoaderMod;
using EnviromentsApi;

namespace envapitests
{



    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
	    


        private const string PluginGuid = "kopie.inscryption.envapitests";
        private const string PluginName = "envapitests";
        private const string PluginVersion = "1.0.0";
        internal static ManualLogSource Log;
        public static string staticpath;



	

        public void tests()
                 {
         	        CardInfo cardInfo= new CardInfo();
         	        cardInfo.name = "TestGrounds";
         	        cardInfo.displayedName = "Test Grounds";
         	        cardInfo.cost = 2;
         	        byte[] imgBytes3 = System.IO.File.ReadAllBytes(staticpath.Replace("envapitests.dll", "")+ "\\lands\\HuntGrounds.png");
         	        Texture2D tex3 = new Texture2D(2, 2);
         	        tex3.LoadImage(imgBytes3);
         	        cardInfo.portraitTex = Sprite.Create(tex3, new Rect(0.0f, 0.0f, tex3.width, tex3.height), new Vector2(0.5f, 0.5f), 100.0f);
         	        cardInfo.baseAttack = 0;
         	        cardInfo.baseHealth = 0;
         	        cardInfo.hideAttackAndHealth = true;
         	        cardInfo.metaCategories.Add(CardMetaCategory.ChoiceNode);
                    // all tags in description #enviroment a needed thing, #wholelane will place on enemy slot too
         	        cardInfo.description = "This doesnt look like i made this one #enviroment";
         	        cardInfo.appearanceBehaviour.Add(CardAppearanceBehaviour.Appearance.TerrainBackground);
         	        NewCard.Add(cardInfo);
                    enviroments.Plugin.enviromentcards.Add(cardInfo);
                    enviroments.Plugin.enviromentcardstypes.Add(typeof(testgrounds));
                    enviroments.Plugin.enviromentcardsrulebookdescription.Add("Creatures in this slot on death log stuff");
                    
                 }
        
        
        public class testgrounds : enviroments.Plugin.baseslottriggerreciever
        {
	        public override IEnumerator OnCardDieHere(PlayableCard card)
	        {
		        Log.LogInfo("test");
		        yield break;
	        }
        }

        private void Awake()
        {
	        staticpath=Info.Location;
            Plugin.Log = base.Logger;
            Harmony harmony = new Harmony(PluginGuid);
            harmony.PatchAll();
            tests();
        }
    }
    
}