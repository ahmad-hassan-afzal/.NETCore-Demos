using System.Collections.Generic;
using GraphQL.Models;

namespace GraphQL.Models.Repos.CompanyRepo
{
    public class CompanyRepo : ICompanyRepo
    {
        List<Company> dataset = new List<Company>();
        public CompanyRepo()
        {
            for (int i = 1; i <= 5; i++)
            {
                dataset.Add(
                    new Company 
                    { 
                        Id = i, 
                        Name = $"Company{i}", 
                        Website = $"company{i}.com", 
                        Address = $"Address{i}", 
                        Ceo = new CEO() { Id = i+10, Name=$"CEO{i}"}
                    }
                    );

            }
        }

        public Company Get(int id)
        {
            return dataset.Find(x => x.Id == id);
        }

        public IEnumerable<Company> GetAll()
        {
            return dataset;
        }

        public Company Add(Company company)
        {
            dataset.Add(company);
            return company;
        }

        public void Delete(int id)
        {
            dataset.Remove(dataset.Find(x => x.Id == id));
            return;
        }
        public Company Update(Company company)
        {
            var result = dataset.Find(x => x.Id == company.Id);
            result.Name = company.Name;
            result.Website = company.Website;
            result.Address = company.Address;
            return result;
        }
    }
}
