﻿using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RFreeTip
    {
        public int RFreeTipId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Match { get; set; }
        public string Tip { get; set; }
        public string Odd { get; set; }
        public string Result { get; set; }
        public string WinLose { get; set; }
        public bool? FirstPage { get; set; }
        public int? Code { get; set; }
    }
}
