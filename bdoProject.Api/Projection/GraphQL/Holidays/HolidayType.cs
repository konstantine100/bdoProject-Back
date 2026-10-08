using bdoProject.Domain.Entities.Holidays;

namespace bdoProject.Api.Projection.GraphQL.Holidays;

public class HolidayType : ObjectType<Holiday>
{
    protected override void Configure(IObjectTypeDescriptor<Holiday> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Date);
        descriptor.Field(x => x.Name);
    }
}