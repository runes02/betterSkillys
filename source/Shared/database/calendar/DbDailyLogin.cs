using StackExchange.Redis;
using Shared.database.account;
using System;

namespace Shared.database.calendar
{
    public class DailyCalendar : RedisObject
    {
        public DbAccount Account { get; private set; }

        public DailyCalendar(DbAccount acc)
        {
            Account = acc;
            Init(acc.Database, "calendar." + acc.AccountId);
        }

        public int[] ClaimedDays
        {
            get { return GetValue<int[]>("claims"); }
            set { SetValue("claims", value); }
        }

        public int ConsecutiveDays
        {
            get { return GetValue<int>("consecutiveDays"); }
            set { SetValue("consecutiveDays", value); }
        }

        public int NonConsecutiveDays
        {
            get { return GetValue<int>("nonConsecutiveDays"); }
            set { SetValue("nonConsecutiveDays", value); }
        }

        public int UnlockableDays
        {
            get { return GetValue<int>("unlockableDays"); }
            set { SetValue("unlockableDays", value); }
        }

        public DateTime LastTime
        {
            get { return GetValue<DateTime>("lastTime"); }
            set { SetValue("lastTime", value); }
        }
    }
}
