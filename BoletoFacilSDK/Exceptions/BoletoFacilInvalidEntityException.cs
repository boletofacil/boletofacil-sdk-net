using System;
using BoletoFacilSDK.Model;

namespace BoletoFacilSDK.Exceptions
{
    public class BoletoFacilInvalidEntityException : BoletoFacilException 
    {
	    public BoletoFacilInvalidEntityException(ModelBase entity)
            : base($"{entity.GetType().Name} inválido.") 
        {
        }
        
	    public BoletoFacilInvalidEntityException(ModelBase entity, Exception e)
            : base($"{entity.GetType().Name} inválido.", e) 
        {
        }
    }
}