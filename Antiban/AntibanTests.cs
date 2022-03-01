using System;
using Xunit;

namespace Antiban
{
    public class AntibanTests
    {
        [Fact]
        public void Test1()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();
            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 1));
            antiban.PushEventMessage(new EventMessage(2, phones[1], new DateTime(year, month, day, 12, 0, 1), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[2], new DateTime(year, month, day, 12, 0, 0, 5), 1));
            antiban.PushEventMessage(new EventMessage(4, phones[1], new DateTime(year, month, day, 12, 0, 7), 0));
            antiban.PushEventMessage(new EventMessage(5, phones[3], new DateTime(year, month, day, 12, 0, 2), 1));
            antiban.PushEventMessage(new EventMessage(6, phones[4], new DateTime(year, month, day, 12, 0, 2, 60), 1));
            antiban.PushEventMessage(new EventMessage(7, phones[0], new DateTime(year, month, day, 12, 5, 0), 0));
            antiban.PushEventMessage(new EventMessage(8, phones[5], new DateTime(year, month, day, 12, 5, 1), 1));
            antiban.PushEventMessage(new EventMessage(9, phones[6], new DateTime(year, month, day, 12, 5, 1, 120), 1));
            antiban.PushEventMessage(new EventMessage(10, phones[2], new DateTime(year, month, day, 12, 5, 2), 1));

            var results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 10));
            Assert.True(results[4].EventMessageId == 5 && results[4].SentDateTime == new DateTime(year, month, day, 12, 1, 30));
            Assert.True(results[5].EventMessageId == 6 && results[5].SentDateTime == new DateTime(year, month, day, 12, 1, 40));
            Assert.True(results[6].EventMessageId == 7 && results[6].SentDateTime == new DateTime(year, month, day, 12, 5, 0));
            Assert.True(results[7].EventMessageId == 8 && results[7].SentDateTime == new DateTime(year, month, day, 12, 5, 10));
            Assert.True(results[8].EventMessageId == 9 && results[8].SentDateTime == new DateTime(year, month, day, 12, 5, 20));
            Assert.True(results[9].EventMessageId == 10 && results[9].SentDateTime == new DateTime(year, month, day, 12, 5, 30));
        }

        [Fact]
        public void Test2()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();
            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 1));
            antiban.PushEventMessage(new EventMessage(2, phones[1], new DateTime(year, month, day, 12, 0, 1), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[2], new DateTime(year, month, day, 12, 0, 0, 5), 1));
            antiban.PushEventMessage(new EventMessage(4, phones[1], new DateTime(year, month, day, 12, 0, 7), 0));
            antiban.PushEventMessage(new EventMessage(5, phones[3], new DateTime(year, month, day, 12, 0, 2), 1));
            antiban.PushEventMessage(new EventMessage(6, phones[4], new DateTime(year, month, day, 12, 0, 2, 60), 1));
            antiban.PushEventMessage(new EventMessage(7, phones[0], new DateTime(year, month, day, 12, 5, 0), 0));
            antiban.PushEventMessage(new EventMessage(8, phones[5], new DateTime(year, month, day, 12, 5, 1), 1));
            
            var results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 10));
            Assert.True(results[4].EventMessageId == 5 && results[4].SentDateTime == new DateTime(year, month, day, 12, 1, 30));
            Assert.True(results[5].EventMessageId == 6 && results[5].SentDateTime == new DateTime(year, month, day, 12, 1, 40));
            Assert.True(results[6].EventMessageId == 7 && results[6].SentDateTime == new DateTime(year, month, day, 12, 5, 0));
            Assert.True(results[7].EventMessageId == 8 && results[7].SentDateTime == new DateTime(year, month, day, 12, 5, 10));
            
            antiban.PushEventMessage(new EventMessage(9, phones[5], new DateTime(year, month, day, 12, 5, 1, 60), 1));
            antiban.PushEventMessage(new EventMessage(10, phones[6], new DateTime(year, month, day, 12, 5, 1, 120), 1));
            antiban.PushEventMessage(new EventMessage(11, phones[2], new DateTime(year, month, day, 12, 5, 2), 0));

            results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 10));
            Assert.True(results[4].EventMessageId == 5 && results[4].SentDateTime == new DateTime(year, month, day, 12, 1, 30));
            Assert.True(results[5].EventMessageId == 6 && results[5].SentDateTime == new DateTime(year, month, day, 12, 1, 40));
            Assert.True(results[6].EventMessageId == 7 && results[6].SentDateTime == new DateTime(year, month, day, 12, 5, 0));
            Assert.True(results[7].EventMessageId == 8 && results[7].SentDateTime == new DateTime(year, month, day, 12, 5, 10));
            Assert.True(results[8].EventMessageId == 9 && results[8].SentDateTime == new DateTime(year, month, day, 12, 5, 20));
            Assert.True(results[9].EventMessageId == 10 && results[9].SentDateTime == new DateTime(year, month, day, 12, 5, 30));
            
            //второе сообщение по рассылке на один номер, отправка только через 24 часа, поэтому становится последним в списке ожидаемых отправок
            Assert.True(results[10].EventMessageId == 9 && results[10].SentDateTime == new DateTime(year, month, day + 1, 12, 5, 30)); 
            
        }
    }
}