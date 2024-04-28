#1 Install from nuget

```
Install-Package Microsoft.EntityFrameworkCore;
Install-Package Microsoft.EntityFrameworkCore.Tools;
// if target database is relational
Install-Package Microsoft.EntityFrameworkCore.Relational;
// if target databse is mysql
Install-Package MySql.Data;
Install-Package MySql.EntityFrameworkCore;
// if target databse is sqlserver
Install-Package Microsoft.EntityFrameworkCore.SqlServer 
// if target databse is postgresql
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL.Design
```

#2 Config connection string

```
// add connection section into appsettings.json
"ConnectionStrings": {
    "mysqlConnectionString": "server=localhost;database=learner;user=root;password=123456",
    "sqlServerConnectionString": "server=localhost;uid=root;pwd=123456;database=learner",
    "postgresqlConnectionString": "User ID=root;Password=123456;Host=localhost;Port=5432;Database=learner;Pooling=true;"
 }
```

#3 Create DbContext for own project

```c#
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<Coupon> Coupons{ get; set;}

    // override the function to initiate some data into the database

    protected override OnModelCreating(ModelBuilder builder)
    {
        base.onModelCreating(builder);
        builder.Entity<Coupon>().HasData(new Coupon{
            // set attributes for first data
        });
    }
}
```

#4 Database Initialization

```C#
builder.Services.AddDbContext<AppDbContext>(option => {
    // if mysql
    option.UseMySQL(builder.Configuration.GetConnectionString("mysqlConnectionString"));
    // if sqlserver
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnectionString"));
    // if postgresql
    option.UseNpgsql(builder.Configuration.GetConnectionString("postgresqlConnectionString"));
});
```

#5 Denpendency injection

```C#
// sample class: CouponAPIController

private readonly AppDbContext _appDbContext;_
public class CouponAPIController(AppDbContext appDbContext)
{
    _appDbContext = appDbContext;
}

```

#6 Using in code

```C#
IEnumerable<Coupon> Coupons = _appDbContext.Coupon;
```

#7 Automatic migration

#7.1 after modification of the database structure, in current project, use cli to add migration

```
Add-Migration ${name}
```

#7.2 Create a function to autoupdate

```C#

//before app.run(); ApplyAutoMigration(); 



void ApplyAutoMigration()
{
    using(var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (db.Database.GetPendingMigration().Count() > 0)
        {
            db.Database.Migrate(); // this will also create database if it doesn't exist
        }
    }
}
```
