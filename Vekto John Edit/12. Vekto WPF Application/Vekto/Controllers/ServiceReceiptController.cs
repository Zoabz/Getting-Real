using Vekto.Models;

namespace Vekto.Controllers
{
    // UC4 Service Kvittering
    public class ServiceReceiptController
    {
        private ServiceRepo serviceRepo;

        public ServiceReceiptController()
        {
            serviceRepo = new ServiceRepo();
        }

        public Service GetService(int serviceId)
        {
            return serviceRepo.GetById(serviceId);
        }
    }
}
