using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetStore.Services.Data;
using PetStore.Services.Models;
using Serilog;
namespace PetStore.Services
{
    public class ZSLogger { 
        private readonly Serilog.Core.Logger _logger;
        public ZSLogger(IConfigurationRoot configuration)
        {
            _logger = new LoggerConfiguration()
                .WriteTo.File("LogFile.txt")
                .CreateLogger();
        }

        public void Information(string message, params object[] propertyValues)
        {
            _logger.Information(message, propertyValues);
        }

        public void Error(string message, params object[] propertyValues)
        {
            _logger.Error(message, propertyValues);
        }
        public void Error(Exception e, string message, params object[] propertyValues)
        {
            _logger.Error(e, message, propertyValues);
        }

    }
}
