# Notes
#1 Install from nuget
```c#
Install-Package AutoMapper
```
#2 Create map
```c#
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
```c#
IMapper mapper = AutomapperConfig.RegisterMapper().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
```
#4 Use it in code

#4.1 Dependency injection in constructor

sample class: CouponAPIController
```c#
private IMapper _mapper;

public CouponAPIController(IMapper mapper)
{
  _mapper = mapper;
}
```
#4.2 Mapping object in code
```c#
TargetClass tc;
TargetClassDto tcd = mapper.Mapper<TargetClassDto>(tc);
```

