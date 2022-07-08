using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model.Enum
{
    public enum ProductTypeEnum
    {
        [field: Description("photoBook")]
        photoBook = 1,

        [field: Description("calendar")]
        calendar = 2,

        [field: Description("canvas")]
        canvas = 3,

        [field: Description("cards")]
        cards = 4,

        [field: Description("mug")]
        mug = 5
    }
}
