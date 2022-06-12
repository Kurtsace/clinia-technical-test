using Newtonsoft.Json;

namespace TechnicalTest.Project.Domain.Modalities
{
    // Payment modality subclass
    public class PaymentModality : Modality 
    {
        public int Price { get; set; }
    }
}
