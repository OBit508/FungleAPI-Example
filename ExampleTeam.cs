using AmongUs.GameOptions;
using FungleAPI.GameOver;
using FungleAPI.Role.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FungleAPI_Example
{
    public class ExampleTeam : ModdedTeam
    {
        public override uint DefaultCount => 1;
        public override CustomGameOver DefaultGameOver { get; } = GameOverManager.Instance<ExampleGameOver>();
        public override uint DefaultPriority => 5;
        public override RoleTypes DefaultRole => base.DefaultRole;
        public override bool FriendlyFire => false;
        public override bool KnowMembers => true;
        public override uint MaxCount => 15;
        public override Color TeamColor => Color.gray;
        public override StringNames TeamName { get; } = new FungleAPI.Translation.Translator("ExampleTeam").StringName;
        public override StringNames PluralName => TeamName;
        public override string VictoryText => DefaultGameOver.WinText;
        public override bool AssignOnlyEnabledRoles => true;
        public override CategoryHeaderEditRole CreatCategoryHeaderEditRole(Transform parent)
        {
            return base.CreatCategoryHeaderEditRole(parent);
        }
        public override CategoryHeaderRoleVariant CreateCategoryHeaderRoleVariant(Transform parent)
        {
            return base.CreateCategoryHeaderRoleVariant(parent);
        }
        public override OptionBehaviour CreateCountOption(Transform transform)
        {
            return base.CreateCountOption(transform);
        }
        public override OptionBehaviour CreatePriorityOption(Transform transform)
        {
            return base.CreatePriorityOption(transform);
        }        
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
