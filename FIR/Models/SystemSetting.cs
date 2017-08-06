using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIR.Models
{
    public class SystemSetting
    {
        public SystemSetting()
        {
            RefreshRate = 300;
            ExpireTime = 3;
        }

        //刷新时间 秒
        public int RefreshRate { get; set; }

        //失效时间 小时
        public int ExpireTime { get; set; }
    }
}
