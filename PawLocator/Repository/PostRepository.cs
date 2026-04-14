using PawLocator.Data;
using PawLocator.Models;
using PawLocator.Models.DbObjects;

namespace PawLocator.Repository
{
    public class PostRepository
    {
        public ApplicationDbContext dbContext;

        public PostRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public PostRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PostModel> GetAllPosts()
        {
            List<PostModel> postList = new List<PostModel>();
            foreach (Post p in dbContext.Posts)
            {
                postList.Add(MapDbObjectToModel(p));
            }
            return postList;
        }

        private PostModel MapDbObjectToModel(Post dbPost)
        {
            PostModel postModel = new PostModel();
            if (dbPost != null)
            {
                postModel.Id = dbPost.Id;
                postModel.ParentPostId = dbPost.ParentPostId;
                postModel.Type = (PostType)dbPost.PostType;
                postModel.Title = dbPost.Title;
                postModel.Description = dbPost.Description;
                postModel.ImageUrl = dbPost.ImageUrl;
                postModel.Location = dbPost.Location;
                postModel.CreatedAt = dbPost.CreatedAt;
            }
            return postModel;

        }
        private Post MapModelToDbObject(PostModel postModel)
        {
            Post dbPost = new Post();
            if (dbPost != null)
            {
                dbPost.Id = postModel.Id;
                dbPost.ParentPostId = postModel.ParentPostId;
                dbPost.PostType = (int)postModel.Type;
                dbPost.Title = postModel.Title;
                dbPost.Description = postModel.Description;
                dbPost.ImageUrl = postModel.ImageUrl;
                dbPost.Location = postModel.Location;
                dbPost.CreatedAt = postModel.CreatedAt;

            }
            return dbPost;
        }
    }
}
