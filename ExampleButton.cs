using FungleAPI.Hud;
using FungleAPI.PluginLoading;
using FungleAPI.Utilities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FungleAPI_Example
{
    public class ExampleButton : CustomAbilityButton
    {
        public static Sprite __sprite;
        public override bool Active => true;
        public override Sprite ButtonSprite => __sprite;
        public override bool CanClick => true;
        public override bool CanUse => true;
        public override float Cooldown => WallWalker_Example.AbilityCooldown;
        public override bool HaveUses => false;
        public override float InitialCooldown => WallWalker_Example.AbilityCooldown / 2;
        public override int NumUses => 0;
        public override string OverrideText => "Walk on Walls";
        public override Color32 TextOutlineColor => Color.yellow;
        public override bool TransformButton => true;
        public override float TransformDuration => WallWalker_Example.AbilityDuration;
        public override void Click()
        {
            base.Click();
        }
        public override void Destransform()
        {
            base.Destransform();
        }
        public override void MeetingStart(MeetingHud meetingHud)
        {
            base.MeetingStart(meetingHud);
        }
        public override void Reset(bool creating = false)
        {
            base.Reset(creating);
        }
        public override void Start()
        {
            base.Start();
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
