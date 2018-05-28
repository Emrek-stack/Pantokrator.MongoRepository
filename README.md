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

If you want to use MongoDriver Bson Attributes.

```cs    
    [CollectionName("items")]
    public class Item : BaseEntity
    {    
        [BsonElement("firstname")]
        public string Firstname { get; set; }
        [BsonElement("lastname")]
        public string Lastname { get; set; }
        [BsonElement("createDate")]
        public DateTime CreateDate { get; set; }
    }
```
    
        
## Repository Implementation

### Repository Interface

Repositroy interfaces implementes IRepository with Entity.    
```cs        
    public interface IItemRepository : IRepository<Item>
    {
    
    }
```    
    
### Repository Class

Repository clases derives BaseRepository and Entity and implemenets Repository Interface
    
```cs       
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
```    
    

### Sample Query

Sample Mongo Query shown below.

```cs       
 public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;
                
        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;                        
        }
        
        [Route("items")]
        public IActionResult Index(string firstName, string lastName)
        {            
            var data = _itemRepository.AsQueryable();
          
            if(!string.IsNullOrEmpty(firstName))
                data = data.Where(c => c.Firstname == firstName);

            if(!string.IsNullOrEmpty(lastName))
                data = data.Where(s => s.Lastname == lastName);

            data = data.OrderByDescending(b => b.CreateDate);
            var result = data.ToList();            
            return View(result);
        }        
    }    
```        
