# How to use Pantokrator Mongo Repository

### IOC Registration
Firstly we have to register our UnitOfWork and Repositories with connectionstrig.

```cs
services.AddScoped<IUnitOfWork>(provider =>
    new UnitOfWork(Configuration.GetConnectionString("DefaultConnection")))
    .AddScoped<IItemRepository, ItemRepository>();
```


### Entity Creation

Our entities derives from BaseEntity.

```cs
    // Entity 
    [CollectionName("items")]
    public class Item : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
```
    
        
## Repository Implementation

### Repository Interface

Repositroy interfaces implementes IRepository with Entity.    
```cs    
    // Interface Implementation
    public interface IItemRepository : IRepository<Item>
    {
    
    }
```    
    
### Repository Class

Repository clases derives BaseRepository and Entity and implemenets Repository Interface
    
```cs    
   // Class Implementation
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
```    
    
    
    
    
