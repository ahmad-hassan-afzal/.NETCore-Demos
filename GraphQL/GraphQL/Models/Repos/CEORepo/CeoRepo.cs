using System.Collections.Generic;

namespace GraphQL.Models.Repos.CEORepo
{
    public class CeoRepo : ICeoRepo
    {
        List<CEO> dataset = new List<CEO>();
        public CeoRepo()
        {
            for (int i = 1; i <= 5; i++)
            {
                dataset.Add( new CEO { Id = i, Name = $"CEO{i}" });

            }
        }

        public CEO Get(int id)
        {
            return dataset.Find(x => x.Id == id);
        }

        public IEnumerable<CEO> GetAll()
        {
            return dataset;
        }

        public CEO Add(CEO ceo)
        {
            dataset.Add(ceo);
            return ceo;
        }

        public void Delete(int id)
        {
            dataset.Remove(dataset.Find(x => x.Id == id));
            return;
        }
        public CEO Update(CEO ceo)
        {
            var result = dataset.Find(x => x.Id == ceo.Id);
            result.Name = ceo.Name;
            return result;
        }
    }
}
