﻿using System;
using wServer.core;
using wServer.core.objects;

namespace wServer.logic.behaviors
{
    internal class RemoveObjectOnDeath : Behavior
    {
        private readonly string _objName;
        private readonly int _range;

        public RemoveObjectOnDeath(string objName, int range)
        {
            _objName = objName;
            _range = range;
        }

        public override void OnDeath(Entity host, ref TickTime time)
        {
            var dat = host.CoreServerManager.Resources.GameData;
            var objType = dat.IdToObjectType[_objName];
            var map = host.World.Map;
            var w = map.Width;
            var h = map.Height;

            for (var y = 0; y < h; y++)
                for (var x = 0; x < w; x++)
                {
                    var tile = map[x, y];

                    if (tile.ObjType != objType)
                        continue;

                    var dx = Math.Abs(x - (int)host.X);
                    var dy = Math.Abs(y - (int)host.Y);

                    if (dx > _range || dy > _range)
                        continue;

                    tile.ObjType = 0;
                    tile.UpdateCount++;

                    map[x, y] = tile;
                }
        }

        protected override void TickCore(Entity host, TickTime time, ref object state)
        { }
    }
}
