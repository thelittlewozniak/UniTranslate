using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslateGoogle;

namespace APIUniTranslate.Google
{
    public interface IGetAll
    {
        DetectGoogle Detect(string q);
    }
}
