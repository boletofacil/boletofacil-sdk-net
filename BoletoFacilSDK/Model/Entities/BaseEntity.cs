using System;
using System.Reflection;
using System.Text;

namespace BoletoFacilSDK.Model.Entities
{
    public abstract class BaseEntity : ModelBase
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo property in GetType().GetRuntimeProperties())
            {
                if (!property.Name.EndsWith("String"))
                {
                    sb.Append(property.Name);
                    sb.Append(": ");
                    if (property.GetIndexParameters().Length > 0)
                    {
                        sb.Append("Indexed Property cannot be used");
                    }
                    else
                    {
                        if (property.PropertyType.IsArray)
                        {
                            Array array = (Array)property.GetValue(this);
                            if (array != null)
                            {
                                sb.Append("[");
                                sb.Append(Environment.NewLine);
                                for (int i = 0; i < array.Length; i++)
                                {
                                    sb.Append(array.GetValue(i));
                                    if (i < array.Length - 1)
                                    {
                                        sb.Append(",");
                                        sb.Append(Environment.NewLine);
                                    }
                                }
                                sb.Append("] ");
                            }
                        }
                        else
                        {
                            sb.Append(property.PropertyType == typeof(DateTime) || 
                                property.PropertyType == typeof(DateTime?) && property.GetValue(this, null) != null
                                ? ((DateTime)property.GetValue(this, null)).ToString("dd/MM/yyyy")
                                : property.GetValue(this, null));
                        }
                    }
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}