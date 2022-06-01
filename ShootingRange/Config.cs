using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Interfaces;

using UnityEngine;

using PlayerBroadcast = Exiled.API.Features.Broadcast;

namespace ShootingRange
{
    public class Config : IConfig
    {
        
        [Description("Indicates if the plugin is enabled or not.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Determines whether spectators will automatically be teleported to the shooting range upon death")]
        public bool ForceSpectators { get; set; } = true;
        [Description("Determines if primitives will be used to prevent players from going outside the bounds of the range")]
        public bool UsePrimitives { get; set; } = true;
        [Description("Determines whether the \".range\" permission is required to use the .range command (this will not affect automatically teleported players)")]
        public bool RequirePermission { get; set; } = false; 
        [Description("Alternative range location. The \"w\" will determine the radius of the sphere (cube) that forms the boundaries.")]
        public Vector4 RangeLocation { get; set; }
        [Description("Determines if the above location will be used or not")]
        public bool UseRangeLocation { get; set; } = false;
        [Description("The items one will spawn with on the range")]
        public List<ItemType> RangerInventory = new List<ItemType>()
        {
            ItemType.GunAK,
            ItemType.GunCOM18,
            ItemType.GunCrossvec,
            ItemType.GunE11SR,
            ItemType.GunFSP9,
            ItemType.GunLogicer,
            ItemType.GunRevolver,
            ItemType.GunShotgun
        };
        [Description("Player broadcast that appears when a player dies or joins as a spectator (This will not show if force_spectators is true)")]
        public PlayerBroadcast DeathBroadcast { get; set; } = new PlayerBroadcast()
        {
            Duration = 5,
            Content = "死亡后输入<color=#cc9900>.bc</color>可加入靶场,如果没进靶场需输<color=#cc9900>.kill</color>解除",
            Show = true
        };
        [Description("Player broadcast that appears when a player enters the shooting range")]
        public PlayerBroadcast RangeGreeting { get; set; } = new PlayerBroadcast()
        {
            Duration = 5,
            Content = "欢迎来到靶场！进入控制台输入<color=#cc9900>.fh</color>可以返回观战模式（如果没到靶场需输入.kill）",
            Show = true
        };
        [Description("Player broadcast that appears when everyone in the range is returned to spectator to spawn")]
        public PlayerBroadcast RespawnBroadcast { get; set; } = new PlayerBroadcast
        {
            Duration = 5,
            Content = "你很快就会重生!",
            Show = true
        };
        [Description("Distance each set of targets are away from each other (default is 24)")]
        public int RelativeTargetDistance { get; set; } = 24;
        [Description("Distance all targets are away from the shooting zone (default is 7)")]
        public int AbsoluteTargetDistance { get; set; } = 7;
    }
}
