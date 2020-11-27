
using Flash.Services.Contract;
using System;

namespace Flash.Services.Core.v1
{
    class ExceptionManagementService : IExceptionManagementService
    {
        public ExceptionManagementService()
        {
        }

        public string FormatOutput(Exception exception)
        {
            return exception.ToString();
        }
    }
}
