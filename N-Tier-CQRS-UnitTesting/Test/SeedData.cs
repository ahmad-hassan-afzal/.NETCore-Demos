using Core;
using Infrastructure.Context;

namespace Test
{
    public static class SeedData
    {
        public static int CompanyId;
        public static int ProjectId;
        
        public static void SeedSampleData(this CommandContext context)
        {
            using (context)
            {
                var company = new Company() { Id = 3248, Name = "asmdhsa", Phone = "632332231", Website = "web.com" };
                var project = new Project() { Id = 38, Name = "asmdhsa", Code = "6323", Description = "sjfkhjmsdnkjfds", CompanyId = 3248 };

                CompanyId = company.Id;
                ProjectId = project.Id;

                context.Company.Add(company);
                context.Projects.Add(project);

                context.SaveChangesAsync().Wait();
            }
        }
    }
}
