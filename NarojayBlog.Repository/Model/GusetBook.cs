﻿using System;

namespace NarojayBlog.DatabaseRepository.Model
{
    public class GuestBook :BaseModel
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
