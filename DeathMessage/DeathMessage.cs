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
    public class DeathMessage : RocketPlugin<Configuration>
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
            switch (limb)
            {
                case ELimb.LEFT_FOOT:
                    killer.Experience += Configuration.Instance.left_foot.Exp;
                    break;
                case ELimb.LEFT_LEG:
                    killer.Experience += Configuration.Instance.left_leg.Exp;
                    break;
                case ELimb.RIGHT_FOOT:
                    killer.Experience += Configuration.Instance.right_foot.Exp;
                    break;
                case ELimb.RIGHT_LEG:
                    killer.Experience += Configuration.Instance.right_leg.Exp;
                    break;
                case ELimb.LEFT_HAND:
                    killer.Experience += Configuration.Instance.left_hand.Exp;
                    break;
                case ELimb.LEFT_ARM:
                    killer.Experience += Configuration.Instance.left_arm.Exp;
                    break;
                case ELimb.RIGHT_HAND:
                    killer.Experience += Configuration.Instance.right_hand.Exp;
                    break;
                case ELimb.RIGHT_ARM:
                    killer.Experience += Configuration.Instance.right_arm.Exp;
                    break;
                case ELimb.LEFT_BACK:
                    killer.Experience += Configuration.Instance.left_back.Exp;
                    break;
                case ELimb.RIGHT_BACK:
                    killer.Experience += Configuration.Instance.right_back.Exp;
                    break;
                case ELimb.LEFT_FRONT:
                    killer.Experience += Configuration.Instance.left_front.Exp;
                    break;
                case ELimb.RIGHT_FRONT:
                    killer.Experience += Configuration.Instance.right_front.Exp;
                    break;
                case ELimb.SPINE:
                    killer.Experience += Configuration.Instance.spine.Exp;
                    break;
                case ELimb.SKULL:
                    killer.Experience += Configuration.Instance.skull.Exp;
                    break;
            }

            if (cause == EDeathCause.GUN || cause == EDeathCause.MELEE || cause == EDeathCause.MISSILE || cause == EDeathCause.PUNCH || cause == EDeathCause.ROADKILL || cause == EDeathCause.GRENADE)
            {
                ChatManager.serverSendMessage(Translate("death_message_" + cause.ToString().ToLower(), killer.CharacterName, player.CharacterName), Color.white, null, null, EChatMode.GLOBAL, null, true);
            }
            else if (cause == EDeathCause.GUN && limb == ELimb.SKULL) 
            {
                ChatManager.serverSendMessage(Translate("death_message_gun_in_skull", killer.CharacterName, player.CharacterName), Color.white, null, null, EChatMode.GLOBAL, null, true);
            }
            else
            {
                ChatManager.serverSendMessage(Translate("death_message_" + cause.ToString().ToLower(), player.CharacterName), Color.white, null, null, EChatMode.GLOBAL, null, true);
            }

        }


        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"death_message_gun_in_skull", "<color=red>{0}</color> застрелил <color=red>{1}</color> в голову." },
            {"death_message_gun", " <color=red>{0}</color> застрелил <color=red>{1}</color>" },
            {"death_message_missile", "<color=red>{0}</color> взорвал <color=red>{1}</color>" },
            {"death_message_melee", "<color=red>{0}</color> зарезал <color=red>{1}</color>" },
            {"death_message_punch", "<color=red>{0}</color> забил <color=red>{1}</color>" },

            {"death_message_roadkill", "<color=red>{0}</color> задавил <color=red>{1}</color>" },
            {"death_message_grenade", "<color=red>{0}</color> подорвал <color=red>{1}</color>" },
            {"death_message_kill", "<color=red>{0}</color> постигла карма!" },

            {"death_message_food", "<color=red>{0}</color> умер от голода." },
            {"death_message_water", "<color=red>{0}</color> умер от жажды." },
            {"death_message_infection", "<color=red>{0}</color> умер от радиации." },
            {"death_message_bones", "<color=red>{0}</color> умер от падения." },

            {"death_message_zombie", "<color=red>{0}</color> умер от зомби." },
            {"death_message_animal", "<color=red>{0}</color> умер от зверя." },
            {"death_message_vehicle", "<color=red>{0}</color> умер от взрыва транспорта." },
            {"death_message_bleeding", "<color=red>{0}</color> умер от кровотечения." },

            {"death_message_burning", "<color=red>{0}</color> сгорел." },
            {"death_message_freezing", "<color=red>{0}</color> умер от холода." },
            {"death_message_suicide", "<color=red>{0}</color> суициднулся." },
            {"death_message_breath", "<color=red>{0}</color> задохнулся." },

            {"death_message_landmine", "<color=red>{0}</color> подорвался на мине." },
            {"death_message_charge", "<color=red>{0}</color> умер от взрыва." },
            {"death_message_splash", "<color=red>{0}</color> умер от сплеш урона." },
            {"death_message_sentry", "<color=red>{0}</color> расстрелян турелью." },

            {"death_message_boulder", "<color=red>{0}</color> раздавлен булыжником." },
            {"death_message_burner", "<color=red>{0}</color> умер от пылающего зомби." },
            {"death_message_spit", "<color=red>{0}</color> умер от кислоты." },
            {"death_message_acid", "<color=red>{0}</color> умер от кислоты." },

        };


    }
}
