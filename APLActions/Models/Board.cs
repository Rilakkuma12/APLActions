using System;
using System.Collections.Generic;
using System.Text;

namespace APLActions.Models
{
    public class Board
    {
        /// <summary>
        /// 工位台面信息：位置
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 工位台面信息： Barcode
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 工位台面信息：盖板       
        /// </summary>
        public string LidBarCode { get; set; }
    }
}
