using Shared;
using Shared.database.guild;
using System;
using System.Collections.Generic;
using System.Linq;
using WorldServer.core.net.handlers;
using WorldServer.core.worlds;
using WorldServer.networking;

namespace WorldServer.core.handlers
{
    class ClaimDailyRewardHandler : IMessageHandler
    {
        public override MessageId MessageId => MessageId.CLAIM_DAILY_REWARD;

        public override void Handle(Client client, NetworkReader rdr, ref TickTime tickTime)
        {
            string claimKey = rdr.ReadString();
            string type = rdr.ReadString();

            DailyCalendar calendarDb = new DailyCalendar(client.Account);
            var calendar = MonthCalendarUtils.MonthCalendarList;

            int parsedKey = (Convert.ToInt32(claimKey) - 1);

            if (MonthCalendarUtils.DISABLE_CALENDAR || DateTime.UtcNow >= MonthCalendarUtils.EndDate || calendarDb.IsNull ||
                calendarDb.ClaimedDays.ToCommaSepString().Contains(claimKey + 1)
                || calendarDb.UnlockableDays < parsedKey || calendar.Count < parsedKey)
                return;

            client.SendPacket(new ClaimDailyRewardResponse
            {
                ItemId = calendar[ClaimKey].Item,
                Quantity = calendar[ClaimKey].Quantity,
                Gold = calendar[ClaimKey].Gold
            });

            if (calendar[ClaimKey].Gold > 0)
                client.Account.Credits += calendar[ClaimKey].Gold;
            else if (calendar[ClaimKey].Item != -1 && calendar[ClaimKey].Quantity > 1)
            {
                List<ushort> items = new List<ushort>();

                for (int i = 0; i < calendar[ClaimKey].Quantity; i++)
                    items.Add((ushort)calendar[ClaimKey].Item);
                client.Manager.Database.AddGifts(client.Account, items);
            }
            else if (calendar[ClaimKey].Item != -1)
                client.Manager.Database.AddGift(client.Account, (ushort)calendar[ClaimKey].Item);

            var ClaimedDays = calendarDb.ClaimedDays.ToList();

            ClaimedDays.Add(ClaimKey + 1);
            calendarDb.ClaimedDays = ClaimedDays.ToArray();
            calendarDb.FlushAsync();

            client.Account.FlushAsync();//
            client.Account.Reload();//
        }
    }
}