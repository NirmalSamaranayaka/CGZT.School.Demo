Scaffold-DbContext "Server={{SERVENAME}};Database={{DBNAME}};User ID={{USERID}};Password={{PASSWORD}};Trusted_Connection=False;" Microsoft.EntityFrameworkCore.SqlServer -contextDir DemoDbContext -context DemoEntities -schema {{SCHEMANAME}} -OutputDir DemoDataModels -Force -NoOnConfiguring

Sample:
Scaffold-DbContext "Server=NIRMAL\MSSQL2019;Database=cgzt-school-db-dev;User ID=cgztdev;Password=pass#word1;Trusted_Connection=False;" Microsoft.EntityFrameworkCore.SqlServer -contextDir DemoDbContext -context DemoEntities -schema cgzt -OutputDir DemoDataModels -Force -NoOnConfiguring


  -d|--data-annotations         Use attributes to configure the model (where possible). If omitted, only the fluent API is used.
  -c|--context <NAME>           The name of the DbContext.
  --context-dir <PATH>          The directory to put DbContext file in. Paths are relative to the project directory.
  -f|--force                    Overwrite existing files.
  -o|--output-dir <PATH>        The directory to put files in. Paths are relative to the project directory.
  --schema <SCHEMA_NAME>...     The schemas of tables to generate entity types for.
  -t|--table <TABLE_NAME>...    The tables to generate entity types for.
  --use-database-names          Use table and column names directly from the database.
  --json                        Show JSON output.
  -a|--assembly <PATH>          The assembly to use.
  -s|--startup-assembly <PATH>  The startup assembly to use. Defaults to the target assembly.
  --data-dir <PATH>             The data directory.
  --project-dir <PATH>          The project directory. Defaults to the current directory.
  --root-namespace <NAMESPACE>  The root namespace. Defaults to the target assembly name.
  --language <LANGUAGE>         The language. Defaults to 'C#'.
  --working-dir <PATH>          The working directory of the tool invoking this command.
  -h|--help                     Show help information
  -v|--verbose                  Show verbose output.
  --no-color                    Don't colorize outputs
  --prefix-output               Prefix output with level.
  --NoOnConfiguring	            Don't generate DbContext.OnConfiguring. Added in EF Core 5.0.
  --NoPluralize	                Don't use the pluralizer. Added in EF Core 5.0.