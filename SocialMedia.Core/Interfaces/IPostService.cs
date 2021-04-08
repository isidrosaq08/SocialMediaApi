using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetPost(int id);
        Task AddPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}