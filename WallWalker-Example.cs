using AmongUs.GameOptions;
using FungleAPI.Configuration;
using FungleAPI.Configuration.Attributes;
using FungleAPI.Hud;
using FungleAPI.Role;
using FungleAPI.Role.Teams;
using FungleAPI.Translation;
using FungleAPI.Utilities;
using Il2CppSystem.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FungleAPI_Example
{
    public class WallWalker_Example : RoleBehaviour, ICustomRole
    {
        [ModdedNumberOption("Ability Cooldown", null, 1, 60)]
        public static float AbilityCooldown => 15;
        [ModdedNumberOption("Ability Duration", null, 1, 60)]
        public static float AbilityDuration => 15;
        public ModdedTeam Team { get; } = ModdedTeam.Instance<ExampleTeam>();
        public StringNames RoleName { get; } = new Translator("Wall Walker").StringName;
        public StringNames RoleBlur { get; } = new Translator("You can walk on walls").StringName;
        public StringNames RoleBlurMed => RoleBlur;
        public StringNames RoleBlurLong => RoleBlur;
        public Color RoleColor { get; } = Color.yellow;
        public List<CustomAbilityButton> Buttons { get; } = new List<CustomAbilityButton>() { CustomAbilityButton.Instance<ExampleButton>() };
        public bool CanUseVent { get; } = false;
        public bool IsAffectedByLightOnAirship { get; } = true;
        public bool UseVanillaKillButton { get; } = true;
        public bool CanSabotage { get; } = false;
        public bool CompletedTasksCountForProgress { get; } = false;
        public bool IsGhostRole { get; } = false;
        public RoleTypes GhostRole { get; } = CustomRoleManager.NeutralGhost.Role;
        public bool ShowTeamColor { get; } = false;
        public Sprite Screenshot { get; } = null;
        public bool HideRole { get; } = false;
        public bool HideInFreeplayComputer { get; } = false;
        public int MaxRoleCount { get; } = 15;
        public Sprite IconSolid { get; } = null;
        public Sprite IconWhite { get; } = null;
        public DeadBodyType CreatedDeadBodyOnKill { get; } = DeadBodyType.Normal;
        public string NeutralWinText => "Victory of the " + RoleName.GetString();
        public bool CanKill => UseVanillaKillButton;
        public Color OutlineColor => RoleColor;
        public override bool IsDead => false;
        public virtual Il2CppSystem.Collections.Generic.List<PlayerControl> GetValidTargets()
        {
            List<PlayerControl> targets = GetTempPlayerList().ToSystemList();
            targets.RemoveAll(t => t.Data.Role.GetTeam() == Team && !Team.FriendlyFire);
            return targets.ToIl2CppList();
        }
        public override PlayerControl FindClosestTarget()
        {
            Il2CppSystem.Collections.Generic.List<PlayerControl> playersInAbilityRangeSorted = GetPlayersInAbilityRangeSorted(GetValidTargets());
            if (playersInAbilityRangeSorted.Count <= 0)
            {
                return null;
            }
            return playersInAbilityRangeSorted[0];
        }
        public override bool DidWin(GameOverReason gameOverReason)
        {
            return Team.DefaultGameOver.Reason == gameOverReason;
        }
        public override DeadBody FindClosestBody()
        {
            return Player.GetClosestDeadBody(GetAbilityDistance());
        }
        public string ExileText(ExileController exileController)
        {
            string[] array = StringNames.ExileTextSP.GetString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return exileController.initData.networkedPlayer.PlayerName + " " + array[1] + " " + array[2] + " " + exileController.initData.networkedPlayer.Role.NiceName;
        }
        public void Update()
        {
            if (Player != null)
            {
                Player.Collider.enabled = !Buttons[0].Transformed;
            }
        }
    }
}
