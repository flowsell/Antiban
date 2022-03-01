using System.Collections.Generic;

namespace Antiban
{
    public class Antiban
    {
        /// <summary>
        /// Добавление сообщений в систему, для обработки порядка сообщений
        /// </summary>
        /// <param name="eventMessage"></param>
        public void PushEventMessage(EventMessage eventMessage)
        {
            //TODO
        }

        /// <summary>
        /// Вовзращает порядок отправок сообщений
        /// </summary>
        /// <returns></returns>
        public List<AntibanResult> GetResult()
        {
            //TODO
            //Example
            var result = new List<AntibanResult>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new AntibanResult());
            }
            
            return result;
        }
    }
}
