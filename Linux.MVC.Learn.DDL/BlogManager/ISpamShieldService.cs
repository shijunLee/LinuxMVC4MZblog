using Linux.MVC.Learn.DDL.BlogManager;
using Linux.MVC.Learn.Model;
using Linux.MVC.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MVC.Learn.Common.Extensions;
using System.Data.Entity;
namespace Linux.MVC.Learn.Common
{


    public interface ISpamShieldService
    {
        string CreateTick(string key);

        string GenerateHash(string tick);

        bool IsSpam(SpamShield command);
    }

    public class SpamShieldService : ISpamShieldService
    {


        public string CreateTick(string key)
        {
            var tick = ObjectId.NewObjectId().ToString();
            var spamHash = new SpamHash
            {
                Id = tick,
                PostKey = key,
                CreatedTime = DateTime.UtcNow
            };
           using(LearnContext context = new LearnContext())
           {
               context.SpamHashs.Add(spamHash);
               context.SaveChanges();
           }
            return tick;
        }

        public string GenerateHash(string tick)
        {
            using (LearnContext context = new LearnContext())
            {
                var nonhash = string.Empty;
                if (tick.IsNullOrWhitespace())
                    return nonhash;

                // var spamHash = _db.SelectKey<SpamHash>(DBTableNames.SpamHashes, tick);
                var spamHash = context.SpamHashs.Where(p => p.Id == tick).SingleOrDefault();

                if (spamHash == null || spamHash.Pass || !spamHash.Hash.IsNullOrWhitespace())
                    return nonhash;

                spamHash.Hash = new Random().NextDouble().ToString();
                // _db.Update(DBTableNames.SpamHashes, spamHash);
                context.Entry<SpamHash>(spamHash).State = EntityState.Modified;
                context.SaveChanges();
                return spamHash.Hash;
            }

        }

        public bool IsSpam(SpamShield command)
        {
            using (LearnContext context = new LearnContext())
            {
                if (command.Tick.IsNullOrWhitespace() || command.Hash.IsNullOrWhitespace())
                    return true;

              //  var spamHash = _db.SelectKey<SpamHash>(DBTableNames.SpamHashes, command.Tick);
                var spamHash = context.SpamHashs.Where(p => p.Id == command.Tick).SingleOrDefault();
                if (spamHash == null || spamHash.Pass || spamHash.Hash != command.Hash)
                    return true;

                spamHash.Pass = true;
               // _db.Update(DBTableNames.SpamHashes, spamHash);
                context.Entry<SpamHash>(spamHash).State = EntityState.Modified;
                context.SaveChanges();
                return false;
            }
        }
    }
}
