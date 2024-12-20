using News.Services.ServicesInterface;

namespace News.Services.ServicesSourceNews;

public class XPublisherFactoryService
{
    private readonly IServiceProvider _serviceProvider;

    public XPublisherFactoryService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IXPublisherService GetService(XPublisherTypeService serviceType)
    {
        return serviceType switch
        {
            XPublisherTypeService.TheGuardian => _serviceProvider.GetRequiredService<ITheGuardianService>(),
            _ => throw new ArgumentException("Invalid service type")
        };
    }
}