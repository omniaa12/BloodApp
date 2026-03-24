using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Application.Enums
{
    public enum BagStatus
    {
        Available,   // متاح في الثلاجة
        Used,        // تم صرفه لمريض
        Disposed,    // اتعدم
        Separated    // اتفصل
    }
}
