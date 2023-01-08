using System;
using static Report.API.Domain.Dto.Enums;

namespace Report.API.Domain.EventHandlers
{
    public class CacheUpdatedEventargs : EventArgs
    {
        public DistirubedCacheKey UpdatedKey { get; set; }
        public string Value { get; set; }
    }
}