using System;
using System.Collections.Generic;
using System.Linq;

namespace Antiban
{
    public class Antiban
    {
        private const int MailingPriority = 1;
        private readonly LinkedList<EventMessage> _queue = new();

        /// <summary>
        /// Добавление сообщений в систему, для обработки порядка сообщений
        /// </summary>
        /// <param name="eventMessage"></param>
        public void PushEventMessage(EventMessage eventMessage)
        {
            var node = _queue.AddLast(eventMessage);
            bool queueHasChanges;

            do queueHasChanges = FixEventOrder(ref node) || FixEventInQueue(node.Value);
            while (queueHasChanges);
        }

        /// <summary>
        /// Переставляет <param name="node" /> на корректную позицию
        /// </summary>
        /// <returns>Истина, если были внесены изменения в очередь</returns>
        private bool FixEventOrder(ref LinkedListNode<EventMessage> node)
        {
            var initialPreviousId = node.Previous?.Value.Id;

            _queue.Remove(node);
            var currentPrevious = _queue.Last;

            while (currentPrevious != null && currentPrevious.Value.ExpireDateTime > node.Value.ExpireDateTime)
            {
                currentPrevious = currentPrevious.Previous;
            }

            node = currentPrevious != null
                ? _queue.AddAfter(currentPrevious, node.Value)
                : _queue.AddFirst(node.Value);

            return initialPreviousId != currentPrevious?.Value.Id;
        }

        /// <summary>
        /// Устанавливает корректный ExpireDateTime, следуя антибан правилам.
        /// Использовать только после сортировки очереди.
        /// </summary>
        /// <returns>Истина, если были внесены изменения в очередь</returns>
        private bool FixEventInQueue(EventMessage message) 
            => message.Priority switch
            {
                // Период между сообщениями с приоритетом=1 на один номер, не менее 24 часа.
                MailingPriority when CheckRule(message,
                    x => x.Phone == message.Phone && x.Priority == 1,
                    TimeSpan.FromDays(1)) => true,

                // Период между сообщениями на один номер, должен быть не менее 1 минуты.
                _ when CheckRule(message,
                    x => x.Phone == message.Phone,
                    TimeSpan.FromMinutes(1)) => true,

                // Период между сообщениями на разные номера, должен быть не менее 10 сек.
                _ when CheckRule(message, TimeSpan.FromSeconds(10)) => true,

                _ => false
            };

        /// <summary>
        /// Проверяет соблюдения правил антибан системы
        /// </summary>
        /// <param name="message">Текущее сообщение</param>
        /// <param name="periodBetweenMessages">Период между сообщениями</param>
        /// <returns>Истина, если правило соблюдается</returns>
        private bool CheckRule(EventMessage message, TimeSpan periodBetweenMessages) 
            => CheckRule(message, _ => true, periodBetweenMessages);

        /// <summary>
        /// Проверяет соблюдения правила
        /// </summary>
        /// <param name="message">Текущее сообщение</param>
        /// <param name="lastMessagePredicate">Предикат для поиска ближайшего по дате eventMessage-a</param>
        /// <param name="periodBetweenMessages">Период между сообщениями</param>
        /// <returns>Истина, если правило соблюдается</returns>
        private bool CheckRule(EventMessage message, Predicate<EventMessage> lastMessagePredicate,
            TimeSpan periodBetweenMessages)
        {
            var last = _queue.LastOrDefault(x =>
                x.ExpireDateTime <= message.ExpireDateTime
                && x.Id != message.Id
                && lastMessagePredicate(x));

            if (last is not null && message.ExpireDateTime - last.ExpireDateTime < periodBetweenMessages)
            {
                message.ExpireDateTime = last.ExpireDateTime.Add(periodBetweenMessages);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Вовзращает порядок отправок сообщений
        /// </summary>
        /// <returns></returns>
        public List<AntibanResult> GetResult() 
            => _queue
                .Select(x => new AntibanResult
                {
                    EventMessageId = x.Id,
                    SentDateTime = x.ExpireDateTime
                })
                .ToList();
    }
}