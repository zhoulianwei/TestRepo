using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class EFCoreModelBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var property = request as PropertyInfo;
            if (property?.GetCustomAttribute<ForeignKeyAttribute>() != null ||
                property?.GetCustomAttribute<InversePropertyAttribute>() != null)
            {
                return null;
            }

            return new NoSpecimen();
        }
    }
}
