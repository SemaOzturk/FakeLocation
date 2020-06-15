using System.Collections.Generic;
using System.Dynamic;
using FakeApplication.Repository.Entities;
using FakeApplication.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Repository
{
    public class TagSqlRepository : BaseSqlRepository<TagRE>, ITagRepository
    {
        public TagSqlRepository(DbContext context) : base(context)
        {
        }
    }
}