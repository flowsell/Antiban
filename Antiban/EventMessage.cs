using System;

namespace Antiban
{
    public  class EventMessage
    {
        public int Id { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Время возникновения события
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Приоритет сообщения
        /// 0 - сервисные
        /// 1 - рассылки
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Срок жизни сообщения
        /// </summary>
        public DateTime ExpireDateTime { get; set; }

        public EventMessage(int id, string phone, DateTime dateTime, 
            int priority)
        {
            Id = id;
            Phone = phone;
            DateTime = dateTime;
            Priority = priority;
            Text = "Something";
            ExpireDateTime = priority == 0 ? dateTime.AddHours(1) : dateTime.AddDays(1);
        }
    }
}
