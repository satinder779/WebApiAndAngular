using System.ServiceModel.Channels;
using System.Text;
using System;

namespace iassetTechnicalTest.Domain.Helpers
{
    public class GWSoapClientHelper
    {
        public static CustomBinding GetCustomBinding(TimeSpan operationTimeOut)
        {
            var customBinding = new CustomBinding(
                CreateEncodingElement(),
                new HttpTransportBindingElement
                {
                    MaxReceivedMessageSize = 10000000
                }
                ) {SendTimeout = operationTimeOut};
            return customBinding;
        }

        private static TextMessageEncodingBindingElement CreateEncodingElement()
        {
            var element = new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8);
            element.ReaderQuotas.MaxArrayLength = int.MaxValue;
            element.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            element.ReaderQuotas.MaxDepth = int.MaxValue;
            element.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
            element.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            return element;
        }
    }
}