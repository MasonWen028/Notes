# Notes
#1 Install from nuget

Install-Package AutoMapper

#2 Create map
```
public AutomapperConfig() 
{
	public static MapperConfiguration RegisterMapper()
	{
		var cfg = new MapperConfiguration(cf => {
			//register config here
			//sample code: cf.CreateMap<TargetClass, TargetClassDto>();
		});
		return cfg;
	}
}
```
#3 Use maps in program.cs

IMapper mapper = AutomapperConfig.RegisterMapper().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#4 Use it in code

#4.1 Dependency injection in constructor

sample class: CouponAPIController
private IMapper _mapper;

public CouponAPIController(IMapper mapper)
{
  _mapper = mapper;
}
#4.2 Mapping object in code

TargetClass tc;
TargetClassDto tcd = mapper.Mapper<TargetClassDto>(tc);

