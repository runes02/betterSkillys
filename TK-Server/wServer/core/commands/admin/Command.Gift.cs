﻿using common;
using System;
using System.Linq;
using wServer.core.objects;

namespace wServer.core.commands
{
    public abstract partial class Command
    {
        internal class Gift : Command
        {
            public override RankingType RankRequirement => RankingType.Admin;
            public override string CommandName => "gift";

            protected override bool Process(Player player, TickTime time, string args)
            {
                if (player == null)
                    return false;

                var manager = player.GameServer;

                // verify argument
                var index = args.IndexOf(' ');
                if (string.IsNullOrWhiteSpace(args) || index == -1)
                {
                    player.SendInfo("Usage: /gift <player name> <item name>");
                    return false;
                }

                // get command args
                var playerName = args.Substring(0, index);
                var item = GetItem(player, args.Substring(index + 1));
                if (item == null)
                {
                    return false;
                }

                if ((item.Soulbound || item.ObjectId == "Ring of The Talisman's Kingdom" || item.ObjectId == "Excalibur") && (player.Client.Account.Name != "Filisha" || player.Client.Account.Name != "ModNidhogg"))
                {
                    player.SendError("What are you trying to do!?");
                    return false;
                }

                var id = manager.Database.ResolveId(playerName);
                var acc = manager.Database.GetAccount(id);
                if (id == 0 || acc == null)
                {
                    player.SendError("Account not found!");
                    return false;
                }

                // add gift
                var result = player.GameServer.Database.AddGift(acc, item.ObjectType);
                if (!result)
                {
                    player.SendError("Gift not added. Something happened with the adding process.");
                    return false;
                }

                // send out success notifications
                player.SendInfoFormat("You gifted {0} one {1}.", acc.Name, item.DisplayName);
                var gifted = player.GameServer.ConnectionManager.Clients.Keys
                    .SingleOrDefault(p => p.Account.AccountId == acc.AccountId);
                gifted?.Player?.SendInfoFormat(
                    "You received a gift from {0}. Enjoy your {1}.",
                    player.Name,
                    item.DisplayName);
                return true;
            }

            private Item GetItem(Player player, string itemName)
            {
                var gameData = player.GameServer.Resources.GameData;


                // allow both DisplayId and Id for query
                if (!gameData.DisplayIdToObjectType.TryGetValue(itemName, out ushort objType))
                {
                    if (!gameData.IdToObjectType.TryGetValue(itemName, out objType))
                        player.SendError("Unknown item type!");
                    return null;
                }

                if (!gameData.Items.ContainsKey(objType))
                {
                    player.SendError("Not an item!");
                    return null;
                }

                return gameData.Items[objType];
            }
        }
    }
}
