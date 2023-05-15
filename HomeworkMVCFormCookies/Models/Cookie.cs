using System;
using System.Collections.Generic;

namespace HomeworkMVCFormCookies.Models;

public partial class Cookie
{
    public string Id { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime ExpireDate { get; set; }
}
