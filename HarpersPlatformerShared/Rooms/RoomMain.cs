using System.Collections.Generic;
using HarpersPlatformer.Entities;
using MonoEngine;

namespace HarpersPlatformer.Rooms
{
    public class RoomMain : Room
    {
        public override void onSwitchTo(Room previousRoom, Dictionary<string, object> args)
        {
            Engine.SpawnInstance<Player>();
            Engine.SpawnInstance<Butterfly>();
            Engine.SpawnInstance<RespawnControl>();
        }

        public override void onSwitchAway(Room nextRoom)
        {
        }
    }
}
