
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Loss.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Loss.DataAccess.LossContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }

        protected override void Seed(Loss.DataAccess.LossContext context)
        {

        }
    }
}
