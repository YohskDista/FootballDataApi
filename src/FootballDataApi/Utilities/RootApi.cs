using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Utilities
{
    public abstract class RootApi
    {
        public int Count { get; set; }
        public object Filters { get; set; }
    }
}
