using CONSOLE_TEST_GAMETEQ;
using DB_TEST_GAMETEQ;
using DB_TEST_GAMETEQ.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

var apiHelper = new ApiHelper("https://www.cnb.cz/en/");
var rates = apiHelper.GetRates(2018, 2023).Result;

var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
optionsBuilder.UseSqlite("Data Source=../../../../rates.db");
using (ApplicationContext db = new ApplicationContext(optionsBuilder.Options))
{
    var existedRecords = db.Rates.ToHashSet();
    // so unoptimal, may be rework
    db.Rates.AddRange(rates.Where(x => !existedRecords.Any(y => x.Date == y.Date && x.Currency == y.Currency )));
    db.SaveChanges();
}