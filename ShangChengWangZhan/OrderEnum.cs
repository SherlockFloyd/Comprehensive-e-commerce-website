using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    
    public enum OrderEnum
    {
        /// <summary>
        /// 尚未付款(等待)
        /// </summary>
        WaitPay = 1,
        /// <summary>
        /// 等待处理
        /// </summary>
        WaitSend = 2,
        /// <summary>
        /// 已处理
        /// </summary>
        Send = 3,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancel = 4,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 5,
    }
}
