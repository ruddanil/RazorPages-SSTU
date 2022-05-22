using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace NET_6_Razor.Pages.Private
{
    public class UserListModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager;
        public List<User> userList;
        public List<User> userListCache;
        private readonly IMemoryCache _cache;
        public UserListModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void OnGet()
        {
            userList = userManager.readAllUsers();
            _cache.Remove("UserListCache");
            _cache.Set<List<User>>("UserListCache", userList, TimeSpan.FromSeconds(15));
            userListCache = _cache.Get<List<User>>("UserListCache");
        }
        public void OnPostDelete(Guid id)
        {
            userList = userManager.readAllUsers();
            User user = userManager.readUser(id);
            if (user != null)
            {
                userManager.deleteUser(id);
            }
            userList = userManager.readAllUsers();
        }

        public void OnPostLoadFromCache()
        {
            
        }

    }

    //public class SimpleMemoryCache<TItem>
    //{
    //    private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

    //    public TItem GetOrCreate(object key, Func<TItem> createItem)
    //    {
    //        TItem cacheEntry;
    //        if (!_cache.TryGetValue(key, out cacheEntry)) // Ищем ключ в кэше.
    //        {
    //            // Ключ отсутствует в кэше, поэтому получаем данные.
    //            cacheEntry = createItem();

    //            // Сохраняем данные в кэше. 
    //            _cache.Set(key, cacheEntry);
    //        }
    //        return cacheEntry;
    //    }
    //}
}
