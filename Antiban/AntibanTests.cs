using System;
using Xunit;

namespace Antiban
{
    public class AntibanTests
    {
        [Fact]
        public void Test3()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();
            
            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[1], new DateTime(year, month, day, 12, 1, 0), 0));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 1, 25), 1));
            antiban.PushEventMessage(new EventMessage(4, phones[1], new DateTime(year, month, day, 12, 1, 35), 1));
            antiban.PushEventMessage(new EventMessage(5, phones[0], new DateTime(year, month, day, 12, 1, 50), 1));
            antiban.PushEventMessage(new EventMessage(6, phones[1], new DateTime(year, month, day, 12, 2, 0), 0));
            antiban.PushEventMessage(new EventMessage(7, phones[0], new DateTime(year, month, day, 12, 2, 1), 0));
            
            var results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 25));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 2, 0));
            Assert.True(results[4].EventMessageId == 7 && results[4].SentDateTime == new DateTime(year, month, day, 12, 2, 25));
            Assert.True(results[5].EventMessageId == 6 && results[5].SentDateTime == new DateTime(year, month, day, 12, 3, 0));
            Assert.True(results[6].EventMessageId == 5 && results[6].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 25));

        }
        
        [Fact]
        public void Test4()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();
            
            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[1], new DateTime(year, month, day, 12, 1, 0), 0));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 1, 25), 1));
            antiban.PushEventMessage(new EventMessage(4, phones[1], new DateTime(year, month, day, 12, 1, 35), 1));
            antiban.PushEventMessage(new EventMessage(5, phones[0], new DateTime(year, month, day, 12, 1, 50), 1));
            
            var results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 25));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 2, 0));
            Assert.True(results[4].EventMessageId == 5 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 25));
            
            antiban.PushEventMessage(new EventMessage(6, phones[1], new DateTime(year, month, day, 12, 2, 0), 0));
            antiban.PushEventMessage(new EventMessage(7, phones[0], new DateTime(year, month, day, 12, 2, 1), 0));
            
            results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 25));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 2, 0));
            Assert.True(results[4].EventMessageId == 7 && results[4].SentDateTime == new DateTime(year, month, day, 12, 2, 25));
            Assert.True(results[5].EventMessageId == 6 && results[5].SentDateTime == new DateTime(year, month, day, 12, 3, 0));
            Assert.True(results[6].EventMessageId == 5 && results[6].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 25));
        }
        
        [Fact]
        public void Test5()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();
            
            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[1], new DateTime(year, month, day, 12, 1, 0), 0));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 1, 25), 1));
            antiban.PushEventMessage(new EventMessage(4, phones[1], new DateTime(year, month, day, 12, 1, 35), 1));
            antiban.PushEventMessage(new EventMessage(5, phones[0], new DateTime(year, month, day, 12, 1, 50), 1));
            
            var results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 25));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 2, 0));
            Assert.True(results[4].EventMessageId == 5 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 25));
            
            antiban.PushEventMessage(new EventMessage(6, phones[1], new DateTime(year, month, day, 12, 2, 0), 0));
            
            results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 25));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 2, 0));
            Assert.True(results[4].EventMessageId == 6 && results[4].SentDateTime == new DateTime(year, month, day, 12, 3, 0));
            Assert.True(results[5].EventMessageId == 5 && results[5].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 25));
            
            antiban.PushEventMessage(new EventMessage(7, phones[0], new DateTime(year, month, day, 12, 2, 1), 0));
            
            results = antiban.GetResult();
            
            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 25));
            Assert.True(results[3].EventMessageId == 4 && results[3].SentDateTime == new DateTime(year, month, day, 12, 2, 0));
            Assert.True(results[4].EventMessageId == 7 && results[4].SentDateTime == new DateTime(year, month, day, 12, 2, 25));
            Assert.True(results[5].EventMessageId == 6 && results[5].SentDateTime == new DateTime(year, month, day, 12, 3, 0));
            Assert.True(results[6].EventMessageId == 5 && results[6].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 25));
        }
        
        [Fact]
        public void Test6()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();

            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[0], new DateTime(year, month, day, 12, 0, 1), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 0, 2), 1));

            var results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));

            antiban.PushEventMessage(new EventMessage(4, phones[1], new DateTime(year, month, day, 12, 0, 3), 0));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 2 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[3].EventMessageId == 3 && results[3].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));
        }

        [Fact]
        public void Test7()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();

            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[0], new DateTime(year, month, day, 12, 0, 1), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 0, 2), 1));

            var results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));

            antiban.PushEventMessage(new EventMessage(4, phones[2], new DateTime(year, month, day, 12, 0, 2, 1), 0));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 2 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[3].EventMessageId == 3 && results[3].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));


            antiban.PushEventMessage(new EventMessage(5, phones[1], new DateTime(year, month, day, 12, 0, 3), 0));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 5 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 2 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[4].EventMessageId == 3 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));
        }
        
        [Fact]
        public void Test8()
        {
            int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();

            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[0], new DateTime(year, month, day, 12, 0, 1), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 0, 2), 1));

            var results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));

            antiban.PushEventMessage(new EventMessage(4, phones[2], new DateTime(year, month, day, 12, 0, 2, 1), 0));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 2 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[3].EventMessageId == 3 && results[3].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));


            antiban.PushEventMessage(new EventMessage(5, phones[1], new DateTime(year, month, day, 12, 0, 3), 1));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 5 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 2 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[4].EventMessageId == 3 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));
        }
        [Fact]
        public void Test9()
        {
        int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();

            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 0));
            antiban.PushEventMessage(new EventMessage(2, phones[0], new DateTime(year, month, day, 12, 0, 1), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day, 12, 0, 2), 1));

            var results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));

            antiban.PushEventMessage(new EventMessage(4, phones[2], new DateTime(year, month, day, 12, 0, 2, 1), 0));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 2 && results[2].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[3].EventMessageId == 3 && results[3].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));


            antiban.PushEventMessage(new EventMessage(5, phones[1], new DateTime(year, month, day, 12, 0, 3), 1));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 5 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 2 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[4].EventMessageId == 3 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));

            antiban.PushEventMessage(new EventMessage(6, phones[1], new DateTime(year, month, day, 12, 0, 4), 1));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 5 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 2 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[4].EventMessageId == 6 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 0, 20));
            Assert.True(results[5].EventMessageId == 3 && results[5].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));

            antiban.PushEventMessage(new EventMessage(7, phones[1], new DateTime(year, month, day, 12, 0, 5), 1));

            results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 4 && results[1].SentDateTime == new DateTime(year, month, day, 12, 0, 10));
            Assert.True(results[2].EventMessageId == 5 && results[2].SentDateTime == new DateTime(year, month, day, 12, 0, 20));
            Assert.True(results[3].EventMessageId == 2 && results[3].SentDateTime == new DateTime(year, month, day, 12, 1, 0));
            Assert.True(results[4].EventMessageId == 6 && results[4].SentDateTime == new DateTime(year, month, day + 1, 12, 0, 20));
            Assert.True(results[5].EventMessageId == 3 && results[5].SentDateTime == new DateTime(year, month, day + 1, 12, 1, 0));
            Assert.True(results[6].EventMessageId == 7 && results[6].SentDateTime == new DateTime(year, month, day + 2, 12, 0, 20));
        }
        
        [Fact]
        public void Test10()
        {
        int day = 1;
            int month = 3;
            int year = 2022;

            string[] phones = {
                "77070001101", "77070001102", "77070001103", "77070001104", "77070001105", "77070001106", "77070001107"
            };

            var antiban = new Antiban();

            antiban.PushEventMessage(new EventMessage(1, phones[0], new DateTime(year, month, day, 12, 0, 0), 1));
            antiban.PushEventMessage(new EventMessage(2, phones[0], new DateTime(year, month, day, 20, 0, 0), 1));
            antiban.PushEventMessage(new EventMessage(3, phones[0], new DateTime(year, month, day + 3, 3, 0, 2), 1));

            var results = antiban.GetResult();

            Assert.True(results[0].EventMessageId == 1 && results[0].SentDateTime == new DateTime(year, month, day, 12, 0, 0));
            Assert.True(results[1].EventMessageId == 2 && results[1].SentDateTime == new DateTime(year, month, day + 1, 12, 0, 0));
            Assert.True(results[2].EventMessageId == 3 && results[2].SentDateTime == new DateTime(year, month, day + 3, 3, 0, 2));

        }
    }
}