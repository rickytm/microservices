using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization.Infrastructure.Data
{
    public class ApplicationDBContextSeedData
    {
        public static void InitDb(ApplicationDBContext context, ILogger logger)
        {
            
            SeedData(context,logger);
        }

        private static void SeedData(ApplicationDBContext context, ILogger logger)
        {
            context.Database.Migrate();

            if(!context.Paises.Any())
            {
                var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Scripts", "02_INSERT_PAISES.sql");
                var sql = File.ReadAllText(sqlFilePath);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var rows = context.Database.ExecuteSqlRaw(sql);

                stopwatch.Stop();
                logger.LogInformation($"País => Migration completed in {stopwatch.Elapsed.TotalSeconds} seconds - Rows added:  {rows}");
            }

            if(!context.Estados.Any())
            {
                var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Scripts", "03_INSERT_ESTADOS.sql");
                var sql = File.ReadAllText(sqlFilePath);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var rows = context.Database.ExecuteSqlRaw(sql);

                stopwatch.Stop();
                logger.LogInformation($"Estado => Migration completed in {stopwatch.Elapsed.TotalSeconds} seconds - Rows added:  {rows}");
            }

            if(!context.Municipios.Any())
            {
                var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Scripts", "04_INSERT_MUNICIPIOS.sql");
                var sql = File.ReadAllText(sqlFilePath);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var rows = context.Database.ExecuteSqlRaw(sql);

                stopwatch.Stop();
                logger.LogInformation($"Municipio => Migration completed in {stopwatch.Elapsed.TotalSeconds} seconds - Rows added: {rows}");
            }

            if(!context.CodigosPostales.Any())
            {
                var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Scripts", "05_INSERT_CODIGO_POSTALES.sql");
                var sql = File.ReadAllText(sqlFilePath);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var rows = context.Database.ExecuteSqlRaw(sql);

                stopwatch.Stop();
                logger.LogInformation($"Código Postal => Migration completed in {stopwatch.Elapsed.TotalSeconds} seconds - Rows added: {rows}");
            }

            if(!context.Colonias.Any())
            {
                var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Scripts", "06_INSERT_COLONIAS.sql");
                var sql = File.ReadAllText(sqlFilePath);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var rows = context.Database.ExecuteSqlRaw(sql);

                stopwatch.Stop();
                logger.LogInformation($"Colonias => Migration completed in {stopwatch.Elapsed.TotalSeconds} seconds - Rows added: {rows}");
            }
        }
    }
}
