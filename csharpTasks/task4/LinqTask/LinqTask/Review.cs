using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTask
{
    // Отзыв пользователя о фильме
    public class Review
    {
        // Идентификатор клиента
        public int UserId { get; set; }
        // Оценка фильму
        public int Mark { get; set; }
        // Название Фильма
        public string Movie { get; set; }
    }
}
