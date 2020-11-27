
using System;

namespace Flash.Services.Contract
{
    public interface IExceptionManagementService
    {
        string FormatOutput(Exception exception);
    }
}
