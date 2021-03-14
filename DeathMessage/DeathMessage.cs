using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DeathMessage
{
    public class DeathMessage : RocketPlugin
    {
        public static DeathMessage Instance;


        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerDeath += PlayerDeath;
        }


        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= PlayerDeath;
        }

        private void PlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            UnturnedPlayer killer = UnturnedPlayer.FromCSteamID(murderer);

            ChatManager.serverSendMessage(Translate("death_message_" + cause.ToString().ToLower(), killer?.CharacterName ?? "", player.CharacterName), Color.white, null, null, EChatMode.GLOBAL, null, true);

        }


        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"death_message_gun", " <color=red>{0}</color> застрелил <color=red>{1}</color>" },
            {"death_message_missile", "<color=red>{0}<color> взорвал <color=red>{1}</color>"},
            {"death_message_melee", "<color=red>{0}<color> зарезал <color=red>{1}</color>" },
            {"death_message_punch", "<color=red>{0}<color> забил <color=red>{1}</color>" },

            {"death_message_roadkill", "<color=red>{0}<color> задавил <color=red>{1}</color>" },
            {"death_message_grenade", "<color=red>{0}<color> подорвал <color=red>{1}</color>" },
            {"death_message_missile", "<color=red>{0}<color> взорвал <color=red>{1}</color>" },
            {"death_message_kill", "<color=red>{1}<color> постигла карма!" },

            {"death_message_food", "<color=red>{1}<color> умер от голода." },
            {"death_message_water", "<color=red>{1}<color> умер от жажды." },
            {"death_message_infection", "<color=red>{1}<color> умер от радиации." },
            {"death_message_bones", "<color=red>{1}<color> умер от падения." },

            {"death_message_zombie", "<color=red>{1}<color> умер от зомби." },
            {"death_message_animal", "<color=red>{1}<color> умер от зверя." },
            {"death_message_vehicle", "<color=red>{1}<color> умер от взрыва транспорта." },
            {"death_message_bleeding", "<color=red>{1}<color> умер от кровотечения." },

            {"death_message_burning", "<color=red>{1}<color> сгорел." },
            {"death_message_freezing", "<color=red>{1}<color> умер от холода." },
            {"death_message_suicide", "<color=red>{1}<color> суициднулся." },
            {"death_message_breath", "<color=red>{1}<color> задохнулся." },

            {"death_message_landmine", "<color=red>{1}<color> подорвался на мине." },
            {"death_message_charge", "<color=red>{1}<color> умер от взрыва." },
            {"death_message_splash", "<color=red>{1}<color> умер от сплеш урона." },
            {"death_message_sentry", "<color=red>{1}<color> расстрелян турелью." },

            {"death_message_boulder", "<color=red>{1}<color> раздавлен булыжником." },
            {"death_message_burner", "<color=red>{1}<color> умер от пылающего зомби." },
            {"death_message_spit", "<color=red>{1}<color> умер от кислоты." },
            {"death_message_acid", "<color=red>{1}<color> умер от кислоты." },

        };


    }
}
