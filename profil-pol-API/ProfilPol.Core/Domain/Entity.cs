﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
