using FungleAPI.GameOver;
using Hazel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FungleAPI_Example
{
    public class ExampleGameOver : CustomGameOver
    {
        public override string WinText => "ExampleTeam Wins";
        public override Color BackgroundColor => Color.gray;
        public override AudioClip Clip => base.Clip;
        public override Color NameColor => Color.gray;
        public override GameOverReason Reason { get; } = GameOverManager.GetValidGameOver();
        public override List<NetworkedPlayerInfo> GetWinners()
        {
            return base.GetWinners();
        }
        public override void Serialize(MessageWriter messageWriter)
        {
            base.Serialize(messageWriter);
        }
        public override void Deserialize(MessageReader messageReader)
        {
            base.Deserialize(messageReader);
        }
        public override void OnSetEverythingUp(EndGameManager endGameManager)
        {
            base.OnSetEverythingUp(endGameManager);
        }
    }
}
