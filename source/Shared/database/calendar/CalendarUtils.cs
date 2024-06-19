using System;
using System.Collections.Generic;

namespace common.resources
{
    public class CalendarUtils
    {
        public static DateTime StartDate = new DateTime(2020, 2, 4, 23, 59, 59, DateTimeKind.Utc);
        public static DateTime EndDate = new DateTime(2020, 4, 4, 23, 59, 59, DateTimeKind.Utc);
        public static bool DISABLE_CALENDAR = false;

        public static bool IsNextDay(DateTime dateTime) => dateTime != DateTime.Today;
        public static bool IsNextCalendar(DateTime dateTime) => dateTime < StartDate;

        public static List<FetchCalendarDay> MonthCalendarList = new List<FetchCalendarDay>() 
        //ST Chest: 0x7811 
        //Oryx's Mystery Chest: 0x7900 
        //Earth Scroll: 0x4039
        //Earth Scroll: 0x4038
        //50 Credits 1: 0x4021
        //Mighty Chest: 0xd8e
        //Regular Chest: 0xd8c
        //backpacks: 0xc6c
        {
            new FetchCalendarDay //1
            {
                Item = 0x7811,
                Quantity = 1
            },
            new FetchCalendarDay //2
            {
                Item = 0x4039,
                Quantity = 1
            },
            new FetchCalendarDay //3
            {
                Item = 0x4021,
                Quantity = 3
            },
            new FetchCalendarDay //4
            {
                Item = 0xc6c,
                Quantity = 1
            },
            new FetchCalendarDay //5
            {
                Item = 0x7900,//0x7810
                Quantity = 1
            },
            new FetchCalendarDay //6 ---
            {
                Item = 0x4039,
                Quantity = 1
            },
            new FetchCalendarDay //7 ---
            {
                Item = 0x4038,
                Quantity = 2
            },
            new FetchCalendarDay //8 ---
            {
                Item = 0x7811 ,
                Quantity = 1
            },
            new FetchCalendarDay //9 ---
            {
                Item = 0x3006,
                Quantity = 5
            },
            new FetchCalendarDay //10
            {
                Item = 0x7811,
                Quantity = 1
            },
            new FetchCalendarDay //11
            {
                Item = 0x7857,
                Quantity = 3
            },
            new FetchCalendarDay //12
            {
                Item = 0xd8e,
                Quantity = 2
            },
            new FetchCalendarDay //13
            {
                Item = 0x7854,
                Quantity = 10
            },
            new FetchCalendarDay //14
            {
                Item = 0x7810,
                Quantity = 2
            },
            new FetchCalendarDay //15
            {
                Item = 0x4408,//
                Quantity = 10
            },
            new FetchCalendarDay //16
            {
                Item = 0x7810, //--------------------
                Quantity = 2
            },
            new FetchCalendarDay //17
            {
                Item = 0x7900,
                Quantity = 1
            },
            new FetchCalendarDay //18
            {
                Item = 0xd8e,
                Quantity = 3
            },
            new FetchCalendarDay //19
            {
                Item = 0xcc2,
                Quantity = 2
            },
            new FetchCalendarDay //20
            {
                Item = 0x7810,
                Quantity = 1
            },
            new FetchCalendarDay //21
            {
                Item = 0xd8c,
                Quantity = 3
            },
            new FetchCalendarDay //22
            {
                Item = 0x7900,
                Quantity = 1
            },
            new FetchCalendarDay //23
            {
                Item = 0x4021,
                Quantity = 1
            },
            new FetchCalendarDay //24
            {
                Item = 0xc6c,
                Quantity = 1
            },
            new FetchCalendarDay //25
            {
                Item = 0x4021,
                Quantity = 5
            },
            new FetchCalendarDay //26
            {
                Item = 0xcc2,
                Quantity = 3
            },
            new FetchCalendarDay //27
            {
                Item = 0x7810,
                Quantity = 1
            },
            new FetchCalendarDay //28
            {
                Item = 0x4021,
                Quantity = 6
            },
            new FetchCalendarDay //29
            {
                Item = 0x7857,
                Quantity = 6
            },
            new FetchCalendarDay //30
            {
                Item = 0x7856,
                Quantity = 6
            },
            new FetchCalendarDay //31
            {
                Item = 0x4017,
                Quantity = 3
            }
        };

        public class FetchCalendarDay
        {
            public int Item = -1;
            public int Gold = 0;
            public int Quantity = 0;
        }
    }
}
