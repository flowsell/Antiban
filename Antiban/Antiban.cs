using System.Collections.Generic;
using System.Linq;

namespace Antiban
{
    public class Antiban
    {
        private readonly LinkedList<EventMessage> _events = new();

        /// <summary>
        /// Добавление сообщений в систему, для обработки порядка сообщений
        /// </summary>
        /// <param name="eventMessage"></param>
        public void PushEventMessage(EventMessage eventMessage)
        {
            var node = _events.AddLast(eventMessage);
            bool queueHasChanges;

            do
            {
                queueHasChanges = FixEventOrder(ref node);
                queueHasChanges = FixEventInQueue(node.Value) || queueHasChanges;
            } while (queueHasChanges);
        }

        /// <summary>
        /// Finds correct position in the queue for <param name="node" />
        /// </summary>
        /// <returns>True if queue has changes</returns>
        private bool FixEventOrder(ref LinkedListNode<EventMessage> node)
        {
            bool queueHasChanged = true;
            var initialPrevious = node.Previous;

            _events.Remove(node);
            var currentPrevious = _events.Last;

            while (currentPrevious != null && currentPrevious.Value.ExpireDateTime > node.Value.ExpireDateTime)
            {
                currentPrevious = currentPrevious.Previous;
            }

            if (initialPrevious?.Value.Id == currentPrevious?.Value.Id)
            {
                queueHasChanged = false;
            }

            node = currentPrevious != null 
                ? _events.AddAfter(currentPrevious, node.Value) 
                : _events.AddFirst(node.Value);

            return queueHasChanged;
        }

        /// <summary>
        /// Sets correct ExpireDateTime, following the anti-ban rules.
        /// Use only with sorted queue
        /// </summary>
        /// <returns>True if queue has changes</returns>
        private bool FixEventInQueue(EventMessage message)
        {
            // last same phone and priority=1 + 24h
            if (message.Priority == 1)
            {
                var lastSamePhoneAndFirstPriority = _events.LastOrDefault(x =>
                    x.ExpireDateTime <= message.ExpireDateTime
                    && x.Id != message.Id
                    && x.Phone == message.Phone
                    && x.Priority == 1);

                if (lastSamePhoneAndFirstPriority is not null 
                    && (message.ExpireDateTime - lastSamePhoneAndFirstPriority.ExpireDateTime).TotalDays < 1)
                {
                    message.ExpireDateTime = lastSamePhoneAndFirstPriority.ExpireDateTime.AddDays(1);
                    return true;
                }
            }

            // last same phone + 1min
            var lastSamePhone = _events.LastOrDefault(x =>
                x.ExpireDateTime <= message.ExpireDateTime
                && x.Id != message.Id
                && x.Phone == message.Phone);
            
            if (lastSamePhone is not null 
                && (message.ExpireDateTime - lastSamePhone.ExpireDateTime).TotalMinutes < 1)
            {
                message.ExpireDateTime = lastSamePhone.ExpireDateTime.AddMinutes(1);
                return true;
            }

            // last + 10sec
            var last = _events.LastOrDefault(x => 
                x.ExpireDateTime <= message.ExpireDateTime
                && x.Id != message.Id);
            
            if (last is not null && (message.ExpireDateTime - last.ExpireDateTime).TotalSeconds < 10)
            {
                message.ExpireDateTime = last.ExpireDateTime.AddSeconds(10);
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Вовзращает порядок отправок сообщений
        /// </summary>
        /// <returns></returns>
        public List<AntibanResult> GetResult()
        {
            return _events
                .Select(x => new AntibanResult
                {
                    EventMessageId = x.Id,
                    SentDateTime = x.ExpireDateTime
                })
                .ToList();
        }
    }
}