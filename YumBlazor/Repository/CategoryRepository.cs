using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Category Create(Category obj)
    {
        _db.Category.Add(obj);
        _db.SaveChanges();
        return obj;
    }

    public Category Update(Category obj)
    {
        Category? objFromDb = _db.Category.Find(obj.Id);
        if (objFromDb == null)
            return obj;
        objFromDb.Name = obj.Name;
        _db.Category.Update(objFromDb);
        _db.SaveChanges();
        return objFromDb;
    }

    public bool Delete(int id)
    {
        var category = _db.Category.Find(id);
        if (category == null)
            return false;
        
        _db.Category.Remove(category);
        return _db.SaveChanges() > 0;
    }

    public Category Get(int id)
    {
        return _db.Category.Find(id);
    }

    public IEnumerable<Category> GetAll()
    {
        return _db.Category.ToList();
    }
}