﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Messages
{
    public abstract class Message
    {
        protected Message(Guid id)
        {
            Id = id;
        }

        public Guid Id { get;private set; }
    }
}
