using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public interface IDBInitializer
    {
        public void SeedDB(StudyBuddyContext ctx);
    }
}
