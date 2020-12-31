﻿using System;

namespace Core.Models
{
    public class TableModel
    {
        public int Id{ get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Match { get; set; }
        public string Tip { get; set; }
        public string Odd { get; set; }
        public string Result { get; set; }
        public string WinLose { get; set; }
        public string CssClassWinLose { get; set; }
    }
}