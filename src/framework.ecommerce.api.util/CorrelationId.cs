﻿using System;

namespace framework.ecommerce.api.util
{
    public class CorrelationId : ICorrelationId
    {
        public CorrelationId()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }
        public void SetCorrelationId(string id)
        {
            Id = id;
        }
    }
}
