﻿using common;
using wServer.core;
using wServer.networking;

namespace wServer.core.net.handlers
{
    public class GotoAckHandler : IMessageHandler
    {
        public override PacketId MessageId => PacketId.GOTOACK;

        public override void Handle(Client client, NReader rdr, ref TickTime tickTime)
        {
            var time = rdr.ReadInt32();
            client.Player.GotoAckReceived();
        }
    }
}
