using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Xunit;

namespace Antiban
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public async void Test2()
        {
            var date1 = new DateTime(2022, 3, 1, 12, 3, 0);
            var date2 = new DateTime(2022, 3, 1, 12, 5, 0);
            var date3 = new DateTime(2022, 3, 1, 12, 5, 1);
            var date4 = new DateTime(2022, 3, 1, 12, 9, 0);
            var date5 = new DateTime(2022, 3, 1, 12, 10, 0);
            var date6 = new DateTime(2022, 3, 1, 12, 15, 0);
            var date7 = new DateTime(2022, 3, 1, 12, 15, 1);
            var date8 = new DateTime(2022, 3, 1, 13, 0, 1);
            var date9 = new DateTime(2022, 3, 1, 13, 0, 0);
            var date10 = new DateTime(2022, 3, 1, 13, 35, 0);

            string phone1 = "77777777777";
            string phone2 = "77766666666";
            string phone3 = "77767767676";
            string phone4 = "77787787878";

            var messages = new List<EventMessage>()
            {
                new EventMessage(1, phone1, date1, 0),
                new EventMessage(2, phone1, date2, 1),
                new EventMessage(3, phone4, date3, 1),
                new EventMessage(4, phone3, date4, 1),
                new EventMessage(5, phone3, date5, 0),
                new EventMessage(6, phone2, date6, 1),
                new EventMessage(7, phone2, date7, 0),
                new EventMessage(8, phone1, date8, 0),
                new EventMessage(9, phone1, date9, 0),
                new EventMessage(10, phone1, date10, 1)
            };

            var antiban = new Antiban();
            var result = new List<AntibanResult>();

            for(int i = 0; i < messages.Count - 1; i++)
            {
                antiban.PushEventMessage(messages[i]);
            }

            Assert.True(result[0].QueueNumber == 1 && result[0].EventMessageId == 1 
                && result[0].Priority == 0 && result[0].DateTime == date1);
            Assert.True(result[1].QueueNumber == 2 && result[1].EventMessageId == 3
                && result[1].Priority == 1 && result[1].DateTime == date2);
            Assert.True(result[2].QueueNumber == 3 && result[2].EventMessageId == 6
                && result[2].Priority == 1 && result[2].DateTime == date4);
            Assert.True(result[3].QueueNumber == 4 && result[3].EventMessageId == 7
                && result[3].Priority == 0 && result[3].DateTime == date5);
            Assert.True(result[4].QueueNumber == 4 && result[4].EventMessageId == 9
                && result[4].Priority == 1 && result[4].DateTime == date6);
            Assert.True(result[5].QueueNumber == 5 && result[5].EventMessageId == 8
                && result[5].Priority == 0 && result[5].DateTime == date7.AddSeconds(9));
            Assert.True(result[6].QueueNumber == 6 && result[6].EventMessageId == 5
                && result[6].Priority == 0 && result[6].DateTime == date9);
            Assert.True(result[7].QueueNumber == 7 && result[7].EventMessageId == 2
                && result[7].Priority == 0 && result[7].DateTime == date10);
            Assert.True(result[8].QueueNumber == 8 && result[8].EventMessageId == 4
                && result[8].Priority == 1 && result[8].DateTime == date8.AddDays(1));
        }
    }
}