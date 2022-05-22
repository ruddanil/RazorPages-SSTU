using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace NET_6_Razor.Pages.Private
{
    public class UserListFromCacheModel : PageModel
    {
        public List<User> userListCache;
        private readonly IMemoryCache _cache;
        public UserListFromCacheModel(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void OnGet()
        {
            userListCache = _cache.Get<List<User>>("UserListCache");
        }
        public void OnPostLoad()
        {
            userListCache = _cache.Get<List<User>>("UserListCache");
        }
    }
}
