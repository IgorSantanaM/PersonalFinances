﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Mail
{
    public interface IMailTemplateProvider
    {
        string AccountCreatedConfirmation { get; }
    }
}
