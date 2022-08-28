using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.EntityFramework.Context;


    /// <summary>
    /// Because this context is followed by migration for more than one provider
    /// works on PostGreSql db by default. If you want to pass sql
    /// When adding AddDbContext, use MsDbContext derived from it.
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        /// <summary>
        /// in constructor we get IConfiguration, parallel to more than one db
        /// we can create migration.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Let's also implement the general version.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        protected ProjectDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>().HasData(new Template
            {
                Id = 1,
                LanguagesSection = "<p>{language}</p>",
                SkillsSection = "<p>{skill}</p>",
                Content = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"UTF-8\" /> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" /> <style> * { margin: 0; padding: 0; } body { background: white; } body a:link, body a:visited { text-decoration: none; } .resumeCanvas { margin: 0 auto; -webkit-box-sizing: border-box; box-sizing: border-box; padding: 0.3in; width: 8.5in; height: 12in; background-color: #faffff; -webkit-box-shadow: 0 3px 8px -3px rgba(0, 0, 0, 0.7); box-shadow: 0 3px 8px -3px rgba(0, 0, 0, 0.7); } .gridParent { width: 100%; height: 100%; display: -ms-grid; display: grid; -ms-grid-columns: (1fr)[4] 255px; grid-template-columns: repeat(4, 1fr) 255px; -ms-grid-rows: (1fr)[5]; grid-template-rows: repeat(5, 1fr); grid-column-gap: 0px; grid-row-gap: 0px; } .titleHeader { -ms-grid-row: 1; -ms-grid-row-span: 1; -ms-grid-column: 1; -ms-grid-column-span: 5; grid-area: 1 / 1 / 2 / 6; display: -webkit-box; display: -ms-flexbox; display: flex; -webkit-box-orient: vertical; -webkit-box-direction: normal; -ms-flex-direction: column; flex-direction: column; -webkit-box-pack: center; -ms-flex-pack: center; justify-content: center; border-bottom: #2d0081 1px solid; } .titleHeader .red1:hover { color: #e40303; } .titleHeader .orange2:hover { color: darkorange; } .titleHeader .yellow3:hover { color: #ffed00; } .titleHeader .green4:hover { color: #008026; } .titleHeader .blue5:hover { color: #004dff; } .titleHeader .purple6:hover { color: #750787; } .titleHeader h1 { font-family: \"Poiret One\", cursive; font-size: 100px; padding-left: 20px; color: #14003d; } .titleHeader h3 { font-family: \"Quicksand\", sans-serif; text-align: right; padding-right: 60px; } .leftSummary { -ms-grid-row: 2; -ms-grid-row-span: 4; -ms-grid-column: 1; -ms-grid-column-span: 4; grid-area: 2 / 1 / 6 / 5; display: -webkit-box; display: -ms-flexbox; display: flex; -webkit-box-orient: vertical; -webkit-box-direction: normal; -ms-flex-direction: column; flex-direction: column; -webkit-box-pack: space-evenly; -ms-flex-pack: space-evenly; justify-content: space-evenly; border-right: #2d0081 1px solid; font-family: \"Quicksand\", sans-serif; } .leftSummary h1 { margin: 5px 0 5px 0; font-family: \"Poiret One\", cursive; font-size: 30px; color: #14003d; } .leftSummary h4 { margin-bottom: 5px; text-decoration: underline; } .leftSummary h5 { font-style: italic; } .leftSummary p { font-size: 16px; margin: 5px; } .rightInfo { -ms-grid-row: 2; -ms-grid-row-span: 4; -ms-grid-column: 5; -ms-grid-column-span: 1; grid-area: 2 / 5 / 6 / 6; display: -webkit-box; display: -ms-flexbox; display: flex; -webkit-box-orient: vertical; -webkit-box-direction: normal; -ms-flex-direction: column; flex-direction: column; -webkit-box-pack: space-evenly; -ms-flex-pack: space-evenly; justify-content: space-evenly; margin-left: 3px; font-size: 16px; font-family: \"Quicksand\", sans-serif; } .rightInfo .red1:hover { color: #e40303; } .rightInfo .orange2:hover { color: darkorange; } .rightInfo .yellow3:hover { color: #ffed00; } .rightInfo .green4:hover { color: #008026; } .rightInfo .blue5:hover { color: #004dff; } .rightInfo .purple6:hover { color: #750787; } .rightInfo h1 { text-align: right; font-family: \"Poiret One\", cursive; font-size: 30px; color: #14003d; } .rightInfo p { margin: 10px; } .rightInfo li { list-style-type: circle; list-style-position: inside; margin: 10px; } .rightInfo a:link, .rightInfo a:visited { color: black; } /*# sourceMappingURL=main.css.map */ </style> <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\" /> <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\" /> <style> @import url(\"https://fonts.googleapis.com/css?family=Poiret+One|Quicksand&display=swap\"); </style> <title>Resume</title> </head> <body> <main class=\"resumeCanvas\"> <div class=\"gridParent\"> <div class=\"titleHeader\"> <h1> {fullName} </h1> </div> <div class=\"leftSummary\"> <div class=\"bioIntro\"> <h1>About Me</h1> <p> {content} </p> </div> </div> <div class=\"rightInfo\"> <div class=\"contacts\"> <h1>Contact details</h1> <p> <i class=\"fa fa-envelope-o\" aria-hidden=\"true\"></i> <a href=\"mailto:{email}\" class=\"red1\">{email}</a> </p> <p> <i class=\"fa fa-phone\" aria-hidden=\"true\"></i> <a class=\"orange2\">{contactNumber}</a> </p> </div> <div class=\"skills\"> <h1>Tech Stack</h1> {skills} </div> <div class=\"skills\"> <h1>Languages</h1> {languages} </div> <div class=\"education\"> <h1>Education</h1> <p> {university} </p> <p> {specialty}</p> <p>{educationLevel}</p> </div> </div> </div> </main> </body> </html>"
            });
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(
                    optionsBuilder.UseNpgsql(
                            Configuration.GetConnectionString("PgSql") 
                            ?? throw new NullReferenceException("Assign connection string in appsettings.json")
                            ).EnableSensitiveDataLogging());
            }
        }
    }